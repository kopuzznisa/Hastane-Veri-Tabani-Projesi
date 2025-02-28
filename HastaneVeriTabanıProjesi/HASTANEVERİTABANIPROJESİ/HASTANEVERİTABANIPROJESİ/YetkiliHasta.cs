using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HASTANEVERİTABANIPROJESİ
{
    public partial class YetkiliHasta : Form
    {
        public YetkiliHasta()
        {
            InitializeComponent();
            this.Size = new Size(1400, 791);
        }

        private void YektkiliHasta_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            YetkiliAnaMenu yetkilianamenu = new YetkiliAnaMenu();
            yetkilianamenu.Show();
            this.Close();
        }
        private void BaglantıHastaKaydı(HastaKaydıControl hastaKaydıControl)
        {
            panelContent.Controls.Clear();
            hastaKaydıControl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(hastaKaydıControl);
        }
        private void HastaEkle_Click(object sender, EventArgs e)
        {
            var hastaKaydıControl = new HastaKaydıControl();
            BaglantıHastaKaydı(hastaKaydıControl);
        }

        private void BaglantıHastaBilgileri(HastaBilgileriControl hastaBilgileriControl)
        {
            panelContent.Controls.Clear();
            hastaBilgileriControl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(hastaBilgileriControl);
        }

        private void HastaGoruntule_Click(object sender, EventArgs e)
        {
            var hastaBilgileriControl = new HastaBilgileriControl();
            BaglantıHastaBilgileri(hastaBilgileriControl);
        }
        private void BaglantıHastaGuncelle(HastaGuncelleControl hastaGuncelleControl)
        {
            panelContent.Controls.Clear();
            hastaGuncelleControl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(hastaGuncelleControl);
        }
        private void HastaGuncelle_Click(object sender, EventArgs e)
        {
            var hastaGuncelleControl = new HastaGuncelleControl();
            BaglantıHastaGuncelle(hastaGuncelleControl);

        }
        private void BaglantıHastaSil(HastaSilControl hastaSilControl)
        {
            panelContent.Controls.Clear();
            hastaSilControl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(hastaSilControl);
        }
        private void HastaSil_Click(object sender, EventArgs e)
        {
            var hastaSilControl = new HastaSilControl();
            BaglantıHastaSil(hastaSilControl);

        }
        private void BaglantıHastaSayisi(GünlükHastaSayisiControl günlükHastaSayisiControl)
        {
            panelContent.Controls.Clear();
            günlükHastaSayisiControl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(günlükHastaSayisiControl);
        }
        private void GunlukHasta_Click(object sender, EventArgs e)
        {
            var günlükHastaSayisiControl = new GünlükHastaSayisiControl();
            BaglantıHastaSayisi(günlükHastaSayisiControl);
        }
    }
}
