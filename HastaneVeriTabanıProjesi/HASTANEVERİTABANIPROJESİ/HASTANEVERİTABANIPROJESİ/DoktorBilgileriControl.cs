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
    public partial class DoktorBilgileriControl : UserControl
    {
        private string connectionString = "Server=KOPUZZNISA\\SQLEXPRESS;Database=HastaneVeriTabanıProjesi;Trusted_Connection=True;";
        public DoktorBilgileriControl()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string doktorAdiSoyadi = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(doktorAdiSoyadi))
            {
                MessageBox.Show("Lütfen doktor adını ve soyadını girin.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT UzmanlikAlani, Maas, Eposta, Telefon
                        FROM Doktorlar
                        WHERE AdSoyad = @DoktorAdiSoyadi";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@DoktorAdiSoyadi", doktorAdiSoyadi);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        label13.Text = reader["Telefon"].ToString();
                        label12.Text = reader["Eposta"].ToString();
                        label10.Text = reader["Maas"].ToString();
                        label9.Text = reader["UzmanlikAlani"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Bu isimde bir doktor bulunamadı.");
                        label13.Text = "Telefon: -";
                        label12.Text = "Eposta: -";
                        label10.Text = "Maaş: -";
                        label9.Text = "Uzmanlık Alanı: -";
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilgiler görüntülenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void DoktorBilgileriControl_Load(object sender, EventArgs e)
        {

        }
    }
}
