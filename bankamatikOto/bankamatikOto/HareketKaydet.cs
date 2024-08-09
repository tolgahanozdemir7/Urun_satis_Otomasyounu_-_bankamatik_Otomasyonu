using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; 


namespace bankamatikOto
{
    internal class HareketKaydet
    {
        
        public static void kaydet( int mID, string islem )
        {
            SqlConnection con = new SqlConnection(" server= . ; initial catalog= bankamatik; integrated security = sspi");

            SqlCommand komut = new SqlCommand(" insert into hareketler (musteriID, islem, tarih ) values (@p1, @p2, @p3)  ", con );
            con.Open();
            komut.Parameters.AddWithValue("@p1", mID);
            komut.Parameters.AddWithValue("@p2",  islem  );
            komut.Parameters.AddWithValue("@p3", DateTime.Now  );
            komut.ExecuteNonQuery();
            con.Close(); 
        }
    }
}
