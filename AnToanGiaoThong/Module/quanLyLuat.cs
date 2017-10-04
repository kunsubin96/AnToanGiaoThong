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
    public partial class quanLyLuat : UserControl
    {
        bussinessAccessLayer.Admin.Luat l = new bussinessAccessLayer.Admin.Luat();
        bool f;
        bool f_Phat;
        bool f_Luat;
        string ma;
        int maPhat;
        int TT_SoDieu;
        public quanLyLuat()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (tabControl1.SelectedIndex)
                {
                    case 0:
                        LoadLuat();
                        break;
                    case 1:
                        LoadThongTu();
                        break;
                    case 2:
                        LoadMucPhat();
                        break;
                    default: break;
                }
            }
            catch { }
           
        }
        public void LoadThongTu()
        {
            dgvThongTu.DataSource = l.getThongTu().Tables[0];
            panelThongTin.Enabled = false;
            richNoiDung.ReadOnly = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }
        public void LoadMucPhat()
        {
            dgvPhat.DataSource = l.getMucPhat().Tables[0];
            groupPhat.Enabled = false;
            richNoiDungPhat.ReadOnly = true;
            btnThemPhat.Enabled = true;
            btnSuaPhat.Enabled = true;
            btnXoaPhat.Enabled = true;
            btnLuuPhat.Enabled = false;
            btnHuyPhat.Enabled = false;
        }
        public void LoadLuat()
        {
            dgvLuat.DataSource = l.getLuatGiaoThong().Tables[0];

            panelLuat.Enabled = false;
            richTextBoxLuat.ReadOnly = true;
            btnThemLuat.Enabled = true;
            btnXoaLuat.Enabled = true;
            btnSuaLuat.Enabled = true;
            btnLuuLuat.Enabled = false;
            btnHuyLuat.Enabled = false;
            comboxMaChuong.Enabled = true;
            //addcombox
            DataView dv1 = new DataView();
            dv1.Table = l.getHocLuatGiaoThong().Tables[0];
            comboxMaChuong.Items.Clear();
            for(int i = 0; i < dv1.Count; i++)
            {
                comboxMaChuong.Items.Add(dv1.Table.Rows[i][0].ToString());
            }
        }
        private void dgvThongTu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvThongTu.CurrentCell.RowIndex;
            if (dgvThongTu.Rows[r].Cells[0].Value != null)
            {
                txtMaThongTu.Text = dgvThongTu.Rows[r].Cells[0].Value.ToString();
                dateTimePicker1.Text= dgvThongTu.Rows[r].Cells[1].Value.ToString();
                richNoiDung.Text= dgvThongTu.Rows[r].Cells[2].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            f = true;
            //
            richNoiDung.ReadOnly = false;
            panelThongTin.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            //
            richNoiDung.ResetText();
            txtMaThongTu.ResetText();
            txtMaThongTu.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            f = false;
            //
            richNoiDung.ReadOnly = false;
            panelThongTin.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            //
            int r = dgvThongTu.CurrentCell.RowIndex;
            if (dgvThongTu.Rows[r].Cells[0].Value != null)
            {
                txtMaThongTu.Text = dgvThongTu.Rows[r].Cells[0].Value.ToString();
                dateTimePicker1.Text = dgvThongTu.Rows[r].Cells[1].Value.ToString();
                richNoiDung.Text = dgvThongTu.Rows[r].Cells[2].Value.ToString();
                ma= dgvThongTu.Rows[r].Cells[0].Value.ToString();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            panelThongTin.Enabled = false;
            richNoiDung.ReadOnly = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgvThongTu.CurrentCell.RowIndex;
                string mathongtu = dgvThongTu.Rows[r].Cells[0].Value.ToString();
                //hỏi xem có muốn xóa không
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (traloi == DialogResult.OK)
                {
                    bool trangthai = l.XoaThongTu(mathongtu);
                    if (trangthai)
                    {

                        MessageBox.Show("Xóa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadThongTu();

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
            catch
            {

            }
           
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaThongTu.Text.Trim() == ""||richNoiDung.Text.Trim()=="")
                {
                    MessageBox.Show("Hãy điền đầy đủ thông tin vào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (f)
                {
                    bool trangthai = l.ThemThongTu(txtMaThongTu.Text, dateTimePicker1.Value, richNoiDung.Text);
                    if (trangthai)
                    {
                        MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadThongTu();
                    }
                    else
                    {
                        MessageBox.Show("Không thêm được!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    bool trangthai = l.CapNhatThongTu(ma, dateTimePicker1.Value, richNoiDung.Text);
                    if (trangthai)
                    {
                        MessageBox.Show("Sữa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadThongTu();
                    }
                    else
                    {
                        MessageBox.Show("Không sữa được!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                    
            }
            catch
            {

            }
        }

        private void btnThemPhat_Click(object sender, EventArgs e)
        {

            f_Phat = true;

            groupPhat.Enabled = true;
            richNoiDungPhat.ReadOnly = false;
            btnThemPhat.Enabled = false;
            btnSuaPhat.Enabled = false;
            btnXoaPhat.Enabled = false;
            btnLuuPhat.Enabled = true;
            btnHuyPhat.Enabled = true;
            txtDen.ResetText();
            txtTu.ResetText();
            richNoiDungPhat.ResetText();
            txtTu.Focus();

        }

        private void dgvPhat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvPhat.CurrentCell.RowIndex;
            if (dgvPhat.Rows[r].Cells[0].Value != null)
            {
                txtTu.Text = dgvPhat.Rows[r].Cells[1].Value.ToString();
                txtDen.Text= dgvPhat.Rows[r].Cells[2].Value.ToString();
                richNoiDungPhat.Text= dgvPhat.Rows[r].Cells[3].Value.ToString();
            }
        }

        private void btnSuaPhat_Click(object sender, EventArgs e)
        {
            f_Phat = false;

            int r = dgvPhat.CurrentCell.RowIndex;
            if (dgvPhat.Rows[r].Cells[0].Value != null)
            {
                txtTu.Text = dgvPhat.Rows[r].Cells[1].Value.ToString();
                txtDen.Text = dgvPhat.Rows[r].Cells[2].Value.ToString();
                richNoiDungPhat.Text = dgvPhat.Rows[r].Cells[3].Value.ToString();
                maPhat= int.Parse(dgvPhat.Rows[r].Cells[0].Value.ToString());
            }

            groupPhat.Enabled = true;
            richNoiDungPhat.ReadOnly = false;
            btnThemPhat.Enabled = false;
            btnSuaPhat.Enabled = false;
            btnXoaPhat.Enabled = false;
            btnLuuPhat.Enabled = true;
            btnHuyPhat.Enabled = true;

            txtTu.Focus();


        }

        private void btnHuyPhat_Click(object sender, EventArgs e)
        {
            groupPhat.Enabled = false;
            richNoiDungPhat.ReadOnly = true;
            btnThemPhat.Enabled = true;
            btnSuaPhat.Enabled = true;
            btnXoaPhat.Enabled = true;
            btnLuuPhat.Enabled = false;
            btnHuyPhat.Enabled = false;
        }

        private void btnXoaPhat_Click(object sender, EventArgs e)
        {
            try
            {
                //lấy hàng cần xóa
                int r = dgvPhat.CurrentCell.RowIndex;
                int maP = int.Parse(dgvPhat.Rows[r].Cells[0].Value.ToString());
                //hỏi xem có muốn xóa không
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (traloi == DialogResult.OK)
                {
                    bool trangthai = l.XoaMucPhat(maP);
                    if (trangthai)
                    {

                        MessageBox.Show("Xóa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMucPhat();

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
            catch { }
        }

        private void btnLuuPhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTu.Text.Trim() == "" || txtDen.Text == "" || richNoiDungPhat.Text.Trim() == "")
                {
                    MessageBox.Show("Hãy điền đầy đủ thông tin vào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (f_Phat)
                {
                    bool trangthai = l.ThemMucPhat(float.Parse(txtTu.Text),float.Parse(txtDen.Text),richNoiDungPhat.Text);
                    if (trangthai)
                    {
                        MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMucPhat();
                    }
                    else
                    {
                        MessageBox.Show("Không thêm được!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    bool trangthai = l.CapNhatMucPhat(maPhat, float.Parse(txtTu.Text),float.Parse(txtDen.Text),richNoiDungPhat.Text);
                    if (trangthai)
                    {
                        MessageBox.Show("Sữa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMucPhat();
                    }
                    else
                    {
                        MessageBox.Show("Không sữa được!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch { }
        }

        private void richTextBoxLuat_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabLuat_Click(object sender, EventArgs e)
        {

        }

        private void comboxMaChuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtTenChuong.Text = l.getTenChuongTheoMa(comboxMaChuong.Text).Tables[0].Rows[0][1].ToString();
            }
            catch { }
           
        }

        private void dgvLuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvLuat.CurrentCell.RowIndex;
            if (dgvLuat.Rows[r].Cells[0].Value != null)
            {
                try
                {
                    comboxMaChuong.Text = l.getMaChuong_TenChuongTheoSoDieu(int.Parse(dgvLuat.Rows[r].Cells[0].Value.ToString())).Tables[0].Rows[0][0].ToString();
                    txtTenChuong.Text = l.getMaChuong_TenChuongTheoSoDieu(int.Parse(dgvLuat.Rows[r].Cells[0].Value.ToString())).Tables[0].Rows[0][1].ToString();
                }
                catch { }
                txtSoDieu.Text = dgvLuat.Rows[r].Cells[1].Value.ToString();
                richTextBoxLuat.Text= dgvLuat.Rows[r].Cells[2].Value.ToString();
            }
        }

        private void btnThemLuat_Click(object sender, EventArgs e)
        {
            f_Luat = true;

            panelLuat.Enabled = true;
            richTextBoxLuat.ReadOnly = false;
            btnThemLuat.Enabled = false;
            btnXoaLuat.Enabled = false;
            btnSuaLuat.Enabled = false;
            btnLuuLuat.Enabled = true;
            btnHuyLuat.Enabled = true;

            comboxMaChuong.ResetText();
            txtTenChuong.ResetText();
            txtSoDieu.ResetText();
            richTextBoxLuat.ResetText();

        }

        private void btnSuaLuat_Click(object sender, EventArgs e)
        {
            f_Luat = false;

            panelLuat.Enabled = true;
            richTextBoxLuat.ReadOnly = false;
            btnThemLuat.Enabled = false;
            btnXoaLuat.Enabled = false;
            btnSuaLuat.Enabled = false;
            btnLuuLuat.Enabled = true;
            btnHuyLuat.Enabled = true;
            comboxMaChuong.Enabled = false;
            int r = dgvLuat.CurrentCell.RowIndex;
            if (dgvLuat.Rows[r].Cells[0].Value != null)
            {
                comboxMaChuong.Text = l.getMaChuong_TenChuongTheoSoDieu(int.Parse(dgvLuat.Rows[r].Cells[0].Value.ToString())).Tables[0].Rows[0][0].ToString();
                txtTenChuong.Text = l.getMaChuong_TenChuongTheoSoDieu(int.Parse(dgvLuat.Rows[r].Cells[0].Value.ToString())).Tables[0].Rows[0][1].ToString();
                txtSoDieu.Text = dgvLuat.Rows[r].Cells[1].Value.ToString();
                richTextBoxLuat.Text = dgvLuat.Rows[r].Cells[2].Value.ToString();
                TT_SoDieu= int.Parse(dgvLuat.Rows[r].Cells[0].Value.ToString());
            }

        }

        private void btnHuyLuat_Click(object sender, EventArgs e)
        {
            panelLuat.Enabled = false;
            richTextBoxLuat.ReadOnly = true;
            btnThemLuat.Enabled = true;
            btnXoaLuat.Enabled = true;
            btnSuaLuat.Enabled = true;
            btnLuuLuat.Enabled = false;
            btnHuyLuat.Enabled = false;
            comboxMaChuong.Enabled = true;
           
        }

        private void btnXoaLuat_Click(object sender, EventArgs e)
        {
            try
            {
                //lấy hàng cần xóa
                int r = dgvLuat.CurrentCell.RowIndex;
                int TT = int.Parse(dgvLuat.Rows[r].Cells[0].Value.ToString());
                //hỏi xem có muốn xóa không
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (traloi == DialogResult.OK)
                {
                    bool trangthai = l.XoaChiTietChuong(TT);
                    if (trangthai)
                    {

                        MessageBox.Show("Xóa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadLuat();

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
            catch
            {

            }
        }

        private void btnLuuLuat_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboxMaChuong.Text.Trim() == "" || txtTenChuong.Text.Trim() == "" || txtSoDieu.Text == "" || richTextBoxLuat.Text.Trim() == "")
                {
                    MessageBox.Show("Hãy điền đầy đủ thông tin vào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (f_Luat)
                {
                    int temp = l.testMaChuong(comboxMaChuong.Text).Tables[0].Rows.Count;
                    if (temp > 0)
                    {
                        bool trangthai = l.ThemChiTietChuong(comboxMaChuong.Text,txtSoDieu.Text,richTextBoxLuat.Text);
                        if (trangthai)
                        {
                            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadLuat();
                        }
                        else
                        {
                            MessageBox.Show("Không thêm được!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        bool trangthai = l.ThemHocLuat_ChiTiet(comboxMaChuong.Text, txtTenChuong.Text, txtSoDieu.Text, richTextBoxLuat.Text);
                        if (trangthai)
                        {
                            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadLuat();
                        }
                        else
                        {
                            MessageBox.Show("Không thêm được!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    bool trangthai = l.CapNhatHocLuatGiaoThong(comboxMaChuong.Text,txtTenChuong.Text,TT_SoDieu,txtSoDieu.Text,richTextBoxLuat.Text);
                    if (trangthai)
                    {
                        MessageBox.Show("Sữa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadLuat();
                    }
                    else
                    {
                        MessageBox.Show("Không sữa được!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { }
        }


        private void quanLyLuat_Load(object sender, EventArgs e)
        {
            LoadLuat();

            toolTip1.SetToolTip(btnThemLuat, "Thêm");
            toolTip1.SetToolTip(btnSuaLuat, "Sữa");
            toolTip1.SetToolTip(btnXoaLuat, "Xóa");
            toolTip1.SetToolTip(btnLuuLuat, "Lưu");
            toolTip1.SetToolTip(btnHuyLuat, "Hủy");
            toolTip1.SetToolTip(richTextBoxLuat, "Nội dung điều luật");
            toolTip1.SetToolTip(btnThem, "Thêm");
            toolTip1.SetToolTip(btnSua, "Sửa");
            toolTip1.SetToolTip(btnXoa, "Xóa");
            toolTip1.SetToolTip(btnLuu, "Lưu");
            toolTip1.SetToolTip(btnHuy, "Hủy");
            toolTip1.SetToolTip(richNoiDung, "Nội dung thông tư");
            toolTip1.SetToolTip(dateTimePicker1, "Ngày thông tư");
            toolTip1.SetToolTip(btnThemPhat, "Thêm");
            toolTip1.SetToolTip(btnSuaPhat, "Sữa");
            toolTip1.SetToolTip(btnXoaPhat, "Xóa");
            toolTip1.SetToolTip(btnLuuPhat, "Lưu");
            toolTip1.SetToolTip(btnHuyPhat, "Hủy");
            toolTip1.SetToolTip(richNoiDungPhat, "Nội dung phạt");
            toolTip1.SetToolTip(txtTu, "Đầu khoảng phạt");
            toolTip1.SetToolTip(txtDen, "Cuối khoảng phạt");
        }
    }
}
