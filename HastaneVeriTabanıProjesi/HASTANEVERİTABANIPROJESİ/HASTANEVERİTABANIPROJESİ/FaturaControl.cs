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
    public partial class FaturaControl : UserControl
    {
        private string connectionString = "Server=KOPUZZNISA\\SQLEXPRESS;Database=HastaneVeriTabanıProjesi;Trusted_Connection=True;MultipleActiveResultSets=True;";

        public FaturaControl()
        {
            InitializeComponent();
        }

        public int HastaID { get; internal set; }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        public void LoadFaturaData()
        {
            string hastaID = HastaID.ToString(); // HastaID'yi buradan alıyoruz

            if (string.IsNullOrEmpty(hastaID))
            {
                MessageBox.Show("Lütfen hasta ID'sini girin.");
                return;
            }

            try
            {
                flowLayoutPanel1.Controls.Clear();
                double toplamFiyat = 0;

                // Tabloyu manuel oluştur
                TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
                {
                    ColumnCount = 3,
                    RowCount = 1,
                    AutoSize = true,
                    Dock = DockStyle.Top,
                    CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
                };

                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33)); // Vitamin
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33)); // İlaç İsmi
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33)); // İlaç Fiyatı

                // Tablo başlıklarını ekle
                tableLayoutPanel.Controls.Add(new Label { Text = "İlaç Sebebi", Font = new Font("Arial", 10, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter }, 0, 0);
                tableLayoutPanel.Controls.Add(new Label { Text = "İlaç İsmi", Font = new Font("Arial", 10, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter }, 1, 0);
                tableLayoutPanel.Controls.Add(new Label { Text = "İlaç Fiyatı", Font = new Font("Arial", 10, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter }, 2, 0);

                flowLayoutPanel1.Controls.Add(tableLayoutPanel);

                // İlaçlar ve şikayeti al
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // İlaçları ve şikayeti almak için SQL Query
                    string ilacQuery = @"
                                SELECT I.Ilac, I.IlacFiyati, R.Sikayet
                                FROM Ilac I
                                INNER JOIN Randevular R ON I.HastaID = R.HastaID
                                WHERE I.HastaID = @HastaID";
                    SqlCommand ilacCommand = new SqlCommand(ilacQuery, connection);
                    ilacCommand.Parameters.AddWithValue("@HastaID", hastaID);

                    using (SqlDataReader ilacReader = ilacCommand.ExecuteReader())
                    {
                        while (ilacReader.Read())
                        {
                            string ilacAdi = ilacReader["Ilac"].ToString();
                            double ilacFiyati = Convert.ToDouble(ilacReader["IlacFiyati"]);
                            string hastalik = ilacReader["Sikayet"].ToString();

                            // Tabloya ilaç bilgilerini ekle
                            tableLayoutPanel.RowCount += 1;
                            tableLayoutPanel.Controls.Add(new Label { Text = hastalik, TextAlign = ContentAlignment.MiddleCenter }, 0, tableLayoutPanel.RowCount - 1);
                            tableLayoutPanel.Controls.Add(new Label { Text = ilacAdi, TextAlign = ContentAlignment.MiddleCenter }, 1, tableLayoutPanel.RowCount - 1);
                            tableLayoutPanel.Controls.Add(new Label { Text = $"{ilacFiyati} ₺", TextAlign = ContentAlignment.MiddleCenter }, 2, tableLayoutPanel.RowCount - 1);

                            toplamFiyat += ilacFiyati;
                        }
                    }

                    // Vitaminler için verileri ekle
                    string tahlilQuery = @"
                                SELECT Demir, Magnezyum, dVitamini, eVitamini
                                FROM KanVeIdrarTahlili
                                WHERE HastaID = @HastaID";
                    SqlCommand tahlilCommand = new SqlCommand(tahlilQuery, connection);
                    tahlilCommand.Parameters.AddWithValue("@HastaID", hastaID);

                    using (SqlDataReader tahlilReader = tahlilCommand.ExecuteReader())
                    {
                        if (tahlilReader.Read())
                        {
                            // Demir, Magnezyum, E ve D Vitamini değerlerini al
                            double demir = Convert.ToDouble(tahlilReader["Demir"]);
                            double magnezyum = Convert.ToDouble(tahlilReader["Magnezyum"]);
                            double dVitamini = Convert.ToDouble(tahlilReader["dVitamini"]);
                            double eVitamini = Convert.ToDouble(tahlilReader["eVitamini"]);

                            // Vitaminlerin aralık dışındaki ilaçlarını kontrol et
                            toplamFiyat += CheckVitaminRange("Demir", demir, connection, tableLayoutPanel);
                            toplamFiyat += CheckVitaminRange("Magnezyum", magnezyum, connection, tableLayoutPanel);
                            toplamFiyat += CheckVitaminRange("D Vitamini", dVitamini, connection, tableLayoutPanel);
                            toplamFiyat += CheckVitaminRange("E Vitamini", eVitamini, connection, tableLayoutPanel);
                        }
                    }

                    // Toplam Fiyatı ekle
                    Label toplamFiyatLabel = new Label
                    {
                        Text = $"\nToplam İlaç Fiyatı: {toplamFiyat} ₺",
                        AutoSize = true,
                        Font = new Font("Arial", 12, FontStyle.Bold),
                        ForeColor = Color.Black
                    };
                    flowLayoutPanel1.Controls.Add(toplamFiyatLabel);

                    // Röntgen Fiyatı
                    double rontgenFiyati = 2100;
                    Label rontgenFiyatiLabel = new Label
                    {
                        Text = $"\nRöntgen Fiyatı: {rontgenFiyati} ₺",
                        AutoSize = true,
                        Font = new Font("Arial", 12, FontStyle.Bold),
                        ForeColor = Color.Black
                    };
                    flowLayoutPanel1.Controls.Add(rontgenFiyatiLabel);

                    // Tomografi Fiyatı
                    double tomografiFiyati = 1000;
                    Label tomografiFiyatiLabel = new Label
                    {
                        Text = $"\nTomografi Fiyatı: {tomografiFiyati} ₺",
                        AutoSize = true,
                        Font = new Font("Arial", 12, FontStyle.Bold),
                        ForeColor = Color.Black
                    };
                    flowLayoutPanel1.Controls.Add(tomografiFiyatiLabel);

                    // Toplam Fatura
                    double toplamFatura = toplamFiyat + rontgenFiyati + tomografiFiyati;
                    Label toplamFaturaLabel = new Label
                    {
                        Text = $"\nToplam Fatura: {toplamFatura} ₺",
                        AutoSize = true,
                        Font = new Font("Arial", 12, FontStyle.Bold),
                        ForeColor = Color.Red
                    };
                    flowLayoutPanel1.Controls.Add(toplamFaturaLabel);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private double CheckVitaminRange(string vitaminIsmi, double vitaminDegeri, SqlConnection connection, TableLayoutPanel tableLayoutPanel)
        {
            double toplamFiyat = 0;
            string ilacSebebi = "Vitamin Eksikliği";

            string aralikQuery = @"
                    SELECT Aralik, Ilac, Fiyat
                    FROM AralıklarveFiyatlar
                    WHERE VitaminIsmi = @VitaminIsmi";

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
                        double fiyat = Convert.ToDouble(aralikReader["Fiyat"]);

                        // Vitamin değeri aralığın dışında mı?
                        if (vitaminDegeri < minAralik || vitaminDegeri > maxAralik)
                        {
                            // Aralık dışındaki vitaminin ilaç ve fiyatını Tabloya ekle
                            tableLayoutPanel.RowCount += 1;
                            tableLayoutPanel.Controls.Add(new Label { Text = ilacSebebi + " (" + vitaminIsmi + " Eksikliği)", TextAlign = ContentAlignment.MiddleCenter }, 0, tableLayoutPanel.RowCount - 1);
                            tableLayoutPanel.Controls.Add(new Label { Text = aralikReader["Ilac"].ToString(), TextAlign = ContentAlignment.MiddleCenter }, 1, tableLayoutPanel.RowCount - 1);
                            tableLayoutPanel.Controls.Add(new Label { Text = $"{fiyat} ₺", TextAlign = ContentAlignment.MiddleCenter }, 2, tableLayoutPanel.RowCount - 1);

                            // Toplam ilaç fiyatını ekle
                            toplamFiyat += fiyat;
                        }
                    }
                }
            }

            return toplamFiyat;
        }
        private void FaturaControl_Load(object sender, EventArgs e)
        {
            // HastaID'yi kontrole aktaralım. Eğer HastaID varsa işlemi başlatacağız.
            if (HastaID > 0)
            {
                LoadFaturaData();
            }

        }
    }
}
