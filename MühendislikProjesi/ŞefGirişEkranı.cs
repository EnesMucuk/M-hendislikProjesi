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

namespace MühendislikProjesi
{
    public partial class ŞefGirişEkranı : Form
    {
        
        public ŞefGirişEkranı()
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

            SqlCommand komut = new SqlCommand("SELECT *FROM SefGiris WHERE AdminKullaniciAdi='"+user+"' and AdminSifre='"+password+"'",baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                ŞefPaneli frm = new ŞefPaneli();
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
            PersonelGirişEkranı frm = new PersonelGirişEkranı();
            frm.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                textBox1.UseSystemPasswordChar = true;
            }
            else if (checkBox1.CheckState == CheckState.Unchecked)
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

        private void ŞefGirişEkranı_Load(object sender, EventArgs e)
        {

        }
    }
}
