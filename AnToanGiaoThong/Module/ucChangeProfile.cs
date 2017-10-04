using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnToanGiaoThong.Classes;
using bussinessAccessLayer.DangNhap_DangKi;
namespace AnToanGiaoThong.Module
{
    public partial class ucChangeProfile : UserControl
    {
        public ucChangeProfile(string username)
        {
            this.username=username;
            InitializeComponent();

        }
        DataTable dt = new DataTable();
        loginBA loginBA = new loginBA();
        editProfileBA editprofileBA = new editProfileBA();
        public string username;
        private void ChangeProfile_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            dt=loginBA.infoUser(username).Tables[0];
            try
            {
                lblUsername.Text=dt.Rows[0][0].ToString();
                lblHoTen.Text=dt.Rows[0][2].ToString();
                lblNgaySinh.Text=((DateTime)dt.Rows[0][4]).ToShortDateString();
                lblQueQuan.Text=dt.Rows[0][3].ToString();
                Function f = new Function();
                imgAvatar.Image=f.ResizeImage(f.Byte2Image((byte[])dt.Rows[0][5]), imgAvatar.Width, imgAvatar.Height);
            }
            catch { }
        }

        private void suaClick(Label lb, TextBox tb)
        {

            if (lb.Text=="Sửa")
            {
                lb.Text="Lưu";
                tb.Enabled=true;
            }
            else
            {

                if (!editprofileBA.editProfile(lblUsername.Text, lblHoTen.Text, lblQueQuan.Text, lblNgaySinh.Value))
                {
                    MessageBox.Show("Thay đổi thất bại");
                    return;
                }
                lb.Text="Sửa";
                tb.Enabled=false;
                LoadData();
            }
        }
        private void label10_Click(object sender, EventArgs e)
        {
            suaClick(this.label10, this.lblHoTen);
        }

        private void label11_Click(object sender, EventArgs e)
        {
            if (label11.Text=="Sửa")
            {
                label11.Text="Lưu";
                lblNgaySinh.Enabled=true;
            }
            else
            {

                if (!editprofileBA.editProfile(lblUsername.Text, lblHoTen.Text, lblQueQuan.Text, lblNgaySinh.Value))
                {
                    MessageBox.Show("Thay đổi thất bại");
                    return;
                }
                //Save vào CSDL
                label11.Text="Sửa";
                lblNgaySinh.Enabled=false;
                LoadData();
            }

        }

        private void label12_Click(object sender, EventArgs e)
        {
            suaClick(this.label12, this.lblQueQuan);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Frm.frmDoiMatKhau(lblUsername.Text).ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter="Image files (*.jpg)|*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog()==DialogResult.OK)
            {
                imgAvatar.Image=Image.FromFile(openFileDialog.FileName);
                if (!editprofileBA.editAvatar(lblUsername.Text, new Function().Image2Byte(imgAvatar.Image)))
                {
                    MessageBox.Show("Thay đổi ảnh đại diện thất bại");
                    return;
                }

                MessageBox.Show("Thay đổi thành công");
            }
        }
    }
}
