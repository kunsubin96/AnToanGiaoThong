namespace AnToanGiaoThong.Module
{
    partial class kingNghiemGiaoThong
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
            this.label2 = new System.Windows.Forms.Label();
            this.rdbLoaiKinhNghiem = new System.Windows.Forms.RadioButton();
            this.rdbKinhNghiem = new System.Windows.Forms.RadioButton();
            this.cmbTenLoaiKN = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.rtbNoiDungXem = new System.Windows.Forms.RichTextBox();
            this.dgvLoaiKN = new System.Windows.Forms.DataGridView();
            this.dgvKinhNghiem = new System.Windows.Forms.DataGridView();
            this.txtTenKN = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiKN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKinhNghiem)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(439, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 20);
            this.label2.TabIndex = 37;
            this.label2.Text = "Tên Kinh Nghiệm:";
            // 
            // rdbLoaiKinhNghiem
            // 
            this.rdbLoaiKinhNghiem.AutoSize = true;
            this.rdbLoaiKinhNghiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbLoaiKinhNghiem.Location = new System.Drawing.Point(10, 13);
            this.rdbLoaiKinhNghiem.Name = "rdbLoaiKinhNghiem";
            this.rdbLoaiKinhNghiem.Size = new System.Drawing.Size(166, 24);
            this.rdbLoaiKinhNghiem.TabIndex = 38;
            this.rdbLoaiKinhNghiem.TabStop = true;
            this.rdbLoaiKinhNghiem.Text = "Loại Kinh Nghiệm";
            this.rdbLoaiKinhNghiem.UseVisualStyleBackColor = true;
            this.rdbLoaiKinhNghiem.CheckedChanged += new System.EventHandler(this.rdbLoaiKinhNghiem_CheckedChanged);
            // 
            // rdbKinhNghiem
            // 
            this.rdbKinhNghiem.AutoSize = true;
            this.rdbKinhNghiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbKinhNghiem.Location = new System.Drawing.Point(454, 13);
            this.rdbKinhNghiem.Name = "rdbKinhNghiem";
            this.rdbKinhNghiem.Size = new System.Drawing.Size(127, 24);
            this.rdbKinhNghiem.TabIndex = 39;
            this.rdbKinhNghiem.TabStop = true;
            this.rdbKinhNghiem.Text = "Kinh Nghiệm";
            this.rdbKinhNghiem.UseVisualStyleBackColor = true;
            this.rdbKinhNghiem.CheckedChanged += new System.EventHandler(this.rdbKinhNghiem_CheckedChanged);
            // 
            // cmbTenLoaiKN
            // 
            this.cmbTenLoaiKN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTenLoaiKN.FormattingEnabled = true;
            this.cmbTenLoaiKN.Location = new System.Drawing.Point(163, 43);
            this.cmbTenLoaiKN.Name = "cmbTenLoaiKN";
            this.cmbTenLoaiKN.Size = new System.Drawing.Size(255, 28);
            this.cmbTenLoaiKN.TabIndex = 34;
            this.cmbTenLoaiKN.SelectedIndexChanged += new System.EventHandler(this.cmbLoaiKinhNghiem_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 20);
            this.label5.TabIndex = 37;
            this.label5.Text = "Tên Loại KN:";
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Image = global::AnToanGiaoThong.Properties.Resources.Close_2_icon;
            this.btnHuy.Location = new System.Drawing.Point(561, 284);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 42);
            this.btnHuy.TabIndex = 40;
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Image = global::AnToanGiaoThong.Properties.Resources.File_Delete_icon;
            this.btnXoa.Location = new System.Drawing.Point(741, 281);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 45);
            this.btnXoa.TabIndex = 28;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Image = global::AnToanGiaoThong.Properties.Resources.Actions_document_save_icon;
            this.btnLuu.Location = new System.Drawing.Point(407, 281);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 45);
            this.btnLuu.TabIndex = 29;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Image = global::AnToanGiaoThong.Properties.Resources.Edit_Document_icon;
            this.btnSua.Location = new System.Drawing.Point(247, 281);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 45);
            this.btnSua.TabIndex = 30;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Image = global::AnToanGiaoThong.Properties.Resources.add_icon__1_;
            this.btnThem.Location = new System.Drawing.Point(69, 281);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 45);
            this.btnThem.TabIndex = 31;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // rtbNoiDungXem
            // 
            this.rtbNoiDungXem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbNoiDungXem.Location = new System.Drawing.Point(5, 82);
            this.rtbNoiDungXem.Name = "rtbNoiDungXem";
            this.rtbNoiDungXem.ReadOnly = true;
            this.rtbNoiDungXem.Size = new System.Drawing.Size(901, 196);
            this.rtbNoiDungXem.TabIndex = 26;
            this.rtbNoiDungXem.Text = "Nội Dung Kinh Nghiệm";
            // 
            // dgvLoaiKN
            // 
            this.dgvLoaiKN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoaiKN.Location = new System.Drawing.Point(10, 332);
            this.dgvLoaiKN.Name = "dgvLoaiKN";
            this.dgvLoaiKN.Size = new System.Drawing.Size(333, 181);
            this.dgvLoaiKN.TabIndex = 41;
            this.dgvLoaiKN.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoaiKN_CellClick);
            // 
            // dgvKinhNghiem
            // 
            this.dgvKinhNghiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKinhNghiem.Location = new System.Drawing.Point(349, 332);
            this.dgvKinhNghiem.Name = "dgvKinhNghiem";
            this.dgvKinhNghiem.Size = new System.Drawing.Size(557, 181);
            this.dgvKinhNghiem.TabIndex = 41;
            this.dgvKinhNghiem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKinhNghiem_CellClick);
            // 
            // txtTenKN
            // 
            this.txtTenKN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKN.Location = new System.Drawing.Point(594, 43);
            this.txtTenKN.Multiline = true;
            this.txtTenKN.Name = "txtTenKN";
            this.txtTenKN.Size = new System.Drawing.Size(312, 33);
            this.txtTenKN.TabIndex = 42;
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // kingNghiemGiaoThong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtTenKN);
            this.Controls.Add(this.dgvKinhNghiem);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.rdbKinhNghiem);
            this.Controls.Add(this.rdbLoaiKinhNghiem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTenLoaiKN);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.rtbNoiDungXem);
            this.Controls.Add(this.dgvLoaiKN);
            this.Name = "kingNghiemGiaoThong";
            this.Size = new System.Drawing.Size(923, 529);
            this.Load += new System.EventHandler(this.kingNghiemGiaoThong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiKN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKinhNghiem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdbLoaiKinhNghiem;
        private System.Windows.Forms.RadioButton rdbKinhNghiem;
        private System.Windows.Forms.ComboBox cmbTenLoaiKN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.RichTextBox rtbNoiDungXem;
        private System.Windows.Forms.DataGridView dgvLoaiKN;
        private System.Windows.Forms.DataGridView dgvKinhNghiem;
        private System.Windows.Forms.TextBox txtTenKN;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
