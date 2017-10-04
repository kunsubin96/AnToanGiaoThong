using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;
using bussinessAccessLayer.SoanDe;
using bussinessAccessLayer.Thi;
using AnToanGiaoThong.Classes;
namespace AnToanGiaoThong.Module
{
    public partial class ucThiTracNghiem : UserControl
    {
        const int SO_CAU_THI = 30;    //Thi 30 câu
        int TIME = 30*60;    //30 phút

        List<CauHoiModel> listCauHoiSeThi;
        SoanDe soande = new SoanDe();
        ThiTracNghiemBA thitracnghiemBA = new ThiTracNghiemBA();
        string userName;
        int currentQuestion = 0;
        bool tamDung = false;
        Timer timer;

        bool _DangThi = false;

        public bool DangThi
        {
            get
            {
                return _DangThi;
            }
        }

        public ucThiTracNghiem(string userName)
        {
            InitializeComponent();

            this.userName=userName;

            panel1.AutoScroll=false;
            panel1.HorizontalScroll.Enabled=false;
            panel1.HorizontalScroll.Visible=false;
            panel1.HorizontalScroll.Maximum=0;
            panel1.AutoScroll=true;

            lbTaiKhoan.Text = userName;
        }


        private void btnBatDau_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult traloi;
                traloi=MessageBox.Show("Bạn muốn tạo lần thi mới ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (traloi==DialogResult.OK)
                {
                    btnSubmit.Enabled=true;

                    createLanThi();

                   

                    randomCauHoi();

                    addControlDapAn();

                    setTimeCountDown();

                    showNoiDungCauHoi(currentQuestion);
                }
            }
            catch { }
        }

        private void createLanThi()
        {
            
            if (!thitracnghiemBA.ThemThiTracNghiem(DateTime.Now, this.userName))
            {
                MessageBox.Show("Không thể thêm mới lần thi");
                return;
            }
            lblMaLanThi.Text=thitracnghiemBA.getMaLanThiMoiNhat() +"";
            
            btnBatDau.Enabled=false;

            disableMenu();
            _DangThi=true;

        }

        private void randomCauHoi()
        {
            int MaxSizeRandom = int.Parse(soande.getMAXCau().Tables[0].Rows[0][0].ToString());

            int NumOfQuestion = int.Parse(soande.getTongCau().Tables[0].Rows[0][0].ToString());

            DataTable dtMaCauHoi = soande.getTatCaMaCauHoi().Tables[0];

            List<int> listMaCauHoiSeThi = new List<int>();

            List<int> listMaTatCaCauHoi = new List<int>();

            foreach (DataRow dr in dtMaCauHoi.Rows)
            {
                int maso = int.Parse(dr[0].ToString());

                listMaTatCaCauHoi.Add(maso);
            }
            int socauthi = SO_CAU_THI;
            Random random = new Random();
            if (socauthi>NumOfQuestion)
            {
                MessageBox.Show("Số câu đã lơn hơn tổng số câu trong ngân hàng câu hỏi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            while (socauthi > 0)
            {
                int macau = random.Next(1, MaxSizeRandom+1);
                if (!listMaCauHoiSeThi.Contains(macau)&&listMaTatCaCauHoi.Contains(macau))
                {
                    listMaCauHoiSeThi.Add(macau);
                    socauthi--;
                }
            }


            listCauHoiSeThi=new List<CauHoiModel>();

            foreach (int i in listMaCauHoiSeThi)
            {

                DataTable dtNoiDungCauHoi = soande.getChiTietCauHoi(i).Tables[0];

                CauHoiModel cauhoi = new CauHoiModel();
                cauhoi.MaCauHoi=int.Parse(dtNoiDungCauHoi.Rows[0][0].ToString());
                cauhoi.NoiDungCauHoi=dtNoiDungCauHoi.Rows[0][1].ToString();
                cauhoi.NoiDungDapAn_A=dtNoiDungCauHoi.Rows[0][2].ToString();
                cauhoi.NoiDungDapAn_B=dtNoiDungCauHoi.Rows[0][3].ToString();
                cauhoi.NoiDungDapAn_C=dtNoiDungCauHoi.Rows[0][4].ToString();
                cauhoi.NoiDungDapAn_D=dtNoiDungCauHoi.Rows[0][5].ToString();
                cauhoi.DapAnDung=dtNoiDungCauHoi.Rows[0][6].ToString();

                if (!thitracnghiemBA.ThemChiTietThi(lblMaLanThi.Text, cauhoi.MaCauHoi))
                    return;
                listCauHoiSeThi.Add(cauhoi);
            }
        }

        private void addControlDapAn()
        {
            this.panel1.Controls.Clear();
            int startX = 3;
            int startY = 4;
            for (int i = 0; i<SO_CAU_THI; i++)
            {
                Module.ucChonDapAn ucChonDapAn = new ucChonDapAn();
                ucChonDapAn.MaLanThi=lblMaLanThi.Text;
                ucChonDapAn.MaCauHoi=listCauHoiSeThi[i].MaCauHoi;
                ucChonDapAn.SetNameLabel("Câu "+(i+1));
                ucChonDapAn.Location=new Point(startX, startY);
                startY=startY+41;
                this.panel1.Controls.Add(ucChonDapAn);
            }
        }

        private void setTimeCountDown()
        {

            timer=new Timer() { Interval=1000 };

            timer.Tick+=(obj, args) =>
            {
                TIME--;
                label11.Text="00:"+TIME/60+":"+((TIME%60)>=10 ? (TIME%60).ToString() : "0"+TIME%60);

                if (TIME<=0)
                {
                    timer.Stop();
                    MessageBox.Show("Hết giờ làm bài! Hệ thống sẽ tiến hành chấm điểm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Chấm điểm
                    btnSubmit.Enabled=false;
                    btnTamDung.Enabled=false;
                    NopBai(true);
                }

            };
            timer.Enabled=true;
        }

        private void showNoiDungCauHoi(int STT)
        {
            if (STT<0) { STT=29; }

            if (STT>29) { STT=0; }

            string noidungcauhoi = listCauHoiSeThi[STT].NoiDungCauHoi;
            string noidungDA_A = listCauHoiSeThi[STT].NoiDungDapAn_A;
            string noidungDA_B = listCauHoiSeThi[STT].NoiDungDapAn_B;
            string noidungDA_C = listCauHoiSeThi[STT].NoiDungDapAn_C;
            string noidungDA_D = listCauHoiSeThi[STT].NoiDungDapAn_D;

            txtNoiDungCauHoi.ResetText();

            txtNoiDungCauHoi.AppendText("\n\n\n");
            txtNoiDungCauHoi.AppendText("Câu  "+(STT+1)+": ");
            txtNoiDungCauHoi.AppendText(noidungcauhoi);
            txtNoiDungCauHoi.AppendText("\n\n");
            txtNoiDungCauHoi.AppendText("A: "+noidungDA_A+"\n");
            txtNoiDungCauHoi.AppendText("B: "+noidungDA_B+"\n");
            txtNoiDungCauHoi.AppendText("C: "+noidungDA_C+"\n");
            txtNoiDungCauHoi.AppendText("D: "+noidungDA_D+"\n");
        }

        private void disableMenu()
        {
            Frm.frmMain frmMain = (this.Parent).Parent as Frm.frmMain;

            frmMain.btnTrangChu.Enabled=false;
            frmMain.btnSoanDe.Enabled=false;
            frmMain.btnLuat.Enabled=false;
            frmMain.btnKinhNghiem.Enabled=false;
            frmMain.btnDiemNong.Enabled=false;
            frmMain.btnThongKe.Enabled=false;
        }

        private void enableMenu()
        {
            Frm.frmMain frmMain = (this.Parent).Parent as Frm.frmMain;

            frmMain.btnTrangChu.Enabled=true;
            frmMain.btnSoanDe.Enabled=true;
            frmMain.btnLuat.Enabled=true;
            frmMain.btnKinhNghiem.Enabled=true;
            frmMain.btnDiemNong.Enabled=true;
            frmMain.btnThongKe.Enabled=true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                currentQuestion = currentQuestion + 1;
                if (currentQuestion >= SO_CAU_THI)
                {
                    currentQuestion = 0;
                }

                showNoiDungCauHoi(currentQuestion);

            }
            catch { }
           
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                currentQuestion = currentQuestion - 1;
                if (currentQuestion < 0)
                {
                    currentQuestion = SO_CAU_THI-1;
                }
                showNoiDungCauHoi(currentQuestion);
            }
            catch { }
           
        }

        private void btnTamDung_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_DangThi)
                    return;
                if (tamDung == false)
                {
                    tamDung = true;
                    btnTamDung.Image = AnToanGiaoThong.Properties.Resources.playy;

                    panel1.Enabled = false;
                    btnSubmit.Enabled = false;
                    btnNext.Enabled = false;
                    btnBack.Enabled = false;

                    txtNoiDungCauHoi.ResetText();
                    timer.Stop();
                }
                else
                {
                    tamDung = false;

                    btnTamDung.Image = AnToanGiaoThong.Properties.Resources.pause;

                    panel1.Enabled = true;
                    btnSubmit.Enabled = true;
                    btnNext.Enabled = true;
                    btnBack.Enabled = true;

                    showNoiDungCauHoi(currentQuestion);
                    if (TIME > 0)
                        timer.Start();
                }
            }
            catch { }
            
        }

        private void NopBai(bool DaHetGio)
        {
            if (DaHetGio==false)
            {
                if (CheckCauChuaLam()) { return; }
            }
            ChamDiem();

        }

        private void ChamDiem()
        {
            int soCauSai = 0;
            double Diem = 0;
            foreach (ucChonDapAn uc in panel1.Controls)
            {
                string status = thitracnghiemBA.KiemTraDapAn(uc.MaCauHoi+"");
                uc.DaChamDiem=true;
                if (status.Equals(uc.DapAnChon))
                {
                    Diem=Diem+0.3;
                    
                }
                else
                {
                    soCauSai++;
                    uc.ChonDapAnDung(status);
                }
                uc.Enabled=false;
            }

            if (!thitracnghiemBA.CapNhatDiem(lblMaLanThi.Text, Diem))
                return;

            MessageBox.Show("Bạn sai: "+soCauSai+"Câu\n"+"Đạt :"+Diem+" Điểm", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (!thitracnghiemBA.XoaChiTietThi(lblMaLanThi.Text))
                return;

            timer.Stop();
            timer.Enabled=false;

            enableMenu();
            label11.Text="00:30:00";
            _DangThi=false;
        }

        private bool CheckCauChuaLam()
        {
            foreach (ucChonDapAn uc in panel1.Controls)
            {
                if (!uc.Ischecked)
                {
                    MessageBox.Show(uc.GetNameLabel()+" Chưa chọn đáp án");
                    return true;
                }
            }
            return false;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                NopBai(false);
            }
            catch { }
           
        }

        private void ucThiTracNghiem_Load(object sender, EventArgs e)
        {

            txtNoiDungCauHoi.ReadOnly = true;
            toolTip1.SetToolTip(btnBatDau, "Bắt đầu thi");
            toolTip1.SetToolTip(btnTamDung, "Tạm dừng bài thi");
            toolTip1.SetToolTip(btnSubmit, "Nộp bài");
            toolTip1.SetToolTip(btnNext, "Chuyển câu");
            toolTip1.SetToolTip(btnBack, "Chuyển câu");
            toolTip1.SetToolTip(txtNoiDungCauHoi, "Nội dung câu hỏi");
            toolTip1.SetToolTip(panel2, "Nơi chọn đáp án");
            toolTip1.SetToolTip(label11, "Thời gian thi");
        }
    }
}
