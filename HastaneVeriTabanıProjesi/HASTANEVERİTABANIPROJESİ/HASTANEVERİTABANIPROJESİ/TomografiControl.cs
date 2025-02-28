using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HASTANEVERİTABANIPROJESİ
{
    public partial class TomografiControl : UserControl
    {
        // HastaID'yi dışarıdan alabilmek için property ekliyoruz
        public int HastaID { get; set; }

        private readonly SqlConnection baglanti = new SqlConnection("Server=KOPUZZNISA\\SQLEXPRESS;Database=HastaneVeriTabanıProjesi;Trusted_Connection=True;MultipleActiveResultSets=True;");

        public TomografiControl()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // Görüntünün düzgün bir şekilde ölçeklenmesini sağlar
        }

        private void TomografiControl_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde, HastaID varsa, tomografi resmini göster
            if (HastaID > 0)
            {
                ShowTomografiByHastaID(HastaID);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void ShowTomografiByHastaID(int hastaID)
        {
            try
            {
                baglanti.Open();

                // Veritabanından tomografi resmini sorgulama
                string query = "SELECT images FROM Tomografi WHERE HastaID = @HastaID";
                SqlCommand komut = new SqlCommand(query, baglanti);
                komut.Parameters.AddWithValue("@HastaID", hastaID);

                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read() && dr["images"] != DBNull.Value) // Resim var mı kontrol et
                {
                    byte[] resim = (byte[])dr["images"];

                    // Resim verisini kontrol et
                    if (resim.Length > 0)
                    {
                        using (MemoryStream memoryStream = new MemoryStream(resim))
                        {
                            try
                            {
                                pictureBox1.Image = Image.FromStream(memoryStream); // Resmi göster
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Tomografi resmi yüklenirken hata oluştu: " + ex.Message);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu HastaID için tomografi verisi boş.");
                        pictureBox1.Image = null; // Resmi temizle
                    }
                }
                else
                {
                    MessageBox.Show("Bu HastaID için tomografi resmi bulunamadı.");
                    pictureBox1.Image = null; // Resmi temizle
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message); // Hata mesajını göster
            }
            finally
            {
                baglanti.Close();
            }
        }
    }
}
