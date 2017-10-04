using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ucLogin
{
    public delegate void LoginHandler(
         mLogin sender, EventArgs e);

    public delegate void pressRegisterHandler(
         mLogin sender, EventArgs e);
    public partial class mLogin: UserControl
    {
        public event LoginHandler login;
        public event pressRegisterHandler register;

        public string userid;
        public string password;
        public string datasource;

        public mLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (login!=null)
            {
                userid=txtUsername.Text.Trim();
                
                password=txtPassword.Text.Trim();

                login(this, e);
            }
        }
        public void setUser(String a)
        {
            txtUsername.Text = a;
           
        }
        public void setFocus()
        {
            txtUsername.Focus();
        }
        public void setPass(String a)
        {
            txtPassword.Text = a;
        }
        private void btnSignup_Click(object sender, EventArgs e)
        {
            if (register!=null)
                register(this, e);
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
       

        private void mLogin_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging=true;  // _dragging is your variable flag
            _start_point=new Point(e.X, e.Y);
        }

        private void mLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                this.Parent.Location=new Point(p.X-this._start_point.X, p.Y-this._start_point.Y);
            }
        }

        private void mLogin_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging=false;
        }
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);
    }
}
