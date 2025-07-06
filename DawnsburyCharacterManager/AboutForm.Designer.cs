namespace DawnsburyCharacterManager
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.labelInfo = new System.Windows.Forms.Label();
            this.labelsmallerinfo = new System.Windows.Forms.Label();
            this.linkBsky = new System.Windows.Forms.LinkLabel();
            this.linkKofi = new System.Windows.Forms.LinkLabel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkGithub = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelInfo
            // 
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.Location = new System.Drawing.Point(12, 9);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(406, 65);
            this.labelInfo.TabIndex = 0;
            this.labelInfo.Text = "label1";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelInfo.Click += new System.EventHandler(this.labelInfo_Click);
            // 
            // labelsmallerinfo
            // 
            this.labelsmallerinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelsmallerinfo.Location = new System.Drawing.Point(12, 37);
            this.labelsmallerinfo.Name = "labelsmallerinfo";
            this.labelsmallerinfo.Size = new System.Drawing.Size(406, 192);
            this.labelsmallerinfo.TabIndex = 1;
            this.labelsmallerinfo.Text = "label1";
            this.labelsmallerinfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelsmallerinfo.Click += new System.EventHandler(this.label1_Click);
            // 
            // linkBsky
            // 
            this.linkBsky.AutoSize = true;
            this.linkBsky.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkBsky.Location = new System.Drawing.Point(63, 284);
            this.linkBsky.Name = "linkBsky";
            this.linkBsky.Size = new System.Drawing.Size(182, 24);
            this.linkBsky.TabIndex = 2;
            this.linkBsky.TabStop = true;
            this.linkBsky.Text = "Find me on Bluesky!";
            this.linkBsky.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBsky_LinkClicked);
            // 
            // linkKofi
            // 
            this.linkKofi.AutoSize = true;
            this.linkKofi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkKofi.Location = new System.Drawing.Point(63, 337);
            this.linkKofi.Name = "linkKofi";
            this.linkKofi.Size = new System.Drawing.Size(132, 24);
            this.linkKofi.TabIndex = 3;
            this.linkKofi.TabStop = true;
            this.linkKofi.Text = "Donate a Ko-fi!";
            this.linkKofi.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkKofi_LinkClicked);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DawnsburyCharacterManager.Properties.Resources.github_icon;
            this.pictureBox4.Location = new System.Drawing.Point(12, 213);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(48, 50);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DawnsburyCharacterManager.Properties.Resources.ChujiOtter;
            this.pictureBox3.Location = new System.Drawing.Point(254, 213);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(164, 162);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DawnsburyCharacterManager.Properties.Resources.kofi;
            this.pictureBox2.Location = new System.Drawing.Point(12, 325);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DawnsburyCharacterManager.Properties.Resources.bsky_icon;
            this.pictureBox1.Location = new System.Drawing.Point(13, 269);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // linkGithub
            // 
            this.linkGithub.AutoSize = true;
            this.linkGithub.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkGithub.Location = new System.Drawing.Point(63, 229);
            this.linkGithub.Name = "linkGithub";
            this.linkGithub.Size = new System.Drawing.Size(180, 24);
            this.linkGithub.TabIndex = 8;
            this.linkGithub.TabStop = true;
            this.linkGithub.Text = "Project GitHub Page";
            this.linkGithub.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkGithub_LinkClicked);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 385);
            this.Controls.Add(this.linkGithub);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.linkKofi);
            this.Controls.Add(this.linkBsky);
            this.Controls.Add(this.labelsmallerinfo);
            this.Controls.Add(this.labelInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AboutForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "About";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label labelsmallerinfo;
        private System.Windows.Forms.LinkLabel linkBsky;
        private System.Windows.Forms.LinkLabel linkKofi;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.LinkLabel linkGithub;
    }
}