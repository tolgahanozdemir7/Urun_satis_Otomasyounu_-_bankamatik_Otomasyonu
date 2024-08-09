using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bankamatikOto
{
    public partial class MusteriIslem : Form
    {
        public MusteriIslem()
        {
            InitializeComponent();
        }

        private void MusteriIslem_Load(object sender, EventArgs e)
        {
            label2.Text = Form1.adSoyad;
            label3.Text = Form1.msID.ToString();
             
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Close(); 
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            ParaCek pc = new ParaCek();
            pc.Show(); 

        }

        private void btnBakiyeGörüntüle_Click(object sender, EventArgs e)
        {
            Bakiye bk = new Bakiye();
            bk.Show(); 
        }

        private void btnParaYatir_Click(object sender, EventArgs e)
        {
            ParaYatir py = new ParaYatir();
            py.Show(); 
        }

        private void btnSifreD_Click(object sender, EventArgs e)
        {
            SifreDegistir sd = new SifreDegistir();
            sd.Show(); 
        }

        private void btnHavale_Click(object sender, EventArgs e)
        {
            Havale hv = new Havale();
            hv.Show(); 

        }

        private void btnHesapH_Click(object sender, EventArgs e)
        {
            HesapHareketleri hh = new HesapHareketleri();
            hh.Show(); 
        }
    }
}
