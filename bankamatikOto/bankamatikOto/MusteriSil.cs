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
    public partial class MusteriSil : Form
    {
        public MusteriSil()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(" server= . ; initial catalog= bankamatik; integrated security = sspi");

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from  musteriler where ID= @p1 or tcNo= @p2  ", con);
            komut.Parameters.AddWithValue("@p1", mtxtID.Text);
            komut.Parameters.AddWithValue("@p2", mtxtID.Text);


            con.Open();
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                txtID.Text = dr["ID"].ToString();
                txtTc.Text = dr["tcNo"].ToString();
                txtAdS.Text = dr["adSoyad"].ToString();
                txtAdr.Text = dr["adres"].ToString();
                txtDurum.Text = dr["durum"].ToString();

                mtxtTel.Text = dr["telefon"].ToString();

                txtBakiye.Text = dr["bakiye"].ToString();
            }
            else
            {
                MessageBox.Show(mtxtID.Text + " Numaralı Kayıt Bulunamadı !", "Kayıt Arama", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtxtID.Text = "";
                txtTc.Text = "";
                txtAdr.Text = "";
                txtAdS.Text = "";
                txtBakiye.Text = "";
                mtxtTel.Text = "";
                txtID.Text = "";
                txtDurum.Text = "";


            }
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //SqlCommand komut = new SqlCommand("delete musteriler where ID= @p1  ", con); // ilişkini kayıtlar silinirken hata alıyoruz..
            SqlCommand komut = new SqlCommand("update musteriler set durum=0 where ID= @p1 and durum=1  ", con);

            komut.Parameters.AddWithValue("@p1", txtID.Text);

            if (mtxtID.Text == ""  )
            {
                MessageBox.Show("Lütfen Silmek İstediginiz Kişinin Numarası / TcNo giriniz !", "Eksik Kayıt Hatası ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult dr =  MessageBox.Show("Müşteri Kaydını Silmek İstediğinize Emin misiniz ? ", "Kayıt Silme Ekranı ", MessageBoxButtons.YesNo,  MessageBoxIcon.Information );
                if ( dr == DialogResult.No     )
                {
                    MessageBox.Show("Silme İşlemi İptal Edildi ", "Kayıt Silme");
                }
                else
                {
                    con.Open();

                    int sonuc= komut.ExecuteNonQuery();
                    con.Close();
                    if( sonuc==1)
                    MessageBox.Show("Müşteri kaydı silindi ", "Müşteri Kaydı Silme ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Müşteri kaydı daha öncesinden silinmiş veya pasif edilmiş durum olduğu için tekrar işlem yapılamadı ", "Müşteri Kaydı Silme ", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }

            }
        }
    }
}
