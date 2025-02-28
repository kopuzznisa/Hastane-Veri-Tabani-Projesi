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
    public partial class YetkiliDoktor : Form
    {
        public YetkiliDoktor()
        {
            InitializeComponent();
            this.Size = new Size(1400, 791);
        }

        private void YetkiliDoktor_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            YetkiliAnaMenu yetkilianamenu = new YetkiliAnaMenu();
            yetkilianamenu.Show();
            this.Close();
        }

        private void BaglantıDoktorEkle(DoktorEkleControl doktorEkleControl)
        {
            panelContent.Controls.Clear();
            doktorEkleControl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(doktorEkleControl);
        }

        private void DoktorEkle_Click(object sender, EventArgs e)
        {
            var doktorEkleControl = new DoktorEkleControl();
            BaglantıDoktorEkle(doktorEkleControl);
        }

        private void BaglantıDoktorBilgileri(DoktorBilgileriControl doktorBilgileriControl)
        {
            panelContent.Controls.Clear();
            doktorBilgileriControl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(doktorBilgileriControl);
        }
        private void DoktorBilgileri_Click(object sender, EventArgs e)
        {
            var doktorBilgileriControl = new DoktorBilgileriControl();
            BaglantıDoktorBilgileri(doktorBilgileriControl);
        }

        private void BaglantıDoktorGuncelle(DoktorGuncelleControl doktorGuncelleControl)
        {
            panelContent.Controls.Clear();
            doktorGuncelleControl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(doktorGuncelleControl);
        }
        private void DoktorGuncelle_Click(object sender, EventArgs e)
        {
            var doktorGuncelleControl = new DoktorGuncelleControl();
            BaglantıDoktorGuncelle(doktorGuncelleControl);
        }

        private void BaglantıDoktorSil(DoktorSilControl doktorSilControl)
        {
            panelContent.Controls.Clear();
            doktorSilControl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(doktorSilControl);
        }
        private void DoktorSil_Click(object sender, EventArgs e)
        {
            var doktorSilControl = new DoktorSilControl();
            BaglantıDoktorSil(doktorSilControl);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            YetkiliAnaMenu yetkilianamenu = new YetkiliAnaMenu();
            yetkilianamenu.Show();
            this.Close();
        }
    }
}
