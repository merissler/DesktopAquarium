namespace DesktopAquarium.Fish
{
    partial class BaseFish
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
            if (disposing && (components != null))
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
            pbMain = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbMain).BeginInit();
            SuspendLayout();
            // 
            // pbMain
            // 
            pbMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pbMain.Location = new Point(0, 0);
            pbMain.Name = "pbMain";
            pbMain.Size = new Size(400, 300);
            pbMain.TabIndex = 0;
            pbMain.TabStop = false;
            // 
            // BaseFish
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 300);
            Controls.Add(pbMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "BaseFish";
            Text = "BaseFish";
            TransparencyKey = SystemColors.Control;
            ((System.ComponentModel.ISupportInitialize)pbMain).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbMain;
    }
}