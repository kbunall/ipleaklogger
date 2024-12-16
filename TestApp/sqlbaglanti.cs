using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
using TestApp.Controllers;
using System.Collections.Generic;

namespace TestApp
{
    public class SqlBaglanti
    {
        private string connectionString = "Data Source=BIDB255;Initial Catalog=gsb_ip_aciklik;User ID=sa;Password=123;";

        public void KayitEkle(string departman, string ipadresi, string aciklik, string kullanici, string aciklama)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO Tbl_Kayit (departman, ipadresi, aciklik, kullanici, aciklama) VALUES (@departman, @ipadresi, @aciklik, @kullanici, @aciklama)", conn))
                {
                    command.Parameters.AddWithValue("@departman", departman);
                    command.Parameters.AddWithValue("@ipadresi", ipadresi);
                    command.Parameters.AddWithValue("@aciklik", aciklik);
                    command.Parameters.AddWithValue("@kullanici", kullanici);
                    command.Parameters.AddWithValue("@aciklama", aciklama);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Kayıt başarıyla eklendi.");
                }
                conn.Close();
            }
        }

        public List<verisorgula> GetirVeriler(string ip)
        {
            List<verisorgula> veriler = new List<verisorgula>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Tbl_Kayit WHERE ipadresi = @ip", conn))
                {
                    command.Parameters.AddWithValue("@ip", ip);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            veriler.Add(new verisorgula
                            {
                                departman = reader["departman"].ToString(),
                                ipadresi = reader["ipadresi"].ToString(),
                                aciklik = reader["aciklik"].ToString(),
                                kullanici = reader["kullanici"].ToString(),
                                aciklama = reader["aciklama"].ToString()
                            });
                        }
                    }
                }
                conn.Close();
            }
            return veriler;
        }

        public class verisorgula
        {
            public string departman { get; set; }
            public string ipadresi { get; set; }
            public string aciklik { get; set; }
            public string kullanici { get; set; }
            public string aciklama { get; set; }
        }
    }
}




//{
//    public class sqlbaglanti
//{
//    public SqlConnection baglanti()
//    {

//        SqlConnection conn = new SqlConnection("Data Source=BIDB255;Initial Catalog=gsb_ip_aciklik;User ID=sa;Password=***********;Trust Server Certificate=True");
//        conn.Open();

//        SqlCommand command = new SqlCommand("Select ipadresi from [Tbl_Kayit] ", conn);
//        command.Parameters.AddWithValue("@zip", "india");
//        // int result = command.ExecuteNonQuery();
//        using (SqlDataReader reader = command.ExecuteReader())
//        {
//            if (reader.Read())
//            {
//                Console.WriteLine(String.Format("{0}", reader["id"]));
//            }
//        }
//        return null;


//    }


//}
//}
