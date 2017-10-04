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
    public partial class ucHelloUser : UserControl
    {
        private UserModel um;
        public ucHelloUser(UserModel um)
        {
            InitializeComponent();

            this.um=um;
            try
            {
                System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
                gp.AddEllipse(0, 0, pictureBox1.Width-3, pictureBox1.Height-3);
                Region rg = new Region(gp);
                pictureBox1.Region=rg;
                pictureBox1.Image=new Function().ResizeImage(new Function().Byte2Image(um.Avatar), pictureBox1.Width, pictureBox1.Height);
            }
            catch { }
           
        }

        private void txtDoiPro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Frm.frmDoiProfile(this.um.Username).Show();
        }
    }
}
