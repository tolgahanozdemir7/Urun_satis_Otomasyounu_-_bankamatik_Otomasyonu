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


namespace bankamatikOto
{
    public partial class MusteriEkle : Form
    {

        public MusteriEkle()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(" server= .; initial catalog= bankamatik; integrated security = sspi");


        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into musteriler ( tcNo, adSoyad, adres, telefon, sifre,  bakiye, durum) values (@p1, @p2, @p3, @p4, @p5, @p6, @p7 )", con);
            komut.Parameters.AddWithValue("@p1", txtTc.Text);
            komut.Parameters.AddWithValue("@p2", txtAdS.Text);
            komut.Parameters.AddWithValue("@p3", txtAdr.Text);
            komut.Parameters.AddWithValue("@p4", mtxtTel.Text);
            komut.Parameters.AddWithValue("@p5", txtTc.Text);
            komut.Parameters.AddWithValue("@p6", mtxtBakiye.Text  );
            komut.Parameters.AddWithValue("@p7", 1);

            if (txtTc.Text =="" || txtAdS.Text == "" || txtAdr.Text == "" || mtxtTel.Text == "" || mtxtBakiye.Text ==""  )
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz !", "Eksik Kayıt Hatası ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                con.Open();

                komut.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Yeni müşteri kaydı tamam ", "Müşteri Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTc.Text = "";
                txtAdS.Text = "";
                txtAdr.Text = "";
                mtxtTel.Text = "";
                mtxtBakiye.Text = "";

            }

        }

        private void MusteriEkle_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            YetkiliIslem yi = new YetkiliIslem();
            yi.Show();
            this.Close(); 
        }
    }
}
