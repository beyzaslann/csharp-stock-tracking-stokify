namespace Stok_Takip
{
    partial class istatistikForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(istatistikForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblGunlukSatis = new System.Windows.Forms.Label();
            this.lblGunlukKazanc = new System.Windows.Forms.Label();
            this.lblGunlukKar = new System.Windows.Forms.Label();
            this.lblGunlukKayit = new System.Windows.Forms.Label();
            this.lblGunlukUrun = new System.Windows.Forms.Label();
            this.lblAzalanStok = new System.Windows.Forms.Label();
            this.btnGeri = new System.Windows.Forms.Button();
            this.btnPdfKaydet = new System.Windows.Forms.Button();
            this.lblTarihSaat = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-13, -6);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 46);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Stok_Takip.Properties.Resources.minimize_window_48;
            this.pictureBox3.Location = new System.Drawing.Point(236, 10);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Stok_Takip.Properties.Resources.close_window_48;
            this.pictureBox2.Location = new System.Drawing.Point(270, 11);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(51, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 28);
            this.label1.TabIndex = 8;
            this.label1.Text = "Günlük Rapor";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Stok_Takip.Properties.Resources.icons8_customer_48;
            this.pictureBox1.Location = new System.Drawing.Point(14, 8);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(75, 55);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Günlük Satış :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(60, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Günlük Kazanç :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(85, 113);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Günlük Kâr :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(75, 142);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Günlük Kayıt :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(77, 171);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "Günlük Ürün :";
            // 
            // lblGunlukSatis
            // 
            this.lblGunlukSatis.AutoSize = true;
            this.lblGunlukSatis.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGunlukSatis.Location = new System.Drawing.Point(171, 55);
            this.lblGunlukSatis.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGunlukSatis.Name = "lblGunlukSatis";
            this.lblGunlukSatis.Size = new System.Drawing.Size(47, 23);
            this.lblGunlukSatis.TabIndex = 6;
            this.lblGunlukSatis.Text = "Value";
            // 
            // lblGunlukKazanc
            // 
            this.lblGunlukKazanc.AutoSize = true;
            this.lblGunlukKazanc.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGunlukKazanc.Location = new System.Drawing.Point(171, 84);
            this.lblGunlukKazanc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGunlukKazanc.Name = "lblGunlukKazanc";
            this.lblGunlukKazanc.Size = new System.Drawing.Size(47, 23);
            this.lblGunlukKazanc.TabIndex = 7;
            this.lblGunlukKazanc.Text = "Value";
            // 
            // lblGunlukKar
            // 
            this.lblGunlukKar.AutoSize = true;
            this.lblGunlukKar.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGunlukKar.Location = new System.Drawing.Point(171, 113);
            this.lblGunlukKar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGunlukKar.Name = "lblGunlukKar";
            this.lblGunlukKar.Size = new System.Drawing.Size(47, 23);
            this.lblGunlukKar.TabIndex = 8;
            this.lblGunlukKar.Text = "Value";
            // 
            // lblGunlukKayit
            // 
            this.lblGunlukKayit.AutoSize = true;
            this.lblGunlukKayit.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGunlukKayit.Location = new System.Drawing.Point(171, 142);
            this.lblGunlukKayit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGunlukKayit.Name = "lblGunlukKayit";
            this.lblGunlukKayit.Size = new System.Drawing.Size(47, 23);
            this.lblGunlukKayit.TabIndex = 9;
            this.lblGunlukKayit.Text = "Value";
            // 
            // lblGunlukUrun
            // 
            this.lblGunlukUrun.AutoSize = true;
            this.lblGunlukUrun.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGunlukUrun.Location = new System.Drawing.Point(171, 171);
            this.lblGunlukUrun.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGunlukUrun.Name = "lblGunlukUrun";
            this.lblGunlukUrun.Size = new System.Drawing.Size(47, 23);
            this.lblGunlukUrun.TabIndex = 10;
            this.lblGunlukUrun.Text = "Value";
            // 
            // lblAzalanStok
            // 
            this.lblAzalanStok.AutoSize = true;
            this.lblAzalanStok.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAzalanStok.Location = new System.Drawing.Point(206, 188);
            this.lblAzalanStok.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAzalanStok.Name = "lblAzalanStok";
            this.lblAzalanStok.Size = new System.Drawing.Size(0, 23);
            this.lblAzalanStok.TabIndex = 12;
            // 
            // btnGeri
            // 
            this.btnGeri.BackColor = System.Drawing.Color.DarkRed;
            this.btnGeri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeri.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGeri.Location = new System.Drawing.Point(88, 232);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(123, 28);
            this.btnGeri.TabIndex = 13;
            this.btnGeri.Text = "Geri Dön";
            this.btnGeri.UseVisualStyleBackColor = false;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // btnPdfKaydet
            // 
            this.btnPdfKaydet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPdfKaydet.Font = new System.Drawing.Font("Poppins Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPdfKaydet.Location = new System.Drawing.Point(89, 201);
            this.btnPdfKaydet.Name = "btnPdfKaydet";
            this.btnPdfKaydet.Size = new System.Drawing.Size(122, 28);
            this.btnPdfKaydet.TabIndex = 14;
            this.btnPdfKaydet.Text = "PDF Kaydet";
            this.btnPdfKaydet.UseVisualStyleBackColor = true;
            this.btnPdfKaydet.Click += new System.EventHandler(this.btnPdfKaydet_Click);
            // 
            // lblTarihSaat
            // 
            this.lblTarihSaat.AutoSize = true;
            this.lblTarihSaat.Font = new System.Drawing.Font("Poppins Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTarihSaat.Location = new System.Drawing.Point(74, 263);
            this.lblTarihSaat.Name = "lblTarihSaat";
            this.lblTarihSaat.Size = new System.Drawing.Size(55, 23);
            this.lblTarihSaat.TabIndex = 15;
            this.lblTarihSaat.Text = "label7";
            this.lblTarihSaat.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // istatistikForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(293, 295);
            this.Controls.Add(this.lblTarihSaat);
            this.Controls.Add(this.btnPdfKaydet);
            this.Controls.Add(this.btnGeri);
            this.Controls.Add(this.lblAzalanStok);
            this.Controls.Add(this.lblGunlukUrun);
            this.Controls.Add(this.lblGunlukKayit);
            this.Controls.Add(this.lblGunlukKar);
            this.Controls.Add(this.lblGunlukKazanc);
            this.Controls.Add(this.lblGunlukSatis);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "istatistikForm";
            this.Text = "İstatistikler";
            this.Load += new System.EventHandler(this.istatistikForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblGunlukSatis;
        private System.Windows.Forms.Label lblGunlukKazanc;
        private System.Windows.Forms.Label lblGunlukKar;
        private System.Windows.Forms.Label lblGunlukKayit;
        private System.Windows.Forms.Label lblGunlukUrun;
        private System.Windows.Forms.Label lblAzalanStok;
        private System.Windows.Forms.Button btnGeri;
        private System.Windows.Forms.Button btnPdfKaydet;
        private System.Windows.Forms.Label lblTarihSaat;
        private System.Windows.Forms.Timer timer1;
    }
}