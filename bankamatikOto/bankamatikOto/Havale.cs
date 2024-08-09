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
using System.Data.SqlClient;


namespace bankamatikOto
{
    public partial class Havale : Form
    {
        public Havale()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(" server= . ; initial catalog= bankamatik; integrated security = sspi");


        private void button1_Click(object sender, EventArgs e)
        {

            float sayi = float.Parse(msTxtHmiktar.Text);

            if (sayi > Form1.bakiye)
            {
                MessageBox.Show("Yetersiz Bakiye", "Pare Çekme İşlemi");
            }
            else
            {

                SqlCommand komut = new SqlCommand("update musteriler set bakiye= bakiye -  @p1 where ID= @p2  ", con);
                komut.Parameters.AddWithValue("@p1", sayi);
                komut.Parameters.AddWithValue("@p2", Form1.msID);

                SqlCommand komut2 = new SqlCommand("update musteriler set bakiye= bakiye +  @p3 where ID= @p4  ", con);
                komut2.Parameters.AddWithValue("@p3",  msTxtHmiktar.Text  );
                komut2.Parameters.AddWithValue("@p4",   msTxtAliciHspNo.Text );

                if (sayi < 10)
                {
                    MessageBox.Show("Lütfen 10 TL ve üzeri giriniz !", "Eksik Kayıt Hatası ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    con.Open();

                    int sonuc1 = komut2.ExecuteNonQuery();
                    con.Close();
                    if (sonuc1 == 1)
                    {
                        con.Open();

                        komut.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Havale işlemi gerçekleştirildi ", "Havale / EFT ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form1.bakiye -= sayi;

                        HareketKaydet.kaydet(Form1.msID, ( sayi + " TL Havale/EFT gönderildi"));
                        HareketKaydet.kaydet(int.Parse( msTxtAliciHspNo.Text), (sayi + " TL Havale/EFT alındı" ) );



                    }
                    else
                    {
                        MessageBox.Show("Alıcı Hesap No Hatalı !", "Havale/ EFT Hatası ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
            }


        }

        private void Havale_Load(object sender, EventArgs e)
        {

        }
    }
}
