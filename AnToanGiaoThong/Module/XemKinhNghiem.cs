using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bussinessAccessLayer;

namespace AnToanGiaoThong.Module
{
    public partial class XemKinhNghiem : UserControl
    {
        bussinessAccessLayer.KinhNghiem.KinhNghiem kn = new bussinessAccessLayer.KinhNghiem.KinhNghiem();
        DataSet ds = new DataSet();
        public XemKinhNghiem()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            ds = kn.LayLoaiKinhNghiem();
            cmbTenLoaiKN.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTenLoaiKN.DataSource = ds.Tables[0];
            cmbTenLoaiKN.DisplayMember = "TenLoaiKN";
            cmbTenLoaiKN.ValueMember = "MaLoaiKN";
            cmbTenLoaiKN.SelectedIndex = 0;
        }

        private void XemKinhNghiem_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cmbTenKinhNghiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds1 = new DataSet();
                DataView KN = new DataView();
                ds1 = kn.LayKinhNghiem();
                KN.Table = ds1.Tables[0];
                string noidung = "";
                for (int i = 0; i < KN.Count; i++)
                {
                    if (cmbTenKinhNghiem.Text == KN.Table.Rows[i][1].ToString())
                    {
                        noidung = KN.Table.Rows[i][2].ToString();
                        break;
                    }
                }
                rtbNoiDungXem.Text = noidung;
                cmbTenKinhNghiem.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch { }
           
        }

        private void cmbTenLoaiKN_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds2 = new DataSet();
                DataView LKN = new DataView();
                ds2 = kn.LayLoaiKinhNghiem();
                LKN.Table = ds2.Tables[0];
                //
                DataSet ds1 = new DataSet();
                DataView KN = new DataView();
                ds1 = kn.LayKinhNghiem();
                KN.Table = ds1.Tables[0];

                cmbTenKinhNghiem.Items.Clear();
                string MaLKN = "";
                for (int i = 0; i < LKN.Count; i++)
                {
                    if (LKN.Table.Rows[i][1].ToString() == cmbTenLoaiKN.Text)
                    {
                        MaLKN = LKN.Table.Rows[i][0].ToString();
                        break;
                    }
                }
                for (int i = 0; i < KN.Count; i++)
                {
                    if (MaLKN == KN.Table.Rows[i][3].ToString())
                    {
                        cmbTenKinhNghiem.Items.Add(KN.Table.Rows[i][1].ToString());
                    }
                }
                //cmbTenKinhNghiem.ResetText();
                cmbTenKinhNghiem.SelectedIndex = 0;
            }
            catch { }
            
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
