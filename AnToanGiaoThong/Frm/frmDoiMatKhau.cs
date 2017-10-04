using AnToanGiaoThong.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnToanGiaoThong.Classes;
namespace AnToanGiaoThong.Frm
{
    public partial class frmDoiMatKhau : Form
    {
        string userName;
        public frmDoiMatKhau(string userName)
        {
            InitializeComponent();

            new MoveFrame(this.panel1);

            this.userName=userName;

            Module.ucDoiMatKhau uc = new Module.ucDoiMatKhau(userName);
            uc.Location=new Point(-1, 50);
            this.Controls.Add(uc);
        }

        
    }
}
