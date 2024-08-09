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
    public partial class FrmMusteriIslemleri : Form
    {
        public FrmMusteriIslemleri()
        {
            InitializeComponent();
        }
        DbUrunSatisEntities db = new DbUrunSatisEntities();
        public void listele()
        {
            //dataGridView1.DataSource = db.TblUrunler.ToList() ; 
            var musteriler = from x in db.TblMusteriler
                             where (x.durum == true)
                             select new
                             {
                                 x.musteriID,
                                 x.ad,
                                 x.soyad,
                                 x.adres,
                                 x.tel,
                             };
            dataGridView1.DataSource = musteriler.ToList();
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtID.Text = "";
            txtAdres.Text = "";
            txtTel.Text = "";

        }
        private void btnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void FrmMusteriIslemleri_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtAd.Text == "" || txtSoyad.Text == "" || txtAdres.Text == "" || txtTel.Text == "")
                MessageBox.Show("Lütfen tüm alanları eksiksiz giriniz ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else
            {
                var x = new TblMusteriler();
                x.ad = txtAd.Text;
                x.soyad = txtSoyad.Text;
                x.adres = txtAdres.Text;
                x.tel = txtTel.Text;
                x.durum = true;
                db.TblMusteriler.Add(x);
                db.SaveChanges();
                MessageBox.Show("Müşteri kaydı tamam ");
            }
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtAdres.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtTel.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
                MessageBox.Show("Lütfen silmek istediğiniz kişiyi seçiniz ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else
            {
                int id = int.Parse(txtID.Text);

                var x = db.TblMusteriler.Find(id);
                x.durum = false;
                db.SaveChanges();
                MessageBox.Show("Müşteki kaydı silindi ");
            }
            listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtAd.Text == "" || txtSoyad.Text == "" || txtAdres.Text == "" || txtTel.Text == "")
                MessageBox.Show("Lütfen güncellenecek kişiyi seçiniz ve tüm alanlarını eksiksiz giriniz ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else
            {
                int id = int.Parse(txtID.Text);
                var x = db.TblMusteriler.Find(id);
                x.ad = txtAd.Text;
                x.soyad = txtSoyad.Text;
                x.adres = txtAdres.Text;
                x.tel = txtTel.Text;
                x.durum = true;
                db.SaveChanges();
                MessageBox.Show("Müşteri güncellendi ");
            }
            listele();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (txtMusteriAra.Text == "")
                MessageBox.Show("Lütfen aradığınız müşterinin adını tam giriniz ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else
            {
                var musteriler = from x in db.TblMusteriler
                                 where (x.durum == true)
                                 select new
                                 {
                                     x.musteriID,
                                     x.ad,
                                     x.soyad,
                                     x.adres,
                                     x.tel,
                                 };
                dataGridView1.DataSource = musteriler.Where(x => x.ad == txtMusteriAra.Text).ToList();
            }
        }
    }
}
