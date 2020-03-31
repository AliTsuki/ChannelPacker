using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ChannelPacker
{
    /// <summary>
    /// Packs multiple images into different channels of a single image.
    /// </summary>
    public partial class ChannelPacker : Form
    {
        /// <summary>
        /// Contains all the map images used in creating a mask map.
        /// </summary>
        private Dictionary<Map.MapType, Map> MaskMaps = new Dictionary<Map.MapType, Map>
        {
            { Map.MapType.Metallic, new Map(null, Map.MapType.Metallic) },
            { Map.MapType.Roughness, new Map(null, Map.MapType.Roughness) },
            { Map.MapType.AO, new Map(null, Map.MapType.AO) },
            { Map.MapType.Detail_Mask, new Map(null, Map.MapType.Detail_Mask) }
        };

        /// <summary>
        /// Contains all the map images used in creating a color map with opacity in the alpha channel.
        /// </summary>
        private Dictionary<Map.MapType, Map> OpacityMaps = new Dictionary<Map.MapType, Map>
        {
            { Map.MapType.Color, new Map(null, Map.MapType.Color) },
            { Map.MapType.Opacity, new Map(null, Map.MapType.Opacity) }
        };

        /// <summary>
        /// List of all the maps currently loaded.
        /// </summary>
        private readonly List<Map.MapType> MapsLoaded = new List<Map.MapType>();
        /// <summary>
        /// A channel packed image.
        /// </summary>
        private Bitmap ChannelPackedImage = null;
        /// <summary>
        /// The width of the images.
        /// </summary>
        private int width = 0;
        /// <summary>
        /// The height of the images.
        /// </summary>
        private int height = 0;

        /// <summary>
        /// Different image operation types.
        /// </summary>
        private enum OperationType
        { 
            Mask,
            Opacity
        }

        /// <summary>
        /// Default constructor. Initializes the form components and all values.
        /// </summary>
        public ChannelPacker()
        {
            this.InitializeComponent();
            this.InitializeValues();
        }

        /// <summary>
        /// Initializes all values to default.
        /// </summary>
        private void InitializeValues()
        {
            this.MapsLoaded.Clear();
            this.MaskMaps = new Dictionary<Map.MapType, Map>
            {
                { Map.MapType.Metallic, new Map(null, Map.MapType.Metallic) },
                { Map.MapType.Roughness, new Map(null, Map.MapType.Roughness) },
                { Map.MapType.AO, new Map(null, Map.MapType.AO) },
                { Map.MapType.Detail_Mask, new Map(null, Map.MapType.Detail_Mask) }
            };
            this.OpacityMaps = new Dictionary<Map.MapType, Map>
            {
                { Map.MapType.Color, new Map(null, Map.MapType.Color) },
                { Map.MapType.Opacity, new Map(null, Map.MapType.Opacity) }
            };
            this.ChannelPackedImage = null;
            this.width = 0;
            this.height = 0;
            this.MetallicMapLabel.Text = "Not Selected";
            this.RoughnessMapLabel.Text = "Not Selected";
            this.AOMapLabel.Text = "Not Selected";
            this.DetailMaskMapLabel.Text = "Not Selected";
            this.ColorMapLabel.Text = "Not Selected";
            this.OpacityMapLabel.Text = "Not Selected";
        }

        /// <summary>
        /// Opens an open file dialog box and saves the image as a bitmap.
        /// </summary>
        /// <param name="type">The map type to load.</param>
        private void OpenImage(Map.MapType type)
        {
            this.OpenFileDialog.Title = $@"Open {type.ToString()} Map...";
            DialogResult result = this.OpenFileDialog.ShowDialog();
            // If open file dialog was successful, load the bitmap of the image into memory and update the label with the filename
            if(result == DialogResult.OK)
            {
                try
                {
                    switch(type)
                    {
                        case Map.MapType.Metallic:
                        {
                            using(Bitmap bmpTemp = new Bitmap(this.OpenFileDialog.FileName))
                            {
                                this.MaskMaps[Map.MapType.Metallic].Bitmap = new Bitmap(bmpTemp);
                            }
                            this.MetallicMapLabel.Text = this.OpenFileDialog.SafeFileName;
                            break;
                        }
                        case Map.MapType.Roughness:
                        {
                            using(Bitmap bmpTemp = new Bitmap(this.OpenFileDialog.FileName))
                            {
                                this.MaskMaps[Map.MapType.Roughness].Bitmap = new Bitmap(bmpTemp);
                            }
                            this.RoughnessMapLabel.Text = this.OpenFileDialog.SafeFileName;
                            break;
                        }
                        case Map.MapType.AO:
                        {
                            using(Bitmap bmpTemp = new Bitmap(this.OpenFileDialog.FileName))
                            {
                                this.MaskMaps[Map.MapType.AO].Bitmap = new Bitmap(bmpTemp);
                            }
                            this.AOMapLabel.Text = this.OpenFileDialog.SafeFileName;
                            break;
                        }
                        case Map.MapType.Detail_Mask:
                        {
                            using(Bitmap bmpTemp = new Bitmap(this.OpenFileDialog.FileName))
                            {
                                this.MaskMaps[Map.MapType.Detail_Mask].Bitmap = new Bitmap(bmpTemp);
                            }
                            this.DetailMaskMapLabel.Text = this.OpenFileDialog.SafeFileName;
                            break;
                        }
                        case Map.MapType.Color:
                        {
                            using(Bitmap bmpTemp = new Bitmap(this.OpenFileDialog.FileName))
                            {
                                this.OpacityMaps[Map.MapType.Color].Bitmap = new Bitmap(bmpTemp);
                            }
                            this.ColorMapLabel.Text = this.OpenFileDialog.SafeFileName;
                            break;
                        }
                        case Map.MapType.Opacity:
                        {
                            using(Bitmap bmpTemp = new Bitmap(this.OpenFileDialog.FileName))
                            {
                                this.OpacityMaps[Map.MapType.Opacity].Bitmap = new Bitmap(bmpTemp);
                            }
                            this.OpacityMapLabel.Text = this.OpenFileDialog.SafeFileName;
                            break;
                        }
                    }
                }
                // If there was an exception, show an error message
                catch(Exception)
                {
                    MessageBox.Show($@"Unable to read image: {this.OpenFileDialog.SafeFileName}!{Environment.NewLine}Please select a valid image format.{Environment.NewLine}For best results use JPG or PNG format.");
                }
            }
            // If file open dialog was unsuccessful, reset file name to default
            else
            {
                this.OpenFileDialog.FileName = "";
            }
        }

        /// <summary>
        /// Saves the current channel packed image to file.
        /// </summary>
        /// <param name="type">The operation type: Mask, or Opacity.</param>
        private void SaveImage(OperationType type)
        {
            // If channel packed image was created, save image to file as jpg
            if(this.ChannelPackedImage != null)
            {
                this.SaveFileDialog.Filter = "PNG Image (*.PNG, *.png)|";
                this.SaveFileDialog.Title = "Save Channel Packed Map...";
                Match match = Regex.Match(this.OpenFileDialog.SafeFileName, "^(.*)_");
                this.SaveFileDialog.FileName = match.Value + (type == OperationType.Mask ? "MaskMap.png" : "ColorWithOpacity.png");
                DialogResult result = this.SaveFileDialog.ShowDialog();
                if(result == DialogResult.OK)
                {
                    this.ChannelPackedImage.Save(this.SaveFileDialog.FileName, ImageFormat.Png);
                }
            }
            else
            {
                MessageBox.Show($@"There is no image to save!");
            }
        }

        /// <summary>
        /// Checks if the current maps loaded into memory are valid for the given type. Returns true if the maps are valid and can be channel packed.
        /// </summary>
        /// <param name="type">The operation type: Mask, or Opacity.</param>
        /// <returns>Returns true if the maps are valid and can be channel packed.</returns>
        private bool AreMapSelectionsValid(OperationType type)
        {
            // Default width, height, and empty maps loaded
            this.width = 0;
            this.height = 0;
            this.MapsLoaded.Clear();
            // Check if mask maps are valid
            if(type == OperationType.Mask)
            {
                // Make sure there is at least one map loaded and check that all maps are the same dimensions
                foreach(KeyValuePair<Map.MapType, Map> map in this.MaskMaps)
                {
                    if(map.Value.Bitmap != null)
                    {
                        this.MapsLoaded.Add(map.Key);
                        // Initialize width and height to first map loaded
                        if(this.width == 0 && this.height == 0)
                        {
                            this.width = map.Value.Bitmap.Width;
                            this.height = map.Value.Bitmap.Height;
                        }
                        // Check all other maps against dimensions
                        else
                        {
                            // If current map does not have same dimensions as previous map return false
                            if(map.Value.Bitmap.Width != this.width || map.Value.Bitmap.Height != this.height)
                            {
                                return false;
                            }
                        }
                    }
                }
                // If all maps are null return false
                if(this.MapsLoaded.Count == 0)
                {
                    return false;
                }
                return true;
            }
            // Check if opacity maps are valid
            else
            {
                // Make sure both maps are loaded and check that all maps are the same dimensions
                foreach(KeyValuePair<Map.MapType, Map> map in this.OpacityMaps)
                {
                    if(map.Value.Bitmap != null)
                    {
                        this.MapsLoaded.Add(map.Key);
                        // Initialize width and height to first map loaded
                        if(this.width == 0 && this.height == 0)
                        {
                            this.width = map.Value.Bitmap.Width;
                            this.height = map.Value.Bitmap.Height;
                        }
                        // Check all other maps against dimensions
                        else
                        {
                            // If current map does not have same dimensions as previous map return false
                            if(map.Value.Bitmap.Width != this.width || map.Value.Bitmap.Height != this.height)
                            {
                                return false;
                            }
                        }
                    }
                }
                // If less than 2 maps are loaded return false
                if(this.MapsLoaded.Count < 2)
                {
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Generates a channel packed map out of the loaded images for the given type.
        /// </summary>
        /// <param name="type">The operation type: Mask, or Opacity.</param>
        private void GenerateChannelPackedMap(OperationType type)
        {
            // Generate channel packed mask map
            if(type == OperationType.Mask)
            {
                // Check if maps are valid
                if(this.AreMapSelectionsValid(type) == true)
                {
                    //Pack channels
                    this.ChannelPackedImage = new Bitmap(this.width, this.height);
                    for(int x = 0; x < this.width; x++)
                    {
                        for(int y = 0; y < this.height; y++)
                        {
                            int a = 255;
                            int r = 255;
                            int g = 255;
                            int b = 255;
                            if(this.MapsLoaded.Contains(Map.MapType.Roughness))
                            {
                                a = this.MaskMaps[Map.MapType.Roughness].Bitmap.GetPixel(x, y).R;
                            }
                            if(this.MapsLoaded.Contains(Map.MapType.Metallic))
                            {
                                r = this.MaskMaps[Map.MapType.Metallic].Bitmap.GetPixel(x, y).R;
                            }
                            if(this.MapsLoaded.Contains(Map.MapType.AO))
                            {
                                g = this.MaskMaps[Map.MapType.AO].Bitmap.GetPixel(x, y).R;
                            }
                            if(this.MapsLoaded.Contains(Map.MapType.Detail_Mask))
                            {
                                b = this.MaskMaps[Map.MapType.Detail_Mask].Bitmap.GetPixel(x, y).R;
                            }
                            this.ChannelPackedImage.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                        }
                    }
                    // Open save dialog
                    this.SaveImage(type);
                }
                // If maps aren't valid show error
                else
                {
                    MessageBox.Show($@"Please load at least one map and make sure they are all the same dimensions.");
                }
            }
            // Generate channel packed opacity map
            else
            {
                // Check if maps are valid
                if(this.AreMapSelectionsValid(type) == true)
                {
                    // Pack channels
                    this.ChannelPackedImage = new Bitmap(this.width, this.height);
                    for(int x = 0; x < this.width; x++)
                    {
                        for(int y = 0; y < this.height; y++)
                        {
                            int a = this.OpacityMaps[Map.MapType.Opacity].Bitmap.GetPixel(x, y).R;
                            Color color = this.OpacityMaps[Map.MapType.Color].Bitmap.GetPixel(x, y);
                            this.ChannelPackedImage.SetPixel(x, y, Color.FromArgb(a, color.R, color.G, color.B));
                        }
                    }
                    // Open save dialog
                    this.SaveImage(type);
                }
                // If maps aren't valid show error
                else
                {
                    MessageBox.Show($@"Please load both maps and make sure they are the same dimensions.");
                }
            }
        }

        /// <summary>
        /// Called when the Select Metallic Map button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetallicMapSelectButton_Click(object sender, EventArgs e)
        {
            this.OpenImage(Map.MapType.Metallic);
        }

        /// <summary>
        /// Called when the Select Roughness Map button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectRoughnessMapButton_Click(object sender, EventArgs e)
        {
            this.OpenImage(Map.MapType.Roughness);
        }

        /// <summary>
        /// Called when the Select Ambient Occlusion Map button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectAOMapButton_Click(object sender, EventArgs e)
        {
            this.OpenImage(Map.MapType.AO);
        }

        /// <summary>
        /// Called when the Select Detail Mask Map button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectDetailMaskMapButton_Click(object sender, EventArgs e)
        {
            this.OpenImage(Map.MapType.Detail_Mask);
        }

        /// <summary>
        /// Called when the Generate Mask Map button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateMaskMapButton_Click(object sender, EventArgs e)
        {
            this.GenerateChannelPackedMap(OperationType.Mask);
        }

        /// <summary>
        /// Called when the Select Color Map button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectColorMapButton_Click(object sender, EventArgs e)
        {
            this.OpenImage(Map.MapType.Color);
        }

        /// <summary>
        /// Called when the Select Opacity Map button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectOpacityMapButton_Click(object sender, EventArgs e)
        {
            this.OpenImage(Map.MapType.Opacity);
        }

        /// <summary>
        /// Called when the Generate Color Map With Opacity button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateColorMapButton_Click(object sender, EventArgs e)
        {
            this.GenerateChannelPackedMap(OperationType.Opacity);
        }

        /// <summary>
        /// Called when the Reset button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetButton_Click(object sender, EventArgs e)
        {
            this.InitializeValues();
        }
    }

    /// <summary>
    /// Class containing a bitmap and a map type.
    /// </summary>
    public class Map
    {
        /// <summary>
        /// The type of map.
        /// </summary>
        public enum MapType
        {
            Metallic,
            Roughness,
            AO,
            Detail_Mask,
            Color,
            Opacity
        }

        /// <summary>
        /// The bitmap contained in the map.
        /// </summary>
        public Bitmap Bitmap;
        /// <summary>
        /// The type of map that this is.
        /// </summary>
        public MapType Type;

        /// <summary>
        /// Map constructor.
        /// </summary>
        /// <param name="bitmap">The bitmap image for this map.</param>
        /// <param name="type">The map type for this map.</param>
        public Map(Bitmap bitmap, MapType type)
        {
            this.Bitmap = bitmap;
            this.Type = type;
        }
    }
}
