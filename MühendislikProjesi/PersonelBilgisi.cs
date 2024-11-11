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
    

    public partial class PersonelBilgisi : Form
    {
        public PersonelBilgisi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source = ENES\SQLEXPRESS; Initial Catalog = DbBenzinlikYonetimSistemi; Integrated Security = SSPI");
        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void PersonelBilgisi_Load(object sender, EventArgs e)
        {
            

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                textBox4.UseSystemPasswordChar = true;
            }
            else if (checkBox1.CheckState == CheckState.Unchecked)
            {
                textBox4.UseSystemPasswordChar = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT*FROM PersonelBilgileri where Sifre like '" + textBox4.Text + "' and KullaniciAdi like'" + textBox3.Text + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {   
                textBox1.Text = read["AdSoyad"].ToString();
                maskedTextBox1.Text = read["DogumTarihi"].ToString();
                maskedTextBox3.Text = read["Telefon"].ToString();
                textBox2.Text = read["TCKimlik"].ToString();
                textBox8.Text = read["Cinsiyet"].ToString();
                textBox5.Text = read["Egitim"].ToString();
                maskedTextBox2.Text = read["IseGirisTarihi"].ToString();
                textBox6.Text = read["Maas"].ToString();
                textBox7.Text = read["Adres"].ToString();
            }
            baglanti.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT*FROM PersonelBilgileri where Sifre like '" + textBox4.Text + "' and KullaniciAdi like'"+textBox3.Text+"'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                textBox1.Text = read["AdSoyad"].ToString();
                maskedTextBox1.Text = read["DogumTarihi"].ToString();
                maskedTextBox3.Text = read["Telefon"].ToString();
                textBox2.Text = read["TCKimlik"].ToString();
                textBox8.Text = read["Cinsiyet"].ToString();
                textBox5.Text = read["Egitim"].ToString();
                maskedTextBox2.Text = read["IseGirisTarihi"].ToString();
                textBox6.Text = read["Maas"].ToString();
                textBox7.Text = read["Adres"].ToString();
            }
            baglanti.Close();
        }
    }
}
