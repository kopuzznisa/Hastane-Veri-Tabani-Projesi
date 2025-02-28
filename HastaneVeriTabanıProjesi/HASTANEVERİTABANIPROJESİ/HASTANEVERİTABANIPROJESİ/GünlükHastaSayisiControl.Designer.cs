namespace HASTANEVERİTABANIPROJESİ
{
    partial class GünlükHastaSayisiControl
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.hastaneVeriTabanıProjesiDataSet = new HASTANEVERİTABANIPROJESİ.HastaneVeriTabanıProjesiDataSet();
            this.randevularBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.randevularTableAdapter = new HASTANEVERİTABANIPROJESİ.HastaneVeriTabanıProjesiDataSetTableAdapters.RandevularTableAdapter();
            this.fKIlacSikayet70DDC3D8BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ilacTableAdapter = new HASTANEVERİTABANIPROJESİ.HastaneVeriTabanıProjesiDataSetTableAdapters.IlacTableAdapter();
            this.fKTahlilRandevuT6B24EA82BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tahlilTableAdapter = new HASTANEVERİTABANIPROJESİ.HastaneVeriTabanıProjesiDataSetTableAdapters.TahlilTableAdapter();
            this.hastaneVeriTabanıProjesiDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.randevularBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.hastalarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hastalarTableAdapter = new HASTANEVERİTABANIPROJESİ.HastaneVeriTabanıProjesiDataSetTableAdapters.HastalarTableAdapter();
            this.randevularBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.hastaneVeriTabanıProjesiDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.randevularBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKIlacSikayet70DDC3D8BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKTahlilRandevuT6B24EA82BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hastaneVeriTabanıProjesiDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.randevularBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hastalarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.randevularBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(41, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Günlük Hasta Sayısı Görüntüle";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(210, 79);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(42, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Randevu Tarihi";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SeaShell;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(46, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(364, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "Görüntüle";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // hastaneVeriTabanıProjesiDataSet
            // 
            this.hastaneVeriTabanıProjesiDataSet.DataSetName = "HastaneVeriTabanıProjesiDataSet";
            this.hastaneVeriTabanıProjesiDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // randevularBindingSource
            // 
            this.randevularBindingSource.DataMember = "Randevular";
            this.randevularBindingSource.DataSource = this.hastaneVeriTabanıProjesiDataSet;
            // 
            // randevularTableAdapter
            // 
            this.randevularTableAdapter.ClearBeforeFill = true;
            // 
            // fKIlacSikayet70DDC3D8BindingSource
            // 
            this.fKIlacSikayet70DDC3D8BindingSource.DataMember = "FK__Ilac__Sikayet__70DDC3D8";
            this.fKIlacSikayet70DDC3D8BindingSource.DataSource = this.randevularBindingSource;
            // 
            // ilacTableAdapter
            // 
            this.ilacTableAdapter.ClearBeforeFill = true;
            // 
            // fKTahlilRandevuT6B24EA82BindingSource
            // 
            this.fKTahlilRandevuT6B24EA82BindingSource.DataMember = "FK__Tahlil__RandevuT__6B24EA82";
            this.fKTahlilRandevuT6B24EA82BindingSource.DataSource = this.randevularBindingSource;
            // 
            // tahlilTableAdapter
            // 
            this.tahlilTableAdapter.ClearBeforeFill = true;
            // 
            // hastaneVeriTabanıProjesiDataSetBindingSource
            // 
            this.hastaneVeriTabanıProjesiDataSetBindingSource.DataSource = this.hastaneVeriTabanıProjesiDataSet;
            this.hastaneVeriTabanıProjesiDataSetBindingSource.Position = 0;
            // 
            // randevularBindingSource1
            // 
            this.randevularBindingSource1.DataMember = "Randevular";
            this.randevularBindingSource1.DataSource = this.hastaneVeriTabanıProjesiDataSetBindingSource;
            // 
            // hastalarBindingSource
            // 
            this.hastalarBindingSource.DataMember = "Hastalar";
            this.hastalarBindingSource.DataSource = this.hastaneVeriTabanıProjesiDataSetBindingSource;
            // 
            // hastalarTableAdapter
            // 
            this.hastalarTableAdapter.ClearBeforeFill = true;
            // 
            // randevularBindingSource2
            // 
            this.randevularBindingSource2.DataMember = "Randevular";
            this.randevularBindingSource2.DataSource = this.hastaneVeriTabanıProjesiDataSetBindingSource;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 170);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1077, 412);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // GünlükHastaSayisiControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Name = "GünlükHastaSayisiControl";
            this.Size = new System.Drawing.Size(1155, 610);
            this.Load += new System.EventHandler(this.GünlükHastaSayisiControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hastaneVeriTabanıProjesiDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.randevularBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKIlacSikayet70DDC3D8BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKTahlilRandevuT6B24EA82BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hastaneVeriTabanıProjesiDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.randevularBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hastalarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.randevularBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource randevularBindingSource;
        private HastaneVeriTabanıProjesiDataSet hastaneVeriTabanıProjesiDataSet;
        private HastaneVeriTabanıProjesiDataSetTableAdapters.RandevularTableAdapter randevularTableAdapter;
        private System.Windows.Forms.BindingSource fKIlacSikayet70DDC3D8BindingSource;
        private HastaneVeriTabanıProjesiDataSetTableAdapters.IlacTableAdapter ilacTableAdapter;
        private System.Windows.Forms.BindingSource fKTahlilRandevuT6B24EA82BindingSource;
        private HastaneVeriTabanıProjesiDataSetTableAdapters.TahlilTableAdapter tahlilTableAdapter;
        private System.Windows.Forms.BindingSource hastaneVeriTabanıProjesiDataSetBindingSource;
        private System.Windows.Forms.BindingSource randevularBindingSource1;
        private System.Windows.Forms.BindingSource hastalarBindingSource;
        private HastaneVeriTabanıProjesiDataSetTableAdapters.HastalarTableAdapter hastalarTableAdapter;
        private System.Windows.Forms.BindingSource randevularBindingSource2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
