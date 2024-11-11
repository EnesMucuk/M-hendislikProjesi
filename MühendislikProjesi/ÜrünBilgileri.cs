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

namespace MühendislikProjesi
{
    public partial class ÜrünBilgileri : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        public ÜrünBilgileri()
        {
            InitializeComponent();
        }

        void UrunGetir()
        {
            baglanti = new SqlConnection(@"Data Source=ENES\SQLEXPRESS;Initial Catalog=DbBenzinlikYonetimSistemi;Integrated Security=SSPI");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT UrunAdi,UrunKodu,Stok,Fiyat,Marka FROM UrunBilgileri", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ÜrünBilgileri_Load(object sender, EventArgs e)
        {
            UrunGetir();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = " INSERT INTO UrunBilgileri(UrunAdi,UrunKodu,Stok,Fiyat,Marka) VALUES (@UrunAdi,@UrunKodu,@Stok,@Fiyat,@Marka)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@UrunAdi", textBox1.Text);
            komut.Parameters.AddWithValue("@UrunKodu", textBox2.Text);
            komut.Parameters.AddWithValue("@Stok", textBox3.Text);
            komut.Parameters.AddWithValue("@Fiyat", textBox4.Text);
            komut.Parameters.AddWithValue("@Marka", textBox5.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            UrunGetir();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM UrunBilgileri WHERE UrunAdi=@UrunAdi";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@UrunAdi", Convert.ToString(textBox1.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            UrunGetir();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            


        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE UrunBilgileri set Stok=Stok+'" + int.Parse(textBox6.Text) + "' where UrunKodu = '"+textBox2.Text+"'",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            UrunGetir();
            textBox6.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE UrunBilgileri set UrunAdi=@UrunAdi, Stok=@Stok, Fiyat=@Fiyat, Marka=@Marka where UrunKodu=@UrunKodu";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@UrunAdi", Convert.ToString(textBox1.Text));
            komut.Parameters.AddWithValue("@UrunKodu", Convert.ToString(textBox2.Text));
            komut.Parameters.AddWithValue("@Stok", Convert.ToString(textBox3.Text));
            komut.Parameters.AddWithValue("@Fiyat", Convert.ToString(textBox4.Text));
            komut.Parameters.AddWithValue("@Marka", Convert.ToString(textBox5.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            UrunGetir();
        }
    }

}
