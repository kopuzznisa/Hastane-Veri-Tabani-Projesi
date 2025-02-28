using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace HASTANEVERİTABANIPROJESİ
{
    public partial class AnaSayfa : Form
    {
        private string connectionString = "Server=KOPUZZNISA\\SQLEXPRESS;Database=HastaneVeriTabanıProjesi;Trusted_Connection=True;";

        public AnaSayfa()
        {
            InitializeComponent();
            this.Size = new Size(1400, 791);
            KanGrubuComboboxDoldur();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GirisEkranı girisEkranı = new GirisEkranı();
            girisEkranı.Show();
            this.Hide();
        }

        private void KanGrubuComboboxDoldur()
        {
            // Kan grubu seçeneklerini combobox'a ekliyoruz
            string[] kanGruplari = { "A+", "A-", "B+", "B-", "AB+", "AB-", "0+", "0-" };
            foreach (var kanGrubu in kanGruplari)
            {
                comboBox1.Items.Add(kanGrubu);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Bos alan kontrolu
            if (string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text) || string.IsNullOrWhiteSpace(dateTimePicker1.Text) ||
                string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Lutfen tum alanlari doldurunuz.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // SQL Sorgusu
                    string query = "INSERT INTO Hastalar (AdSoyad, Telefon, DogumTarihi, KanGrubu) " +
                                   "VALUES (@AdSoyad, @Telefon, @DogumTarihi, @KanGrubu)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Ad ve Soyad birlestirilerek AdSoyad olusturuluyor
                        string adSoyad = textBox2.Text + " " + textBox4.Text;

                        // Parametreleri ekleme
                        cmd.Parameters.AddWithValue("@AdSoyad", adSoyad);
                        cmd.Parameters.AddWithValue("@Telefon", textBox6.Text);
                        cmd.Parameters.AddWithValue("@DogumTarihi", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@KanGrubu", comboBox1.SelectedItem.ToString());

                        // Sorguyu calistirma
                        cmd.ExecuteNonQuery();
                    }
                }

                // Basarili mesaji
                MessageBox.Show("Kayit basarili!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Hasta ana menuye gecis
                HastaAnaMenu hastaAnaMenu = new HastaAnaMenu();
                hastaAnaMenu.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata olustu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int yetkiliId;
            bool isNumeric = int.TryParse(textBox7.Text.Trim(), out yetkiliId);

            if (!isNumeric)
            {
                MessageBox.Show("Geçerli bir Yetkili ID girin.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Yetkili WHERE YetkiliId = @YetkiliId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@YetkiliId", yetkiliId);

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        YetkiliAnaMenu yetkiliAnaMenu = new YetkiliAnaMenu();
                        yetkiliAnaMenu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Yetkili kişi değilsiniz.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            
        }

       
    }
}
