using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bussinessAccessLayer.Thi;
namespace AnToanGiaoThong.Module
{
    public partial class ucChonDapAn : UserControl
    {
        ThiTracNghiemBA thitracnghiemBA = new ThiTracNghiemBA();

        bool         _Ischecked=false;
        int          _MaCauHoi;
        string       _STT;
        string       _MaLanThi;
        string       _DapAnChon;
        public bool Ischecked
        {
            get
            {
                return _Ischecked;
            }

            set
            {
                _Ischecked=value;
            }
        }
        public bool DaChamDiem = false;
        public int MaCauHoi
        {
            get
            {
                return _MaCauHoi;
            }

            set
            {
                _MaCauHoi=value;
            }
        }

        public string MaLanThi
        {
            get
            {
                return _MaLanThi;
            }

            set
            {
                _MaLanThi=value;
            }
        }

        public string DapAnChon
        {
            get
            {
                return _DapAnChon;
            }

            set
            {
                _DapAnChon=value;
            }
        }

        public void SetNameLabel(string name)
        {
            lblCauHoi.Text=name;
        }
        public string GetNameLabel()
        {
            return lblCauHoi.Text;
        }
        public ucChonDapAn()
        {
            InitializeComponent();
        }

        private void radiobtnA_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtonChecked(sender, e);
        }

        private void radiobtnB_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtonChecked(sender, e);
        }

        private void radiobtnC_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtonChecked(sender, e);
        }

        private void radiobtnD_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtonChecked(sender, e);
        }

        private void RadioButtonChecked(object sender, EventArgs e)
        {
            RadioButton radioBtn = sender as RadioButton;

            try
            {
                switch (radioBtn.Name)
                {
                    case "radiobtnA":
                        if (DaChamDiem==false) { if (!thitracnghiemBA.CapNhatDapAn(_MaLanThi, _MaCauHoi, "A")) { return; }; _Ischecked=true; _DapAnChon="A";  }
                        break;
                    case "radiobtnB":
                        if (DaChamDiem==false) { if (!thitracnghiemBA.CapNhatDapAn(_MaLanThi, _MaCauHoi, "B")) { return; }; _Ischecked=true; _DapAnChon="B"; }
                        break;
                    case "radiobtnC":
                        if (DaChamDiem==false) { if (!thitracnghiemBA.CapNhatDapAn(_MaLanThi, _MaCauHoi, "C")) { return; }; _Ischecked=true; _DapAnChon="C"; }
                        break;
                    case "radiobtnD":
                        if (DaChamDiem==false) { if (!thitracnghiemBA.CapNhatDapAn(_MaLanThi, _MaCauHoi, "D")) { return; }; _Ischecked=true; _DapAnChon="D"; }
                        break;
                    default:
                        _Ischecked=false;
                        break;
                }
               
            }
            catch { }
        }
        public void ChonDapAnDung(string dapandung)
        {
            switch (dapandung)
            {
                case "A": radiobtnA.Checked=true; break;
                case "B": radiobtnB.Checked=true; break;
                case "C": radiobtnC.Checked=true; break;
                case "D": radiobtnD.Checked=true; break;
                default:
                    break;
            }
        }
    }
}
