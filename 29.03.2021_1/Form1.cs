﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _29._03._2021_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-6CRR4TF\SQLEXPRESS;Initial Catalog=ProjeDb;Integrated Security=True");
        public void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TblOgrenciler", baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void temizle()
        {
            mskTC.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtSifre.Text = "";
            txtEmail.Text = "";
            cmbBolum.Text = "";
            cmbSinif.Text = "";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
          
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO TblOgrenciler (O_Tc_Kimlik,O_Ad,O_Soyad,O_Sifre,[O_E-mail],O_Bolum,O_Sinif) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)",baglanti);
            komut.Parameters.AddWithValue("@p1",mskTC.Text);
            komut.Parameters.AddWithValue("@p2",txtAd.Text);
            komut.Parameters.AddWithValue("@p3",txtSoyad.Text);
            komut.Parameters.AddWithValue("@p4",txtSifre.Text);
            komut.Parameters.AddWithValue("@p5",txtEmail.Text);
            komut.Parameters.AddWithValue("@p6",cmbBolum.Text);
            komut.Parameters.AddWithValue("@p7",cmbSinif.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Eklendi...");
            listele();
            temizle();
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
