using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace AnToanGiaoThong.Frm
{
    public partial class savePDF : Form
    {
        string DeThi;
        public savePDF(string dethi)
        {
            InitializeComponent();
            DeThi = dethi;
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                txtPath.Text = fbd.SelectedPath;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Trim() != "" && txtPath.Text.Trim() != "")
                {
                    iTextSharp.text.pdf.BaseFont Vn_Helvetica = iTextSharp.text.pdf.BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", "Identity-H", iTextSharp.text.pdf.BaseFont.EMBEDDED);
                    iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(Vn_Helvetica, 10, iTextSharp.text.Font.NORMAL);

                    Document doc = new Document(iTextSharp.text.PageSize.A4, 30f, 30f, 30f, 40f);

                    PdfWriter write = PdfWriter.GetInstance(doc, new FileStream(txtPath.Text + "\\" + txtName.Text + ".pdf", FileMode.Create));
                    doc.Open();

                    Chunk c = new Chunk();
                    c.Font = fontNormal;
                    c.Append(DeThi);

                    doc.Add(new Paragraph(c));
                    doc.Close();

                    MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Hãy nhập đầy đủ thông tin vào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch {
                MessageBox.Show("Không lưu được!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
    }
}
