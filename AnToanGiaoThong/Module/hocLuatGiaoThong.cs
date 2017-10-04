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
    public partial class hocLuatGiaoThong : UserControl
    {
        bussinessAccessLayer.HocLuat.HocLuat hl = new bussinessAccessLayer.HocLuat.HocLuat();
        DataSet ds = new DataSet();
        public hocLuatGiaoThong()
        {
            InitializeComponent();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (tabControl1.SelectedIndex)
                {
                    //luật giao thông
                    case 0:
                        richTextBoxLuat.ReadOnly = true;
                        ds = hl.getAllLuatGiaoThong();
                        DataView dvLuat = new DataView();
                        dvLuat.Table = ds.Tables[0];
                        treeViewLuat.Nodes.Clear();
                        for (int i = 0; i < dvLuat.Count; i++)
                        {
                            treeViewLuat.Nodes.Add(dvLuat.Table.Rows[i][1].ToString().Split(':')[0]);
                            DataView dvDieu = new DataView();
                            dvDieu.Table = hl.getDieuTheoChuong(dvLuat.Table.Rows[i][0].ToString()).Tables[0];
                            for (int j = 0; j < dvDieu.Count; j++)
                            {
                                treeViewLuat.Nodes[i].Nodes.Add(dvDieu.Table.Rows[j][1].ToString().Split('.')[0]);
                            }
                        }
                        break;
                    //thông tư
                    case 1:
                        richTextBoxThongTu.ReadOnly = true;
                        ds = hl.getAllDate();
                        DataView dv = new DataView();
                        dv.Table = ds.Tables[0];
                        treeViewThongTu.Nodes.Clear();
                        for (int i = 0; i < dv.Count; i++)
                        {
                            DateTime dt = DateTime.Parse(dv.Table.Rows[i][0].ToString());
                            string ngay = dt.Day.ToString() + "/" + dt.Month.ToString() + "/" + dt.Year.ToString();
                            treeViewThongTu.Nodes.Add(ngay);

                        }
                        break;
                    //tra cứu mức phạt
                    case 2:
                        richTextBoxPhat.ReadOnly = true;
                        DataView dvPhat = new DataView();
                        dvPhat.Table = hl.getKhoangPhat().Tables[0];
                        treeViewKhoangPhat.Nodes.Clear();
                        for (int i = 0; i < dvPhat.Count; i++)
                        {
                            treeViewKhoangPhat.Nodes.Add(dvPhat.Table.Rows[i][0].ToString() + " - " + dvPhat.Table.Rows[i][1].ToString());
                        }
                        break;
                    default: break;
                }
            }
            catch { }
           
        }

        private void treeViewThongTu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                string ngay = e.Node.Text;
                string[] temp = ngay.Split('/');
                string day = temp[2].ToString() + "-" + temp[1].ToString() + "-" + temp[0].ToString();
                //MessageBox.Show(day);
                DataSet dsNoiDung = new DataSet();
                dsNoiDung = hl.getNoiDungThongTu(day);
                DataView dv = new DataView();
                dv.Table = dsNoiDung.Tables[0];
                richTextBoxThongTu.ResetText();
                for (int i = 0; i < dv.Count; i++)
                {
                    richTextBoxThongTu.Text = richTextBoxThongTu.Text + "Số hiệu thông tư: " + dv.Table.Rows[i][0].ToString() + "\n" +
                        "Nội dung: " + dv.Table.Rows[i][3].ToString() + "\n\n";
                }
            }
            catch { }
           
        }

        private void treeViewLuat_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                string luat = e.Node.Text;

                switch (luat.Split(' ')[0])
                {
                    case "CHƯƠNG":
                        string maChuong = hl.getChuong(luat).Tables[0].Rows[0][0].ToString();
                        string tenChuong = hl.getChuong(luat).Tables[0].Rows[0][1].ToString();
                        DataView dvDieuCuaChuong = new DataView();
                        dvDieuCuaChuong.Table = hl.getDieuCuaChuong(maChuong).Tables[0];
                        richTextBoxLuat.ResetText();
                        richTextBoxLuat.SelectionFont = new Font("arial", 9, FontStyle.Bold);
                        richTextBoxLuat.Text = tenChuong + "\n";

                        for (int i = 0; i < dvDieuCuaChuong.Count; i++)
                        {
                            richTextBoxLuat.Text = richTextBoxLuat.Text + "\n" + dvDieuCuaChuong.Table.Rows[i][0].ToString() + "\nNội dung:\n " + dvDieuCuaChuong.Table.Rows[i][1].ToString() + "\n";
                        }
                        break;
                    case "Điều":
                        richTextBoxLuat.ResetText();
                        richTextBoxLuat.SelectionFont = new Font("arial", 9, FontStyle.Bold);
                        DataView dvDieu = new DataView();
                        dvDieu.Table = hl.getNoiDungDieu(luat).Tables[0];
                        richTextBoxLuat.Text = dvDieu.Table.Rows[0][0].ToString() + "\n" + "\n" +
                            dvDieu.Table.Rows[0][1].ToString();
                        break;
                    default: break;
                }
            }
            catch { }
          
        }

        private void treeViewKhoangPhat_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                float dau = float.Parse(e.Node.Text.Split('-')[0].Trim());
                float cuoi = float.Parse(e.Node.Text.Split('-')[1].Trim());
                DataView dv = new DataView();
                dv.Table = hl.getNoiDungPhat(dau, cuoi).Tables[0];
                richTextBoxPhat.ResetText();
                int k = 1;
                for (int i = 0; i < dv.Count; i++)
                {
                    richTextBoxPhat.Text = richTextBoxPhat.Text + (k++).ToString() + ". " + dv.Table.Rows[i][0].ToString() + "\n" + "\n";
                }
            }
            catch { }
        }

        private void hocLuatGiaoThong_Load(object sender, EventArgs e)
        {
            try
            {
                richTextBoxLuat.ReadOnly = true;
                tabControl1.SelectedIndex = 0;

                ds = hl.getAllLuatGiaoThong();
                DataView dvLuat = new DataView();
                dvLuat.Table = ds.Tables[0];
                treeViewLuat.Nodes.Clear();
                for (int i = 0; i < dvLuat.Count; i++)
                {
                    treeViewLuat.Nodes.Add(dvLuat.Table.Rows[i][1].ToString().Split(':')[0]);
                    DataView dvDieu = new DataView();
                    dvDieu.Table = hl.getDieuTheoChuong(dvLuat.Table.Rows[i][0].ToString()).Tables[0];
                    for (int j = 0; j < dvDieu.Count; j++)
                    {
                        treeViewLuat.Nodes[i].Nodes.Add(dvDieu.Table.Rows[j][1].ToString().Split('.')[0]);
                    }
                }
            }
            catch { }
           
        }
    }
}
