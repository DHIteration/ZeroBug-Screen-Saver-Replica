namespace SmileyPirateScreenSaver
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.lblInfect = new System.Windows.Forms.Label();
            this.lblGrowth = new System.Windows.Forms.Label();
            this.scrlSpeed = new System.Windows.Forms.HScrollBar();
            this.scrlAmount = new System.Windows.Forms.HScrollBar();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.btnLaunch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pic2 = new System.Windows.Forms.PictureBox();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.picLaunch = new System.Windows.Forms.PictureBox();
            this.chkGhost = new System.Windows.Forms.CheckBox();
            this.chkInflateDeflate = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLaunch)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInfect
            // 
            this.lblInfect.AutoSize = true;
            this.lblInfect.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfect.Location = new System.Drawing.Point(108, 12);
            this.lblInfect.Name = "lblInfect";
            this.lblInfect.Size = new System.Drawing.Size(79, 11);
            this.lblInfect.TabIndex = 3;
            this.lblInfect.Text = "Infection Speed:";
            // 
            // lblGrowth
            // 
            this.lblGrowth.AutoSize = true;
            this.lblGrowth.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrowth.Location = new System.Drawing.Point(108, 62);
            this.lblGrowth.Name = "lblGrowth";
            this.lblGrowth.Size = new System.Drawing.Size(60, 11);
            this.lblGrowth.TabIndex = 5;
            this.lblGrowth.Text = "Replication:";
            // 
            // scrlSpeed
            // 
            this.scrlSpeed.LargeChange = 1;
            this.scrlSpeed.Location = new System.Drawing.Point(110, 23);
            this.scrlSpeed.Maximum = 30;
            this.scrlSpeed.Minimum = 1;
            this.scrlSpeed.Name = "scrlSpeed";
            this.scrlSpeed.Size = new System.Drawing.Size(135, 20);
            this.scrlSpeed.TabIndex = 6;
            this.scrlSpeed.Value = 1;
            this.scrlSpeed.ValueChanged += new System.EventHandler(this.scrlSpeed_ValueChanged);
            // 
            // scrlAmount
            // 
            this.scrlAmount.LargeChange = 1;
            this.scrlAmount.Location = new System.Drawing.Point(110, 73);
            this.scrlAmount.Minimum = 1;
            this.scrlAmount.Name = "scrlAmount";
            this.scrlAmount.Size = new System.Drawing.Size(135, 20);
            this.scrlAmount.TabIndex = 7;
            this.scrlAmount.Value = 1;
            this.scrlAmount.ValueChanged += new System.EventHandler(this.scrlAmount_ValueChanged);
            // 
            // lblSpeed
            // 
            this.lblSpeed.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.Location = new System.Drawing.Point(193, 12);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(52, 11);
            this.lblSpeed.TabIndex = 8;
            this.lblSpeed.Text = "3.33%";
            this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblAmount
            // 
            this.lblAmount.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(193, 62);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(52, 11);
            this.lblAmount.TabIndex = 9;
            this.lblAmount.Text = "1.00%";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnLaunch
            // 
            this.btnLaunch.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaunch.Location = new System.Drawing.Point(58, 164);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(87, 22);
            this.btnLaunch.TabIndex = 10;
            this.btnLaunch.Text = "Launch";
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(204, 164);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 22);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pic2
            // 
            this.pic2.BackColor = System.Drawing.Color.Black;
            this.pic2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic2.Image = global::SmileyPirate.Properties.Resources.PacSide;
            this.pic2.Location = new System.Drawing.Point(260, 12);
            this.pic2.Name = "pic2";
            this.pic2.Size = new System.Drawing.Size(85, 81);
            this.pic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic2.TabIndex = 1;
            this.pic2.TabStop = false;
            // 
            // pic1
            // 
            this.pic1.BackColor = System.Drawing.Color.Black;
            this.pic1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic1.Image = global::SmileyPirate.Properties.Resources.PacFront;
            this.pic1.Location = new System.Drawing.Point(12, 12);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(85, 81);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic1.TabIndex = 0;
            this.pic1.TabStop = false;
            // 
            // picLaunch
            // 
            this.picLaunch.Image = ((System.Drawing.Image)(resources.GetObject("picLaunch.Image")));
            this.picLaunch.Location = new System.Drawing.Point(-1, 141);
            this.picLaunch.Name = "picLaunch";
            this.picLaunch.Size = new System.Drawing.Size(359, 58);
            this.picLaunch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLaunch.TabIndex = 11;
            this.picLaunch.TabStop = false;
            this.picLaunch.Visible = false;
            // 
            // chkGhost
            // 
            this.chkGhost.AutoSize = true;
            this.chkGhost.Location = new System.Drawing.Point(110, 102);
            this.chkGhost.Name = "chkGhost";
            this.chkGhost.Size = new System.Drawing.Size(71, 17);
            this.chkGhost.TabIndex = 13;
            this.chkGhost.Text = "Ghosting:";
            this.chkGhost.UseVisualStyleBackColor = true;
            // 
            // chkInflateDeflate
            // 
            this.chkInflateDeflate.AutoSize = true;
            this.chkInflateDeflate.Location = new System.Drawing.Point(110, 122);
            this.chkInflateDeflate.Name = "chkInflateDeflate";
            this.chkInflateDeflate.Size = new System.Drawing.Size(130, 17);
            this.chkInflateDeflate.TabIndex = 14;
            this.chkInflateDeflate.Text = "File Inflation Deflation:";
            this.chkInflateDeflate.UseVisualStyleBackColor = true;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 195);
            this.ControlBox = false;
            this.Controls.Add(this.chkInflateDeflate);
            this.Controls.Add(this.chkGhost);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLaunch);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.scrlAmount);
            this.Controls.Add(this.scrlSpeed);
            this.Controls.Add(this.lblGrowth);
            this.Controls.Add(this.lblInfect);
            this.Controls.Add(this.pic2);
            this.Controls.Add(this.pic1);
            this.Controls.Add(this.picLaunch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Virus Launch Panel";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLaunch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.PictureBox pic2;
        private System.Windows.Forms.Label lblInfect;
        private System.Windows.Forms.Label lblGrowth;
        private System.Windows.Forms.HScrollBar scrlSpeed;
        private System.Windows.Forms.HScrollBar scrlAmount;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.PictureBox picLaunch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkGhost;
        private System.Windows.Forms.CheckBox chkInflateDeflate;
    }
}