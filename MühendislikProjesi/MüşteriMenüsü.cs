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

namespace MühendislikProjesi
{
    public partial class MüşteriMenüsü : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        public MüşteriMenüsü()
        {
            InitializeComponent();
        }
        void MusteriGetir()
        {
            baglanti = new SqlConnection(@"Data Source=ENES\SQLEXPRESS;Initial Catalog=DbBenzinlikYonetimSistemi;Integrated Security=SSPI");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT Musteri, Plaka, Telefon FROM MusteriBilgileri", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        void SatısGetir()
        {
            baglanti = new SqlConnection(@"Data Source=ENES\SQLEXPRESS;Initial Catalog=DbBenzinlikYonetimSistemi;Integrated Security=SSPI");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT Urun,Adet,Fiyat,Tutar,Saat FROM Satıslar", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView2.DataSource = tablo;
            baglanti.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MüşteriMenüsü_Load(object sender, EventArgs e)
        {
            MusteriGetir();
            SatısGetir();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = " INSERT INTO MusteriBilgileri(musteri,plaka,telefon) VALUES (@musteri,@plaka,@telefon)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@musteri", textBox1.Text);
            komut.Parameters.AddWithValue("@plaka", textBox2.Text);
            komut.Parameters.AddWithValue("@telefon", maskedTextBox1.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MusteriGetir();
            textBox1.Text = "";
            textBox2.Text = "";
            maskedTextBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM MusteriBilgileri WHERE musteri=@musteri";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@musteri", Convert.ToString(textBox1.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MusteriGetir();
            textBox1.Text = "";
            textBox2.Text = "";
            maskedTextBox1.Text = "";
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            maskedTextBox1.Text = "";
        }
        int id = 0;

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE Table_1 SET plaka= '" + textBox2.Text.ToString()+ "',musteri='" + textBox1.Text.ToString()+ "',telefon='" + maskedTextBox1.Text.ToString()+ "'where telefon=" + id + "", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MusteriGetir();



            textBox1.Text = "";
            textBox2.Text = "";
            maskedTextBox1.Text = "";
       }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string sorgu = "UPDATE MusteriBilgileri set Plaka=@Plaka, Telefon=@Telefon where Musteri=@Musteri";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@Musteri",Convert.ToString(textBox1.Text));
            komut.Parameters.AddWithValue("@Plaka", Convert.ToString(textBox2.Text));
            komut.Parameters.AddWithValue("@Telefon", Convert.ToString(maskedTextBox1.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MusteriGetir();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}