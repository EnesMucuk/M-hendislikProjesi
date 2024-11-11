namespace MühendislikProjesi
{
    partial class PersonelPaneli
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ÜrünP = new System.Windows.Forms.Button();
            this.ÇıkışP = new System.Windows.Forms.Button();
            this.MüşteriP = new System.Windows.Forms.Button();
            this.PersonelP = new System.Windows.Forms.Button();
            this.SatışP = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ÜrünP
            // 
            this.ÜrünP.BackColor = System.Drawing.Color.White;
            this.ÜrünP.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ÜrünP.Location = new System.Drawing.Point(0, 36);
            this.ÜrünP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ÜrünP.Name = "ÜrünP";
            this.ÜrünP.Size = new System.Drawing.Size(148, 29);
            this.ÜrünP.TabIndex = 0;
            this.ÜrünP.Text = "Ürün Bilgileri";
            this.ÜrünP.UseVisualStyleBackColor = false;
            this.ÜrünP.Click += new System.EventHandler(this.button2_Click);
            // 
            // ÇıkışP
            // 
            this.ÇıkışP.BackColor = System.Drawing.Color.White;
            this.ÇıkışP.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ÇıkışP.Location = new System.Drawing.Point(43, 221);
            this.ÇıkışP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ÇıkışP.Name = "ÇıkışP";
            this.ÇıkışP.Size = new System.Drawing.Size(42, 50);
            this.ÇıkışP.TabIndex = 0;
            this.ÇıkışP.Text = "Çıkış";
            this.ÇıkışP.UseVisualStyleBackColor = false;
            this.ÇıkışP.Click += new System.EventHandler(this.button4_Click);
            // 
            // MüşteriP
            // 
            this.MüşteriP.BackColor = System.Drawing.Color.White;
            this.MüşteriP.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MüşteriP.Location = new System.Drawing.Point(0, 69);
            this.MüşteriP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MüşteriP.Name = "MüşteriP";
            this.MüşteriP.Size = new System.Drawing.Size(148, 28);
            this.MüşteriP.TabIndex = 0;
            this.MüşteriP.Text = "Müşteriler ve Satışlar";
            this.MüşteriP.UseVisualStyleBackColor = false;
            this.MüşteriP.Click += new System.EventHandler(this.button5_Click);
            // 
            // PersonelP
            // 
            this.PersonelP.BackColor = System.Drawing.Color.White;
            this.PersonelP.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.PersonelP.Location = new System.Drawing.Point(0, 166);
            this.PersonelP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PersonelP.Name = "PersonelP";
            this.PersonelP.Size = new System.Drawing.Size(82, 50);
            this.PersonelP.TabIndex = 0;
            this.PersonelP.Text = "Personel Bilgisi";
            this.PersonelP.UseVisualStyleBackColor = false;
            this.PersonelP.Click += new System.EventHandler(this.button6_Click);
            // 
            // SatışP
            // 
            this.SatışP.BackColor = System.Drawing.Color.White;
            this.SatışP.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.SatışP.Location = new System.Drawing.Point(2, 0);
            this.SatışP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SatışP.Name = "SatışP";
            this.SatışP.Size = new System.Drawing.Size(146, 32);
            this.SatışP.TabIndex = 0;
            this.SatışP.Text = "Satış İşlemleri";
            this.SatışP.UseVisualStyleBackColor = false;
            this.SatışP.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.SatışP);
            this.panel2.Controls.Add(this.MüşteriP);
            this.panel2.Controls.Add(this.ÇıkışP);
            this.panel2.Controls.Add(this.ÜrünP);
            this.panel2.Controls.Add(this.PersonelP);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(150, 400);
            this.panel2.TabIndex = 3;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = global::MühendislikProjesi.Properties.Resources._1892509_200;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(2, 221);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 50);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Location = new System.Drawing.Point(164, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(681, 400);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // PersonelPaneli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(842, 400);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PersonelPaneli";
            this.Text = "PersonelPaneli";
            this.Load += new System.EventHandler(this.PersonelPaneli_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ÜrünP;
        private System.Windows.Forms.Button ÇıkışP;
        private System.Windows.Forms.Button MüşteriP;
        private System.Windows.Forms.Button PersonelP;
        private System.Windows.Forms.Button SatışP;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
    }
}