namespace DesktopAquarium
{
    partial class frmCredit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCredit));
            linkLabel1 = new LinkLabel();
            label1 = new Label();
            linkLabel2 = new LinkLabel();
            linkLabel3 = new LinkLabel();
            linkLabel4 = new LinkLabel();
            label2 = new Label();
            label3 = new Label();
            linkLabel5 = new LinkLabel();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.Black;
            linkLabel1.Location = new Point(12, 91);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(226, 28);
            linkLabel1.TabIndex = 0;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Main dev dude: JJSnader";
            linkLabel1.VisitedLinkColor = Color.Black;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 133);
            label1.Name = "label1";
            label1.Size = new Size(131, 28);
            label1.TabIndex = 1;
            label1.Text = "Collaborators";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.LinkColor = Color.Black;
            linkLabel2.Location = new Point(12, 172);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(89, 28);
            linkLabel2.TabIndex = 2;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "merissler";
            linkLabel2.VisitedLinkColor = Color.Black;
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // linkLabel3
            // 
            linkLabel3.AutoSize = true;
            linkLabel3.LinkColor = Color.Black;
            linkLabel3.Location = new Point(12, 205);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(139, 28);
            linkLabel3.TabIndex = 3;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "druburkholder";
            linkLabel3.VisitedLinkColor = Color.Black;
            linkLabel3.LinkClicked += linkLabel3_LinkClicked;
            // 
            // linkLabel4
            // 
            linkLabel4.AutoSize = true;
            linkLabel4.LinkColor = Color.Black;
            linkLabel4.Location = new Point(12, 519);
            linkLabel4.Name = "linkLabel4";
            linkLabel4.Size = new Size(297, 28);
            linkLabel4.TabIndex = 4;
            linkLabel4.TabStop = true;
            linkLabel4.Text = "https://freesound.org/s/543386/";
            linkLabel4.VisitedLinkColor = Color.Black;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 491);
            label2.Name = "label2";
            label2.Size = new Size(516, 28);
            label2.TabIndex = 5;
            label2.Text = "Shark Chomping Sound - Nom Noise by TheDragonSpark";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 407);
            label3.Name = "label3";
            label3.Size = new Size(557, 28);
            label3.TabIndex = 6;
            label3.Text = "Shark Chasing Sound - Low-bit Retro Chase Loop by digimistic";
            // 
            // linkLabel5
            // 
            linkLabel5.AutoSize = true;
            linkLabel5.LinkColor = Color.Black;
            linkLabel5.Location = new Point(12, 435);
            linkLabel5.Name = "linkLabel5";
            linkLabel5.Size = new Size(297, 28);
            linkLabel5.TabIndex = 7;
            linkLabel5.TabStop = true;
            linkLabel5.Text = "https://freesound.org/s/703692/";
            linkLabel5.VisitedLinkColor = Color.Black;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 368);
            label4.Name = "label4";
            label4.Size = new Size(66, 28);
            label4.TabIndex = 8;
            label4.Text = "Assets";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 256);
            label5.Name = "label5";
            label5.Size = new Size(246, 28);
            label5.TabIndex = 9;
            label5.Text = "Tester: Austin (Braga_Rhun)";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.Font = new Font("Segoe UI", 30F);
            label6.Location = new Point(12, 9);
            label6.Name = "label6";
            label6.Size = new Size(577, 47);
            label6.TabIndex = 10;
            label6.Text = "Credits";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmCredit
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 148, 255);
            ClientSize = new Size(601, 556);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(linkLabel5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(linkLabel4);
            Controls.Add(linkLabel3);
            Controls.Add(linkLabel2);
            Controls.Add(label1);
            Controls.Add(linkLabel1);
            Font = new Font("Segoe UI", 15F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            Name = "frmCredit";
            Text = "Credit";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LinkLabel linkLabel1;
        private Label label1;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel3;
        private LinkLabel linkLabel4;
        private Label label2;
        private Label label3;
        private LinkLabel linkLabel5;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}