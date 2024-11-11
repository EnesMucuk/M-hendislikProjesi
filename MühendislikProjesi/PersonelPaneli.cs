using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MühendislikProjesi
{
    public partial class PersonelPaneli : Form
    {
        public PersonelPaneli()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormGetir(Form frm)
        {
            panel1.Controls.Clear();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(frm);
            frm.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SatışEkranı ekle = new SatışEkranı(); 
            FormGetir(ekle);    
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PersonelBilgisi ekle = new PersonelBilgisi();
            FormGetir(ekle);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MüşteriMenüsü ekle = new MüşteriMenüsü();   
            FormGetir(ekle);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ÜrünBilgileri ekle = new ÜrünBilgileri();
            FormGetir(ekle);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PersonelPaneli_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
    }
}
