namespace AnToanGiaoThong.Module
{
    partial class soanDeThi
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.richDeThi = new System.Windows.Forms.RichTextBox();
            this.btnSoan = new System.Windows.Forms.Button();
            this.dgvDsCauHoi = new System.Windows.Forms.DataGridView();
            this.Cau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaCau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DapAn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownSoCau = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            this.btnXuatPDF = new System.Windows.Forms.Button();
            this.btnHuyDeThi = new System.Windows.Forms.Button();
            this.btnXuat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDsCauHoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSoCau)).BeginInit();
            this.SuspendLayout();
            // 
            // richDeThi
            // 
            this.richDeThi.Location = new System.Drawing.Point(333, 75);
            this.richDeThi.Name = "richDeThi";
            this.richDeThi.Size = new System.Drawing.Size(589, 411);
            this.richDeThi.TabIndex = 17;
            this.richDeThi.Text = "";
            // 
            // btnSoan
            // 
            this.btnSoan.BackColor = System.Drawing.Color.Teal;
            this.btnSoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSoan.Location = new System.Drawing.Point(189, 21);
            this.btnSoan.Name = "btnSoan";
            this.btnSoan.Size = new System.Drawing.Size(75, 33);
            this.btnSoan.TabIndex = 16;
            this.btnSoan.Text = "SOẠN";
            this.btnSoan.UseVisualStyleBackColor = false;
            this.btnSoan.Click += new System.EventHandler(this.btnSoan_Click);
            // 
            // dgvDsCauHoi
            // 
            this.dgvDsCauHoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDsCauHoi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cau,
            this.MaCau,
            this.DapAn});
            this.dgvDsCauHoi.Location = new System.Drawing.Point(33, 75);
            this.dgvDsCauHoi.Name = "dgvDsCauHoi";
            this.dgvDsCauHoi.Size = new System.Drawing.Size(240, 411);
            this.dgvDsCauHoi.TabIndex = 13;
            this.dgvDsCauHoi.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDsCauHoi_CellDoubleClick);
            // 
            // Cau
            // 
            this.Cau.HeaderText = "Câu";
            this.Cau.Name = "Cau";
            this.Cau.Width = 50;
            // 
            // MaCau
            // 
            this.MaCau.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaCau.HeaderText = "Mã Câu";
            this.MaCau.Name = "MaCau";
            // 
            // DapAn
            // 
            this.DapAn.HeaderText = "Đáp Án";
            this.DapAn.Name = "DapAn";
            this.DapAn.Width = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Số Câu";
            // 
            // numericUpDownSoCau
            // 
            this.numericUpDownSoCau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownSoCau.Location = new System.Drawing.Point(105, 25);
            this.numericUpDownSoCau.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownSoCau.Name = "numericUpDownSoCau";
            this.numericUpDownSoCau.Size = new System.Drawing.Size(65, 26);
            this.numericUpDownSoCau.TabIndex = 11;
            this.numericUpDownSoCau.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = global::AnToanGiaoThong.Properties.Resources.folder_printer_icon;
            this.button3.Location = new System.Drawing.Point(676, 492);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 45);
            this.button3.TabIndex = 22;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnXuatPDF
            // 
            this.btnXuatPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatPDF.Image = global::AnToanGiaoThong.Properties.Resources.pdf_icon__1_;
            this.btnXuatPDF.Location = new System.Drawing.Point(484, 492);
            this.btnXuatPDF.Name = "btnXuatPDF";
            this.btnXuatPDF.Size = new System.Drawing.Size(75, 45);
            this.btnXuatPDF.TabIndex = 20;
            this.btnXuatPDF.UseVisualStyleBackColor = true;
            this.btnXuatPDF.Click += new System.EventHandler(this.btnXuatPDF_Click);
            // 
            // btnHuyDeThi
            // 
            this.btnHuyDeThi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyDeThi.Image = global::AnToanGiaoThong.Properties.Resources.File_Delete_icon;
            this.btnHuyDeThi.Location = new System.Drawing.Point(279, 255);
            this.btnHuyDeThi.Name = "btnHuyDeThi";
            this.btnHuyDeThi.Size = new System.Drawing.Size(48, 40);
            this.btnHuyDeThi.TabIndex = 19;
            this.btnHuyDeThi.UseVisualStyleBackColor = true;
            this.btnHuyDeThi.Click += new System.EventHandler(this.btnHuyDeThi_Click);
            // 
            // btnXuat
            // 
            this.btnXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuat.Image = global::AnToanGiaoThong.Properties.Resources.document_arrow_right_icon;
            this.btnXuat.Location = new System.Drawing.Point(279, 187);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(48, 40);
            this.btnXuat.TabIndex = 18;
            this.btnXuat.UseVisualStyleBackColor = true;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Image = global::AnToanGiaoThong.Properties.Resources.Close_2_icon;
            this.btnXoa.Location = new System.Drawing.Point(173, 492);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 45);
            this.btnXoa.TabIndex = 15;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::AnToanGiaoThong.Properties.Resources.add_icon__1_;
            this.btnAdd.Location = new System.Drawing.Point(54, 492);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 45);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Thông tin";
            // 
            // soanDeThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnXuatPDF);
            this.Controls.Add(this.btnHuyDeThi);
            this.Controls.Add(this.btnXuat);
            this.Controls.Add(this.richDeThi);
            this.Controls.Add(this.btnSoan);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvDsCauHoi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownSoCau);
            this.Name = "soanDeThi";
            this.Size = new System.Drawing.Size(951, 566);
            this.Load += new System.EventHandler(this.soanDeThi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDsCauHoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSoCau)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnXuatPDF;
        private System.Windows.Forms.Button btnHuyDeThi;
        private System.Windows.Forms.Button btnXuat;
        private System.Windows.Forms.RichTextBox richDeThi;
        private System.Windows.Forms.Button btnSoan;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvDsCauHoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cau;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCau;
        private System.Windows.Forms.DataGridViewTextBoxColumn DapAn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownSoCau;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
