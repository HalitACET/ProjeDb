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
    public partial class Form6 : Form
    {
        string yol;
        public Form6(string gvideo)
        {
            InitializeComponent();
            yol = gvideo;
        }
        
        private void Form6_Load(object sender, EventArgs e)
        {
            label1.Text = yol;
            VT bgl = new VT();
            bgl.baglanti.Open();
            DBcrud sorubul = new DBcrud();
            
            SqlDataReader dr = sorubul.soru(label1.Text);

            while (dr.Read())
            {
                label2.Text = dr["Soru"].ToString();
                radioButton1.Text = dr["Sec1"].ToString();
                radioButton2.Text = dr["Sec2"].ToString();
                radioButton3.Text = dr["Sec3"].ToString();
                radioButton4.Text = dr["Sec4"].ToString();
                radioButton5.Text = dr["Sec5"].ToString();
            }
            bgl.baglanti.Close();
        }
    }
}
