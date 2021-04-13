using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace _29._03._2021_1
{
    class BilgiGetir
    {
        VT vt = new VT();
        public DataTable videobilgileri(string video)
        {
            vt.baglanti.Open();
            DataTable dt = new DataTable();
            SqlCommand komut = new SqlCommand("Select * from TblDers_Video inner join TblDersler on TblDersler.D_Kodu=TblDers_Video.D_Kodu inner join TblOgrenci_Dersleri on TblOgrenci_Dersleri.D_Kodu=TblDers_Video.D_Kodu inner join TblVideolar on TblVideolar.VideoKod=TblDers_Video.D_VideoKod Where D_VideoKod=@p1", vt.baglanti);
            komut.Parameters.AddWithValue("@p1",video);
            dt.Load(komut.ExecuteReader());
            vt.baglanti.Close();
            return dt;
            
        }
    }
}
