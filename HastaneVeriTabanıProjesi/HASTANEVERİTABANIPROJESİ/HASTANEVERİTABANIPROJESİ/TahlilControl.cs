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
    public partial class TahlilControl : UserControl
    {
        private string connectionString = "Server=KOPUZZNISA\\SQLEXPRESS;Database=HastaneVeriTabanıProjesi;Trusted_Connection=True;MultipleActiveResultSets=True;";

        public int HastaID { get; internal set; }

        public TahlilControl()
        {
            InitializeComponent();
        }

        private void TahlilControl_Load(object sender, EventArgs e)
        {
            // HastaID'yi kontrole aktaralım. Eğer HastaID varsa işlemi başlatacağız.
            if (HastaID > 0)
            {
                LoadTahlilData(HastaID);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void LoadTahlilData(int hastaID)
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Tabloyu oluşturuyoruz
                    TableLayoutPanel table = new TableLayoutPanel
                    {
                        ColumnCount = 4,
                        AutoSize = true, // Otomatik boyutlandırmayı aktifleştiriyoruz
                        Width = flowLayoutPanel1.Width, // Panelin genişliği kadar genişliğini ayarlıyoruz
                        RowCount = 5, // 4 satır + başlık satırı
                        CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                        Dock = DockStyle.Top
                    };

                    // Her sütunun genişliği ve yüksekliği eşit olacak şekilde ayarlıyoruz
                    for (int i = 0; i < 6; i++)
                    {
                        table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F)); // Sütunlar eşit genişlikte olacak
                    }

                    // Tablo başlıkları
                    table.Controls.Add(new Label { Text = "Vitamin", Font = new Font("Arial", 10, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill }, 0, 0);
                    table.Controls.Add(new Label { Text = "Sonucunuz", Font = new Font("Arial", 10, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill }, 1, 0);
                    table.Controls.Add(new Label { Text = "Aralık", Font = new Font("Arial", 10, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill }, 2, 0);
                    table.Controls.Add(new Label { Text = "Sonuç", Font = new Font("Arial", 10, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill }, 3, 0);

                    // Vitaminlerin ve aralıkların verilerini alıyoruz
                    string tahlilQuery = @"
                                SELECT Demir, Magnezyum, eVitamini, dVitamini
                                FROM KanVeIdrarTahlili
                                WHERE HastaID = @HastaID";
                    SqlCommand tahlilCommand = new SqlCommand(tahlilQuery, connection);
                    tahlilCommand.Parameters.AddWithValue("@HastaID", hastaID);

                    using (SqlDataReader tahlilReader = tahlilCommand.ExecuteReader())
                    {
                        if (tahlilReader.Read())
                        {
                            // Vitamin değerlerini ve aralıklarını alıp kontrol ediyoruz
                            AddVitaminRow("Demir", tahlilReader["Demir"], table, connection);
                            AddVitaminRow("Magnezyum", tahlilReader["Magnezyum"], table, connection);
                            AddVitaminRow("E Vitamini", tahlilReader["eVitamini"], table, connection);
                            AddVitaminRow("D Vitamini", tahlilReader["dVitamini"], table, connection);
                        }
                    }

                    flowLayoutPanel1.Controls.Add(table);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void AddVitaminRow(string vitaminIsmi, object vitaminDegeri, TableLayoutPanel table, SqlConnection connection)
        {
            // Aralıkları almak için sorgu
            string aralikQuery = @"
                    SELECT Aralik
                    FROM AralıklarveFiyatlar
                    WHERE vitaminIsmi = @VitaminIsmi";

            using (SqlCommand aralikCommand = new SqlCommand(aralikQuery, connection))
            {
                aralikCommand.Parameters.AddWithValue("@VitaminIsmi", vitaminIsmi);

                using (SqlDataReader aralikReader = aralikCommand.ExecuteReader())
                {
                    if (aralikReader.Read())
                    {
                        string aralik = aralikReader["Aralik"].ToString();
                        double minAralik = Convert.ToDouble(aralik.Split('-')[0]);
                        double maxAralik = Convert.ToDouble(aralik.Split('-')[1]);
                        string durum = "Normal";
                        Color renk = Color.Green;

                        // Durumu belirliyoruz
                        double value = Convert.ToDouble(vitaminDegeri);
                        if (value < minAralik)
                        {
                            durum = "Düşük";
                            renk = Color.Red;
                        }
                        else if (value > maxAralik)
                        {
                            durum = "Yüksek";
                            renk = Color.Red;
                        }

                        // Vitamin adını, değeri, aralıkları ve durumu tabloya ekliyoruz
                        table.Controls.Add(new Label { Text = vitaminIsmi, TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill }, 0, table.RowCount);
                        table.Controls.Add(new Label { Text = value.ToString(), TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill }, 1, table.RowCount);
                        table.Controls.Add(new Label { Text = $"{minAralik} - {maxAralik}", TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill }, 2, table.RowCount);
                        Label durumLabel = new Label
                        {
                            Text = durum,
                            ForeColor = renk,
                            Font = new Font("Arial", 10, FontStyle.Bold),
                            TextAlign = ContentAlignment.MiddleCenter,
                            Dock = DockStyle.Fill
                        };
                        table.Controls.Add(durumLabel, 3, table.RowCount);
                        table.RowCount++; // Her satır için satır sayısını artırıyoruz
                    }
                }
            }
        }
    }
}

