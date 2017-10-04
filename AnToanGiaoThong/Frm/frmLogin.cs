using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ucLogin;

using bussinessAccessLayer.DangNhap_DangKi;
using AnToanGiaoThong.Classes;
using System.IO;

namespace AnToanGiaoThong.Frm
{
    public partial class frmLogin : Form
    {

        loginBA lg = new loginBA();
        DataTable dt = new DataTable();
        public frmLogin()
        {
            InitializeComponent();

            mLogin1.login+=new ucLogin.LoginHandler(loginMethod);
            mLogin1.register+=new ucLogin.pressRegisterHandler(pressRegisterMethod);
        }
        private void loginMethod(ucLogin.mLogin sender,EventArgs e)
        {
            string username = mLogin1.userid;
            string password = mLogin1.password;

            int result_login = lg.checkLogin(username, password);

            if (1!=result_login)
            {
                MessageBox.Show("Tên đăng nhập mật khẩu không chính xác");
                mLogin1.setUser("");
                mLogin1.setPass("");
                mLogin1.setFocus();
                return;
            }
            UserModel um=null;
            try
            {
                dt=lg.infoUser(username).Tables[0];

                um= new UserModel();
                um.Username=dt.Rows[0][0].ToString();
                um.Hoten=dt.Rows[0][2]==null ? "" : dt.Rows[0][2].ToString();
                um.Ngaysinh=((DateTime)dt.Rows[0][4])==null ? "" : ((DateTime)dt.Rows[0][4]).ToShortDateString();
                um.Quequan=dt.Rows[0][3].ToString();
                um.Avatar=(byte[])dt.Rows[0][5];
            }
            catch { }
          

            this.Hide();
            if (um==null)
                return;
            if (um.Username=="ADMIN")
                new frmAdmin().ShowDialog();
            else
                new frmMain(um).ShowDialog();
            this.Close();

        }
        private void pressRegisterMethod(mLogin sender,EventArgs e)
        {
            Frm.frmRegister frm = new frmRegister();
            frm.Show();
                
        }
        
        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Minimized;
        }
        private void label2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mLogin1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        ///*Move form*/
        //protected override void WndProc(ref Message m)
        //{
        //    base.WndProc(ref m);
        //    if (m.Msg==WM_NCHITTEST)
        //        m.Result=(IntPtr)(HT_CAPTION);
        //}

        //private const int WM_NCHITTEST = 0x84;
        //private const int HT_CLIENT = 0x1;
        //private const int HT_CAPTION = 0x2;
        ///////
    }
}
