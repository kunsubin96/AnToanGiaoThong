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
    public partial class frmSoLuongThem : Form
    {
        bool trangthai = false;
        public frmSoLuongThem()
        {
            InitializeComponent();
        }
       
        private void frmSoLuongThem_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            trangthai = true;
            this.Close();
        }
        public bool getTrangThai()
        {
            return trangthai;
        }
        public int getSoLuong()
        {
            return (int)numericUpDownSoLuong.Value;
        }
    }
}
