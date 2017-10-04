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
using System.Drawing.Printing;

namespace AnToanGiaoThong.Module
{
    public partial class soanDeThi : UserControl
    {
        bussinessAccessLayer.SoanDe.SoanDe sd = new bussinessAccessLayer.SoanDe.SoanDe();
        public soanDeThi()
        {
            InitializeComponent();
        }
        List<int> list = new List<int>();
        //List tất cả các mã trong ngân hàng câu hỏi
        List<int> listTatCa = new List<int>();
        private void btnSoan_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> listCau = new List<int>();
                //add list tất cả mã ngân hàng câu hỏi
                DataSet ds = new DataSet();
                ds = sd.getTatCaMaCauHoi();
                DataView dv = new DataView();

                dv.Table = ds.Tables[0];
                for (int k = 0; k < dv.Count; k++)
                {
                    listTatCa.Add(int.Parse(dv.Table.Rows[k][0].ToString()));
                }
                //khởi tạo hàm để sinh ngẩu nhiên
                Random cau = new Random();

                //Lấy mã cao nhất trong ngân hàng câu hỏi
                int maxCau = int.Parse(sd.getMAXCau().Tables[0].Rows[0][0].ToString());
                //đếm số câu hỏi trong ngân hàng câu hỏi
                int tongCau = int.Parse(sd.getTongCau().Tables[0].Rows[0][0].ToString());
                int soCau = (int)numericUpDownSoCau.Value;
                //Kiểm tra số câu yêu cầu so với ngân hàng câu hỏi
                if (soCau > tongCau)
                {
                    MessageBox.Show("Số câu đã lơn hơn tổng số câu trong ngân hàng câu hỏi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                while (soCau > 0)
                {
                    int macau = cau.Next(1, maxCau+1);
                    if (!listCau.Contains(macau) && listTatCa.Contains(macau))
                    {
                        listCau.Add(macau);
                        soCau--;
                    }
                } 
                int i = 1;
                dgvDsCauHoi.Rows.Clear();
                foreach (var u in listCau)
                {
                    dgvDsCauHoi.Rows.Add((i++).ToString(), u.ToString(), sd.getDapAnCau(u.ToString()).Tables[0].Rows[0][0].ToString());
                }
                list = listCau;
            }
            catch { }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDsCauHoi.Rows.Count - 1 <= 10)
                {
                    MessageBox.Show("Không thể xóa khi câu hỏi ở dưới mức 10 câu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //Lấy câu cần xóa
                int r = dgvDsCauHoi.CurrentCell.RowIndex;
                if (dgvDsCauHoi.Rows[r].Cells[0].Value != null)
                {
                    dgvDsCauHoi.Rows.Remove(dgvDsCauHoi.Rows[r]);
                }
                //Load lại thứ tự câu hỏi
                List<int> listUpdateXoa = new List<int>();
                for (int i = 0; i < dgvDsCauHoi.Rows.Count - 1; i++)
                    listUpdateXoa.Add(int.Parse(dgvDsCauHoi.Rows[i].Cells[1].Value.ToString()));
                dgvDsCauHoi.Rows.Clear();
                int k = 1;
                foreach (var u in listUpdateXoa)
                {
                    dgvDsCauHoi.Rows.Add((k++).ToString(), u.ToString(), sd.getDapAnCau(u.ToString()).Tables[0].Rows[0][0].ToString());
                }
            }
            catch { }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDsCauHoi.Rows[0].Cells[0].Value != null)
                {
                    Frm.frmSoLuongThem them = new Frm.frmSoLuongThem();
                    them.ShowDialog();
                    if (them.getTrangThai())
                    {
                        int maxCau = int.Parse(sd.getMAXCau().Tables[0].Rows[0][0].ToString());
                        int tongCau = int.Parse(sd.getTongCau().Tables[0].Rows[0][0].ToString());
                        Random cau = new Random();
                        if (them.getSoLuong() + dgvDsCauHoi.Rows.Count - 1 > tongCau)
                        {
                            MessageBox.Show("Số câu đã lơn hơn tổng số câu trong ngân hàng câu hỏi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        List<int> listCauThem = new List<int>();
                        int soCau = them.getSoLuong();
                        while (soCau > 0)
                        {
                            int macau = cau.Next(1, maxCau+1);
                            if (!list.Contains(macau) && listTatCa.Contains(macau))
                            {
                                list.Add(macau);
                                listCauThem.Add(macau);
                                soCau--;
                            }
                        }
                        int i = dgvDsCauHoi.Rows.Count;
                        foreach (var u in listCauThem)
                        {
                            dgvDsCauHoi.Rows.Add((i++).ToString(), u.ToString(), sd.getDapAnCau(u.ToString()).Tables[0].Rows[0][0].ToString());
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa soạn đề!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch { }
           
        }
        private void dgvDsCauHoi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvDsCauHoi.CurrentCell.RowIndex;
            if (dgvDsCauHoi.Rows[r].Cells[0].Value != null)
            {
                try
                {
                    string cauhoi = sd.getChiTietCauHoi(int.Parse(dgvDsCauHoi.Rows[r].Cells[1].Value.ToString())).Tables[0].Rows[0][1].ToString();
                    string A = sd.getChiTietCauHoi(int.Parse(dgvDsCauHoi.Rows[r].Cells[1].Value.ToString())).Tables[0].Rows[0][2].ToString();
                    string B = sd.getChiTietCauHoi(int.Parse(dgvDsCauHoi.Rows[r].Cells[1].Value.ToString())).Tables[0].Rows[0][3].ToString();
                    string C = sd.getChiTietCauHoi(int.Parse(dgvDsCauHoi.Rows[r].Cells[1].Value.ToString())).Tables[0].Rows[0][4].ToString();
                    string D = sd.getChiTietCauHoi(int.Parse(dgvDsCauHoi.Rows[r].Cells[1].Value.ToString())).Tables[0].Rows[0][5].ToString();
                    string dapanDung = dgvDsCauHoi.Rows[r].Cells[2].Value.ToString();
                    MessageBox.Show("Nội dung: " + cauhoi + "\n\nA: " + A + "\n\nB: " + B + "\n\nC: " + C + "\n\nD: " + D + "\n\nĐáp án đúng là: " + dapanDung, "Câu: " + dgvDsCauHoi.Rows[r].Cells[0].Value.ToString() + " (Mã câu: "
                        + dgvDsCauHoi.Rows[r].Cells[1].Value.ToString() + ")");
                }
                catch { }
               
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDsCauHoi.Rows[0].Cells[0].Value != null)
                {
                    if (richDeThi.Text.Trim() == "")
                    {
                        richDeThi.Text = "                                                                ĐỀ THI GIAO THÔNG\n\n";
                        //In đề
                        for (int i = 0; i < dgvDsCauHoi.Rows.Count - 1; i++)
                        {
                            string CauHoi = sd.getChiTietCauHoi(int.Parse(dgvDsCauHoi.Rows[i].Cells[1].Value.ToString())).Tables[0].Rows[0][1].ToString();
                            string A = sd.getChiTietCauHoi(int.Parse(dgvDsCauHoi.Rows[i].Cells[1].Value.ToString())).Tables[0].Rows[0][2].ToString();
                            string B = sd.getChiTietCauHoi(int.Parse(dgvDsCauHoi.Rows[i].Cells[1].Value.ToString())).Tables[0].Rows[0][3].ToString();
                            string C = sd.getChiTietCauHoi(int.Parse(dgvDsCauHoi.Rows[i].Cells[1].Value.ToString())).Tables[0].Rows[0][4].ToString();
                            string D = sd.getChiTietCauHoi(int.Parse(dgvDsCauHoi.Rows[i].Cells[1].Value.ToString())).Tables[0].Rows[0][5].ToString();

                            richDeThi.Text = richDeThi.Text + "Câu " + (i + 1).ToString() + ": " + CauHoi + "\nA: " + A + "\nB: " + B + "\nC: " + C + "\nD: " + D + "\n\n";
                        }
                        //In đáp án
                        richDeThi.Text = richDeThi.Text + "\nĐáp án:";
                        for (int i = 0; i < dgvDsCauHoi.Rows.Count - 1; i++)
                        {
                            richDeThi.Text = richDeThi.Text + "\nCâu " + (i + 1).ToString() + ": " + dgvDsCauHoi.Rows[i].Cells[2].Value.ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đã có đề thi rùi nếu muốn xuất lại đề hãy nhấn nút hủy bỏ đề này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("Vui lòng hãy soạn đề vào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch { }
           
        }

        private void btnHuyDeThi_Click(object sender, EventArgs e)
        {
            if (richDeThi.Text.Trim() != "")
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có muốn hủy đề thi này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(traloi== DialogResult.OK)
                {
                    richDeThi.ResetText();
                }
            }
        }

        private void btnXuatPDF_Click(object sender, EventArgs e)
        {
            if (richDeThi.Text.Trim() != "")
            {
                Frm.savePDF save = new Frm.savePDF(richDeThi.Text);
                save.ShowDialog();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (richDeThi.Text.Trim() != "")
            {
                printDialog1.Document = printDocument1;
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    
                    printDocument1.Print();
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richDeThi.Text.ToString(), new Font("arial", 9), Brushes.Black, 0, 0);
            e.PageSettings.Margins = new Margins(30, 30, 30, 30);
            e.PageSettings.PaperSize = new PaperSize("A4", 210,297);


        }

        private void soanDeThi_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnSoan, "Bấm để soạn đề thi theo số câu bên cạnh");
            toolTip1.SetToolTip(btnHuyDeThi, "Nhấn để hủy đề thi trong khung.");
            toolTip1.SetToolTip(btnAdd, "Nhấn chọn câu hỏi cần thêm vào.");
            toolTip1.SetToolTip(btnXoa, "Xóa câu hỏi trong table câu hỏi.");
            toolTip1.SetToolTip(btnXuat, "Xuất đề thi từ table sang khung nhập liệu bên phải.");
            toolTip1.SetToolTip(btnXuatPDF, "Xuất dữ liệu trong khung ra file PDF.");
            toolTip1.SetToolTip(button3, "In nội dung ra.");
            toolTip1.SetToolTip(dgvDsCauHoi, "Table các câu hỏi soạn sẳn.\n Nhấn DoubleClick vào để xem thông tin câu.");
            toolTip1.SetToolTip(richDeThi, "Khung đề thi.");
        }
    }
}
