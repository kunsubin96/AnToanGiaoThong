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
using System.IO;
using System.Data.SqlClient;
namespace AnToanGiaoThong.Module
{
    public partial class user : UserControl
    {
        bussinessAccessLayer.Admin.TaiKhoan tk = new bussinessAccessLayer.Admin.TaiKhoan();
        MemoryStream ms = null;


        byte[] arrImg;
        bool f;
        string username;
        public user()
        {
            InitializeComponent();
        }

        private void dgvUser_Load(object sender, EventArgs e)
        {
            LoadData();

            toolTip1.SetToolTip(btnThem, "Thêm");
            toolTip1.SetToolTip(btnSua, "Sữa");
            toolTip1.SetToolTip(btnXoa, "Xóa");
            toolTip1.SetToolTip(btnLuu, "Lưu");
            toolTip1.SetToolTip(btnHuy, "Hủy");
            toolTip1.SetToolTip(btnBrowser, "Tìm hình");
            toolTip1.SetToolTip(dateTimePicker1, "Ngày sinh");
            toolTip1.SetToolTip(avatar, "Hình đại diện");
        }
        public void LoadData()
        {
            dgvUser.DataSource = tk.getAllUser().Tables[0];
            //
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            panelThongTin.Enabled = false;
            txtPass.ResetText();
            txtUserName.Enabled = false;
            txtPass.Enabled = false;


            Image imgDefault = AnToanGiaoThong.Properties.Resources.Vista_login12;
            ms=new MemoryStream();
            imgDefault.Save(ms, imgDefault.RawFormat);
            arrImg=ms.GetBuffer();
            ms.Close();
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dgvUser.CurrentCell.RowIndex;
                if (dgvUser.Rows[r].Cells[0].Value != null)
                {
                    txtUserName.Text = dgvUser.Rows[r].Cells[0].Value.ToString();
                    txtHoTen.Text = dgvUser.Rows[r].Cells[1].Value.ToString();
                    txtQueQuan.Text = dgvUser.Rows[r].Cells[2].Value.ToString();
                    dateTimePicker1.Text = dgvUser.Rows[r].Cells[3].Value.ToString();

                    if (!dgvUser.Rows[r].Cells[4].Value.GetType().ToString().Equals("System.DBNull"))
                        avatar.Image = (Image)dgvUser.Rows[r].Cells[4].FormattedValue;
                    else
                    {
                        avatar.Image = AnToanGiaoThong.Properties.Resources.Vista_login12;
                    }
                }
            }
            catch { }
            
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Image files (*.jpg)|*.jpg|All files (*.*)|*.*";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                avatar.Image = Image.FromFile(opf.FileName);
                ms=new MemoryStream();
                avatar.Image.Save(ms, avatar.Image.RawFormat);
                arrImg=ms.GetBuffer();
                ms.Close();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            f = true;
            //
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            panelThongTin.Enabled = true;
            txtUserName.Enabled = true;
            txtPass.Enabled = true;
            txtUserName.ResetText();
            txtPass.ResetText();
            txtHoTen.ResetText();
            txtQueQuan.ResetText();
            //


        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            panelThongTin.Enabled = false;
        }
        
        private void btnSua_Click(object sender, EventArgs e)
        {
            f = false;
            //
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            panelThongTin.Enabled = true;
            int r = dgvUser.CurrentCell.RowIndex;
            if (dgvUser.Rows[r].Cells[0].Value != null)
            {
                txtUserName.Text= dgvUser.Rows[r].Cells[0].Value.ToString();
                txtHoTen.Text = dgvUser.Rows[r].Cells[1].Value.ToString();
                txtQueQuan.Text = dgvUser.Rows[r].Cells[2].Value.ToString();
                dateTimePicker1.Text = dgvUser.Rows[r].Cells[3].Value.ToString();
                avatar.Image = (Image)dgvUser.Rows[r].Cells[4].FormattedValue;
                username= dgvUser.Rows[r].Cells[0].Value.ToString();
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                //lấy hàng cần xóa
                int r = dgvUser.CurrentCell.RowIndex;
                string user = dgvUser.Rows[r].Cells[0].Value.ToString();
                //hỏi xem có muốn xóa không
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có muốn xóa không?\nMọi thông tin về tài khoản này kể cả các lần thi sẽ mất. ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (traloi == DialogResult.OK)
                {
                    bool trangthai = tk.XoaTaiKhoan(user);
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
            catch
            {

            }
        }
     
        private void btnLuu_Click(object sender, EventArgs e)
        {
            
            try
            {
                if(txtHoTen.Text.Trim()==""||txtQueQuan.Text.Trim()=="")
                {
                    MessageBox.Show("Điền đầy đủ thông tin vào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (f)
                {
                    if (txtUserName.Text.Trim()==""||txtPass.Text.Trim()=="")
                    {
                        MessageBox.Show("Điền đầy đủ thông tin vào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                  

                    bool trangthai = tk.ThemTaiKhoan(txtUserName.Text, txtPass.Text, txtHoTen.Text, txtQueQuan.Text, dateTimePicker1.Value, arrImg);
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
                    bool trangthai=tk.CapNhatTaiKhoan(username, txtHoTen.Text, txtQueQuan.Text, dateTimePicker1.Value, arrImg);
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
            catch
            {

            }
        }
    }
}
