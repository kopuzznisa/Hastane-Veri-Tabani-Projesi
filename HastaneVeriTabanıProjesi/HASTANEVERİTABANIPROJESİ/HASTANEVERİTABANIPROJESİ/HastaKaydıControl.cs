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
    public partial class HastaKaydıControl : UserControl
    {
        private string connectionString = "Server=KOPUZZNISA\\SQLEXPRESS;Database=HastaneVeriTabanıProjesi;Trusted_Connection=True;";

        public HastaKaydıControl()
        {
            InitializeComponent();
            LoadKanGruplari();
        }

        private void LoadKanGruplari()
        {
            // Kan gruplarını comboboxa ekleme, eğer zaten ekliyse bir daha ekleme
            if (comboBox1.Items.Count == 0)
            {
                comboBox1.Items.Add("0 Rh+");
                comboBox1.Items.Add("0 Rh-");
                comboBox1.Items.Add("A Rh+");
                comboBox1.Items.Add("A Rh-");
                comboBox1.Items.Add("B Rh+");
                comboBox1.Items.Add("B Rh-");
                comboBox1.Items.Add("AB Rh+");
                comboBox1.Items.Add("AB Rh-");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string hastaAdiSoyadi = textBox1.Text.Trim();
            string telefon = textBox2.Text.Trim();
            DateTime dogumTarihi = dateTimePicker1.Value;
            string kanGrubu = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(hastaAdiSoyadi) || string.IsNullOrEmpty(telefon) || string.IsNullOrEmpty(kanGrubu))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Yeni kayıt için HastaID otomatik olarak artan bir değer olarak belirlenir
                    string query = @"
                        INSERT INTO Hastalar (AdSoyad, Telefon, DogumTarihi, KanGrubu) 
                        VALUES (@HastaAdiSoyadi, @Telefon, @DogumTarihi, @KanGrubu)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@HastaAdiSoyadi", hastaAdiSoyadi);
                    command.Parameters.AddWithValue("@Telefon", telefon);
                    command.Parameters.AddWithValue("@DogumTarihi", dogumTarihi);
                    command.Parameters.AddWithValue("@KanGrubu", kanGrubu);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Hasta başarıyla eklendi.");

                    // Tüm alanları temizle
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hasta eklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            dateTimePicker1.Value = DateTime.Now;
            comboBox1.SelectedIndex = -1;
        }

    }
}
