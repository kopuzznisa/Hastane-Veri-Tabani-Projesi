namespace HASTANEVERİTABANIPROJESİ
{
    partial class RandevuHasta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RandevuHasta));
            this.label1 = new System.Windows.Forms.Label();
            this.randevuEkle = new System.Windows.Forms.Button();
            this.RandevuSil = new System.Windows.Forms.Button();
            this.RandevuGuncelle = new System.Windows.Forms.Button();
            this.randevuGoruntule = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.geri = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(246, 346);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Randevu İşlemleri";
            // 
            // randevuEkle
            // 
            this.randevuEkle.BackColor = System.Drawing.Color.SeaShell;
            this.randevuEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.randevuEkle.Location = new System.Drawing.Point(251, 419);
            this.randevuEkle.Name = "randevuEkle";
            this.randevuEkle.Size = new System.Drawing.Size(214, 35);
            this.randevuEkle.TabIndex = 2;
            this.randevuEkle.Text = "Randevu Ekle";
            this.randevuEkle.UseVisualStyleBackColor = false;
            this.randevuEkle.Click += new System.EventHandler(this.button2_Click);
            // 
            // RandevuSil
            // 
            this.RandevuSil.BackColor = System.Drawing.Color.SeaShell;
            this.RandevuSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.RandevuSil.Location = new System.Drawing.Point(251, 643);
            this.RandevuSil.Name = "RandevuSil";
            this.RandevuSil.Size = new System.Drawing.Size(214, 35);
            this.RandevuSil.TabIndex = 3;
            this.RandevuSil.Text = "Randevu Sil";
            this.RandevuSil.UseVisualStyleBackColor = false;
            this.RandevuSil.Click += new System.EventHandler(this.RandevuSil_Click);
            // 
            // RandevuGuncelle
            // 
            this.RandevuGuncelle.BackColor = System.Drawing.Color.SeaShell;
            this.RandevuGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.RandevuGuncelle.Location = new System.Drawing.Point(251, 569);
            this.RandevuGuncelle.Name = "RandevuGuncelle";
            this.RandevuGuncelle.Size = new System.Drawing.Size(214, 35);
            this.RandevuGuncelle.TabIndex = 4;
            this.RandevuGuncelle.Text = "Randevu Güncelle";
            this.RandevuGuncelle.UseVisualStyleBackColor = false;
            this.RandevuGuncelle.Click += new System.EventHandler(this.RandevuGuncelle_Click);
            // 
            // randevuGoruntule
            // 
            this.randevuGoruntule.BackColor = System.Drawing.Color.SeaShell;
            this.randevuGoruntule.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.randevuGoruntule.Location = new System.Drawing.Point(251, 497);
            this.randevuGoruntule.Name = "randevuGoruntule";
            this.randevuGoruntule.Size = new System.Drawing.Size(214, 35);
            this.randevuGoruntule.TabIndex = 5;
            this.randevuGoruntule.Text = "Randevu Görüntüle";
            this.randevuGoruntule.UseVisualStyleBackColor = false;
            this.randevuGoruntule.Click += new System.EventHandler(this.button5_Click);
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.Transparent;
            this.panelContent.Location = new System.Drawing.Point(765, 301);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(720, 538);
            this.panelContent.TabIndex = 6;
            // 
            // geri
            // 
            this.geri.BackgroundImage = global::HASTANEVERİTABANIPROJESİ.Properties.Resources.geri1;
            this.geri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.geri.FlatAppearance.BorderSize = 0;
            this.geri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.geri.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.geri.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.geri.Location = new System.Drawing.Point(38, 24);
            this.geri.Name = "geri";
            this.geri.Size = new System.Drawing.Size(151, 92);
            this.geri.TabIndex = 14;
            this.geri.Text = "geri";
            this.geri.UseVisualStyleBackColor = true;
            this.geri.UseWaitCursor = true;
            this.geri.Click += new System.EventHandler(this.geri_Click);
            // 
            // RandevuHasta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1382, 744);
            this.Controls.Add(this.geri);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.randevuGoruntule);
            this.Controls.Add(this.RandevuGuncelle);
            this.Controls.Add(this.RandevuSil);
            this.Controls.Add(this.randevuEkle);
            this.Controls.Add(this.label1);
            this.Name = "RandevuHasta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RandevuHasta";
            this.Load += new System.EventHandler(this.RandevuHasta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button randevuEkle;
        private System.Windows.Forms.Button RandevuSil;
        private System.Windows.Forms.Button RandevuGuncelle;
        private System.Windows.Forms.Button randevuGoruntule;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button geri;
    }
}