﻿using System;
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
    public partial class YetkiliAnaMenu : Form
    {
        public YetkiliAnaMenu()
        {
            InitializeComponent();
            this.Size = new Size(1400, 791);
        }

        private void YetkiliAnaMenu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa();
            anaSayfa.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            YetkiliDoktor yetkilidoktor = new YetkiliDoktor();
            yetkilidoktor.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            YetkiliHasta yetkilihasta = new YetkiliHasta();
            yetkilihasta.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa();
            anaSayfa.Show();
            this.Close();
        }
    }
}
