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

namespace AnToanGiaoThong.Frm
{
    public partial class frmDoiProfile : Form
    {
        private string username;
        public frmDoiProfile(string username)
        {
            InitializeComponent();

            this.username=username;

            new MoveFrame(this.panel1);

        }

        private void frmDoiProfile_Load(object sender, EventArgs e)
        {
            Module.ucChangeProfile cp = new Module.ucChangeProfile(username);
            this.panel2.Controls.Add(cp);

        }
    }
}
