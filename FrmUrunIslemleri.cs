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
    public partial class FrmUrunIslemleri : Form
    {
        public FrmUrunIslemleri()
        {
            InitializeComponent();
        }

        DbUrunSatisEntities db = new DbUrunSatisEntities();

        public void listele()
        {
            //dataGridView1.DataSource = db.TblUrunler.ToList() ; 
            var urunler = from x in db.TblUrunler
                          where (x.durum == true)
                          select new
                          {
                              x.urunID,
                              x.urunAd,
                              x.stok,
                              x.alisFiyat,
                              x.satisFiyat,
                          };
            dataGridView1.DataSource = urunler.ToList();
            txtUrunAd.Text = "";
            txtID.Text = "";
            txtAlisFiyat.Text = "";
            txtSatisFiyat.Text = "";
            numStok.Value = 1;

        }
        private void FrmUrunIslemleri_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtUrunAd.Text == "" || numStok.Value < 1 || txtAlisFiyat.Text == "" || txtSatisFiyat.Text == "")
                MessageBox.Show("Lütfen tüm alanları eksiksiz giriniz ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else
            {
                var x = new TblUrunler();
                x.urunAd = txtUrunAd.Text;
                x.stok = int.Parse(numStok.Value.ToString());
                x.alisFiyat = int.Parse(txtAlisFiyat.Text);
                x.satisFiyat = int.Parse(txtSatisFiyat.Text);
                x.durum = true;
                db.TblUrunler.Add(x);
                db.SaveChanges();
                MessageBox.Show("Ürün kaydı tamam ");
            }
            listele();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
                MessageBox.Show("Lütfen silmek istediğiniz ürün seçiniz ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else
            {
                int id = int.Parse(txtID.Text);

                var x = db.TblUrunler.Find(id);
                x.durum = false;
                db.SaveChanges();
                MessageBox.Show("Ürün kaydı silindi ");
            }
            listele();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtUrunAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            numStok.Value = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            txtAlisFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSatisFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtUrunAd.Text == "" || numStok.Value < 1 || txtAlisFiyat.Text == "" || txtSatisFiyat.Text == "")
                MessageBox.Show("Lütfen Güncellemek istediğiniz kaydı seçiniz ve tüm alanları eksiksiz giriniz ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else
            {
                int id = int.Parse(txtID.Text);
                var x = db.TblUrunler.Find(id);
                x.urunAd = txtUrunAd.Text;
                x.stok = int.Parse(numStok.Value.ToString());
                x.alisFiyat = int.Parse(txtAlisFiyat.Text);
                x.satisFiyat = int.Parse(txtSatisFiyat.Text);
                x.durum = true;
                db.SaveChanges();
                MessageBox.Show("Ürün güncellendi ");
            }
            listele();

        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (txtUrunAra.Text == "")
                MessageBox.Show("Lütfen aradığınız ürünün adını tam giriniz ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else
            {
                var urunler = from x in db.TblUrunler
                              where (x.durum == true)
                              select new
                              {
                                  x.urunID,
                                  x.urunAd,
                                  x.stok,
                                  x.alisFiyat,
                                  x.satisFiyat,
                              };
                dataGridView1.DataSource = urunler.Where(x=>x.urunAd==txtUrunAra.Text).ToList();

            }



        }
    }
}
