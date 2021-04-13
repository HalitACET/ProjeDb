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
        string Vkod;
        public Form6(string gvideokod)
        {
            InitializeComponent();
            Vkod = gvideokod;
        }
        
        private void Form6_Load(object sender, EventArgs e)
        {
            label1.Text = Vkod;
          
           
            DBcrud sorubul = new DBcrud();

            DataTable dt = sorubul.soru(label1.Text);

           
            
                label2.Text = dt.Rows[0]["Soru"].ToString();
                radioButton1.Text = dt.Rows[0]["Sec1"].ToString();
                radioButton2.Text = dt.Rows[0]["Sec2"].ToString();
                radioButton3.Text = dt.Rows[0]["Sec3"].ToString();
                radioButton4.Text = dt.Rows[0]["Sec4"].ToString();
                radioButton5.Text = dt.Rows[0]["Sec5"].ToString();
            
           


            
        }
    }
}
