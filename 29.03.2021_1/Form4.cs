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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public string yaz;
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-6CRR4TF\SQLEXPRESS;Initial Catalog=ProjeDb;Integrated Security=True");
        private void Form4_Load(object sender, EventArgs e)
        {
            label1.Text = yaz;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM TblDers_Video WHERE D_Kodu=@p1",baglanti);
            komut.Parameters.AddWithValue("@p1",yaz);
            SqlDataReader dr = komut.ExecuteReader();
            dataGridView1.Columns.Add("D_Kodu","Ders Kodu");
            dataGridView1.Columns.Add("D_Hafta", "Dersin Haftası");
            dataGridView1.Columns.Add("D_No", "Dersin Numarası");
            dataGridView1.Columns.Add("D_Video", "Dersin Videosu");
            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr["D_Kodu"], dr["D_Hafta"], dr["D_No"], dr["D_Video"]);
            }
            baglanti.Close();
        }
    }
}
