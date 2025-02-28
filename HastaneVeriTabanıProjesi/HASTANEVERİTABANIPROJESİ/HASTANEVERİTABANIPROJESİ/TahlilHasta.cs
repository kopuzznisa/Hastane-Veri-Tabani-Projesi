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
using System.Reflection.Emit;

namespace HASTANEVERİTABANIPROJESİ
{
    public partial class TahlilHasta : Form
    {
        private string connectionString = "Server=KOPUZZNISA\\SQLEXPRESS;Database=HastaneVeriTabanıProjesi;Trusted_Connection=True;MultipleActiveResultSets=True;";

        private int HastaID;
        public TahlilHasta(int hastaId)
        {
            InitializeComponent();
            this.Size = new Size(1400, 791);
            this.HastaID = hastaId; // Hasta ID'yi saklar
        }

        private void TahlilHasta_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HastaAnaMenu hastaanamenu = new HastaAnaMenu();
            hastaanamenu.Show();
            this.Close();
        }

        // RöntgenControl'e HastaID'yi aktarma
        private void BaglantıTahlilMR(RontgenControl mrControl)
        {
            panelContent.Controls.Clear();
            mrControl.HastaID = HastaID; // HastaID'yi atıyoruz
            mrControl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(mrControl);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var mrControl = new RontgenControl();
            BaglantıTahlilMR(mrControl);
        }

        // TomografiControl'e HastaID'yi aktarma
        private void BaglantıTahlilTomografi(TomografiControl tomografiControl)
        {
            panelContent.Controls.Clear();
            tomografiControl.HastaID = HastaID; // HastaID'yi atıyoruz
            tomografiControl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(tomografiControl);
        }

        private void tomografiSonuc_Click(object sender, EventArgs e)
        {
            var tomografiControl = new TomografiControl();
            BaglantıTahlilTomografi(tomografiControl);
        }

        // TahlilControl'e HastaID'yi aktarma
        private void BaglantıTahlil(TahlilControl tahlilControl)
        {
            panelContent.Controls.Clear();
            tahlilControl.HastaID = HastaID; // HastaID'yi atıyoruz
            tahlilControl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(tahlilControl);
        }

        private void tahlilSonuc_Click(object sender, EventArgs e)
        {
            var tahlilControl = new TahlilControl();
            BaglantıTahlil(tahlilControl);
        }

        // İlacControl'e HastaID'yi aktarma
        private void BaglantıTahlilİlac(İlacControl ilacControl)
        {
            panelContent.Controls.Clear();
            ilacControl.HastaID = HastaID; // HastaID'yi atıyoruz
            ilacControl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(ilacControl);
        }

        private void ilac_Click(object sender, EventArgs e)
        {
            var ilacControl = new İlacControl();
            BaglantıTahlilİlac(ilacControl);
        }

        // FaturaControl'e HastaID'yi aktarma
        private void BaglantıTahlilFatura(FaturaControl faturaControl)
        {
            panelContent.Controls.Clear();
            faturaControl.HastaID = HastaID; // HastaID'yi atıyoruz
            faturaControl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(faturaControl);
        }

        private void Fatura_Click(object sender, EventArgs e)
        {
            var faturaControl = new FaturaControl();
            BaglantıTahlilFatura(faturaControl);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            HastaAnaMenu hastaanamenu = new HastaAnaMenu();
            hastaanamenu.Show();
            this.Close();
        }
    }
}
