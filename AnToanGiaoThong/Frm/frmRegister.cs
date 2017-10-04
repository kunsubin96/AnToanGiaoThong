using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ucRegister;
using bussinessAccessLayer.DangNhap_DangKi;
namespace AnToanGiaoThong.Frm
{
    public partial class frmRegister : Form
    {
        registerBA reg = new registerBA();
        public frmRegister()
        {
            InitializeComponent();
            mRegister1.register+=new ucRegister.RegisterHandler(registerMethod);

        }
        private void registerMethod(mRegister sender,EventArgs e)
        {
            string username = mRegister1.username;
            string password = mRegister1.password;
            bool result_register = reg.register(username, password);
            if (true==result_register)
            {
                MessageBox.Show("Đăng Kí thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
           
        }
        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Minimized;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
