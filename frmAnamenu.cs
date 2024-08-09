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
    public partial class frmAnamenu : Form
    {
        public frmAnamenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmUrunIslemleri frm = new FrmUrunIslemleri();
            frm.Show(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmMusteriIslemleri frm = new FrmMusteriIslemleri();
            frm.Show(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmSatislar frm = new FrmSatislar();
            frm.Show(); 
        }
    }
}
