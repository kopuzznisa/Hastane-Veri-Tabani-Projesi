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
    public partial class RandevuGoruntuleKontrol : UserControl
    {
        private string connectionString = "Server=KOPUZZNISA\\SQLEXPRESS;Database=HastaneVeriTabanıProjesi;Trusted_Connection=True;";

        public RandevuGoruntuleKontrol()
        {
            InitializeComponent();
        }

        private void RandevuGoruntuleKontrol_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string HastaID = textBox1.Text;

            if (string.IsNullOrEmpty(HastaID))
            {
                MessageBox.Show("Lütfen bir Hasta ID giriniz.");
                return;
            }

            try
            {
                // Veritabanı bağlantısı (connection string'i uygun şekilde düzenleyin)
                string connectionString = "Server=KOPUZZNISA\\SQLEXPRESS;Database=HastaneVeriTabanıProjesi;Trusted_Connection=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // SQL sorgusu: HastaID'ye göre randevu bilgilerini al
                    string query = @"
                        SELECT d.AdSoyad, r.RandevuTarihi, r.Sikayet
                        FROM Randevular r
                        JOIN Doktorlar d ON r.DoktorID = d.DoktorID
                        WHERE r.HastaID = @HastaID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@HastaID", HastaID);

                        // Veritabanından dönen verileri al
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            // Doktor adı, randevu tarihi, şikayeti al ve etiketlere yaz
                            label3.Text = "" + reader["AdSoyad"].ToString();
                            label5.Text = "" + Convert.ToDateTime(reader["RandevuTarihi"]).ToString("yyyy-MM-dd HH:mm");
                            label7.Text = "" + reader["Sikayet"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Bu Hasta ID'ye ait bir randevu bulunamadı.");
                        }

                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}
