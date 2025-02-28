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
    public partial class GünlükHastaSayisiControl : UserControl
    {
        private string connectionString = "Server=KOPUZZNISA\\SQLEXPRESS;Database=HastaneVeriTabanıProjesi;Trusted_Connection=True;";

        public GünlükHastaSayisiControl()
        {
            InitializeComponent();
        }

        private void GünlükHastaSayisiControl_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            try
            {
                flowLayoutPanel1.Controls.Clear();

                // Tabloyu manuel oluştur
                TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
                {
                    ColumnCount = 3,
                    RowCount = 1,
                    AutoSize = true,
                    Dock = DockStyle.Top,
                    CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
                };

                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33)); // Hasta ID
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33)); // Ad Soyad
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33)); // Şikayet

                // Tablo başlıklarını ekle
                tableLayoutPanel.Controls.Add(new Label { Text = "Hasta ID", Font = new Font("Arial", 10, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter }, 0, 0);
                tableLayoutPanel.Controls.Add(new Label { Text = "Ad Soyad", Font = new Font("Arial", 10, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter }, 1, 0);
                tableLayoutPanel.Controls.Add(new Label { Text = "Şikayet", Font = new Font("Arial", 10, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter }, 2, 0);

                flowLayoutPanel1.Controls.Add(tableLayoutPanel);

                // Veritabanından bilgileri çek
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT R.HastaID, H.AdSoyad, R.Sikayet
                        FROM Randevular R
                        INNER JOIN Hastalar H ON R.HastaID = H.HastaID
                        WHERE CONVERT(DATE, R.RandevuTarihi) = @SelectedDate ORDER BY H.AdSoyad ASC";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SelectedDate", selectedDate);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string hastaID = reader["HastaID"].ToString();
                            string adSoyad = reader["AdSoyad"].ToString();
                            string sikayet = reader["Sikayet"].ToString();

                            // Tabloya bilgileri ekle
                            tableLayoutPanel.RowCount += 1;
                            tableLayoutPanel.Controls.Add(new Label { Text = hastaID, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Arial", 10), Height = 35 }, 0, tableLayoutPanel.RowCount - 1);
                            tableLayoutPanel.Controls.Add(new Label { Text = adSoyad, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Arial", 10), Height = 35 }, 1, tableLayoutPanel.RowCount - 1);
                            tableLayoutPanel.Controls.Add(new Label { Text = sikayet, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Arial", 10), Height = 35 }, 2, tableLayoutPanel.RowCount - 1);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }


    }
}
