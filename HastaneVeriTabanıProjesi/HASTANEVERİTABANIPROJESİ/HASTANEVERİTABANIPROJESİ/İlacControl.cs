using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HASTANEVERİTABANIPROJESİ
{
    public partial class İlacControl : UserControl
    {
        private string connectionString = "Server=KOPUZZNISA\\SQLEXPRESS;Database=HastaneVeriTabanıProjesi;Trusted_Connection=True;MultipleActiveResultSets=True;";

        public İlacControl()
        {
            InitializeComponent();
        }

        public int HastaID { get; internal set; }  // HastaID'yi alıyoruz

        private void İlacControl_Load(object sender, EventArgs e)
        {
            // Eğer HastaID zaten belirli bir değere sahipse, işlemi başlat
            if (HastaID > 0)
            {
                LoadData(HastaID);
            }
        }

        private void LoadData(int hastaID)
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel1.FlowDirection = FlowDirection.TopDown; // Elemanlar alt alta sıralanacak
                flowLayoutPanel1.WrapContents = false; // Elemanlar yan yana taşmayacak

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // İlaçlar başlığı
                    Label ilacBaslik = new Label
                    {
                        Text = "Hastalığınızın İlaçları:",
                        AutoSize = true,
                        Font = new Font("Arial", 12, FontStyle.Bold),
                        ForeColor = Color.Black
                    };
                    flowLayoutPanel1.Controls.Add(ilacBaslik);

                    // İlaçları ve fiyatlarını ekle
                    SqlCommand ilacCommand = new SqlCommand("GetIlaclarByHastaID", connection);
                    ilacCommand.CommandType = CommandType.StoredProcedure;
                    ilacCommand.Parameters.AddWithValue("@HastaID", hastaID);

                    using (SqlDataReader ilacReader = ilacCommand.ExecuteReader())
                    {
                        while (ilacReader.Read())
                        {
                            Label ilacLabel = new Label
                            {
                                Text = $"{ilacReader["Ilac"]} - {ilacReader["IlacFiyati"]} ₺",
                                AutoSize = true,
                                Font = new Font("Arial", 10, FontStyle.Regular)
                            };
                            flowLayoutPanel1.Controls.Add(ilacLabel);
                        }
                    }

                    // Vitamin Değerleri başlığı
                    Label vitaminBaslik = new Label
                    {
                        Text = "\nVitamin Değerleriniz:",
                        AutoSize = true,
                        Font = new Font("Arial", 12, FontStyle.Bold),
                        ForeColor = Color.Black
                    };
                    flowLayoutPanel1.Controls.Add(vitaminBaslik);

                    // Kan ve İdrar Tahlili tablosundan vitamin değerlerini kontrol et
                    SqlCommand tahlilCommand = new SqlCommand("GetVitaminTahlilByHastaID", connection);
                    tahlilCommand.CommandType = CommandType.StoredProcedure;
                    tahlilCommand.Parameters.AddWithValue("@HastaID", hastaID);

                    using (SqlDataReader tahlilReader = tahlilCommand.ExecuteReader())
                    {
                        if (tahlilReader.Read())
                        {
                            CheckVitaminRange("Demir", Convert.ToDouble(tahlilReader["Demir"]), flowLayoutPanel1);
                            CheckVitaminRange("Magnezyum", Convert.ToDouble(tahlilReader["Magnezyum"]), flowLayoutPanel1);
                            CheckVitaminRange("E vitamini", Convert.ToDouble(tahlilReader["eVitamini"]), flowLayoutPanel1);
                            CheckVitaminRange("D vitamini", Convert.ToDouble(tahlilReader["dVitamini"]), flowLayoutPanel1);
                        }
                    }

                    /*
                    Label vitaminIlacBaslik = new Label
                    {
                        Text = "\nVitamin İlaçlarınız:",
                        AutoSize = true,
                        Font = new Font("Arial", 12, FontStyle.Bold),
                        ForeColor = Color.Black
                    };
                    flowLayoutPanel1.Controls.Add(vitaminIlacBaslik);

                    // Vitamin ilaçları ve fiyatlarını ekle (Yalnızca aralığın altında veya üstünde olanlar)
                    SqlCommand araliklarCommand = new SqlCommand("GetVitaminIlacByHastaID", connection);
                    araliklarCommand.CommandType = CommandType.StoredProcedure;
                    araliklarCommand.Parameters.AddWithValue("@HastaID", hastaID);

                    using (SqlDataReader araliklarReader = araliklarCommand.ExecuteReader())
                    {
                        while (araliklarReader.Read())
                        {
                            string vitaminIsmi = araliklarReader["vitaminIsmi"].ToString();
                            double minAralik = Convert.ToDouble(araliklarReader["Aralik"].ToString().Split('-')[0]);
                            double maxAralik = Convert.ToDouble(araliklarReader["Aralik"].ToString().Split('-')[1]);
                            double vitaminDegeri = Convert.ToDouble(araliklarReader["VitaminDegeri"]);

                            // Vitamin değerini aralıklara göre kontrol et
                            if (vitaminDegeri < minAralik || vitaminDegeri > maxAralik)
                            {
                                Label vitaminIlacLabel = new Label
                                {
                                    Text = $"{araliklarReader["Ilac"]} - {araliklarReader["Fiyat"]} ₺",
                                    AutoSize = true,
                                    Font = new Font("Arial", 10, FontStyle.Regular),
                                    ForeColor = Color.Red
                                };
                                flowLayoutPanel1.Controls.Add(vitaminIlacLabel);
                            }
                        }
                    }
                    */
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void CheckVitaminRange(string vitaminIsmi, double vitaminDegeri, FlowLayoutPanel flowPanel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Aralıkları almak için stored procedure çağır
                SqlCommand aralikCommand = new SqlCommand("GetVitaminAralikByIsmi", connection);
                aralikCommand.CommandType = CommandType.StoredProcedure;
                aralikCommand.Parameters.AddWithValue("@vitaminIsmi", vitaminIsmi);

                using (SqlDataReader aralikReader = aralikCommand.ExecuteReader())
                {
                    if (aralikReader.Read())
                    {
                        string aralik = aralikReader["Aralik"].ToString();
                        double minAralik = Convert.ToDouble(aralik.Split('-')[0]);
                        double maxAralik = Convert.ToDouble(aralik.Split('-')[1]);

                        // Durumu belirleme
                        string durum = $"{vitaminIsmi} aralıkta";
                        Color renk = Color.Green;

                        if (vitaminDegeri < minAralik)
                        {
                            durum = $"{vitaminIsmi} aralığın altında";
                            renk = Color.Red;
                        }
                        else if (vitaminDegeri > maxAralik)
                        {
                            durum = $"{vitaminIsmi} aralığın üstünde";
                            renk = Color.Red;
                        }

                        // Vitamin durumu etiketi oluşturma
                        Label vitaminLabel = new Label
                        {
                            Text = durum,
                            AutoSize = true,
                            Font = new Font("Arial", 10, FontStyle.Regular),
                            ForeColor = renk
                        };

                        flowPanel.Controls.Add(vitaminLabel);
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
