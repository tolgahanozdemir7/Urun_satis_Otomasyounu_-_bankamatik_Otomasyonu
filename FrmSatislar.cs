using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace urunSatisOto
{
    public partial class FrmSatislar : Form
    {
        public FrmSatislar()
        {
            InitializeComponent();
        }
        DbUrunSatisEntities db = new DbUrunSatisEntities();
        public void listele()
        {
            
            dataGridView1.DataSource = db.satisListesi2().ToList();

            cbUrun.ValueMember = "urunID";
            cbUrun.DisplayMember = "urunAd";
            cbUrun.DataSource = db.TblUrunler.Where(x => x.stok > 0 && x.durum==true).ToList() ;

            cbMusteri.ValueMember = "musteriID";

            var musteriler = db.TblMusteriler.Where(x=>x.durum==true).Select(x => new
            {
                x.musteriID,
                adSoyad = x.ad + " " + x.soyad

            }).ToList();
            cbMusteri.DisplayMember = "adSoyad";
            cbMusteri.DataSource = musteriler.ToList();

            txtID.Text = "";
            cbMusteri.Text = "";
            cbUrun.Text = "";
            txtBirimFiyat.Text = ""; 
            txtTopFiyat.Text = "";
            numAdet.Value = 1;


        }
        private void FrmSatislar_Load(object sender, EventArgs e)
        {
            listele();

        }

        TblUrunler u;
        TblSatislar s; 
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            s = new TblSatislar();
            s.urun = int.Parse(cbUrun.SelectedValue.ToString());
            s.musteri = int.Parse(cbMusteri.SelectedValue.ToString());
            s.adet = int.Parse(numAdet.Value.ToString());
            s.tarih = DateTime.Today;

            u = db.TblUrunler.Find(s.urun);

            if (u.stok < s.adet)
                MessageBox.Show("Stoktaki ürün yetersiz ", "Hatalı İşlem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                s.toplamFiyat = s.adet * u.satisFiyat;
                txtBirimFiyat.Text = u.satisFiyat.ToString();
                txtTopFiyat.Text = s.toplamFiyat.ToString();
            } 
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if( txtTopFiyat.Text=="")
                MessageBox.Show("Önce hesaplama işlemini yapınız ", "Hata" , MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            else
            {
                db.TblSatislar.Add(s);
                u.stok = u.stok - s.adet;
                db.TblSatislar.Add(s);
                db.SaveChanges();
                MessageBox.Show("Satış yapıldı ");

            }
            listele(); 

        }
    }
}
