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
    public partial class RandevuGuncelleKontrol : UserControl
    {
        private string connectionString = "Server=KOPUZZNISA\\SQLEXPRESS;Database=HastaneVeriTabanıProjesi;Trusted_Connection=True;";

        public RandevuGuncelleKontrol()
        {
            InitializeComponent();
        }

        private void RandevuGuncelleKontrol_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kullanıcıdan alınan RandevuID ve tarih bilgileri
            string randevuId = textBox2.Text.Trim(); // RandevuID alınır
            DateTime selectedDate = dateTimePicker1.Value.Date; // Yeni tarih alınır

            if (string.IsNullOrEmpty(randevuId))
            {
                MessageBox.Show("Lütfen Randevu ID'sini girin.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Randevu tarihini güncelleyen sorgu
                    string query = @"
                        UPDATE Randevular
                        SET RandevuTarihi = @RandevuTarihi
                        WHERE RandevuID = @RandevuID";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@RandevuTarihi", selectedDate);
                    command.Parameters.AddWithValue("@RandevuID", randevuId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Randevu tarihi başarıyla güncellendi.");
                    }
                    else
                    {
                        MessageBox.Show("Belirtilen RandevuID bulunamadı.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Randevu güncellenirken hata oluştu: " + ex.Message);
            }
        }
    }
}
