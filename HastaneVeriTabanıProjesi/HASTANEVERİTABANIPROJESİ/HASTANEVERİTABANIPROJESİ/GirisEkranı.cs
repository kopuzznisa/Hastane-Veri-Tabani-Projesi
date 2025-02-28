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
    public partial class GirisEkranı : Form
    {
        private string connectionString = "Server=KOPUZZNISA\\SQLEXPRESS;Database=HastaneVeriTabanıProjesi;Trusted_Connection=True;";

        public GirisEkranı()
        {
            InitializeComponent();
            this.Size = new Size(1400, 791);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa();
            anaSayfa.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa();
            anaSayfa.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tcNo = textBox7.Text.Trim();
            string adSoyad = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(tcNo) || string.IsNullOrEmpty(adSoyad))
            {
                MessageBox.Show("Lütfen TC No ve Ad Soyad bilgilerini eksiksiz giriniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "SELECT COUNT(*) FROM Hastalar WHERE AdSoyad = @AdSoyad AND HastaID = @TcNo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AdSoyad", adSoyad);
                        command.Parameters.AddWithValue("@TcNo", tcNo);

                        int count = (int)command.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Giriş başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            HastaAnaMenu hastaAnaMenu = new HastaAnaMenu();
                            hastaAnaMenu.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Girdiğiniz bilgilerle eşleşen bir hasta bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa();
            anaSayfa.Show();
            this.Close();
        }
    }
}
