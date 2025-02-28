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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HASTANEVERİTABANIPROJESİ
{
    public partial class DoktorEkleControl : UserControl
    {
        private string connectionString = "Server=KOPUZZNISA\\SQLEXPRESS;Database=HastaneVeriTabanıProjesi;Trusted_Connection=True;";

        public DoktorEkleControl()
        {
            InitializeComponent();
            LoadUzmanlikAlanlari();
        }

        private void LoadUzmanlikAlanlari()
        {
            // Uzmanlık alanlarını comboboxa ekleme, eğer zaten ekliyse bir daha ekleme
            if (comboBox1.Items.Count == 0)
            {
                comboBox1.Items.Add("Kardiyoloji");
                comboBox1.Items.Add("Diş Hekimliği");
                comboBox1.Items.Add("Çocuk Sağlığı");
                comboBox1.Items.Add("Psikiyatri");
                comboBox1.Items.Add("Kadın Doğum ve Bebek");
                comboBox1.Items.Add("Genel Cerrahi");
                comboBox1.Items.Add("Göz Hastalıkları");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string adSoyad = textBox1.Text.Trim();
            string uzmanlikAlani = comboBox1.SelectedItem?.ToString();
            string maas = textBox2.Text.Trim();
            string telefon = textBox3.Text.Trim();
            string eposta = textBox5.Text.Trim();

            if (string.IsNullOrEmpty(adSoyad) || string.IsNullOrEmpty(uzmanlikAlani) ||
                string.IsNullOrEmpty(telefon) || string.IsNullOrEmpty(eposta))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            if (telefon.Length > 20)
            {
                MessageBox.Show("Telefon numarası en fazla 20 karakter olabilir.");
                return;
            }

            if (eposta.Length > 100)
            {
                MessageBox.Show("E-posta en fazla 100 karakter olabilir.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                INSERT INTO Doktorlar (AdSoyad, UzmanlikAlani, Maas, Telefon, Eposta) 
                VALUES (@AdSoyad, @UzmanlikAlani, @Maas, @Telefon, @Eposta)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@AdSoyad", adSoyad);
                    command.Parameters.AddWithValue("@UzmanlikAlani", uzmanlikAlani);
                    command.Parameters.AddWithValue("@Maas", maas);
                    command.Parameters.AddWithValue("@Telefon", telefon);
                    command.Parameters.AddWithValue("@Eposta", eposta);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Doktor başarıyla eklendi.");
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doktor eklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            textBox1.Clear();
            comboBox1.SelectedIndex = -1;
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
        }

        private void DoktorEkleControl_Load(object sender, EventArgs e)
        {

        }
    }
}
