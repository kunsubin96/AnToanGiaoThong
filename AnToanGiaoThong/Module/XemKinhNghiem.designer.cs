namespace AnToanGiaoThong.Module
{
    partial class XemKinhNghiem
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
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTenKinhNghiem = new System.Windows.Forms.ComboBox();
            this.cmbTenLoaiKN = new System.Windows.Forms.ComboBox();
            this.rtbNoiDungXem = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 20);
            this.label5.TabIndex = 49;
            this.label5.Text = "Tên Loại KN:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 20);
            this.label2.TabIndex = 50;
            this.label2.Text = "Tên Kinh Nghiệm:";
            // 
            // cmbTenKinhNghiem
            // 
            this.cmbTenKinhNghiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTenKinhNghiem.FormattingEnabled = true;
            this.cmbTenKinhNghiem.Location = new System.Drawing.Point(184, 51);
            this.cmbTenKinhNghiem.Name = "cmbTenKinhNghiem";
            this.cmbTenKinhNghiem.Size = new System.Drawing.Size(440, 28);
            this.cmbTenKinhNghiem.TabIndex = 48;
            this.cmbTenKinhNghiem.SelectedIndexChanged += new System.EventHandler(this.cmbTenKinhNghiem_SelectedIndexChanged);
            // 
            // cmbTenLoaiKN
            // 
            this.cmbTenLoaiKN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTenLoaiKN.FormattingEnabled = true;
            this.cmbTenLoaiKN.Location = new System.Drawing.Point(184, 17);
            this.cmbTenLoaiKN.Name = "cmbTenLoaiKN";
            this.cmbTenLoaiKN.Size = new System.Drawing.Size(440, 28);
            this.cmbTenLoaiKN.TabIndex = 47;
            this.cmbTenLoaiKN.SelectedIndexChanged += new System.EventHandler(this.cmbTenLoaiKN_SelectedIndexChanged);
            // 
            // rtbNoiDungXem
            // 
            this.rtbNoiDungXem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbNoiDungXem.Location = new System.Drawing.Point(13, 88);
            this.rtbNoiDungXem.Name = "rtbNoiDungXem";
            this.rtbNoiDungXem.ReadOnly = true;
            this.rtbNoiDungXem.Size = new System.Drawing.Size(920, 413);
            this.rtbNoiDungXem.TabIndex = 41;
            this.rtbNoiDungXem.Text = "Nội Dung Kinh Nghiệm";
            // 
            // XemKinhNghiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTenKinhNghiem);
            this.Controls.Add(this.cmbTenLoaiKN);
            this.Controls.Add(this.rtbNoiDungXem);
            this.Name = "XemKinhNghiem";
            this.Size = new System.Drawing.Size(945, 518);
            this.Load += new System.EventHandler(this.XemKinhNghiem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTenKinhNghiem;
        private System.Windows.Forms.ComboBox cmbTenLoaiKN;
        private System.Windows.Forms.RichTextBox rtbNoiDungXem;
    }
}
