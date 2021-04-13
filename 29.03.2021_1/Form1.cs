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

namespace _29._03._2021_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-6CRR4TF\SQLEXPRESS;Initial Catalog=ProjeDb;Integrated Security=True");
       
        public void temizle()
        {
            textBox1.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtSifre.Text = "";
            txtEmail.Text = "";
            cmbBolum.Text = "";
            textBox2.Text = "";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select Ad from TblBolumler",baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbBolum.Items.Add(dr[0].ToString());
            }
            baglanti.Close();


          
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            DBcrud kayit = new DBcrud();
            Ogrenci ogrenci = new Ogrenci();

            
            bool uyemi= kayit.uyevarmi(textBox1.Text);
            if (uyemi==false)
            {
                ogrenci.ad = txtAd.Text;
                ogrenci.soyad = txtSoyad.Text;
                ogrenci.TC = textBox1.Text;
                ogrenci.sifre = txtSifre.Text;
                ogrenci.email = txtEmail.Text;
                ogrenci.bolum = cmbBolum.Text;
                ogrenci.sinif = textBox2.Text;

                bool kontrol = kayit.kayit(ogrenci);
                if (kontrol == true)
                {
                    MessageBox.Show("Kayıt Eklendi...");
                    temizle();
                    Form2 frm = new Form2();
                    frm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Zaten Kayıt Var!");
                Form2 frm = new Form2();
                frm.Show();
                this.Hide();
            }

            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
