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
    public partial class DoktorGuncelleControl : UserControl
    {
        private string connectionString = "Server=KOPUZZNISA\\SQLEXPRESS;Database=HastaneVeriTabanıProjesi;Trusted_Connection=True;";

        public DoktorGuncelleControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string doktorAdiSoyadi = textBox1.Text.Trim();
            string yeniMaas = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(doktorAdiSoyadi))
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz doktorun adını ve soyadını girin.");
                return;
            }

            if (string.IsNullOrEmpty(yeniMaas))
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz bilgileri girin.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE Doktorlar SET ";
                    bool addComma = false;

                    if (!string.IsNullOrEmpty(yeniMaas))
                    {
                        query += "Maas = @Maas";
                        addComma = true;
                    }


                    query += " WHERE AdSoyad = @DoktorAdiSoyadi";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@DoktorAdiSoyadi", doktorAdiSoyadi);

                    if (!string.IsNullOrEmpty(yeniMaas))
                        command.Parameters.AddWithValue("@Maas", yeniMaas);


                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Doktor bilgileri başarıyla güncellendi.");
                    }
                    else
                    {
                        MessageBox.Show("Bu isimde bir doktor bulunamadı.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilgiler güncellenirken bir hata oluştu: " + ex.Message);
            }
        }
    }
}
