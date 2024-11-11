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
    public partial class SatışBilgileri : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        public SatışBilgileri()
        {
            InitializeComponent();
        }

        
        void Faturaİşlemleri()
        {
            baglanti = new SqlConnection(@"Data Source=ENES\SQLEXPRESS;Initial Catalog=DbBenzinlikYonetimSistemi;Integrated Security=SSPI");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT VergiDairesi,VergiNo,Tarih,Sube,FaturaNo,TutarNo,IskontoOrani,NetTutar,KDVTutari,ToplamTutar FROM FaturaIslemleri", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close(); ;
        }
        private void SatışBilgileri_Load(object sender, EventArgs e)
        {
            Faturaİşlemleri();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            dateTimePicker1.Text = "";
            comboBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = " INSERT INTO FaturaIslemleri(VergiDairesi,VergiNo,Tarih,Sube,FaturaNo,TutarNo,IskontoOrani,NetTutar,KDVTutari,ToplamTutar) VALUES (@VergiDairesi,@VergiNo,@Tarih,@Sube,@FaturaNo,@TutarNo,@IskontoOrani,@NetTutar,@KDVTutari,@ToplamTutar)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@VergiDairesi", textBox1.Text);
            komut.Parameters.AddWithValue("@VergiNo", textBox2.Text);
            komut.Parameters.AddWithValue("@Tarih", dateTimePicker1.Text);
            komut.Parameters.AddWithValue("@Sube", comboBox1.Text);
            komut.Parameters.AddWithValue("@FaturaNo", textBox3.Text);
            komut.Parameters.AddWithValue("@TutarNo", textBox4.Text);
            komut.Parameters.AddWithValue("@IskontoOrani", textBox5.Text);
            komut.Parameters.AddWithValue("@NetTutar", textBox6.Text);
            komut.Parameters.AddWithValue("@KDVTutari", textBox7.Text);
            komut.Parameters.AddWithValue("@ToplamTutar", textBox8.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Faturaİşlemleri();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM FaturaIslemleri WHERE VergiNo=@VergiNo";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@VergiNo", Convert.ToString(textBox2.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Faturaİşlemleri();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void SatışBilgileri_Load_1(object sender, EventArgs e)
        {
            Faturaİşlemleri();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }
    }
}
