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

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btn);
            btn.Text = "Video İzle";
            btn.Name = "İzle";
            btn.UseColumnTextForButtonValue = true;

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr["D_Kodu"], dr["D_Hafta"], dr["D_No"], dr["D_VideoKod"]);

            }
            baglanti.Close();

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            VideoTasiyici video = new VideoTasiyici();
            video.video= dataGridView1.CurrentRow.Cells[3].Value.ToString();

            Form5 frm5 = new Form5(video,label1.Text);
            
            frm5.Show();
            this.Hide();

           
        }
    }
}
