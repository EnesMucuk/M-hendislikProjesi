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
    public partial class İstasyonBilgileri : Form
    {
        public İstasyonBilgileri()
        {
            InitializeComponent();
        }

        private void İstasyonBilgileri_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label10.Text = DateTime.Now.ToString();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
