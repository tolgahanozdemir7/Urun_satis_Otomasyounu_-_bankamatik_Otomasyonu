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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        //Bilgisayar Mühendisi Sadık Şahin

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtKulAdi.Text=="" || txtParola.Text=="")
                MessageBox.Show("Lütfen Kullanıcı Adı/Parola giriniz ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (txtKulAdi.Text=="admin" && txtParola.Text=="123")
                {
                    MessageBox.Show("Giriş Başarılı, Anamenüye Yönlendiriliyorsunuz...", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information );
                    frmAnamenu frm = new frmAnamenu();
                    frm.Show();
                    this.Hide(); 
                }
                else
                    MessageBox.Show("Hatalı kullanıcı adı/parola", "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
            txtKulAdi.Text = "";
            txtParola.Text = ""; 

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
