using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HASTANEVERİTABANIPROJESİ
{
    public partial class RontgenControl : UserControl
    {
        public int HastaID { get; set; }

        private readonly SqlConnection baglanti = new SqlConnection("Server=KOPUZZNISA\\SQLEXPRESS;Database=HastaneVeriTabanıProjesi;Trusted_Connection=True;MultipleActiveResultSets=True;");

        public RontgenControl()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // Görüntünün düzgün bir şekilde ölçeklenmesini sağlar
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Bu durumda, HastaID'yi textBox'tan alabilirsiniz. Fakat burada HastaID, constructor üzerinden aktarılıyor.
            if (HastaID > 0)
            {
                ShowImageByHastaID(HastaID); // HastaID'yi kullanarak resmi göster
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir HastaID giriniz.");
            }
        }

        private void ShowImageByHastaID(int hastaID)
        {
            try
            {
                baglanti.Open();

                // Veritabanından resim sorgulama
                string query = "SELECT images FROM Rontgen WHERE HastaID = @HastaID";
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
                                MessageBox.Show("Resim yüklenirken hata oluştu: " + ex.Message);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu HastaID için resim verisi boş.");
                        pictureBox1.Image = null; // Resmi temizle
                    }
                }
                else
                {
                    MessageBox.Show("Bu HastaID için resim bulunamadı.");
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

        private void RontgenControl_Load(object sender, EventArgs e)
        {
            // Eğer HastaID varsa, röntgen sonuçlarını veritabanından çek
            if (HastaID > 0)
            {
                using (SqlConnection connection = new SqlConnection("Server=KOPUZZNISA\\SQLEXPRESS;Database=HastaneVeriTabanıProjesi;Trusted_Connection=True;MultipleActiveResultSets=True;"))
                {
                    string query = "SELECT * FROM [Rontgen] WHERE HastaID = @HastaID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@HastaID", HastaID);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // Burada veriyi işleyebilirsiniz. Örneğin, image alanını alabilir ve gösterebilirsiniz
                        byte[] imageBytes = reader["images"] as byte[];
                        if (imageBytes != null && imageBytes.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                pictureBox1.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            pictureBox1.Image = null;  // Resim yoksa temizleyin
                        }
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
