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
    public partial class HastaBilgileriControl : UserControl
    {
        private string connectionString = "Server=KOPUZZNISA\\SQLEXPRESS;Database=HastaneVeriTabanıProjesi;Trusted_Connection=True;";

        public HastaBilgileriControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string hastaAdiSoyadi = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(hastaAdiSoyadi))
            {
                MessageBox.Show("Lütfen hasta adını ve soyadını girin.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT Telefon, DogumTarihi, KanGrubu
                        FROM Hastalar
                        WHERE AdSoyad = @HastaAdiSoyadi";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@HastaAdiSoyadi", hastaAdiSoyadi);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        label7.Text = reader["Telefon"].ToString();
                        label8.Text = Convert.ToDateTime(reader["DogumTarihi"]).ToShortDateString();
                        label9.Text = reader["KanGrubu"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Bu isimde bir hasta bulunamadı.");
                        label7.Text = "Telefon: -";
                        label8.Text = "Doğum Tarihi: -";
                        label9.Text = "Kan Grubu: -";
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilgiler görüntülenirken bir hata oluştu: " + ex.Message);
            }
        }

    }
}

