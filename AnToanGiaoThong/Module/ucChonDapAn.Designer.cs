namespace AnToanGiaoThong.Module
{
    partial class ucChonDapAn
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
            if (disposing&&(components!=null))
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.radiobtnD = new System.Windows.Forms.RadioButton();
            this.radiobtnC = new System.Windows.Forms.RadioButton();
            this.radiobtnB = new System.Windows.Forms.RadioButton();
            this.radiobtnA = new System.Windows.Forms.RadioButton();
            this.lblCauHoi = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.radiobtnD);
            this.panel3.Controls.Add(this.radiobtnC);
            this.panel3.Controls.Add(this.radiobtnB);
            this.panel3.Controls.Add(this.radiobtnA);
            this.panel3.Controls.Add(this.lblCauHoi);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(204, 35);
            this.panel3.TabIndex = 1;
            // 
            // radiobtnD
            // 
            this.radiobtnD.AutoSize = true;
            this.radiobtnD.Location = new System.Drawing.Point(169, 9);
            this.radiobtnD.Name = "radiobtnD";
            this.radiobtnD.Size = new System.Drawing.Size(33, 17);
            this.radiobtnD.TabIndex = 6;
            this.radiobtnD.Text = "D";
            this.radiobtnD.UseVisualStyleBackColor = true;
            this.radiobtnD.CheckedChanged += new System.EventHandler(this.radiobtnD_CheckedChanged);
            // 
            // radiobtnC
            // 
            this.radiobtnC.AutoSize = true;
            this.radiobtnC.Location = new System.Drawing.Point(131, 9);
            this.radiobtnC.Name = "radiobtnC";
            this.radiobtnC.Size = new System.Drawing.Size(32, 17);
            this.radiobtnC.TabIndex = 5;
            this.radiobtnC.Text = "C";
            this.radiobtnC.UseVisualStyleBackColor = true;
            this.radiobtnC.CheckedChanged += new System.EventHandler(this.radiobtnC_CheckedChanged);
            // 
            // radiobtnB
            // 
            this.radiobtnB.AutoSize = true;
            this.radiobtnB.Location = new System.Drawing.Point(93, 9);
            this.radiobtnB.Name = "radiobtnB";
            this.radiobtnB.Size = new System.Drawing.Size(32, 17);
            this.radiobtnB.TabIndex = 4;
            this.radiobtnB.Text = "B";
            this.radiobtnB.UseVisualStyleBackColor = true;
            this.radiobtnB.CheckedChanged += new System.EventHandler(this.radiobtnB_CheckedChanged);
            // 
            // radiobtnA
            // 
            this.radiobtnA.AutoSize = true;
            this.radiobtnA.ForeColor = System.Drawing.Color.Black;
            this.radiobtnA.Location = new System.Drawing.Point(55, 9);
            this.radiobtnA.Name = "radiobtnA";
            this.radiobtnA.Size = new System.Drawing.Size(32, 17);
            this.radiobtnA.TabIndex = 3;
            this.radiobtnA.Text = "A";
            this.radiobtnA.UseVisualStyleBackColor = true;
            this.radiobtnA.CheckedChanged += new System.EventHandler(this.radiobtnA_CheckedChanged);
            // 
            // lblCauHoi
            // 
            this.lblCauHoi.AutoSize = true;
            this.lblCauHoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCauHoi.Location = new System.Drawing.Point(6, 11);
            this.lblCauHoi.Name = "lblCauHoi";
            this.lblCauHoi.Size = new System.Drawing.Size(40, 13);
            this.lblCauHoi.TabIndex = 2;
            this.lblCauHoi.Text = "Câu 1";
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(0, 57);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(213, 51);
            this.panel4.TabIndex = 1;
            // 
            // ucChonDapAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Name = "ucChonDapAn";
            this.Size = new System.Drawing.Size(206, 37);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radiobtnD;
        private System.Windows.Forms.RadioButton radiobtnC;
        private System.Windows.Forms.RadioButton radiobtnB;
        private System.Windows.Forms.RadioButton radiobtnA;
        private System.Windows.Forms.Label lblCauHoi;
        private System.Windows.Forms.Panel panel4;
    }
}
