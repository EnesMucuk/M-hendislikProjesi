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
    public partial class ŞefPaneli : Form
    {
        public ŞefPaneli()
        {
            InitializeComponent();
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

        private void button5_Click(object sender, EventArgs e)
        {
            MüşteriMenüsü ekle = new MüşteriMenüsü();
            FormGetir(ekle);
        }

     
        private void button6_Click(object sender, EventArgs e)
        {
            PersonelKontrolEkranı ekle = new PersonelKontrolEkranı();
            FormGetir(ekle);
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ÜrünBilgileri ekle = new ÜrünBilgileri();
            FormGetir(ekle);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            İstasyonBilgileri ekle = new İstasyonBilgileri();
            FormGetir(ekle);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SatışBilgileri ekle = new SatışBilgileri();
            FormGetir(ekle);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
    }
}
