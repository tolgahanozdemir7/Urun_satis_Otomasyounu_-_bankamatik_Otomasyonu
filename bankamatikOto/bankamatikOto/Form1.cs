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

// Bankamatik Otomasyonu 
// Sadık ŞAHİN - Bilgisayar Mühendisi

namespace bankamatikOto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(" server= .; initial catalog= bankamatik; integrated security = sspi");

        public static string adSoyad = "";
        public static int msID = 1;
        public static float bakiye = 0.0f; 

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool girisKontrolu = false;

            if (radioButton1.Checked)
            {
                if (txtKulAdi.Text == "admin" && txtParola.Text == "123")
                {
                    YetkiliIslem y1 = new YetkiliIslem();

                    this.Hide();
                    y1.Show();

                }
                else
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı/Parola ! ", "Hatalı Giriş Denemesi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                con.Close(); 
            }

            else
            {
                SqlCommand komut = new SqlCommand("select * from Musteriler where tcNo=@p1 and sifre= @p2", con);
                con.Open();
                komut.Parameters.AddWithValue("@p1", txtKulAdi.Text);
                komut.Parameters.AddWithValue("@p2", txtParola.Text);

                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {

                    adSoyad = dr["AdSoyad"].ToString();
                    msID = int.Parse(dr["ID"].ToString());
                    bakiye = float.Parse(dr["bakiye"].ToString()); 
                    girisKontrolu = true;
                }

                con.Close();

                if (girisKontrolu)
                {
                    girisKontrolu = false;
                    MusteriIslem mi = new MusteriIslem();
                    this.Hide();
                    mi.Show();
                }
                else
                    MessageBox.Show("Hatalı KullanıcıAdı/TcNo veya Parola ", "Hatalı Giriş Denemesi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            txtKulAdi.Text = "";
            txtParola.Text = "";

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifremiUnuttum su = new SifremiUnuttum();
            su.Show(); 

        }
    }
}
