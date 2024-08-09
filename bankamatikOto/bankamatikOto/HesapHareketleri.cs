using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bankamatikOto
{
    public partial class HesapHareketleri : Form
    {
        public HesapHareketleri()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(" server= . ; initial catalog= bankamatik; integrated security = sspi");

        private void HesapHareketleri_Load(object sender, EventArgs e)
        {
            label2.Text = Form1.adSoyad;
            label3.Text = Form1.msID.ToString();

            SqlCommand komut = new SqlCommand(" select * from hareketler where musteriID= @p1", con );
            komut.Parameters.AddWithValue("@p1", Form1.msID); 
            SqlDataAdapter dr = new SqlDataAdapter(komut );
              
            DataTable tablo = new DataTable();
            dr.Fill(tablo);
            dataGridView1.DataSource = tablo;

        }
    }
}
