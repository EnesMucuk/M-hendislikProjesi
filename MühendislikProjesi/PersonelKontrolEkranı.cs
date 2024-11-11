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
    public partial class PersonelKontrolEkranı : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        public PersonelKontrolEkranı()
        {
            InitializeComponent();
        }

        void Personelİşlemleri()
        {
            baglanti = new SqlConnection(@"Data Source=ENES\SQLEXPRESS;Initial Catalog=DbBenzinlikYonetimSistemi;Integrated Security=SSPI");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT KullaniciAdi,Sifre,AdSoyad,TCKimlik,DogumTarihi,Telefon,Cinsiyet,Egitim,IseGirisTarihi,Maas,Adres FROM PersonelBilgileri", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void PersonelKontrolEkranı_Load(object sender, EventArgs e)
        {
            Personelİşlemleri();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = " INSERT INTO PersonelBilgileri(KullaniciAdi,Sifre,AdSoyad,TCKimlik,DogumTarihi,Telefon,Cinsiyet,Egitim,IseGirisTarihi,Maas,Adres) VALUES (@KullaniciAdi,@Sifre,@AdSoyad,@TCKimlik,@DogumTarihi,@Telefon,@Cinsiyet,@Egitim,@IseGirisTarihi,@Maas,@Adres)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@KullaniciAdi", textBox3.Text);
            komut.Parameters.AddWithValue("@Sifre", textBox4.Text);
            komut.Parameters.AddWithValue("@AdSoyad", textBox1.Text);
            komut.Parameters.AddWithValue("@TCKimlik", textBox2.Text);
            komut.Parameters.AddWithValue("@DogumTarihi", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@Telefon", maskedTextBox3.Text);
            komut.Parameters.AddWithValue("@Cinsiyet", comboBox1.Text);
            komut.Parameters.AddWithValue("@Egitim", comboBox2.Text);
            komut.Parameters.AddWithValue("@IseGirisTarihi", maskedTextBox2.Text);
            komut.Parameters.AddWithValue("@Maas", textBox6.Text);
            komut.Parameters.AddWithValue("@Adres", textBox7.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Personelİşlemleri();

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            maskedTextBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            maskedTextBox2.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox2.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM PersonelBİlgileri WHERE AdSoyad=@AdSoyad";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@AdSoyad", Convert.ToString(textBox1.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Personelİşlemleri();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE PersonelBilgileri set KullaniciAdi=@KullaniciAdi, Sifre=@Sifre,TCKimlik=@TCKimlik,DogumTarihi=@DogumTarihi,Telefon=@Telefon,Cinsiyet=@Cinsiyet,Egitim=@Egitim,IseGirisTarihi=@IseGirisTarihi,Maas=@Maas,Adres=@Adres where AdSoyad=@AdSoyad";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@KullaniciAdi", Convert.ToString(textBox3.Text));
            komut.Parameters.AddWithValue("@Sifre", Convert.ToString(textBox4.Text));
            komut.Parameters.AddWithValue("@AdSoyad", Convert.ToString(textBox1.Text));
            komut.Parameters.AddWithValue("@TCKimlik", Convert.ToInt64(textBox2.Text));
            komut.Parameters.AddWithValue("@DogumTarihi", Convert.ToString(maskedTextBox1.Text));
            komut.Parameters.AddWithValue("@Telefon", Convert.ToString(maskedTextBox3.Text));
            komut.Parameters.AddWithValue("@Cinsiyet", Convert.ToString(comboBox1.Text));
            komut.Parameters.AddWithValue("@Egitim", Convert.ToString(comboBox2.Text));
            komut.Parameters.AddWithValue("@IseGirisTarihi", Convert.ToString(maskedTextBox2.Text));
            komut.Parameters.AddWithValue("@Maas", Convert.ToInt32(textBox6.Text));
            komut.Parameters.AddWithValue("@Adres", Convert.ToString(textBox7.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Personelİşlemleri();


        }
    }
}
