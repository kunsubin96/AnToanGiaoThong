using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ucRegister
{
    public delegate void RegisterHandler(mRegister sender, EventArgs e);

    public partial class mRegister : UserControl
    {
        public event RegisterHandler register;

        public string username;
        public string password;

        string reason;

        public mRegister()
        {
            InitializeComponent();
        }
       

        private bool constraintRegister()
        {
            if (txtUsername.Text.Trim().Equals(""))
            {
                lblReason.Text="Tên tài khoản không được bỏ trống";
                txtUsername.Focus();
                return false;
            }
            else
            {
                if (!txtPassword.Text.Trim().Equals(txtRepassword.Text.Trim()))
                {
                    lblReason.Text="Không trùng khớp! vui lòng gõ lại";
                    txtRepassword.Focus();
                    return false;
                }
                else
                {
                    bool truePassword = new PasswordRule().IsPassword(txtPassword.Text.Trim(), ref reason);
                    if (!truePassword)
                    {
                        lblReason.Text=reason;
                        txtPassword.ResetText();
                        txtRepassword.ResetText();
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (constraintRegister()&&register!=null)
            {
                lblReason.ResetText();

                username=txtUsername.Text.Trim();
                password=txtPassword.Text.Trim();

                register(this, e);

            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging=true;  // _dragging is your variable flag
            _start_point=new Point(e.X, e.Y);
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging=false;
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                this.Parent.Location=new Point(p.X-this._start_point.X, p.Y-this._start_point.Y);
            }
        }
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging=true;  // _dragging is your variable flag
            _start_point=new Point(e.X, e.Y);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                this.Parent.Location=new Point(p.X-this._start_point.X, p.Y-this._start_point.Y);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging=false;
        }
    }
}
