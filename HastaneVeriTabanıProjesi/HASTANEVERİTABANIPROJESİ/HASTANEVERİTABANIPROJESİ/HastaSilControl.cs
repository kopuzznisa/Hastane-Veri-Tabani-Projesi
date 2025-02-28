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
    public partial class HastaSilControl : UserControl
    {
        private string connectionString = "Server=KOPUZZNISA\\SQLEXPRESS;Database=HastaneVeriTabanıProjesi;Trusted_Connection=True;";

        public HastaSilControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string hastaAdiSoyadi = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(hastaAdiSoyadi))
            {
                MessageBox.Show("Lütfen silmek istediğiniz hastanın ad ve soyadını giriniz.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM Hastalar WHERE AdSoyad = @HastaAdiSoyadi";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@HastaAdiSoyadi", hastaAdiSoyadi);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Hasta kaydı başarıyla silindi.");
                        }
                        else
                        {
                            MessageBox.Show("Bu isimde bir hasta bulunamadı.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }

            textBox1.Clear();
        }
    }
    }

