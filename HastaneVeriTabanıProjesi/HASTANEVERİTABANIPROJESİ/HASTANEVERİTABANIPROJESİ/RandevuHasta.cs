using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HASTANEVERİTABANIPROJESİ
{
    public partial class RandevuHasta : Form
    {
        public RandevuHasta()
        {
            InitializeComponent();
            this.Size = new Size(1400, 791);
        }
        private void RandevuHasta_Load(object sender, EventArgs e)
        {

        }
        private void BaglantıHastaEkle(RandevuEkleControl randevuEkleControl)
        {
            panelContent.Controls.Clear();
            randevuEkleControl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(randevuEkleControl);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            HastaAnaMenu hastaanamenu = new HastaAnaMenu();
            hastaanamenu.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var randevuEkleControl = new RandevuEkleControl();
            BaglantıHastaEkle(randevuEkleControl);
        }

        private void BaglantıHastaGoruntule(RandevuGoruntuleKontrol randevuGoruntuleKontrol)
        {
            panelContent.Controls.Clear();
            randevuGoruntuleKontrol.Dock = DockStyle.Fill;
            panelContent.Controls.Add(randevuGoruntuleKontrol);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            var randevuGoruntuleKontrol = new RandevuGoruntuleKontrol();
            BaglantıHastaGoruntule(randevuGoruntuleKontrol);
        }
        private void BaglantıHastaGuncelle(RandevuGuncelleKontrol randevuGuncelleKontrol)
        {
            panelContent.Controls.Clear();
            randevuGuncelleKontrol.Dock = DockStyle.Fill;
            panelContent.Controls.Add(randevuGuncelleKontrol);
        }
        private void RandevuGuncelle_Click(object sender, EventArgs e)
        {
            var randevuGuncelleKontrol = new RandevuGuncelleKontrol();
            BaglantıHastaGuncelle(randevuGuncelleKontrol);
        }

        private void BaglantıHastaSil(RandevuSilKontrol randevuSilKontrol)
        {
            panelContent.Controls.Clear();
            randevuSilKontrol.Dock = DockStyle.Fill;
            panelContent.Controls.Add(randevuSilKontrol);
        }
        private void RandevuSil_Click(object sender, EventArgs e)
        {
            var randevuSilKontrol = new RandevuSilKontrol();
            BaglantıHastaSil(randevuSilKontrol);
        }

        private void geri_Click(object sender, EventArgs e)
        {
            HastaAnaMenu hastaanamenu = new HastaAnaMenu();
            hastaanamenu.Show();
            this.Close();
        }
    }
}
