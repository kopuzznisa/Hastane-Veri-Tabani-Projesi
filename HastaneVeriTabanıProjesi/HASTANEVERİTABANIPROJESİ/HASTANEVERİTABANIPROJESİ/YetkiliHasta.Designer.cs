namespace HASTANEVERİTABANIPROJESİ
{
    partial class YetkiliHasta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YetkiliHasta));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.GunlukHasta = new System.Windows.Forms.Button();
            this.HastaSil = new System.Windows.Forms.Button();
            this.HastaGuncelle = new System.Windows.Forms.Button();
            this.HastaGoruntule = new System.Windows.Forms.Button();
            this.HastaEkle = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::HASTANEVERİTABANIPROJESİ.Properties.Resources.geri1;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(32, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 92);
            this.button1.TabIndex = 0;
            this.button1.Text = "geri";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.UseWaitCursor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(258, 342);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hasta İşlemleri";
            // 
            // GunlukHasta
            // 
            this.GunlukHasta.BackColor = System.Drawing.Color.SeaShell;
            this.GunlukHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.GunlukHasta.Location = new System.Drawing.Point(263, 684);
            this.GunlukHasta.Name = "GunlukHasta";
            this.GunlukHasta.Size = new System.Drawing.Size(271, 35);
            this.GunlukHasta.TabIndex = 3;
            this.GunlukHasta.Text = "Günlük Hasta Sayısı";
            this.GunlukHasta.UseVisualStyleBackColor = false;
            this.GunlukHasta.Click += new System.EventHandler(this.GunlukHasta_Click);
            // 
            // HastaSil
            // 
            this.HastaSil.BackColor = System.Drawing.Color.SeaShell;
            this.HastaSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.HastaSil.Location = new System.Drawing.Point(263, 616);
            this.HastaSil.Name = "HastaSil";
            this.HastaSil.Size = new System.Drawing.Size(271, 35);
            this.HastaSil.TabIndex = 4;
            this.HastaSil.Text = "Hasta Kaydı Sil";
            this.HastaSil.UseVisualStyleBackColor = false;
            this.HastaSil.Click += new System.EventHandler(this.HastaSil_Click);
            // 
            // HastaGuncelle
            // 
            this.HastaGuncelle.BackColor = System.Drawing.Color.SeaShell;
            this.HastaGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.HastaGuncelle.Location = new System.Drawing.Point(263, 549);
            this.HastaGuncelle.Name = "HastaGuncelle";
            this.HastaGuncelle.Size = new System.Drawing.Size(271, 35);
            this.HastaGuncelle.TabIndex = 5;
            this.HastaGuncelle.Text = "Hasta Bilgileri Güncelle";
            this.HastaGuncelle.UseVisualStyleBackColor = false;
            this.HastaGuncelle.Click += new System.EventHandler(this.HastaGuncelle_Click);
            // 
            // HastaGoruntule
            // 
            this.HastaGoruntule.BackColor = System.Drawing.Color.SeaShell;
            this.HastaGoruntule.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.HastaGoruntule.Location = new System.Drawing.Point(263, 476);
            this.HastaGoruntule.Name = "HastaGoruntule";
            this.HastaGoruntule.Size = new System.Drawing.Size(271, 35);
            this.HastaGoruntule.TabIndex = 6;
            this.HastaGoruntule.Text = "Hasta Bilgileri Görüntüle";
            this.HastaGoruntule.UseVisualStyleBackColor = false;
            this.HastaGoruntule.Click += new System.EventHandler(this.HastaGoruntule_Click);
            // 
            // HastaEkle
            // 
            this.HastaEkle.BackColor = System.Drawing.Color.SeaShell;
            this.HastaEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.HastaEkle.Location = new System.Drawing.Point(263, 407);
            this.HastaEkle.Name = "HastaEkle";
            this.HastaEkle.Size = new System.Drawing.Size(271, 35);
            this.HastaEkle.TabIndex = 7;
            this.HastaEkle.Text = "Hasta Kaydı Ekle";
            this.HastaEkle.UseVisualStyleBackColor = false;
            this.HastaEkle.Click += new System.EventHandler(this.HastaEkle_Click);
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.Transparent;
            this.panelContent.Location = new System.Drawing.Point(832, 331);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(524, 426);
            this.panelContent.TabIndex = 8;
            // 
            // YetkiliHasta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1382, 744);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.HastaEkle);
            this.Controls.Add(this.HastaGoruntule);
            this.Controls.Add(this.HastaGuncelle);
            this.Controls.Add(this.HastaSil);
            this.Controls.Add(this.GunlukHasta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "YetkiliHasta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YetkiliHasta";
            this.Load += new System.EventHandler(this.YektkiliHasta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button GunlukHasta;
        private System.Windows.Forms.Button HastaSil;
        private System.Windows.Forms.Button HastaGuncelle;
        private System.Windows.Forms.Button HastaGoruntule;
        private System.Windows.Forms.Button HastaEkle;
        private System.Windows.Forms.Panel panelContent;
    }
}