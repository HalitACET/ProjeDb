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
    public partial class Form5 : Form
    {
        VideoTasiyici videon;
        public Form5(VideoTasiyici video)
        {
            InitializeComponent();
            videon = video;
        
           
        }
        
        private void Form5_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            BilgiGetir getir = new BilgiGetir();
            dt = getir.videobilgileri(videon.video.ToString());
            lblHafta.Text = dt.Rows[0]["D_Hafta"].ToString();
            lblVideo.Text = dt.Rows[0]["D_Video"].ToString();
            lblDers.Text = dt.Rows[0]["D_Adi"].ToString();
            lblOgrenci.Text = dt.Rows[0]["O_Tc_Kimlik"].ToString();
            label5.Text = dt.Rows[0]["D_VideoKod"].ToString();





            axWindowsMediaPlayer1.URL = lblVideo.Text;
            axWindowsMediaPlayer1.settings.autoStart = true;
            axWindowsMediaPlayer1.Ctlcontrols.play();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //openFileDialog1.Filter = "(mp3,wav,mp4,mov,wmv,mpg)|*.mp3;*.wav;*.mp4;*.mov;*.wmv;*.mpg|all files|*.*";
            //openFileDialog1.ShowDialog();

           
            //MessageBox.Show(openFileDialog1.FileName);
            //axWindowsMediaPlayer1.URL = openFileDialog1.FileName;
            //axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 8)
            {
                Form6 frm = new Form6(label5.Text);
                frm.Show();
            }
            
        }
    }
}
