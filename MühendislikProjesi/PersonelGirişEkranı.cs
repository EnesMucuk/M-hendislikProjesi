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
    public partial class PersonelGirişEkranı : Form
    {
        public PersonelGirişEkranı()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source = ENES\SQLEXPRESS; Initial Catalog = DbBenzinlikYonetimSistemi; Integrated Security = SSPI");

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string user;
            string password;
            user = textBox2.Text;
            password = textBox1.Text;

            SqlCommand komut = new SqlCommand("SELECT *FROM PersonelBilgileri WHERE KullaniciAdi='" + user + "' and Sifre='" + password + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                PersonelPaneli frm = new PersonelPaneli();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");
            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                
            ŞefGirişEkranı frm = new ŞefGirişEkranı();
            frm.Show();
            this.Hide();
        
         }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.CheckState==CheckState.Checked) 
            {
                textBox1.UseSystemPasswordChar = true;  
            }
            else if(checkBox1.CheckState==CheckState.Unchecked)   
            {
                textBox1.UseSystemPasswordChar = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void PersonelGirişEkranı_Load(object sender, EventArgs e)
        {

        }
    }
}
