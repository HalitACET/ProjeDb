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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public string tc;
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-6CRR4TF\SQLEXPRESS;Initial Catalog=ProjeDb;Integrated Security=True");
        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text = "Hoşgeldin: "+tc;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM TblOgrenci_Dersleri  inner join TblDersler on TblDersler.D_Kodu=TblOgrenci_Dersleri.D_Kodu WHERE O_Tc_Kimlik=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", tc);
            dataGridView1.Columns.Add("D_Kodu","Ders Kodu");
            dataGridView1.Columns.Add("Adi", "Ders Adı");
            
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
               // label2.Text += dr["D_Kodu"];
                dataGridView1.Rows.Add(dr["D_Kodu"],dr["D_Adi"]);
            }
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void label3_TextChanged(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.yaz = label3.Text;
            frm.Show();
            this.Hide();
        }
    }
}
