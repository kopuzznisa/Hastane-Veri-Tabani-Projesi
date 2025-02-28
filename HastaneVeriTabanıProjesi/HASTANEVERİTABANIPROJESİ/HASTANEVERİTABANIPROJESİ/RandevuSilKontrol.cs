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
    public partial class RandevuSilKontrol : UserControl
    {
        private string connectionString = "Server=KOPUZZNISA\\SQLEXPRESS;Database=HastaneVeriTabanıProjesi;Trusted_Connection=True;";

        public RandevuSilKontrol()
        {
            InitializeComponent();
        }

        private void RandevuSilKontrol_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string randevuId = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(randevuId))
            {
                MessageBox.Show("Lütfen silmek istediğiniz Randevu ID'sini girin.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Silme sorgusu
                    string deleteQuery = "DELETE FROM Randevular WHERE RandevuId = @RandevuId";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, connection))
                    {
                        deleteCmd.Parameters.AddWithValue("@RandevuId", randevuId);
                        int rowsAffected = deleteCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Randevu başarıyla silindi.");
                        }
                        else
                        {
                            MessageBox.Show("Belirtilen ID'ye sahip bir randevu bulunamadı.");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Teknik detayları loglamak veya geliştirme aşamasında kullanmak için
                Console.WriteLine("Hata Detayı: " + ex.Message);

                // Kullanıcı dostu mesaj
                MessageBox.Show("Silme işlemi sırasında bir hata oluştu. Lütfen tekrar deneyin.");
            }
        }
    }
}
