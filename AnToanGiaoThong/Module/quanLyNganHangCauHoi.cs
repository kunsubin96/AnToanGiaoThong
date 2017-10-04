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
using System.Data.SqlClient;
namespace AnToanGiaoThong.Module
{
    public partial class quanLyNganHangCauHoi : UserControl
    {
        bussinessAccessLayer.Admin.NganHangCauHoi nh = new bussinessAccessLayer.Admin.NganHangCauHoi();
        bool f;
        int macauhoi;
        public quanLyNganHangCauHoi()
        {
            InitializeComponent();
        }

        private void quanLyNganHangCauHoi_Load(object sender, EventArgs e)
        {
            LoadData();

            toolTip1.SetToolTip(btnThem, "Thêm");
            toolTip1.SetToolTip(btnSua, "Sửa");
            toolTip1.SetToolTip(btnXoa, "Xóa");
            toolTip1.SetToolTip(btnHuy, "Hủy");
            toolTip1.SetToolTip(btnLuu, "Lưu");
            toolTip1.SetToolTip(richChiTiet, "Chi tiết nội dung câu hỏi đang được chọn trên table");
            toolTip1.SetToolTip(richNoiDung, "Nội dung câu hỏi muốn thêm hoặc sửa");
            toolTip1.SetToolTip(panelDapAn, "Lưu nội dung các đáp án và đáp án đúng của câu");
        }
        public void LoadData()
        {
            DataView dv = new DataView();
            dv.Table = nh.getNganHangCauHoi().Tables[0];
            dgvCauHoi.Rows.Clear();
            if (dv.Count > 0)
                for (int i = 0; i < dv.Count; i++)
                {
                    dgvCauHoi.Rows.Add(dv.Table.Rows[i][0].ToString(), dv.Table.Rows[i][1].ToString());
                }
            else
            {

            }
            //
            richNoiDung.ReadOnly = true;
            panelDapAn.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
        }
        private void dgvCauHoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvCauHoi.CurrentCell.RowIndex;
            if (dgvCauHoi.Rows[r].Cells[0].Value != null)
            {
                DataView dv = new DataView();
                dv.Table = nh.getCauHoiTheoMa(int.Parse(dgvCauHoi.Rows[r].Cells[0].Value.ToString())).Tables[0];
                richChiTiet.Text = "Nội Dung: " + dv.Table.Rows[0][1].ToString() + "\n" +
                    "A: " + dv.Table.Rows[0][2].ToString() + "\n" + "B: " + dv.Table.Rows[0][3].ToString() + "\n" +
                    "C: " + dv.Table.Rows[0][4].ToString() + "\n" + "D: " + dv.Table.Rows[0][5].ToString() + "\n" +
                    "Đáp án đúng là: " + dv.Table.Rows[0][6].ToString();

                richNoiDung.Text = dv.Table.Rows[0][1].ToString();
                txtA.Text = dv.Table.Rows[0][2].ToString();
                txtB.Text = dv.Table.Rows[0][3].ToString();
                txtC.Text = dv.Table.Rows[0][4].ToString();
                txtD.Text = dv.Table.Rows[0][5].ToString();

                switch (dv.Table.Rows[0][6].ToString())
                {
                    case "A":
                        radioA.Checked = true;
                        break;
                    case "B":
                        radioB.Checked = true;
                        break;
                    case "C":
                        radioC.Checked = true;
                        break;
                    case "D":
                        radioD.Checked = true;
                        break;
                    default: break;
                }

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            f = true;
            //
            richNoiDung.ReadOnly = false;
            panelDapAn.Enabled = true;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            //
            richNoiDung.ResetText();
            txtA.ResetText();
            txtB.ResetText();
            txtC.ResetText();
            txtD.ResetText();
            radioA.Checked = false;
            radioB.Checked = false;
            radioC.Checked = false;
            radioD.Checked = false;
            //
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            f = false;
            //Load dữ liệu lên để sửa
            int r = dgvCauHoi.CurrentCell.RowIndex;
            if (dgvCauHoi.Rows[r].Cells[0].Value != null)
            {
                DataView dv = new DataView();
                dv.Table = nh.getCauHoiTheoMa(int.Parse(dgvCauHoi.Rows[r].Cells[0].Value.ToString())).Tables[0];
                richChiTiet.Text = "Nội Dung: " + dv.Table.Rows[0][1].ToString() + "\n" +
                    "A: " + dv.Table.Rows[0][2].ToString() + "\n" + "B: " + dv.Table.Rows[0][3].ToString() + "\n" +
                    "C: " + dv.Table.Rows[0][4].ToString() + "\n" + "D: " + dv.Table.Rows[0][5].ToString() + "\n" +
                    "Đáp án đúng là: " + dv.Table.Rows[0][6].ToString();

                richNoiDung.Text = dv.Table.Rows[0][1].ToString();
                txtA.Text = dv.Table.Rows[0][2].ToString();
                txtB.Text = dv.Table.Rows[0][3].ToString();
                txtC.Text = dv.Table.Rows[0][4].ToString();
                txtD.Text = dv.Table.Rows[0][5].ToString();
                //mã câu sữa
                macauhoi=int.Parse(dv.Table.Rows[0][0].ToString());
                switch (dv.Table.Rows[0][6].ToString())
                {
                    case "A":
                        radioA.Checked = true;
                        break;
                    case "B":
                        radioB.Checked = true;
                        break;
                    case "C":
                        radioC.Checked = true;
                        break;
                    case "D":
                        radioD.Checked = true;
                        break;
                    default: break;
                }

                //
                richNoiDung.ReadOnly = false;
                panelDapAn.Enabled = true;
                btnHuy.Enabled = true;
                btnLuu.Enabled = true;
                btnSua.Enabled = false;
                btnThem.Enabled = false;
                btnXoa.Enabled = false;

            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            richNoiDung.ReadOnly = true;
            panelDapAn.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                //lấy hàng cần xóa
                int r = dgvCauHoi.CurrentCell.RowIndex;
                int macau = int.Parse(dgvCauHoi.Rows[r].Cells[0].Value.ToString());
                //hỏi xem có muốn xóa không
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (traloi == DialogResult.OK)
                {
                    bool trangthai =nh.XoaNganHangCauHoi(macau);
                    if (trangthai)
                    {

                        MessageBox.Show("Xóa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();

                    }
                    else
                    {
                        MessageBox.Show("Không xóa được!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {

                }
            }
            catch (SqlException)
            {

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtA.Text.Trim() == "" || txtB.Text.Trim() == "" || txtC.Text.Trim() == "" || txtD.Text.Trim() == "" || richNoiDung.Text.Trim() == "")
                {
                    MessageBox.Show("Điền đầy đủ thông tin vào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                    
                if (radioA.Checked == false && radioB.Checked == false && radioC.Checked == false && radioD.Checked == false)
                {
                    MessageBox.Show("Chưa chọn đáp án!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }      
                if (f)
                {
                    string DapAn = "";
                    if (radioA.Checked == true)
                        DapAn = "A";
                    if (radioB.Checked == true)
                        DapAn = "B";
                    if (radioC.Checked == true)
                        DapAn = "C";
                    if (radioD.Checked == true)
                        DapAn = "D";
                    bool trangthai = nh.ThemNganHangCauHoi(richNoiDung.Text, txtA.Text, txtB.Text, txtC.Text, txtD.Text, DapAn);
                    if (trangthai)
                    {
                        MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không thêm được!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    string DapAn = "";
                    if (radioA.Checked == true)
                        DapAn = "A";
                    if (radioB.Checked == true)
                        DapAn = "B";
                    if (radioC.Checked == true)
                        DapAn = "C";
                    if (radioD.Checked == true)
                        DapAn = "D";
                    bool trangthai = nh.CapNhatNganHangCauHoi(macauhoi,richNoiDung.Text, txtA.Text, txtB.Text, txtC.Text, txtD.Text, DapAn);
                    if (trangthai)
                    {
                        MessageBox.Show("Sữa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không sữa được!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (SqlException) { }
        }
    }
}
