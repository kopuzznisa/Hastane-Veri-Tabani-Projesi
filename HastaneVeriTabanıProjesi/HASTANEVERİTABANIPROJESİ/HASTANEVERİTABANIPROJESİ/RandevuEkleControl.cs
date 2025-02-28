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
    public partial class RandevuEkleControl : UserControl
    {
        private string connectionString = "Server=KOPUZZNISA\\SQLEXPRESS;Database=HastaneVeriTabanıProjesi;Trusted_Connection=True;";

        public RandevuEkleControl()
        {
            InitializeComponent();
            LoadSikayetler();
        }

        private void LoadSikayetler()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT DISTINCT SikayetAdi FROM Sikayetler";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        comboBoxSikayet.Items.Add(reader["SikayetAdi"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Şikayetler yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void LoadDoktorlar(string sikayet)
        {
            comboBox1.Items.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT d.DoktorID, d.AdSoyad 
                        FROM Doktorlar d
                        INNER JOIN Sikayetler s ON d.UzmanlikAlani = s.UygunBolum
                        WHERE s.SikayetAdi = @SikayetAdi";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SikayetAdi", sikayet);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        comboBox1.Items.Add(new ComboboxItem
                        {
                            Value = reader["DoktorID"],
                            Text = reader["AdSoyad"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doktorlar yüklenirken bir hata oluştu: " + ex.Message);
            }
        }
        private void SaveRandevu()
        {
            if (comboBox1.SelectedItem is ComboboxItem selectedDoktor &&
                comboBoxSikayet.SelectedItem != null)
            {
                int doktorId = (int)selectedDoktor.Value;
                string sikayet = comboBoxSikayet.SelectedItem.ToString();
                DateTime randevuTarihi = dateTimePicker1.Value.Date;

                int hastaId = GetLoggedInHastaId(); // HastaID alınır
                if (hastaId == 0)
                {
                    MessageBox.Show("Hasta kimliği bulunamadı.");
                    return;
                }

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = @"
                    INSERT INTO Randevular (RandevuTarihi, HastaID, DoktorID, Sikayet) 
                    VALUES (@RandevuTarihi, @HastaId, @DoktorId, @Sikayet)";

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@RandevuTarihi", randevuTarihi);
                        command.Parameters.AddWithValue("@HastaId", hastaId);
                        command.Parameters.AddWithValue("@DoktorId", doktorId);
                        command.Parameters.AddWithValue("@Sikayet", sikayet);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Randevu başarıyla kaydedildi.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Randevu kaydedilirken bir hata oluştu: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
            }
        }


        private int GetLoggedInHastaId()
        {
            // Örnek bir HastaID döndürüyor
            return 1;
        }

        private void comboBoxSikayet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSikayet.SelectedItem != null)
            {
                LoadDoktorlar(comboBoxSikayet.SelectedItem.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveRandevu();
        }

        private class ComboboxItem
        {
            public object Value { get; set; }
            public string Text { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void RandevuEkleControl_Load(object sender, EventArgs e)
        {

        }
    }
}