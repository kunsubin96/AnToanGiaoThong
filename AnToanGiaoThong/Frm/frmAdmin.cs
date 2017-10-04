using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ucButtonMenu;
namespace AnToanGiaoThong.Frm
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
            new Classes.MoveFrame(this.panel6);
            InitMenu();
        }
        private void InitMenu()
        {
            btnQuanLyUser.click += new ClickHandler(btnMenuClick);
            btnQuanLyUser.Click += new EventHandler(btnMenuClick);
            btnQuanLyUser.SetImage(AnToanGiaoThong.Properties.Resources.thitracnghiem);
            btnQuanLyUser.SetText("Tài Khoản");

            btnQuanLyNganHangCauHoi.click += new ClickHandler(btnMenuClick);
            btnQuanLyNganHangCauHoi.Click += new EventHandler(btnMenuClick);
            btnQuanLyNganHangCauHoi.SetImage(AnToanGiaoThong.Properties.Resources.soande);
            btnQuanLyNganHangCauHoi.SetText("Câu Hỏi");

            btnQuanLyLuat.click += new ClickHandler(btnMenuClick);
            btnQuanLyLuat.Click += new EventHandler(btnMenuClick);
            btnQuanLyLuat.SetImage(AnToanGiaoThong.Properties.Resources.xemluat);
            btnQuanLyLuat.SetText("Luật");

            btnQuanLyKinhNghiem.click += new ClickHandler(btnMenuClick);
            btnQuanLyKinhNghiem.Click += new EventHandler(btnMenuClick);
            btnQuanLyKinhNghiem.SetImage(AnToanGiaoThong.Properties.Resources.xemkinhnghiem);
            btnQuanLyKinhNghiem.SetText("Kinh Nghiệm");


            btnThoat.click += new ClickHandler(btnMenuClick);
            btnThoat.Click += new EventHandler(btnMenuClick);
            btnThoat.SetImage(AnToanGiaoThong.Properties.Resources.thoat);
            btnThoat.SetText("Thoát");

        }
        private void btnMenuClick(object sender, EventArgs e)
        {
            mButtonMenu t = sender as mButtonMenu;
            switch (t.Name)
            {
               
                case "btnQuanLyUser":
                    btnQuanLyUser.setBackColor(0, 128, 128);
                    btnQuanLyNganHangCauHoi.setBackColor(27, 42, 61);
                    btnQuanLyLuat.setBackColor(27, 42, 61);
                    btnQuanLyKinhNghiem.setBackColor(27, 42, 61);
                    btnThoat.setBackColor(27, 42, 61);
                    this.panel3.Controls.Clear();
                    this.panel3.Controls.Add(new Module.user());
                    break;
                case "btnQuanLyNganHangCauHoi":
                    btnQuanLyUser.setBackColor(27, 42, 61);
                    btnQuanLyNganHangCauHoi.setBackColor(0, 128, 128);
                    btnQuanLyLuat.setBackColor(27, 42, 61);
                    btnQuanLyKinhNghiem.setBackColor(27, 42, 61);
                    btnThoat.setBackColor(27, 42, 61);
                    this.panel3.Controls.Clear();
                    this.panel3.Controls.Add(new Module.quanLyNganHangCauHoi());
                    break;
                case "btnQuanLyLuat":
                    btnQuanLyUser.setBackColor(27, 42, 61);
                    btnQuanLyNganHangCauHoi.setBackColor(27, 42, 61);
                    btnQuanLyLuat.setBackColor(0, 128, 128);
                    btnQuanLyKinhNghiem.setBackColor(27, 42, 61);
                    btnThoat.setBackColor(27, 42, 61);
                    this.panel3.Controls.Clear();
                    this.panel3.Controls.Add(new Module.quanLyLuat());
                    break;
                case "btnQuanLyKinhNghiem":
                    btnQuanLyUser.setBackColor(27, 42, 61);
                    btnQuanLyNganHangCauHoi.setBackColor(27, 42, 61);
                    btnQuanLyLuat.setBackColor(27, 42, 61);
                    btnQuanLyKinhNghiem.setBackColor(0, 128, 128);
                    btnThoat.setBackColor(27, 42, 61);
                    this.panel3.Controls.Clear();
                    this.panel3.Controls.Add(new Module.kingNghiemGiaoThong());
                    break;
                case "btnThoat":
                    DialogResult traloi;
                    traloi = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (traloi == DialogResult.OK)
                    {
                        Application.Exit();
                    }
                    break;
                default: break;
            }
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            btnQuanLyUser.setBackColor(0, 128, 128);
            btnQuanLyNganHangCauHoi.setBackColor(27, 42, 61);
            btnQuanLyLuat.setBackColor(27, 42, 61);
            btnQuanLyKinhNghiem.setBackColor(27, 42, 61);
            btnThoat.setBackColor(27, 42, 61);
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(new Module.user());
        }
    }
}
