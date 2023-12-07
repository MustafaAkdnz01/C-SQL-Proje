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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace mustafaakdeniz20215070013
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-LIE8SLV\\SQLEXPRESS;Initial Catalog=sirketveritabani;Integrated Security=True;");

        private void button1_Click(object sender, EventArgs e)
        {

            string kullaniciAdi = textBox1.Text;
            string sifre = textBox2.Text;

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş bırakılamaz.", "Hata");
                return;
            }

            if (GirisKontrol(kullaniciAdi, sifre))
            {
                MessageBox.Show("Giriş başarılı!", "Başarılı");
                Form2 mainForm = new Form2();
                this.Hide(); 
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı.", "Hata");
            }
        }

        private bool GirisKontrol(string kullaniciAdi, string sifre)
        {

            baglanti.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM uyeler WHERE kullaniciadi = @KullaniciAdi AND sifre = @Sifre", baglanti);
                command.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                command.Parameters.AddWithValue("@Sifre", sifre);

                using (SqlDataReader reader = command.ExecuteReader())

                {
                    return reader.HasRows;
                

                }

        }             
    }
}
