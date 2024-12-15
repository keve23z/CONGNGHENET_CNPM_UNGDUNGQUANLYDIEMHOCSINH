namespace UNGDUNGQUANLYDIEMHOCSINH
{
    partial class PhanCong
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
            this.lb_ThongTin = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            this.grb_CTTT = new System.Windows.Forms.GroupBox();
            this.cmb_MaLop = new System.Windows.Forms.ComboBox();
            this.cmb_MaPhanCong = new System.Windows.Forms.ComboBox();
            this.cmb_MaMH = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_MaGV = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.grb_TimKiem = new System.Windows.Forms.GroupBox();
            this.btn_TK = new System.Windows.Forms.Button();
            this.cmb_ThongTInTImKIem = new System.Windows.Forms.ComboBox();
            this.cmb_KieuTimKiem = new System.Windows.Forms.ComboBox();
            this.lb_TT = new System.Windows.Forms.Label();
            this.lb_KTK = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grb_CTTT.SuspendLayout();
            this.grb_TimKiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_ThongTin
            // 
            this.lb_ThongTin.AutoSize = true;
            this.lb_ThongTin.Font = new System.Drawing.Font("Tahoma", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ThongTin.ForeColor = System.Drawing.Color.SeaGreen;
            this.lb_ThongTin.Location = new System.Drawing.Point(456, 13);
            this.lb_ThongTin.Name = "lb_ThongTin";
            this.lb_ThongTin.Size = new System.Drawing.Size(393, 36);
            this.lb_ThongTin.TabIndex = 54;
            this.lb_ThongTin.Text = "PHÂN CÔNG GIẢNG DẠY ";
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.groupBox1.BackColor = System.Drawing.Color.MediumAquamarine;
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox1.Location = new System.Drawing.Point(479, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(771, 647);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DANH SÁCH PHÂN CÔNG";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(727, 592);
            this.dataGridView1.TabIndex = 32;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btn_Sua
            // 
            this.btn_Sua.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_Sua.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sua.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn_Sua.Location = new System.Drawing.Point(244, 382);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(98, 35);
            this.btn_Sua.TabIndex = 63;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.UseVisualStyleBackColor = false;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_Xoa.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn_Xoa.Location = new System.Drawing.Point(130, 382);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(98, 35);
            this.btn_Xoa.TabIndex = 62;
            this.btn_Xoa.Text = "Xoá";
            this.btn_Xoa.UseVisualStyleBackColor = false;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_Them
            // 
            this.btn_Them.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_Them.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Them.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn_Them.Location = new System.Drawing.Point(16, 382);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(98, 35);
            this.btn_Them.TabIndex = 61;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = false;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // grb_CTTT
            // 
            this.grb_CTTT.BackColor = System.Drawing.Color.MediumAquamarine;
            this.grb_CTTT.Controls.Add(this.cmb_MaLop);
            this.grb_CTTT.Controls.Add(this.cmb_MaPhanCong);
            this.grb_CTTT.Controls.Add(this.cmb_MaMH);
            this.grb_CTTT.Controls.Add(this.label3);
            this.grb_CTTT.Controls.Add(this.label2);
            this.grb_CTTT.Controls.Add(this.cmb_MaGV);
            this.grb_CTTT.Controls.Add(this.label4);
            this.grb_CTTT.Controls.Add(this.label1);
            this.grb_CTTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_CTTT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grb_CTTT.Location = new System.Drawing.Point(16, 132);
            this.grb_CTTT.Name = "grb_CTTT";
            this.grb_CTTT.Size = new System.Drawing.Size(440, 230);
            this.grb_CTTT.TabIndex = 64;
            this.grb_CTTT.TabStop = false;
            this.grb_CTTT.Text = "Thông Tin Giáo Viên";
            // 
            // cmb_MaLop
            // 
            this.cmb_MaLop.FormattingEnabled = true;
            this.cmb_MaLop.Location = new System.Drawing.Point(164, 126);
            this.cmb_MaLop.Name = "cmb_MaLop";
            this.cmb_MaLop.Size = new System.Drawing.Size(255, 28);
            this.cmb_MaLop.TabIndex = 39;
            // 
            // cmb_MaPhanCong
            // 
            this.cmb_MaPhanCong.FormattingEnabled = true;
            this.cmb_MaPhanCong.Location = new System.Drawing.Point(164, 32);
            this.cmb_MaPhanCong.Name = "cmb_MaPhanCong";
            this.cmb_MaPhanCong.Size = new System.Drawing.Size(255, 28);
            this.cmb_MaPhanCong.TabIndex = 38;
            // 
            // cmb_MaMH
            // 
            this.cmb_MaMH.FormattingEnabled = true;
            this.cmb_MaMH.Location = new System.Drawing.Point(164, 173);
            this.cmb_MaMH.Name = "cmb_MaMH";
            this.cmb_MaMH.Size = new System.Drawing.Size(255, 28);
            this.cmb_MaMH.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(7, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 21);
            this.label3.TabIndex = 36;
            this.label3.Text = "Mã Môn Học";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(6, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 21);
            this.label2.TabIndex = 34;
            this.label2.Text = "Mã Lớp";
            // 
            // cmb_MaGV
            // 
            this.cmb_MaGV.FormattingEnabled = true;
            this.cmb_MaGV.Location = new System.Drawing.Point(164, 79);
            this.cmb_MaGV.Name = "cmb_MaGV";
            this.cmb_MaGV.Size = new System.Drawing.Size(255, 28);
            this.cmb_MaGV.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 21);
            this.label4.TabIndex = 32;
            this.label4.Text = "Mã Giáo Viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 21);
            this.label1.TabIndex = 30;
            this.label1.Text = "Mã Phân Công";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SpringGreen;
            this.button1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button1.Location = new System.Drawing.Point(358, 382);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 35);
            this.button1.TabIndex = 66;
            this.button1.Text = "Làm mới";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // grb_TimKiem
            // 
            this.grb_TimKiem.BackColor = System.Drawing.Color.MediumAquamarine;
            this.grb_TimKiem.Controls.Add(this.btn_TK);
            this.grb_TimKiem.Controls.Add(this.cmb_ThongTInTImKIem);
            this.grb_TimKiem.Controls.Add(this.cmb_KieuTimKiem);
            this.grb_TimKiem.Controls.Add(this.lb_TT);
            this.grb_TimKiem.Controls.Add(this.lb_KTK);
            this.grb_TimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_TimKiem.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grb_TimKiem.Location = new System.Drawing.Point(16, 64);
            this.grb_TimKiem.Name = "grb_TimKiem";
            this.grb_TimKiem.Size = new System.Drawing.Size(1249, 62);
            this.grb_TimKiem.TabIndex = 69;
            this.grb_TimKiem.TabStop = false;
            this.grb_TimKiem.Text = "TÌM KIẾM";
            // 
            // btn_TK
            // 
            this.btn_TK.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_TK.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TK.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn_TK.Location = new System.Drawing.Point(1103, 15);
            this.btn_TK.Name = "btn_TK";
            this.btn_TK.Size = new System.Drawing.Size(122, 35);
            this.btn_TK.TabIndex = 72;
            this.btn_TK.Text = "Tìm Kiếm";
            this.btn_TK.UseVisualStyleBackColor = false;
            this.btn_TK.Click += new System.EventHandler(this.btn_TK_Click);
            // 
            // cmb_ThongTInTImKIem
            // 
            this.cmb_ThongTInTImKIem.FormattingEnabled = true;
            this.cmb_ThongTInTImKIem.Location = new System.Drawing.Point(804, 19);
            this.cmb_ThongTInTImKIem.Name = "cmb_ThongTInTImKIem";
            this.cmb_ThongTInTImKIem.Size = new System.Drawing.Size(293, 28);
            this.cmb_ThongTInTImKIem.TabIndex = 31;
            // 
            // cmb_KieuTimKiem
            // 
            this.cmb_KieuTimKiem.FormattingEnabled = true;
            this.cmb_KieuTimKiem.Location = new System.Drawing.Point(373, 19);
            this.cmb_KieuTimKiem.Name = "cmb_KieuTimKiem";
            this.cmb_KieuTimKiem.Size = new System.Drawing.Size(293, 28);
            this.cmb_KieuTimKiem.TabIndex = 30;
            this.cmb_KieuTimKiem.SelectedIndexChanged += new System.EventHandler(this.cmb_KieuTimKiem_SelectedIndexChanged_1);
            // 
            // lb_TT
            // 
            this.lb_TT.AutoSize = true;
            this.lb_TT.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TT.Location = new System.Drawing.Point(688, 23);
            this.lb_TT.Name = "lb_TT";
            this.lb_TT.Size = new System.Drawing.Size(95, 21);
            this.lb_TT.TabIndex = 19;
            this.lb_TT.Text = "Thông Tin";
            // 
            // lb_KTK
            // 
            this.lb_KTK.AutoSize = true;
            this.lb_KTK.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_KTK.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lb_KTK.Location = new System.Drawing.Point(223, 23);
            this.lb_KTK.Name = "lb_KTK";
            this.lb_KTK.Size = new System.Drawing.Size(132, 21);
            this.lb_KTK.TabIndex = 11;
            this.lb_KTK.Text = "Kiểu Tìm Kiếm";
            // 
            // PhanCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grb_TimKiem);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grb_CTTT);
            this.Controls.Add(this.btn_Sua);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lb_ThongTin);
            this.Name = "PhanCong";
            this.Size = new System.Drawing.Size(1286, 800);
            this.Load += new System.EventHandler(this.PhanCong_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grb_CTTT.ResumeLayout(false);
            this.grb_CTTT.PerformLayout();
            this.grb_TimKiem.ResumeLayout(false);
            this.grb_TimKiem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_ThongTin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.GroupBox grb_CTTT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_MaGV;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox grb_TimKiem;
        private System.Windows.Forms.ComboBox cmb_ThongTInTImKIem;
        private System.Windows.Forms.ComboBox cmb_KieuTimKiem;
        private System.Windows.Forms.Label lb_TT;
        private System.Windows.Forms.Label lb_KTK;
        private System.Windows.Forms.Button btn_TK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_MaMH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_MaLop;
        private System.Windows.Forms.ComboBox cmb_MaPhanCong;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}
