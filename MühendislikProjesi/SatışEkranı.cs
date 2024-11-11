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
    public partial class SatışEkranı : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        public SatışEkranı()
        {
            InitializeComponent();
        }

        void UrunGetir()
        {
            baglanti = new SqlConnection(@"Data Source=ENES\SQLEXPRESS;Initial Catalog=DbBenzinlikYonetimSistemi;Integrated Security=SSPI");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT UrunAdi,UrunKodu,Fiyat FROM UrunBilgileri", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }



        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
        double Depo_benzin95 = 0, Depo_benzin97 = 0, Depo_dizel = 0, Depo_eurodizel = 0, Depo_lpg = 0;
        double Ekle_benzin95 = 0, Ekle_benzin97 = 0, Ekle_dizel = 0, Ekle_eurodizel = 0, Ekle_lpg = 0;
        double Fiyat_benzin95 = 0, Fiyat_benzin97 = 0, Fiyat_dizel = 0, Fiyat_eurodizel = 0, Fiyat_lpg = 0;
        double Satis_benzin95 = 0, Satis_benzin97 = 0, Satis_dizel = 0, Satis_eurodizel = 0, Satis_lpg = 0;

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox14.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox13.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (textBox12.Text != "" )
            {
                double sayi6 = Convert.ToDouble(textBox12.Text);
                double sayi5 = Convert.ToDouble(textBox13.Text);
                label34.Text = Convert.ToString(sayi5 * sayi6);
            }
            else
            {
                label34.Text = "0";
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            textBox14.Text = "";
            textBox13.Text = "";
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT*FROM UrunBilgileri where UrunKodu like '" + textBox11.Text + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                textBox14.Text = read["UrunAdi"].ToString();
                textBox13.Text = read["Fiyat"].ToString();
            }
            baglanti.Close();
        }
        double toplamTutar = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            baglanti = new SqlConnection(@"Data Source=ENES\SQLEXPRESS;Initial Catalog=DbBenzinlikYonetimSistemi;Integrated Security=SSPI");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE UrunBilgileri set Stok=Stok-'" + int.Parse(textBox12.Text) + "' where UrunKodu = '" + textBox11.Text + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();

            string sorgu = " INSERT INTO Satıslar(Urun,Adet,Fiyat,Tutar,Saat) VALUES (@Urun,@Adet,@Fiyat,@Tutar,@Saat)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@Urun", textBox14.Text);
            komut.Parameters.AddWithValue("@Adet", textBox12.Text);
            komut.Parameters.AddWithValue("@Fiyat", textBox13.Text);
            komut.Parameters.AddWithValue("@Tutar", label34.Text);
            komut.Parameters.AddWithValue("@Saat", label44.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

            string urun, adet, fiyat, tutar;
            urun = textBox14.Text;
            adet = textBox12.Text;
            fiyat = textBox13.Text;
            tutar = label34.Text;

            string[] bilgiler = { urun, adet, fiyat, tutar };
            ListViewItem kayit = new ListViewItem(bilgiler);
            listView1.Items.Add(kayit);
            
            double tutar2 = Convert.ToDouble(label34.Text);
            toplamTutar += tutar2;
            label36.Text = Convert.ToString(toplamTutar);

            textBox14.Text = "";
            textBox13.Text = "";
            textBox12.Text = "";
            label34.Text = "0";

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            label36.Text = "0";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label44.Text = DateTime.Now.ToString();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
         
        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Benzin 95 Oktan")
            {
                numericUpDown6.Enabled = true;
                numericUpDown7.Enabled = false;
                numericUpDown8.Enabled = false;
                numericUpDown9.Enabled = false;
                numericUpDown10.Enabled = false;
            }

            else if (comboBox2.Text == "Benzin 97 Oktan")
            {
                numericUpDown6.Enabled = false;
                numericUpDown7.Enabled = true;
                numericUpDown8.Enabled = false;
                numericUpDown9.Enabled = false;
                numericUpDown10.Enabled = false;
            }

            else if (comboBox2.Text == "Dizel")
            {
                numericUpDown6.Enabled = false;
                numericUpDown7.Enabled = false;
                numericUpDown8.Enabled = true;
                numericUpDown9.Enabled = false;
                numericUpDown10.Enabled = false;
            }

            else if (comboBox2.Text == "Euro Dizel")
            {
                numericUpDown6.Enabled = false;
                numericUpDown7.Enabled = false;
                numericUpDown8.Enabled = false;
                numericUpDown9.Enabled = true;
                numericUpDown10.Enabled = false;
            }

            else if (comboBox2.Text == "LPG")
            {
                numericUpDown6.Enabled = false;
                numericUpDown7.Enabled = false;
                numericUpDown8.Enabled = false;
                numericUpDown9.Enabled = false;
                numericUpDown10.Enabled = true;
            }
            label47.Text = "_______";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(numericUpDown6.Enabled == true)
            {
                double fiyat,fiyat2,litre;
                fiyat= double.Parse(numericUpDown6.Value.ToString());
                fiyat2 = Fiyat_benzin95;
                label47.Text = Convert.ToString(fiyat / fiyat2);
                litre = double.Parse(label47.Text);
                double Kbenzin95 = Depo_benzin95 - litre - 0.0000001;
                if (Kbenzin95 < 0)
                {
                    MessageBox.Show("Yetersiz Stok");
                    label47.Text = "_______";
                }

                else
                {
                    Depo_benzin95 = Depo_benzin95 - litre;

                    string sorgu = " INSERT INTO Satıslar(Urun,Adet,Fiyat,Tutar,Saat) VALUES (@Urun,@Adet,@Fiyat,@Tutar,@Saat)";
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@Urun", comboBox2.Text);
                    komut.Parameters.AddWithValue("@Adet", label47.Text);
                    komut.Parameters.AddWithValue("@Fiyat", label15.Text);
                    komut.Parameters.AddWithValue("@Tutar", numericUpDown6.Text);
                    komut.Parameters.AddWithValue("@Saat", label44.Text);
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                }
            }

            else if (numericUpDown7.Enabled == true)
            {
                double fiyat, fiyat2, litre;
                fiyat = double.Parse(numericUpDown7.Value.ToString());
                fiyat2 = Fiyat_benzin97;
                label47.Text = Convert.ToString(fiyat / fiyat2);
                litre = double.Parse(label47.Text);
                double Kbenzin97 = Depo_benzin97 - litre - 0.00000001;

                if (Kbenzin97 < 0)
                {
                    MessageBox.Show("Yetersiz Stok");
                    label47.Text = "_______";
                }

                else
                {
                    Depo_benzin97 = Depo_benzin97 - litre;

                    string sorgu = " INSERT INTO Satıslar(Urun,Adet,Fiyat,Tutar,Saat) VALUES (@Urun,@Adet,@Fiyat,@Tutar,@Saat)";
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@Urun", comboBox2.Text);
                    komut.Parameters.AddWithValue("@Adet", label47.Text);
                    komut.Parameters.AddWithValue("@Fiyat", label14.Text);
                    komut.Parameters.AddWithValue("@Tutar", numericUpDown7.Text);
                    komut.Parameters.AddWithValue("@Saat", label44.Text);
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                }
            }

            else if (numericUpDown8.Enabled == true)
            {
                double fiyat, fiyat2, litre;
                fiyat = double.Parse(numericUpDown8.Value.ToString());
                fiyat2 = Fiyat_dizel;
                label47.Text = Convert.ToString(fiyat / fiyat2);
                litre = double.Parse(label47.Text);
                double Kdizel = Depo_dizel - litre - 0.00000001;

                if (Kdizel < 0)
                {
                    MessageBox.Show("Yetersiz Stok");
                    label47.Text = "_______";
                }

                else
                {
                    Depo_dizel = Depo_dizel - litre;

                    string sorgu = " INSERT INTO Satıslar(Urun,Adet,Fiyat,Tutar,Saat) VALUES (@Urun,@Adet,@Fiyat,@Tutar,@Saat)";
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@Urun", comboBox2.Text);
                    komut.Parameters.AddWithValue("@Adet", label47.Text);
                    komut.Parameters.AddWithValue("@Fiyat", label13.Text);
                    komut.Parameters.AddWithValue("@Tutar", numericUpDown8.Text);
                    komut.Parameters.AddWithValue("@Saat", label44.Text);
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                }
            }

            else if (numericUpDown9.Enabled == true)
            {
                double fiyat, fiyat2, litre;
                fiyat = double.Parse(numericUpDown9.Value.ToString());
                fiyat2 = Fiyat_eurodizel;
                label47.Text = Convert.ToString(fiyat / fiyat2);
                litre = double.Parse(label47.Text);
                double Keurodizel = Depo_eurodizel - litre - 0.000000001;

                if (Keurodizel < 0)
                {
                    MessageBox.Show("Yetersiz Stok");
                    label47.Text = "_______";
                }

                else
                {
                    Depo_eurodizel = Depo_eurodizel - litre;

                    string sorgu = " INSERT INTO Satıslar(Urun,Adet,Fiyat,Tutar,Saat) VALUES (@Urun,@Adet,@Fiyat,@Tutar,@Saat)";
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@Urun", comboBox2.Text);
                    komut.Parameters.AddWithValue("@Adet", label47.Text);
                    komut.Parameters.AddWithValue("@Fiyat", label12.Text);
                    komut.Parameters.AddWithValue("@Tutar", numericUpDown9.Text);
                    komut.Parameters.AddWithValue("@Saat", label44.Text);
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                }
            }

            else if (numericUpDown10.Enabled == true)
            {
                double fiyat, fiyat2, litre;
                fiyat = double.Parse(numericUpDown10.Value.ToString());
                fiyat2 = Fiyat_lpg;
                label47.Text = Convert.ToString(fiyat / fiyat2);
                litre = double.Parse(label47.Text);
                double Klpg = Depo_lpg - litre - 0.000000001;

                if (Klpg < 0)
                {
                    MessageBox.Show("Yetersiz Stok");
                    label47.Text = "_______";
                }

                else
                {
                    Depo_lpg = Depo_lpg - litre;

                    string sorgu = " INSERT INTO Satıslar(Urun,Adet,Fiyat,Tutar,Saat) VALUES (@Urun,@Adet,@Fiyat,@Tutar,@Saat)";
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@Urun", comboBox2.Text);
                    komut.Parameters.AddWithValue("@Adet", label47.Text);
                    komut.Parameters.AddWithValue("@Fiyat", label11.Text);
                    komut.Parameters.AddWithValue("@Tutar", numericUpDown10.Text);
                    komut.Parameters.AddWithValue("@Saat", label44.Text);
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                }
            }


            depo_bilgileri[0] = Convert.ToString(Depo_benzin95);
            depo_bilgileri[1] = Convert.ToString(Depo_benzin97);
            depo_bilgileri[2] = Convert.ToString(Depo_dizel);
            depo_bilgileri[3] = Convert.ToString(Depo_eurodizel);
            depo_bilgileri[4] = Convert.ToString(Depo_lpg);

            System.IO.File.WriteAllLines(Application.StartupPath + "\\depos.txt", depo_bilgileri);

            txt_depo_bilgi();
            txt_depo_yazici();
            proggressbar_new();
            numeric_kalan();

            numericUpDown6.Value = 0;
            numericUpDown7.Value = 0;
            numericUpDown8.Value = 0;
            numericUpDown9.Value = 0;
            numericUpDown10.Value = 0;

            label38.Text = Depo_benzin95.ToString("N");
            label39.Text = Depo_benzin97.ToString("N");
            label40.Text = Depo_dizel.ToString("N");
            label41.Text = Depo_eurodizel.ToString("N");
            label42.Text = Depo_lpg.ToString("N");

            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = false;
            numericUpDown6.Enabled = false;
            numericUpDown7.Enabled = false;
            numericUpDown8.Enabled = false;
            numericUpDown9.Enabled = false;
            numericUpDown10.Enabled = false;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Fiyat_benzin95 = Fiyat_benzin95 + (Fiyat_benzin95 * Convert.ToDouble(textBox10.Text) / 100);
                fiyat_bilgileri[0] = Convert.ToString(Fiyat_benzin95);
            }
            catch 
            {
                textBox10.Text = "Sayi girin";
            }

            try
            {
                Fiyat_benzin97 = Fiyat_benzin97 + (Fiyat_benzin97 * Convert.ToDouble(textBox9.Text) / 100);
                fiyat_bilgileri[1] = Convert.ToString(Fiyat_benzin97);
            }
            catch
            {
                textBox9.Text = "Sayi girin";
            }

            try
            {
                Fiyat_dizel = Fiyat_dizel + (Fiyat_dizel * Convert.ToDouble(textBox8.Text) / 100);
                fiyat_bilgileri[2] = Convert.ToString(Fiyat_dizel);
            }
            catch
            {
                textBox8.Text = "Sayi girin";
            }

            try
            {
                Fiyat_eurodizel = Fiyat_eurodizel + (Fiyat_eurodizel * Convert.ToDouble(textBox7.Text) / 100);
                fiyat_bilgileri[3] = Convert.ToString(Fiyat_eurodizel);
            }
            catch
            {
                textBox7.Text = "Sayi girin";
            }

            try
            {
                Fiyat_lpg = Fiyat_lpg + (Fiyat_lpg * Convert.ToDouble(textBox6.Text) / 100);
                fiyat_bilgileri[4] = Convert.ToString(Fiyat_lpg);
            }
            catch
            {
                textBox6.Text = "Sayi girin";
            }
            System.IO.File.WriteAllLines(Application.StartupPath + "\\fiyat.txt",fiyat_bilgileri);
            
            txt_fiyatoku();
            txt_fiyatyaz();
            textBox7.Text = " ";
            textBox6.Text = " ";
            textBox8.Text = " ";
            textBox9.Text = " ";
            textBox10.Text = " ";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Benzin 95 Oktan")
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }

            else if (comboBox1.Text == "Benzin 97 Oktan")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }

            else if (comboBox1.Text == "Dizel")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = true;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }

            else if (comboBox1.Text == "Eurodizel")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = true;
                numericUpDown5.Enabled = false;
            }

            else if (comboBox1.Text == "LPG")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = true;
            }
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
            label29.Text = "_______";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Ekle_benzin95 = Convert.ToDouble(textBox1.Text);
                if (1000 < Depo_benzin95 + Ekle_benzin95)
                {
                    textBox1.Text = "Geçerli değerler giriniz.";
                }
                else
                {
                    depo_bilgileri[0] = Convert.ToString(Depo_benzin95 + Ekle_benzin95);
                }
                
            }

            catch
            {

                textBox6.Text = "Sayi Giriniz";

            }



            try
            {
                Ekle_benzin97 = Convert.ToDouble(textBox2.Text);
                if (1000 < Depo_benzin97 + Ekle_benzin97)
                {
                    textBox2.Text = "Geçerli değerler giriniz.";
                }
                else
                {
                    depo_bilgileri[1] = Convert.ToString(Depo_benzin97 + Ekle_benzin97);
                }
            }
            catch
            {

                textBox2.Text = "Sayi Giriniz";

            }


            try
            {
                Ekle_dizel = Convert.ToDouble(textBox3.Text);
                if (1000 < Depo_dizel + Ekle_dizel)
                {
                    textBox3.Text = "Geçerli değerler giriniz.";
                }
                else
                {
                    depo_bilgileri[2] = Convert.ToString(Depo_dizel + Ekle_dizel);
                }
            }



            catch
            {

                textBox3.Text = "Sayi Giriniz";

            }



            try
            {
                Ekle_eurodizel = Convert.ToDouble(textBox4.Text);
                if (1000 < Depo_eurodizel + Ekle_eurodizel)
                {
                    textBox4.Text = "Geçerli değerler giriniz.";
                }
                else
                {
                    depo_bilgileri[3] = Convert.ToString(Depo_eurodizel + Ekle_eurodizel);
                }
            }




            catch
            {

                textBox4.Text = "Sayi Giriniz";

            }



            try
            {
                Ekle_lpg = Convert.ToDouble(textBox5.Text);
                if (1000 < Depo_lpg + Ekle_lpg)
                {
                    textBox5.Text = "Geçerli değerler giriniz.";
                }
                else
                {
                    depo_bilgileri[4] = Convert.ToString(Depo_lpg + Ekle_lpg);
                }
            }




            catch
            {

                textBox5.Text = "Sayı Giriniz";

            }

            System.IO.File.WriteAllLines(Application.StartupPath + "\\depos.txt", depo_bilgileri);
            txt_depo_bilgi();
            txt_depo_yazici();
            proggressbar_new();
            numeric_kalan();

            label38.Text = Depo_benzin95.ToString("N");
            label39.Text = Depo_benzin97.ToString("N");
            label40.Text = Depo_dizel.ToString("N");
            label41.Text = Depo_eurodizel.ToString("N");
            label42.Text = Depo_lpg.ToString("N");


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double kbenzin95, kbenzin97, kdizel, keurodizel, klpg;
            Satis_benzin95 = double.Parse(numericUpDown1.Value.ToString());
            Satis_benzin97 = double.Parse(numericUpDown2.Value.ToString());
            Satis_dizel = double.Parse(numericUpDown3.Value.ToString());
            Satis_eurodizel = double.Parse(numericUpDown4.Value.ToString());
            Satis_lpg = double.Parse(numericUpDown5.Value.ToString());

            if (numericUpDown1.Enabled == true)
            {
                kbenzin95 = Depo_benzin95 - Satis_benzin95 - 0.000000000000001;

                if (kbenzin95 < 0)
                {
                    MessageBox.Show("Yetersiz Stok");
                }

                else 
                {
                    Depo_benzin95 = Depo_benzin95 - Satis_benzin95;
                    label29.Text = Convert.ToString(Fiyat_benzin95 * Satis_benzin95);
                    string sorgu = " INSERT INTO Satıslar(Urun,Adet,Fiyat,Tutar,Saat) VALUES (@Urun,@Adet,@Fiyat,@Tutar,@Saat)";
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@Urun", comboBox1.Text);
                    komut.Parameters.AddWithValue("@Adet", numericUpDown1.Text);
                    komut.Parameters.AddWithValue("@Fiyat", label15.Text);
                    komut.Parameters.AddWithValue("@Tutar", label29.Text);
                    komut.Parameters.AddWithValue("@Saat", label44.Text);
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                }
            }

            else if (numericUpDown2.Enabled == true)
            {
                kbenzin97 = Depo_benzin97 - Satis_benzin97 - 0.0000000000001;

                if (kbenzin97 < 0)
                {
                    MessageBox.Show("Yetersiz Stok");
                }
                else
                {
                    Depo_benzin97 = Depo_benzin97 - Satis_benzin97;
                    label29.Text = Convert.ToString(Fiyat_benzin97 * Satis_benzin97);
                    string sorgu = " INSERT INTO Satıslar(Urun,Adet,Fiyat,Tutar,Saat) VALUES (@Urun,@Adet,@Fiyat,@Tutar,@Saat)";
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@Urun", comboBox1.Text);
                    komut.Parameters.AddWithValue("@Adet", numericUpDown2.Text);
                    komut.Parameters.AddWithValue("@Fiyat", label14.Text);
                    komut.Parameters.AddWithValue("@Tutar", label29.Text);
                    komut.Parameters.AddWithValue("@Saat", label44.Text);
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                }
            }

            else if (numericUpDown3.Enabled == true)
            {
                kdizel = Depo_dizel - Satis_dizel - 0.0000000000001;

                if (kdizel < 0)
                {
                    MessageBox.Show("Yetersiz Stok");
                }

                else
                {
                    Depo_dizel = Depo_dizel - Satis_dizel;
                    label29.Text = Convert.ToString(Fiyat_dizel * Satis_dizel);
                    string sorgu = " INSERT INTO Satıslar(Urun,Adet,Fiyat,Tutar,Saat) VALUES (@Urun,@Adet,@Fiyat,@Tutar,@Saat)";
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@Urun", comboBox1.Text);
                    komut.Parameters.AddWithValue("@Adet", numericUpDown3.Text);
                    komut.Parameters.AddWithValue("@Fiyat", label13.Text);
                    komut.Parameters.AddWithValue("@Tutar", label29.Text);
                    komut.Parameters.AddWithValue("@Saat", label44.Text);
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                }
            }

            else if (numericUpDown4.Enabled == true)
            {
                keurodizel = Depo_eurodizel - Satis_eurodizel - 0.00000000001;

                if (keurodizel < 0)
                {
                    MessageBox.Show("Yetersiz Stok");
                }

                else 
                {
                    Depo_eurodizel = Depo_eurodizel - Satis_eurodizel;
                    label29.Text = Convert.ToString(Fiyat_eurodizel * Satis_eurodizel);
                    string sorgu = " INSERT INTO Satıslar(Urun,Adet,Fiyat,Tutar,Saat) VALUES (@Urun,@Adet,@Fiyat,@Tutar,@Saat)";
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@Urun", comboBox1.Text);
                    komut.Parameters.AddWithValue("@Adet", numericUpDown4.Text);
                    komut.Parameters.AddWithValue("@Fiyat", label12.Text);
                    komut.Parameters.AddWithValue("@Tutar", label29.Text);
                    komut.Parameters.AddWithValue("@Saat", label44.Text);
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                }
            }

            else if (numericUpDown5.Enabled == true)
            {
                klpg = Depo_lpg - Satis_lpg - 0.00000000001;

                if(klpg < 0)
                {
                    MessageBox.Show("Yetersiz Stok");
                }

                else
                {
                    Depo_lpg = Depo_lpg - Satis_lpg;
                    label29.Text = Convert.ToString(Fiyat_lpg * Satis_lpg);
                    string sorgu = " INSERT INTO Satıslar(Urun,Adet,Fiyat,Tutar,Saat) VALUES (@Urun,@Adet,@Fiyat,@Tutar,@Saat)";
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@Urun", comboBox1.Text);
                    komut.Parameters.AddWithValue("@Adet", numericUpDown5.Text);
                    komut.Parameters.AddWithValue("@Fiyat", label11.Text);
                    komut.Parameters.AddWithValue("@Tutar", label29.Text);
                    komut.Parameters.AddWithValue("@Saat", label44.Text);
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                }
            }

            depo_bilgileri[0] = Convert.ToString(Depo_benzin95);
            depo_bilgileri[1] = Convert.ToString(Depo_benzin97);
            depo_bilgileri[2] = Convert.ToString(Depo_dizel);
            depo_bilgileri[3] = Convert.ToString(Depo_eurodizel);
            depo_bilgileri[4] = Convert.ToString(Depo_lpg);

            System.IO.File.WriteAllLines(Application.StartupPath + "\\depos.txt", depo_bilgileri);

            txt_depo_bilgi();
            txt_depo_yazici();
            proggressbar_new();
            numeric_kalan();

            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;

            label38.Text = Depo_benzin95.ToString("N");
            label39.Text = Depo_benzin97.ToString("N");
            label40.Text = Depo_dizel.ToString("N");
            label41.Text = Depo_eurodizel.ToString("N");
            label42.Text = Depo_lpg.ToString("N");

            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = false;
            numericUpDown6.Enabled = false;
            numericUpDown7.Enabled = false;
            numericUpDown8.Enabled = false;
            numericUpDown9.Enabled = false;
            numericUpDown10.Enabled = false;
        }

        string[] depo_bilgileri;
        string[] fiyat_bilgileri;

        private void txt_depo_bilgi()
        {
            depo_bilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\depos.txt");
            Depo_benzin95 = Convert.ToDouble(depo_bilgileri[0]);
            Depo_benzin97 = Convert.ToDouble(depo_bilgileri[1]);
            Depo_dizel = Convert.ToDouble(depo_bilgileri[2]);
            Depo_eurodizel = Convert.ToDouble(depo_bilgileri[3]);
            Depo_lpg = Convert.ToDouble(depo_bilgileri[4]);
        }
        private void txt_depo_yazici()
        {
            label6.Text = Depo_benzin95.ToString("N");
            label7.Text = Depo_benzin97.ToString("N");
            label8.Text = Depo_dizel.ToString("N");
            label9.Text = Depo_eurodizel.ToString("N");
            label10.Text = Depo_lpg.ToString("N");

        }
        private void txt_fiyatoku()
        {
            fiyat_bilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\fiyat.txt");
            Fiyat_benzin95 = Convert.ToDouble(fiyat_bilgileri[0]);
            Fiyat_benzin97 = Convert.ToDouble(fiyat_bilgileri[1]);
            Fiyat_dizel = Convert.ToDouble(fiyat_bilgileri[2]);
            Fiyat_eurodizel = Convert.ToDouble(fiyat_bilgileri[3]);
            Fiyat_lpg = Convert.ToDouble(fiyat_bilgileri[4]);
        }

        private void txt_fiyatyaz()
        {
            label15.Text = Fiyat_benzin95.ToString("N");
            label14.Text = Fiyat_benzin97.ToString("N");
            label13.Text = Fiyat_dizel.ToString("N");
            label12.Text = Fiyat_eurodizel.ToString("N");
            label11.Text = Fiyat_lpg.ToString("N");

        }
        private void proggressbar_new()
        {
            progressBar1.Value = Convert.ToInt16(Depo_benzin95);
            progressBar2.Value = Convert.ToInt16(Depo_benzin97);
            progressBar3.Value = Convert.ToInt16(Depo_dizel);
            progressBar4.Value = Convert.ToInt16(Depo_eurodizel);
            progressBar5.Value = Convert.ToInt16(Depo_lpg);
        }
        private void numeric_kalan()
        {
            numericUpDown1.Maximum = decimal.Parse(Depo_benzin95.ToString());
            numericUpDown2.Maximum = decimal.Parse(Depo_benzin97.ToString());
            numericUpDown3.Maximum = decimal.Parse(Depo_dizel.ToString());
            numericUpDown4.Maximum = decimal.Parse(Depo_eurodizel.ToString());
            numericUpDown5.Maximum = decimal.Parse(Depo_lpg.ToString());
        }

        private void SatışEkranı_Load(object sender, EventArgs e)
        {
            timer1.Start();
            UrunGetir();
            listView1.Columns.Add("Ürün", 75);
            listView1.Columns.Add("Adet", 75);
            listView1.Columns.Add("Fiyat", 75);
            listView1.Columns.Add("Tutar", 75);
            listView1.Width = 305;
            progressBar1.Maximum = 1000;
            progressBar2.Maximum = 1000;
            progressBar3.Maximum = 1000;
            progressBar4.Maximum = 1000;
            progressBar5.Maximum = 1000;

            txt_depo_bilgi();
            txt_depo_yazici();
            txt_fiyatoku();
            txt_fiyatyaz();
            proggressbar_new();
            numeric_kalan();

            string[] yakit_cesitleri = { "Benzin 95 Oktan", "Benzin 97 Oktan", "Dizel", "Eurodizel", "LPG" };

            comboBox1.Items.AddRange(yakit_cesitleri);

            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = false;

            numericUpDown6.Maximum = 5000;
            numericUpDown7.Maximum = 5000;
            numericUpDown8.Maximum = 5000;
            numericUpDown9.Maximum = 5000;
            numericUpDown10.Maximum = 5000;

            numericUpDown1.DecimalPlaces = 2;
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown3.DecimalPlaces = 2;
            numericUpDown4.DecimalPlaces = 2;
            numericUpDown5.DecimalPlaces = 2;
            numericUpDown6.DecimalPlaces = 2;
            numericUpDown7.DecimalPlaces = 2;
            numericUpDown8.DecimalPlaces = 2;
            numericUpDown9.DecimalPlaces = 2;
            numericUpDown10.DecimalPlaces = 2;

            numericUpDown1.Increment = 0.1M;
            numericUpDown2.Increment = 0.1M;
            numericUpDown3.Increment = 0.1M;
            numericUpDown4.Increment = 0.1M;
            numericUpDown5.Increment = 0.1M;
            numericUpDown6.Increment = 0.1M;
            numericUpDown7.Increment = 0.1M;
            numericUpDown8.Increment = 0.1M;
            numericUpDown9.Increment = 0.1M;
            numericUpDown10.Increment = 0.1M;


            label38.Text = Depo_benzin95.ToString("N");
            label39.Text = Depo_benzin97.ToString("N");
            label40.Text = Depo_dizel.ToString("N");
            label41.Text = Depo_eurodizel.ToString("N");
            label42.Text = Depo_lpg.ToString("N");

            label47.Text = "_______";
            label29.Text = "_______";
        }
    }
}
