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
    public partial class DoktorSilControl : UserControl
    {
        private string connectionString = "Server=KOPUZZNISA\\SQLEXPRESS;Database=HastaneVeriTabanıProjesi;Trusted_Connection=True;";
        public DoktorSilControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string doktorAdiSoyadi = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(doktorAdiSoyadi))
            {
                MessageBox.Show("Lütfen silmek istediğiniz doktorun ad ve soyadını giriniz.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM Doktorlar WHERE AdSoyad = @DoktorAdiSoyadi";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DoktorAdiSoyadi", doktorAdiSoyadi);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Doktor kaydı başarıyla silindi.");
                        }
                        else
                        {
                            MessageBox.Show("Bu isimde bir doktor bulunamadı.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }

            textBox1.Clear();
        }
    }
    
}
