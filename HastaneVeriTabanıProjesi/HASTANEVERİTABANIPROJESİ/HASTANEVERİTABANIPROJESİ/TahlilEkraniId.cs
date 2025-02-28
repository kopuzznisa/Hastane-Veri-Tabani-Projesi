using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HASTANEVERİTABANIPROJESİ
{
    public partial class TahlilEkraniId : Form
    {
        private string connectionString = "Server=KOPUZZNISA\\SQLEXPRESS;Database=HastaneVeriTabanıProjesi;Trusted_Connection=True;MultipleActiveResultSets=True;";

        public TahlilEkraniId()
        {
            InitializeComponent();
            this.Size = new Size(1400, 791);
        }

        private void TahlilEkraniId_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string hastaId = textBox1.Text;

            if (!string.IsNullOrWhiteSpace(hastaId) && int.TryParse(hastaId, out int parsedHastaID))
            {
                // RontgenControl oluştur ve HastaID'yi ata
                RontgenControl rontgenControl = new RontgenControl
                {
                    HastaID = parsedHastaID // Hasta ID'yi aktarıyoruz
                };

                // TomografiControl oluştur ve HastaID'yi ata
                TomografiControl tomografiControl = new TomografiControl
                {
                    HastaID = parsedHastaID // Hasta ID'yi aktarıyoruz
                };


                // TahlilHasta formuna HastaID'yi gönderiyoruz
                TahlilHasta tahlilhasta = new TahlilHasta(parsedHastaID);
                tahlilhasta.Show();
                this.Hide();



                //panel1.Controls.Clear();  // Önceki kontrolü temizle
                //panel1.Controls.Add(rontgenControl); // Yeni kontrolü ekle
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir Hasta ID giriniz.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HastaAnaMenu hastaanamenu = new HastaAnaMenu();
            hastaanamenu.Show();
            this.Close();
        }
    }
}
