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
    public partial class kingNghiemGiaoThong : UserControl
    {
        bussinessAccessLayer.KinhNghiem.KinhNghiem kn = new bussinessAccessLayer.KinhNghiem.KinhNghiem();
        DataSet ds = new DataSet();
        bool f = false;

        public kingNghiemGiaoThong()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            ds = kn.LayLoaiKinhNghiem();
            dgvLoaiKN.DataSource = ds.Tables[0];
            ds = kn.LayKinhNghiem();
            dgvKinhNghiem.DataSource = ds.Tables[0];
            rdbLoaiKinhNghiem.Checked = true;

            cmbTenLoaiKN.Enabled = false;
            txtTenKN.Enabled = false;
            rtbNoiDungXem.ReadOnly = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            dgvKinhNghiem.Enabled = false;

            //
            toolTip1.SetToolTip(btnHuy, "Hủy Thông Tin");
            toolTip1.SetToolTip(btnLuu, "Lưu Thông Tin");
            toolTip1.SetToolTip(btnThem, "Thêm Thông Tin");
            toolTip1.SetToolTip(btnXoa, "Xóa Dữ liệu");
            toolTip1.SetToolTip(dgvKinhNghiem, "Kinh Nghiệm Giao Thông");
            toolTip1.SetToolTip(dgvLoaiKN, "Loại Kinh Nghiệm Giao Thông");

        }

        private void kingNghiemGiaoThong_Load(object sender, EventArgs e)
        {
            LoadData();
            
           
        }

        private void cmbTenKinhNghiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbLoaiKinhNghiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            f = true;
            cmbTenLoaiKN.Enabled = true;
            if (rdbLoaiKinhNghiem.Checked==true)
            { 
                cmbTenLoaiKN.DropDownStyle = ComboBoxStyle.Simple;
                cmbTenLoaiKN.ResetText();
            }
            if(rdbKinhNghiem.Checked==true)
            {
                txtTenKN.Enabled=true;
                rtbNoiDungXem.ReadOnly = false;
            }
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            //
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            f = false;
            cmbTenLoaiKN.Enabled = true;
            if (rdbLoaiKinhNghiem.Checked == true)
            {
                cmbTenLoaiKN.DropDownStyle = ComboBoxStyle.Simple;
                cmbTenLoaiKN.Focus();
            }
            if (rdbKinhNghiem.Checked == true)
            {
                txtTenKN.Enabled = true;
                rtbNoiDungXem.ReadOnly = false;
            }
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            //
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(rdbLoaiKinhNghiem.Checked==true)
            {
                try
                {
                    //lấy hàng cần xóa
                    int r = dgvLoaiKN.CurrentCell.RowIndex;
                    //lấy mã khách hàng
                    int MaLKN = Int32.Parse(dgvLoaiKN.Rows[r].Cells[0].Value.ToString());
                    //hỏi xem có muốn xóa không
                    DialogResult traloi;
                    traloi = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (traloi == DialogResult.OK)
                    {
                        bool trangthai = kn.XoaLoaiKinhNghiem( MaLKN);
                        if (trangthai)
                        {

                            MessageBox.Show("Xóa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Không xóa được!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {

                    }
                }
                catch
                {

                }
            }
            else
                if(rdbKinhNghiem.Checked==true)
            {
                try
                {
                    //lấy hàng cần xóa
                    int r = dgvKinhNghiem.CurrentCell.RowIndex;
                    //lấy mã khách hàng
                    int MaLKN = Int32.Parse(dgvKinhNghiem.Rows[r].Cells[0].Value.ToString());
                    //hỏi xem có muốn xóa không
                    DialogResult traloi;
                    traloi = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (traloi == DialogResult.OK)
                    {
                        bool trangthai = kn.XoaKinhNghiem(MaLKN);
                        if (trangthai)
                        {

                            MessageBox.Show("Xóa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Không xóa được!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {

                    }
                }
                catch
                {

                }
            }
        }

        private void rdbLoaiKinhNghiem_CheckedChanged(object sender, EventArgs e)
        {
         
            btnThem.Enabled = true;
            txtTenKN.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            rtbNoiDungXem.Enabled = false;
            cmbTenLoaiKN.Enabled = false;
            dgvKinhNghiem.Enabled = false;

            dgvLoaiKN.Enabled = true;
        }

        private void rdbKinhNghiem_CheckedChanged(object sender, EventArgs e)
        {
            ds = kn.LayLoaiKinhNghiem();
            cmbTenLoaiKN.DataSource = ds.Tables[0];
            cmbTenLoaiKN.DisplayMember = "TenLoaiKN";
            cmbTenLoaiKN.ValueMember = "MaLoaiKN";
            cmbTenLoaiKN.ResetText();

            dgvKinhNghiem.Enabled = true;
            dgvLoaiKN.Enabled = false;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            rtbNoiDungXem.Enabled = false;
            cmbTenLoaiKN.Enabled = false;
            cmbTenLoaiKN.Enabled = false;
            cmbTenLoaiKN.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            cmbTenLoaiKN.ResetText();
            txtTenKN.ResetText();
            rtbNoiDungXem.Text = "Nội Dung kinh Nghiệm...";
            LoadData();

        }

        private void dgvLoaiKN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvLoaiKN.CurrentCell.RowIndex;
            cmbTenLoaiKN.Text =dgvLoaiKN.Rows[r].Cells[1].Value.ToString();

            //dgvKinhNghiem.DataSource = ds.Tables[0].Rows[r].V;
            txtTenKN.ResetText();
            rtbNoiDungXem.ResetText();

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
        }

        private void dgvKinhNghiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvKinhNghiem.CurrentCell.RowIndex;
            txtTenKN.Text = dgvKinhNghiem.Rows[r].Cells[1].Value.ToString();
            rtbNoiDungXem.Text = dgvKinhNghiem.Rows[r].Cells[2].Value.ToString();

            DataView dv = new DataView();
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            rtbNoiDungXem.Enabled = true;
            dv.Table = kn.LayLoaiKinhNghiem().Tables[0];
            string TenLoaiKN = "";
            for (int i = 0; i < dv.Count; i++)
            {
                if ((dv.Table.Rows[i][0].ToString()) == dgvKinhNghiem.Rows[r].Cells[3].Value.ToString())
                {
                    TenLoaiKN = dv.Table.Rows[i][1].ToString();
                    break;
                }
            }
            cmbTenLoaiKN.Text = TenLoaiKN;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int MaLKN =0;
            DataSet dsf = new DataSet();
            dsf = kn.LayLoaiKinhNghiem();
            DataView dv1 = new DataView();
            dv1.Table = dsf.Tables[0];
            for (int i = 0; i < dv1.Count; i++)
            {
                if (dv1.Table.Rows[i][1].ToString() == cmbTenLoaiKN.Text)
                {
                    MaLKN = Int32.Parse(dv1.Table.Rows[i][0].ToString());
                    break;
                }
                
            }
            if (rdbKinhNghiem.Checked==true)
            {
                //bool f = false;
                try
                {
                    if (cmbTenLoaiKN.Text.Trim() != "" && txtTenKN.Text.Trim() != ""
                        && rtbNoiDungXem.Text.Trim() != "")
                    {
                        if (f)
                        {

                            bool trangthai = kn.ThemKinhNghiem(txtTenKN.Text,rtbNoiDungXem.Text,MaLKN);
                            if (trangthai)
                            {


                                MessageBox.Show("Thêm dữ liệu thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData();

                            }
                            else
                            {
                                LoadData();
                                MessageBox.Show("Không thêm được dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }


                        }
                        else
                        {
                            int r = dgvKinhNghiem.CurrentCell.RowIndex;
                            int MaKN = Int32.Parse(dgvKinhNghiem.Rows[r].Cells[0].Value.ToString());
                            bool trangthai = kn.UpdateKinhNghiem(MaKN, txtTenKN.Text, rtbNoiDungXem.Text, MaLKN);
                            if (trangthai)
                            {


                                MessageBox.Show("Sữa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData();
                            }
                            else
                            {
                                LoadData();
                                MessageBox.Show("Không sữa được dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hãy nhập dữ liệu vào ô!", "Thông báo");
                    }

                }
                catch
                {
                    MessageBox.Show("Lỗi Rồi!");
                }
            }
            else
                if(rdbLoaiKinhNghiem.Checked==true)
            {
                try
                {
                    if (cmbTenLoaiKN.Text.Trim() != "")
                    {
                        if (f)
                        {

                            bool trangthai = kn.ThemLoaiKinhNghiem(cmbTenLoaiKN.Text);
                            if (trangthai)
                            {


                                MessageBox.Show("Thêm dữ liệu thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData();

                            }
                            else
                            {
                                LoadData();
                                MessageBox.Show("Không thêm được dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }


                        }
                        else
                        {
                            int r = dgvLoaiKN.CurrentCell.RowIndex;
                            int MaKN = Int32.Parse(dgvLoaiKN.Rows[r].Cells[0].Value.ToString());
                            bool trangthai = kn.UpdateLoaiKinhNghiem(MaKN, cmbTenLoaiKN.Text);
                            if (trangthai)
                            {


                                MessageBox.Show("Sữa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData();
                            }
                            else
                            {
                                LoadData();
                                MessageBox.Show("Không sữa được dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hãy nhập dữ liệu vào ô!", "Thông báo");
                    }

                }
                catch
                {
                    MessageBox.Show("Lỗi Rồi!");
                }
            }
        }
    }
}
