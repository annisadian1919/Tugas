namespace Tugas
{
    partial class Payment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Payment));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Cash = new System.Windows.Forms.PictureBox();
            this.btnQR = new System.Windows.Forms.Button();
            this.btnCash = new System.Windows.Forms.Button();
            this.lblPembayaran = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cash)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.Cash);
            this.panel1.Controls.Add(this.btnQR);
            this.panel1.Controls.Add(this.btnCash);
            this.panel1.Controls.Add(this.lblPembayaran);
            this.panel1.Location = new System.Drawing.Point(27, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1099, 581);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(600, 104);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(274, 246);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // Cash
            // 
            this.Cash.Image = ((System.Drawing.Image)(resources.GetObject("Cash.Image")));
            this.Cash.Location = new System.Drawing.Point(106, 116);
            this.Cash.Name = "Cash";
            this.Cash.Size = new System.Drawing.Size(287, 234);
            this.Cash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Cash.TabIndex = 3;
            this.Cash.TabStop = false;
            // 
            // btnQR
            // 
            this.btnQR.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQR.Location = new System.Drawing.Point(652, 367);
            this.btnQR.Name = "btnQR";
            this.btnQR.Size = new System.Drawing.Size(191, 40);
            this.btnQR.TabIndex = 2;
            this.btnQR.Text = "QRIS";
            this.btnQR.UseVisualStyleBackColor = true;
            // 
            // btnCash
            // 
            this.btnCash.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCash.Location = new System.Drawing.Point(150, 367);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(191, 40);
            this.btnCash.TabIndex = 1;
            this.btnCash.Text = "Cash";
            this.btnCash.UseVisualStyleBackColor = true;
            // 
            // lblPembayaran
            // 
            this.lblPembayaran.AutoSize = true;
            this.lblPembayaran.Font = new System.Drawing.Font("Modern No. 20", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPembayaran.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblPembayaran.Location = new System.Drawing.Point(369, 27);
            this.lblPembayaran.Name = "lblPembayaran";
            this.lblPembayaran.Size = new System.Drawing.Size(247, 45);
            this.lblPembayaran.TabIndex = 0;
            this.lblPembayaran.Text = "Pembayaran";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(429, 546);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Applikasi by SigmaFarma";
            // 
            // Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 654);
            this.Controls.Add(this.panel1);
            this.Name = "Payment";
            this.Text = "Payment";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cash)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPembayaran;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox Cash;
        private System.Windows.Forms.Button btnQR;
        private System.Windows.Forms.Button btnCash;
        private System.Windows.Forms.Label label1;
    }
}