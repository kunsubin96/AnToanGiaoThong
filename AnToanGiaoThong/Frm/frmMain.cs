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
using ucButtonMenu;
using bussinessAccessLayer.Thi;
namespace AnToanGiaoThong.Frm
{
    public partial class frmMain : Form
    {
        private UserModel curUser;
        public frmMain(UserModel um)
        {
            this.curUser=um;

            InitializeComponent();

            this.panel2.Controls.Add(new Module.ucHelloUser(curUser));

            new Classes.MoveFrame(this.panel6);

            InitMenu();


        }
        private void InitMenu()
        {
            btnThiTracNghiem.click+=new ClickHandler(btnMenuClick);
            btnThiTracNghiem.Click+=new EventHandler(btnMenuClick);
            btnThiTracNghiem.SetImage(AnToanGiaoThong.Properties.Resources.thitracnghiem);
            btnThiTracNghiem.SetText("Thi Trắc Nghiệm");

            btnSoanDe.click+=new ClickHandler(btnMenuClick);
            btnSoanDe.Click+=new EventHandler(btnMenuClick);
            btnSoanDe.SetImage(AnToanGiaoThong.Properties.Resources.soande);
            btnSoanDe.SetText("Soạn Đề");

            btnLuat.click+=new ClickHandler(btnMenuClick);
            btnLuat.Click+=new EventHandler(btnMenuClick);
            btnLuat.SetImage(AnToanGiaoThong.Properties.Resources.xemluat);
            btnLuat.SetText("Xem Luật");

            btnKinhNghiem.click+=new ClickHandler(btnMenuClick);
            btnKinhNghiem.Click+=new EventHandler(btnMenuClick);
            btnKinhNghiem.SetImage(AnToanGiaoThong.Properties.Resources.xemkinhnghiem);
            btnKinhNghiem.SetText("Xem Kinh Nghiệm");

            btnDiemNong.click+=new ClickHandler(btnMenuClick);
            btnDiemNong.Click+=new EventHandler(btnMenuClick);
            btnDiemNong.SetImage(AnToanGiaoThong.Properties.Resources.diemnong);
            btnDiemNong.SetText("Điểm nóng CSGT");

            btnThongKe.click+=new ClickHandler(btnMenuClick);
            btnThongKe.Click+=new EventHandler(btnMenuClick);
            btnThongKe.SetImage(AnToanGiaoThong.Properties.Resources.thongke);
            btnThongKe.SetText("Thống Kê");

            btnThoat.click+=new ClickHandler(btnMenuClick);
            btnThoat.Click+=new EventHandler(btnMenuClick);
            btnThoat.SetImage(AnToanGiaoThong.Properties.Resources.thoat);
            btnThoat.SetText("Thoát");

            btnTrangChu.click+=new ClickHandler(btnMenuClick);
            btnTrangChu.Click+=new EventHandler(btnMenuClick);
            btnTrangChu.SetImage(AnToanGiaoThong.Properties.Resources.Home_64px);
            btnTrangChu.SetText("Trang chủ");

        }
        private void KiemTraDangThi(mButtonMenu menubtn)
        {
            if (panel3.Controls[0].Name.Equals("ucThiTracNghiem"))
            {
                Module.ucThiTracNghiem ucc = panel3.Controls[0] as Module.ucThiTracNghiem;
                if (ucc.DangThi)
                {
                    menubtn.Enabled=false;
                    return;
                }

            }
        }
        private void btnMenuClick(object sender, EventArgs e)
        {
            mButtonMenu t = sender as mButtonMenu;
            switch (t.Name)
            {
                case "btnTrangChu":
                   
                    btnSoanDe.setBackColor(27, 42, 61);
                    btnTrangChu.setBackColor(0, 128, 128);
                    btnThiTracNghiem.setBackColor(27, 42, 61);
                    btnLuat.setBackColor(27, 42, 61);
                    btnKinhNghiem.setBackColor(27, 42, 61);
                    btnDiemNong.setBackColor(27, 42, 61);
                    btnThongKe.setBackColor(27, 42, 61);
                    btnThoat.setBackColor(27, 42, 61);
                    this.panel3.Controls.Clear();
                    this.panel3.Controls.Add(pictureBox1);
                    break;
                case "btnThiTracNghiem":
                    this.panel3.Controls.Clear();
                    Module.ucThiTracNghiem uc = new Module.ucThiTracNghiem(curUser.Username);
                    this.panel3.Controls.Add(uc);
                    btnSoanDe.setBackColor(27, 42, 61);
                    btnTrangChu.setBackColor(27, 42, 61);
                    btnThiTracNghiem.setBackColor(0, 128, 128);
                    btnLuat.setBackColor(27, 42, 61);
                    btnKinhNghiem.setBackColor(27, 42, 61);
                    btnDiemNong.setBackColor(27, 42, 61);
                    btnThongKe.setBackColor(27, 42, 61);
                    btnThoat.setBackColor(27, 42, 61);

                    break;
                case "btnSoanDe":
                 
                    btnSoanDe.setBackColor(0, 128, 128);
                    btnTrangChu.setBackColor(27, 42, 61);
                    btnThiTracNghiem.setBackColor(27, 42, 61);
                    btnLuat.setBackColor(27, 42, 61);
                    btnKinhNghiem.setBackColor(27, 42, 61);
                    btnDiemNong.setBackColor(27, 42, 61);
                    btnThongKe.setBackColor(27, 42, 61);
                    btnThoat.setBackColor(27, 42, 61);
                    this.panel3.Controls.Clear();
                    this.panel3.Controls.Add(new Module.soanDeThi());
                    break;
                case "btnLuat":
                 
                    btnSoanDe.setBackColor(27, 42, 61);
                    btnTrangChu.setBackColor(27, 42, 61);
                    btnThiTracNghiem.setBackColor(27, 42, 61);
                    btnLuat.setBackColor(0, 128, 128);
                    btnKinhNghiem.setBackColor(27, 42, 61);
                    btnDiemNong.setBackColor(27, 42, 61);
                    btnThongKe.setBackColor(27, 42, 61);
                    btnThoat.setBackColor(27, 42, 61);
                    this.panel3.Controls.Clear();
                    this.panel3.Controls.Add(new Module.hocLuatGiaoThong());
                    break;
                case "btnKinhNghiem":
                    btnSoanDe.setBackColor(27, 42, 61);
                    btnTrangChu.setBackColor(27, 42, 61);
                    btnThiTracNghiem.setBackColor(27, 42, 61);
                    btnLuat.setBackColor(27, 42, 61);
                    btnKinhNghiem.setBackColor(0, 128, 128);
                    btnDiemNong.setBackColor(27, 42, 61);
                    btnThongKe.setBackColor(27, 42, 61);
                    btnThoat.setBackColor(27, 42, 61);
                    this.panel3.Controls.Clear();
                    this.panel3.Controls.Add(new Module.XemKinhNghiem());
                    break;
                case "btnDiemNong":
               
                    btnSoanDe.setBackColor(27, 42, 61);
                    btnTrangChu.setBackColor(27, 42, 61);
                    btnThiTracNghiem.setBackColor(27, 42, 61);
                    btnLuat.setBackColor(27, 42, 61);
                    btnKinhNghiem.setBackColor(27, 42, 61);
                    btnDiemNong.setBackColor(0, 128, 128);
                    btnThongKe.setBackColor(27, 42, 61);
                    btnThoat.setBackColor(27, 42, 61);
                    this.panel3.Controls.Clear();
                    this.panel3.Controls.Add(new Module.ucDiemNongGT());
                    break;
                case "btnThongKe":
       
                    btnSoanDe.setBackColor(27, 42, 61);
                    btnTrangChu.setBackColor(27, 42, 61);
                    btnThiTracNghiem.setBackColor(27, 42, 61);
                    btnLuat.setBackColor(27, 42, 61);
                    btnKinhNghiem.setBackColor(27, 42, 61);
                    btnDiemNong.setBackColor(27, 42, 61);
                    btnThongKe.setBackColor(0, 128, 128);
                    btnThoat.setBackColor(27, 42, 61);
                    this.panel3.Controls.Clear();
                    this.panel3.Controls.Add(new Module.thongKe(curUser));
                    break;
                case "btnThoat":
                    DialogResult traloi;
                    traloi = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (traloi == DialogResult.OK)
                    {
                        Application.Exit();
                    }
                    break;
                case "btnThongTinCaNhan":
                   
                    break;
                
                default: break;
            }
        }

        private void btnThoat_Load(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            btnTrangChu.setBackColor(0, 128, 128);
        }
        ThiTracNghiemBA thitrng = new ThiTracNghiemBA();
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
          
            if (panel3.Controls[0].Name.Equals("ucThiTracNghiem"))
            {
                Module.ucThiTracNghiem uc = panel3.Controls[0] as Module.ucThiTracNghiem;

                if (uc.DangThi==true)
                {
                    DialogResult traloi;
                    traloi=MessageBox.Show("Bạn đang làm bài thi!!!! Nếu bạn thật sự muốn thoát thì bài thi của bạn sẽ bị 0 điểm", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (traloi==DialogResult.OK)
                    {
                        thitrng.CapNhatDiem(uc.lblMaLanThi.Text, 0);
                    }else {
                        e.Cancel=true;
                    }
                }                                                                                    
            }
        }
           
    }
}
