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

namespace mustafaakdeniz20215070013
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-LIE8SLV\\SQLEXPRESS;Initial Catalog=sirketveritabani;Integrated Security=True;");

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand stokguncelle = new SqlCommand("update urunler set urunad=@p2,stoksayisi=@p3 where urunad=@p2 ", baglanti);
            stokguncelle.Parameters.AddWithValue("@p2", comboBox1.Text);
            stokguncelle.Parameters.AddWithValue("@p3", textBox1.Text);
            stokguncelle.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from urunler", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Open();
            SqlCommand command = new SqlCommand("SELECT urunad FROM urunler", baglanti);
            comboBox1.Items.Clear(); 
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["urunad"].ToString());
                }

            }
            baglanti.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand urunekle = new SqlCommand("insert into urunler(urunad, stoksayisi) values(@p1,@p2)", baglanti);
            urunekle.Parameters.AddWithValue("@p1", comboBox1.Text);
            urunekle.Parameters.AddWithValue("@p2", textBox1.Text);
            urunekle.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from urunler where stoksayisi = 0", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand urunsil = new SqlCommand("delete from urunler where urunad=@urunad", baglanti);
            urunsil.Parameters.AddWithValue("@urunad", comboBox1.Text);
            urunsil.ExecuteNonQuery();
            MessageBox.Show("Ürün Silindi.");
            baglanti.Close();
        }
    }
}
