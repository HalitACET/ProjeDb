using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace _29._03._2021_1
{
    class DBcrud
    {
        VT baglan = new VT();
        public bool kayit(Ogrenci ogr)
        {
            baglan.baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO TblOgrenciler (O_Tc_Kimlik,O_Ad,O_Soyad,O_Sifre,[O_E-mail],O_Bolum,O_Sinif) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)",baglan.baglanti);
            komut.Parameters.AddWithValue("@p1",ogr.TC);
            komut.Parameters.AddWithValue("@p2",ogr.ad);
            komut.Parameters.AddWithValue("@p3",ogr.soyad);
            komut.Parameters.AddWithValue("@p4",ogr.sifre);
            komut.Parameters.AddWithValue("@p5",ogr.email);
            komut.Parameters.AddWithValue("@p6",ogr.bolum);
            komut.Parameters.AddWithValue("@p7",ogr.sinif);
            int durum = komut.ExecuteNonQuery();
            baglan.baglanti.Close();
            if (durum==0)
            {
                return false;
            }
            return true;
        }

        public bool uyevarmi(string gtc)
        {
            baglan.baglanti.Open();

            SqlCommand komut = new SqlCommand("Select Count(*) from TblOgrenciler Where O_Tc_Kimlik=@p1",baglan.baglanti);
            komut.Parameters.AddWithValue("@p1",gtc);
            int ks = Convert.ToInt16(komut.ExecuteScalar());
            if (ks>0)
            {
                return true;
            }
            baglan.baglanti.Close();
            return false;

        }

        public DataTable soru(string videokod)
        {
            baglan.baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TblVideo_Soruları where D_VideoKod=@p1",baglan.baglanti);
            komut.Parameters.AddWithValue("@p1",videokod);
            DataTable dt = new DataTable();
            dt.Load(komut.ExecuteReader());
            baglan.baglanti.Close();
            return dt;
        }
        public void Darttir(string Vkod)
        {
         baglan.baglanti.Open();

            SqlCommand komut2 = new SqlCommand("Select DogruSay From TblDers_Video_Istatistik Where D_VideoKod=@p1", baglan.baglanti);
            komut2.Parameters.AddWithValue("@p1", Vkod);
            int ks = Convert.ToInt16(komut2.ExecuteScalar());
            ks++;

            SqlCommand komut = new SqlCommand("Update TblDers_Video_Istatistik set DogruSay=@p2 Where D_VideoKod=@p1", baglan.baglanti);
            komut.Parameters.AddWithValue("@p1", Vkod);
            komut.Parameters.AddWithValue("@p2",ks);
            komut.ExecuteNonQuery();
            baglan.baglanti.Close();   
            
        }
        public void Yarttir(string Vkod)
        {
            baglan.baglanti.Open();

            SqlCommand komut2 = new SqlCommand("Select YanlisSay From TblDers_Video_Istatistik Where D_VideoKod=@p1",baglan.baglanti);
            komut2.Parameters.AddWithValue("@p1",Vkod);
            int ks=Convert.ToInt16( komut2.ExecuteScalar());
            ks++;
            SqlCommand komut = new SqlCommand("Update TblDers_Video_Istatistik set YanlisSay=@p2 Where D_VideoKod=@p1", baglan.baglanti);
            komut.Parameters.AddWithValue("@p2",ks);
            komut.Parameters.AddWithValue("@p1", Vkod);
            komut.ExecuteNonQuery();
            baglan.baglanti.Close();

        }

        public void ODarttir(string tc,string DKod,string Vkod)
        {
            baglan.baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert into TblOgrenci_Video_Istatistik values (@p1,@p2,@p3,1,0)", baglan.baglanti);
            komut.Parameters.AddWithValue("@p1",tc);
            komut.Parameters.AddWithValue("@p2",DKod);
            komut.Parameters.AddWithValue("@p3",Vkod);
            komut.ExecuteNonQuery();
            baglan.baglanti.Close();

        }

        public void OYarttir(string tc,string DKod,string Vkod)
        {
            
            baglan.baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert into TblOgrenci_Video_Istatistik values (@p1,@p2,@p3,0,1)", baglan.baglanti);
            komut.Parameters.AddWithValue("@p1",tc);
            komut.Parameters.AddWithValue("@p2",DKod);
            komut.Parameters.AddWithValue("@p3",Vkod);
            komut.ExecuteNonQuery();
            baglan.baglanti.Close();

        }

        public bool Cevapvarmi(string gtc)
        {
            baglan.baglanti.Open();

            SqlCommand komut = new SqlCommand("Select Count(*) from TblOgrenci_Video_Istatistik Where O_Tc_Kimlik=@p1", baglan.baglanti);
            komut.Parameters.AddWithValue("@p1", gtc);
            int ks = Convert.ToInt16(komut.ExecuteScalar());
            if (ks > 0)
            {
                return true;
            }
            baglan.baglanti.Close();
            return false;

         }
        }
    }
