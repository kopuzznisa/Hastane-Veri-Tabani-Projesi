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
    public partial class HastaGuncelleControl : UserControl
    {
        private string connectionString = "Server=KOPUZZNISA\\SQLEXPRESS;Database=HastaneVeriTabanıProjesi;Trusted_Connection=True;";

        public HastaGuncelleControl()
        {
            InitializeComponent();
            LoadKanGruplari();
        }

        private void LoadKanGruplari()
        {
            // Kan gruplarını comboboxa ekleme
            comboBox1.Items.Add("0 Rh+");
            comboBox1.Items.Add("0 Rh-");
            comboBox1.Items.Add("A Rh+");
            comboBox1.Items.Add("A Rh-");
            comboBox1.Items.Add("B Rh+");
            comboBox1.Items.Add("B Rh-");
            comboBox1.Items.Add("AB Rh+");
            comboBox1.Items.Add("AB Rh-");
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string hastaAdiSoyadi = textBox1.Text.Trim();
            string yeniTelefon = textBox2.Text.Trim();
            DateTime? yeniDogumTarihi = dateTimePicker1.Value;
            string yeniKanGrubu = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(hastaAdiSoyadi))
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz hastanın adını ve soyadını girin.");
                return;
            }

            if (string.IsNullOrEmpty(yeniTelefon) && yeniDogumTarihi == null && string.IsNullOrEmpty(yeniKanGrubu))
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz bilgileri girin.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE Hastalar SET ";
                    bool addComma = false;

                    if (!string.IsNullOrEmpty(yeniTelefon))
                    {
                        query += "Telefon = @Telefon";
                        addComma = true;
                    }

                    if (yeniDogumTarihi != null)
                    {
                        if (addComma) query += ", ";
                        query += "DogumTarihi = @DogumTarihi";
                        addComma = true;
                    }

                    if (!string.IsNullOrEmpty(yeniKanGrubu))
                    {
                        if (addComma) query += ", ";
                        query += "KanGrubu = @KanGrubu";
                    }

                    query += " WHERE AdSoyad = @HastaAdiSoyadi";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@HastaAdiSoyadi", hastaAdiSoyadi);

                    if (!string.IsNullOrEmpty(yeniTelefon))
                        command.Parameters.AddWithValue("@Telefon", yeniTelefon);

                    if (yeniDogumTarihi != null)
                        command.Parameters.AddWithValue("@DogumTarihi", yeniDogumTarihi);

                    if (!string.IsNullOrEmpty(yeniKanGrubu))
                        command.Parameters.AddWithValue("@KanGrubu", yeniKanGrubu);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Hasta bilgileri başarıyla güncellendi.");
                    }
                    else
                    {
                        MessageBox.Show("Bu isimde bir hasta bulunamadı.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilgiler güncellenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void HastaGuncelleControl_Load(object sender, EventArgs e)
        {

        }
    }
}
