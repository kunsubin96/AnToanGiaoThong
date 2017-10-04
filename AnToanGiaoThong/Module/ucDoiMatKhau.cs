using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnToanGiaoThong.Classes;

namespace AnToanGiaoThong.Module
{
    public partial class ucDoiMatKhau : UserControl
    {
        string userName;
        bussinessAccessLayer.DangNhap_DangKi.editProfileBA editProfile = new bussinessAccessLayer.DangNhap_DangKi.editProfileBA();
        public ucDoiMatKhau(string userName)
        {
            InitializeComponent();

            this.userName=userName;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!constraintRegister())
            {
                return;
            }
            string newPassword = txtPassword2.Text;
            string oldPassword = txtPassword1.Text;
            if (!editProfile.changePassword(this.userName, oldPassword, newPassword))
            {
                MessageBox.Show("Thay đổi thất bại");
                return;
            }

            MessageBox.Show("Thay đổi mật khẩu thành công");
        }
       
        private bool constraintRegister()
        {
            string reason = "";

            if (txtPassword1.Text.Trim().Equals("")||txtPassword2.Text.Trim().Equals("")||txtRepassword.Text.Trim().Equals(""))
            {
                lblReason.Text="Không được bỏ trốn ô này";
                txtPassword1.Focus();
                return false;
            }
            else
            {
                if (!txtPassword2.Text.Trim().Equals(txtRepassword.Text.Trim()))
                {
                    lblReason.Text="Không trùng khớp! vui lòng gõ lại";
                    txtRepassword.Focus();
                    return false;
                }
                else
                {
                    bool truePassword = new PasswordRule().IsPassword(txtPassword2.Text.Trim(), ref reason);
                    if (!truePassword)
                    {
                        lblReason.Text=reason;
                        txtPassword2.ResetText();
                        txtRepassword.ResetText();
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
