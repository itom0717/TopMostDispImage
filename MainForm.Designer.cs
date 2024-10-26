namespace TopMostDispImage
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            ImagePictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)ImagePictureBox).BeginInit();
            SuspendLayout();
            // 
            // ImagePictureBox
            // 
            ImagePictureBox.Location = new Point(68, 68);
            ImagePictureBox.Name = "ImagePictureBox";
            ImagePictureBox.Size = new Size(200, 162);
            ImagePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            ImagePictureBox.TabIndex = 0;
            ImagePictureBox.TabStop = false;
            ImagePictureBox.Click += ImagePictureBox_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(345, 328);
            Controls.Add(ImagePictureBox);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            Text = "MainForm";
            TopMost = true;
            Load += MainForm_Load;
            Shown += MainForm_Shown;
            Click += MainForm_Click;
            ((System.ComponentModel.ISupportInitialize)ImagePictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox ImagePictureBox;
    }
}
