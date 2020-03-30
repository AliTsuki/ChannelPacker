namespace ChannelPacker
{
    partial class ChannelPacker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MetallicMapSelectButton = new System.Windows.Forms.Button();
            this.SelectRoughnessMapButton = new System.Windows.Forms.Button();
            this.SelectDetailMaskMapButton = new System.Windows.Forms.Button();
            this.SelectAOMapButton = new System.Windows.Forms.Button();
            this.GenerateMaskMapButton = new System.Windows.Forms.Button();
            this.MetallicMapLabel = new System.Windows.Forms.Label();
            this.RoughnessMapLabel = new System.Windows.Forms.Label();
            this.AOMapLabel = new System.Windows.Forms.Label();
            this.DetailMaskMapLabel = new System.Windows.Forms.Label();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.MaskMapGroupBox = new System.Windows.Forms.GroupBox();
            this.OpacityGroupBox = new System.Windows.Forms.GroupBox();
            this.OpacityMapLabel = new System.Windows.Forms.Label();
            this.ColorMapLabel = new System.Windows.Forms.Label();
            this.GenerateColorMapButton = new System.Windows.Forms.Button();
            this.SelectOpacityMapButton = new System.Windows.Forms.Button();
            this.SelectColorMapButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.MaskMapGroupBox.SuspendLayout();
            this.OpacityGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MetallicMapSelectButton
            // 
            this.MetallicMapSelectButton.Location = new System.Drawing.Point(6, 21);
            this.MetallicMapSelectButton.Name = "MetallicMapSelectButton";
            this.MetallicMapSelectButton.Size = new System.Drawing.Size(129, 23);
            this.MetallicMapSelectButton.TabIndex = 0;
            this.MetallicMapSelectButton.Text = "Select Metallic Map";
            this.MetallicMapSelectButton.UseVisualStyleBackColor = true;
            this.MetallicMapSelectButton.Click += new System.EventHandler(this.MetallicMapSelectButton_Click);
            // 
            // SelectRoughnessMapButton
            // 
            this.SelectRoughnessMapButton.Location = new System.Drawing.Point(6, 50);
            this.SelectRoughnessMapButton.Name = "SelectRoughnessMapButton";
            this.SelectRoughnessMapButton.Size = new System.Drawing.Size(129, 23);
            this.SelectRoughnessMapButton.TabIndex = 1;
            this.SelectRoughnessMapButton.Text = "Select Roughness Map";
            this.SelectRoughnessMapButton.UseVisualStyleBackColor = true;
            this.SelectRoughnessMapButton.Click += new System.EventHandler(this.SelectRoughnessMapButton_Click);
            // 
            // SelectDetailMaskMapButton
            // 
            this.SelectDetailMaskMapButton.Location = new System.Drawing.Point(6, 108);
            this.SelectDetailMaskMapButton.Name = "SelectDetailMaskMapButton";
            this.SelectDetailMaskMapButton.Size = new System.Drawing.Size(129, 23);
            this.SelectDetailMaskMapButton.TabIndex = 2;
            this.SelectDetailMaskMapButton.Text = "Select Detail Mask Map";
            this.SelectDetailMaskMapButton.UseVisualStyleBackColor = true;
            this.SelectDetailMaskMapButton.Click += new System.EventHandler(this.SelectDetailMaskMapButton_Click);
            // 
            // SelectAOMapButton
            // 
            this.SelectAOMapButton.Location = new System.Drawing.Point(6, 79);
            this.SelectAOMapButton.Name = "SelectAOMapButton";
            this.SelectAOMapButton.Size = new System.Drawing.Size(129, 23);
            this.SelectAOMapButton.TabIndex = 3;
            this.SelectAOMapButton.Text = "Select AO Map";
            this.SelectAOMapButton.UseVisualStyleBackColor = true;
            this.SelectAOMapButton.Click += new System.EventHandler(this.SelectAOMapButton_Click);
            // 
            // GenerateMaskMapButton
            // 
            this.GenerateMaskMapButton.Location = new System.Drawing.Point(6, 178);
            this.GenerateMaskMapButton.Name = "GenerateMaskMapButton";
            this.GenerateMaskMapButton.Size = new System.Drawing.Size(129, 23);
            this.GenerateMaskMapButton.TabIndex = 4;
            this.GenerateMaskMapButton.Text = "Generate Mask Map";
            this.GenerateMaskMapButton.UseVisualStyleBackColor = true;
            this.GenerateMaskMapButton.Click += new System.EventHandler(this.GenerateMaskMapButton_Click);
            // 
            // MetallicMapLabel
            // 
            this.MetallicMapLabel.AutoSize = true;
            this.MetallicMapLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MetallicMapLabel.Location = new System.Drawing.Point(141, 26);
            this.MetallicMapLabel.Name = "MetallicMapLabel";
            this.MetallicMapLabel.Size = new System.Drawing.Size(88, 15);
            this.MetallicMapLabel.TabIndex = 5;
            this.MetallicMapLabel.Text = "Metallic Map File";
            // 
            // RoughnessMapLabel
            // 
            this.RoughnessMapLabel.AutoSize = true;
            this.RoughnessMapLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RoughnessMapLabel.Location = new System.Drawing.Point(141, 55);
            this.RoughnessMapLabel.Name = "RoughnessMapLabel";
            this.RoughnessMapLabel.Size = new System.Drawing.Size(106, 15);
            this.RoughnessMapLabel.TabIndex = 6;
            this.RoughnessMapLabel.Text = "Roughness Map File";
            // 
            // AOMapLabel
            // 
            this.AOMapLabel.AutoSize = true;
            this.AOMapLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AOMapLabel.Location = new System.Drawing.Point(141, 84);
            this.AOMapLabel.Name = "AOMapLabel";
            this.AOMapLabel.Size = new System.Drawing.Size(67, 15);
            this.AOMapLabel.TabIndex = 7;
            this.AOMapLabel.Text = "AO Map File";
            // 
            // DetailMaskMapLabel
            // 
            this.DetailMaskMapLabel.AutoSize = true;
            this.DetailMaskMapLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DetailMaskMapLabel.Location = new System.Drawing.Point(141, 113);
            this.DetailMaskMapLabel.Name = "DetailMaskMapLabel";
            this.DetailMaskMapLabel.Size = new System.Drawing.Size(108, 15);
            this.DetailMaskMapLabel.TabIndex = 8;
            this.DetailMaskMapLabel.Text = "Detail Mask Map File";
            // 
            // MaskMapGroupBox
            // 
            this.MaskMapGroupBox.Controls.Add(this.SelectDetailMaskMapButton);
            this.MaskMapGroupBox.Controls.Add(this.DetailMaskMapLabel);
            this.MaskMapGroupBox.Controls.Add(this.MetallicMapSelectButton);
            this.MaskMapGroupBox.Controls.Add(this.AOMapLabel);
            this.MaskMapGroupBox.Controls.Add(this.SelectRoughnessMapButton);
            this.MaskMapGroupBox.Controls.Add(this.RoughnessMapLabel);
            this.MaskMapGroupBox.Controls.Add(this.SelectAOMapButton);
            this.MaskMapGroupBox.Controls.Add(this.MetallicMapLabel);
            this.MaskMapGroupBox.Controls.Add(this.GenerateMaskMapButton);
            this.MaskMapGroupBox.Location = new System.Drawing.Point(12, 12);
            this.MaskMapGroupBox.Name = "MaskMapGroupBox";
            this.MaskMapGroupBox.Size = new System.Drawing.Size(695, 209);
            this.MaskMapGroupBox.TabIndex = 9;
            this.MaskMapGroupBox.TabStop = false;
            this.MaskMapGroupBox.Text = "Mask Map";
            // 
            // OpacityGroupBox
            // 
            this.OpacityGroupBox.Controls.Add(this.OpacityMapLabel);
            this.OpacityGroupBox.Controls.Add(this.ColorMapLabel);
            this.OpacityGroupBox.Controls.Add(this.GenerateColorMapButton);
            this.OpacityGroupBox.Controls.Add(this.SelectOpacityMapButton);
            this.OpacityGroupBox.Controls.Add(this.SelectColorMapButton);
            this.OpacityGroupBox.Location = new System.Drawing.Point(12, 228);
            this.OpacityGroupBox.Name = "OpacityGroupBox";
            this.OpacityGroupBox.Size = new System.Drawing.Size(695, 166);
            this.OpacityGroupBox.TabIndex = 10;
            this.OpacityGroupBox.TabStop = false;
            this.OpacityGroupBox.Text = "Opacity";
            // 
            // OpacityMapLabel
            // 
            this.OpacityMapLabel.AutoSize = true;
            this.OpacityMapLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OpacityMapLabel.Location = new System.Drawing.Point(141, 55);
            this.OpacityMapLabel.Name = "OpacityMapLabel";
            this.OpacityMapLabel.Size = new System.Drawing.Size(88, 15);
            this.OpacityMapLabel.TabIndex = 4;
            this.OpacityMapLabel.Text = "Opacity Map File";
            // 
            // ColorMapLabel
            // 
            this.ColorMapLabel.AutoSize = true;
            this.ColorMapLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColorMapLabel.Location = new System.Drawing.Point(141, 26);
            this.ColorMapLabel.Name = "ColorMapLabel";
            this.ColorMapLabel.Size = new System.Drawing.Size(76, 15);
            this.ColorMapLabel.TabIndex = 3;
            this.ColorMapLabel.Text = "Color Map File";
            // 
            // GenerateColorMapButton
            // 
            this.GenerateColorMapButton.Location = new System.Drawing.Point(6, 120);
            this.GenerateColorMapButton.Name = "GenerateColorMapButton";
            this.GenerateColorMapButton.Size = new System.Drawing.Size(129, 37);
            this.GenerateColorMapButton.TabIndex = 2;
            this.GenerateColorMapButton.Text = "Generate Color Map With Opacity";
            this.GenerateColorMapButton.UseVisualStyleBackColor = true;
            this.GenerateColorMapButton.Click += new System.EventHandler(this.GenerateColorMapButton_Click);
            // 
            // SelectOpacityMapButton
            // 
            this.SelectOpacityMapButton.Location = new System.Drawing.Point(6, 50);
            this.SelectOpacityMapButton.Name = "SelectOpacityMapButton";
            this.SelectOpacityMapButton.Size = new System.Drawing.Size(129, 23);
            this.SelectOpacityMapButton.TabIndex = 1;
            this.SelectOpacityMapButton.Text = "Select Opacity Map";
            this.SelectOpacityMapButton.UseVisualStyleBackColor = true;
            this.SelectOpacityMapButton.Click += new System.EventHandler(this.SelectOpacityMapButton_Click);
            // 
            // SelectColorMapButton
            // 
            this.SelectColorMapButton.Location = new System.Drawing.Point(6, 21);
            this.SelectColorMapButton.Name = "SelectColorMapButton";
            this.SelectColorMapButton.Size = new System.Drawing.Size(129, 23);
            this.SelectColorMapButton.TabIndex = 0;
            this.SelectColorMapButton.Text = "Select Color Map";
            this.SelectColorMapButton.UseVisualStyleBackColor = true;
            this.SelectColorMapButton.Click += new System.EventHandler(this.SelectColorMapButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(18, 413);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(129, 26);
            this.ResetButton.TabIndex = 5;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // ChannelPacker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 462);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.OpacityGroupBox);
            this.Controls.Add(this.MaskMapGroupBox);
            this.Name = "ChannelPacker";
            this.Text = "Channel Packer";
            this.MaskMapGroupBox.ResumeLayout(false);
            this.MaskMapGroupBox.PerformLayout();
            this.OpacityGroupBox.ResumeLayout(false);
            this.OpacityGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MetallicMapSelectButton;
        private System.Windows.Forms.Button SelectRoughnessMapButton;
        private System.Windows.Forms.Button SelectDetailMaskMapButton;
        private System.Windows.Forms.Button SelectAOMapButton;
        private System.Windows.Forms.Button GenerateMaskMapButton;
        private System.Windows.Forms.Label MetallicMapLabel;
        private System.Windows.Forms.Label RoughnessMapLabel;
        private System.Windows.Forms.Label AOMapLabel;
        private System.Windows.Forms.Label DetailMaskMapLabel;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.GroupBox MaskMapGroupBox;
        private System.Windows.Forms.GroupBox OpacityGroupBox;
        private System.Windows.Forms.Label OpacityMapLabel;
        private System.Windows.Forms.Label ColorMapLabel;
        private System.Windows.Forms.Button GenerateColorMapButton;
        private System.Windows.Forms.Button SelectOpacityMapButton;
        private System.Windows.Forms.Button SelectColorMapButton;
        private System.Windows.Forms.Button ResetButton;
    }
}

