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
using bussinessAccessLayer;
using System.Data.SqlClient;
namespace AnToanGiaoThong.Module
{
    public partial class thongKe : UserControl
    {
        private UserModel user;
        bussinessAccessLayer.ThongKe.ThongKe tk = new bussinessAccessLayer.ThongKe.ThongKe();
        public thongKe(UserModel curUser)
        {
            InitializeComponent();
            this.user = curUser;
           // user.
        }

        private void thongKe_Load(object sender, EventArgs e)
        {
            try
            {
                string username = user.Username;

                chart1.DataSource = tk.getAllLanThiUser(username).Tables[0];
                chart1.Series[0].YValueMembers = "Diem";

                lbMaxDiem.Text = tk.getDiemMAX_DiemTB(username).Tables[0].Rows[0][0].ToString();
                lbDTB.Text = tk.getDiemMAX_DiemTB(username).Tables[0].Rows[0][1].ToString();
                lbSoLanThi.Text = tk.getAllLanThiUser(username).Tables[0].Rows.Count.ToString();

                label2.Text = "Điểm Cao Nhất: ";
                label3.Text = "Điểm Trung Bình: ";
                label4.Text = "Số Lần Thi: ";

                lbTen.Text = user.Hoten;
            }
            catch
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error); 
            }
          
        }
    }
}
