namespace UNGDUNGQUANLYDIEMHOCSINH
{
    partial class PhanCongLop
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
            this.lb_Title = new System.Windows.Forms.Label();
            this.grb_DSHS = new System.Windows.Forms.GroupBox();
            this.dgv_DanhSachHS = new System.Windows.Forms.DataGridView();
            this.grb_TTCT = new System.Windows.Forms.GroupBox();
            this.cbo_MaHS = new System.Windows.Forms.ComboBox();
            this.txt_TenHS = new System.Windows.Forms.TextBox();
            this.lblTenHS = new System.Windows.Forms.Label();
            this.lbl_TenNV = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo_TenKhoi = new System.Windows.Forms.ComboBox();
            this.cbo_TenLop = new System.Windows.Forms.ComboBox();
            this.lbl_TenLop = new System.Windows.Forms.Label();
            this.lbl_Khoi = new System.Windows.Forms.Label();
            this.grb_DSLop = new System.Windows.Forms.GroupBox();
            this.dgv_DanhSachLop = new System.Windows.Forms.DataGridView();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.grb_TimKiem = new System.Windows.Forms.GroupBox();
            this.chkChuaCoLop = new System.Windows.Forms.CheckBox();
            this.txt_TTTimKiem = new System.Windows.Forms.TextBox();
            this.btn_TimKiem = new System.Windows.Forms.Button();
            this.cbo_KieuTimKiem = new System.Windows.Forms.ComboBox();
            this.lbl_TTTK = new System.Windows.Forms.Label();
            this.lbl_KTK = new System.Windows.Forms.Label();
            this.lbl_SiSo = new System.Windows.Forms.Label();
            this.lbl_SiSoResult = new System.Windows.Forms.Label();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.grb_DSHS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSachHS)).BeginInit();
            this.grb_TTCT.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grb_DSLop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSachLop)).BeginInit();
            this.grb_TimKiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_Title
            // 
            this.lb_Title.AutoSize = true;
            this.lb_Title.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Title.ForeColor = System.Drawing.Color.SeaGreen;
            this.lb_Title.Location = new System.Drawing.Point(527, 12);
            this.lb_Title.Name = "lb_Title";
            this.lb_Title.Size = new System.Drawing.Size(270, 36);
            this.lb_Title.TabIndex = 55;
            this.lb_Title.Text = "PHÂN CÔNG LỚP";
            // 
            // grb_DSHS
            // 
            this.grb_DSHS.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.grb_DSHS.BackColor = System.Drawing.Color.MediumAquamarine;
            this.grb_DSHS.Controls.Add(this.dgv_DanhSachHS);
            this.grb_DSHS.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_DSHS.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grb_DSHS.Location = new System.Drawing.Point(523, 369);
            this.grb_DSHS.Name = "grb_DSHS";
            this.grb_DSHS.Size = new System.Drawing.Size(736, 413);
            this.grb_DSHS.TabIndex = 57;
            this.grb_DSHS.TabStop = false;
            this.grb_DSHS.Text = "DANH SÁCH HỌC SINH ";
            // 
            // dgv_DanhSachHS
            // 
            this.dgv_DanhSachHS.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_DanhSachHS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DanhSachHS.Location = new System.Drawing.Point(19, 31);
            this.dgv_DanhSachHS.Name = "dgv_DanhSachHS";
            this.dgv_DanhSachHS.RowHeadersWidth = 51;
            this.dgv_DanhSachHS.RowTemplate.Height = 24;
            this.dgv_DanhSachHS.Size = new System.Drawing.Size(698, 377);
            this.dgv_DanhSachHS.TabIndex = 32;
            this.dgv_DanhSachHS.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DanhSachHS_CellClick);
            this.dgv_DanhSachHS.SelectionChanged += new System.EventHandler(this.dgv_DanhSachHS_SelectionChanged);
            // 
            // grb_TTCT
            // 
            this.grb_TTCT.BackColor = System.Drawing.Color.MediumAquamarine;
            this.grb_TTCT.Controls.Add(this.cbo_MaHS);
            this.grb_TTCT.Controls.Add(this.txt_TenHS);
            this.grb_TTCT.Controls.Add(this.lblTenHS);
            this.grb_TTCT.Controls.Add(this.lbl_TenNV);
            this.grb_TTCT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_TTCT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grb_TTCT.Location = new System.Drawing.Point(542, 69);
            this.grb_TTCT.Name = "grb_TTCT";
            this.grb_TTCT.Size = new System.Drawing.Size(717, 137);
            this.grb_TTCT.TabIndex = 64;
            this.grb_TTCT.TabStop = false;
            this.grb_TTCT.Text = "Thông Tin Học Sinh";
            // 
            // cbo_MaHS
            // 
            this.cbo_MaHS.FormattingEnabled = true;
            this.cbo_MaHS.Location = new System.Drawing.Point(181, 31);
            this.cbo_MaHS.Name = "cbo_MaHS";
            this.cbo_MaHS.Size = new System.Drawing.Size(504, 28);
            this.cbo_MaHS.TabIndex = 35;
            this.cbo_MaHS.SelectionChangeCommitted += new System.EventHandler(this.cbo_MaHS_SelectionChangeCommitted);
            // 
            // txt_TenHS
            // 
            this.txt_TenHS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TenHS.Location = new System.Drawing.Point(181, 74);
            this.txt_TenHS.Name = "txt_TenHS";
            this.txt_TenHS.Size = new System.Drawing.Size(504, 27);
            this.txt_TenHS.TabIndex = 31;
            // 
            // lblTenHS
            // 
            this.lblTenHS.AutoSize = true;
            this.lblTenHS.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenHS.Location = new System.Drawing.Point(35, 74);
            this.lblTenHS.Name = "lblTenHS";
            this.lblTenHS.Size = new System.Drawing.Size(122, 21);
            this.lblTenHS.TabIndex = 30;
            this.lblTenHS.Text = "Tên Học Sinh";
            // 
            // lbl_TenNV
            // 
            this.lbl_TenNV.AutoSize = true;
            this.lbl_TenNV.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TenNV.Location = new System.Drawing.Point(35, 34);
            this.lbl_TenNV.Name = "lbl_TenNV";
            this.lbl_TenNV.Size = new System.Drawing.Size(116, 21);
            this.lbl_TenNV.TabIndex = 11;
            this.lbl_TenNV.Text = "Mã Học Sinh";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.MediumAquamarine;
            this.groupBox1.Controls.Add(this.cbo_TenKhoi);
            this.groupBox1.Controls.Add(this.cbo_TenLop);
            this.groupBox1.Controls.Add(this.lbl_TenLop);
            this.groupBox1.Controls.Add(this.lbl_Khoi);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox1.Location = new System.Drawing.Point(15, 232);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 117);
            this.groupBox1.TabIndex = 65;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Phân Công Lớp";
            // 
            // cbo_TenKhoi
            // 
            this.cbo_TenKhoi.FormattingEnabled = true;
            this.cbo_TenKhoi.Location = new System.Drawing.Point(142, 32);
            this.cbo_TenKhoi.Name = "cbo_TenKhoi";
            this.cbo_TenKhoi.Size = new System.Drawing.Size(330, 28);
            this.cbo_TenKhoi.TabIndex = 33;
            this.cbo_TenKhoi.SelectionChangeCommitted += new System.EventHandler(this.cbo_TenKhoi_SelectionChangeCommitted);
            // 
            // cbo_TenLop
            // 
            this.cbo_TenLop.FormattingEnabled = true;
            this.cbo_TenLop.Location = new System.Drawing.Point(142, 71);
            this.cbo_TenLop.Name = "cbo_TenLop";
            this.cbo_TenLop.Size = new System.Drawing.Size(330, 28);
            this.cbo_TenLop.TabIndex = 31;
            // 
            // lbl_TenLop
            // 
            this.lbl_TenLop.AutoSize = true;
            this.lbl_TenLop.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TenLop.Location = new System.Drawing.Point(6, 73);
            this.lbl_TenLop.Name = "lbl_TenLop";
            this.lbl_TenLop.Size = new System.Drawing.Size(78, 21);
            this.lbl_TenLop.TabIndex = 30;
            this.lbl_TenLop.Text = "Tên Lớp";
            // 
            // lbl_Khoi
            // 
            this.lbl_Khoi.AutoSize = true;
            this.lbl_Khoi.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Khoi.Location = new System.Drawing.Point(6, 34);
            this.lbl_Khoi.Name = "lbl_Khoi";
            this.lbl_Khoi.Size = new System.Drawing.Size(49, 21);
            this.lbl_Khoi.TabIndex = 11;
            this.lbl_Khoi.Text = "Khối";
            // 
            // grb_DSLop
            // 
            this.grb_DSLop.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.grb_DSLop.BackColor = System.Drawing.Color.MediumAquamarine;
            this.grb_DSLop.Controls.Add(this.dgv_DanhSachLop);
            this.grb_DSLop.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_DSLop.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grb_DSLop.Location = new System.Drawing.Point(15, 369);
            this.grb_DSLop.Name = "grb_DSLop";
            this.grb_DSLop.Size = new System.Drawing.Size(483, 413);
            this.grb_DSLop.TabIndex = 58;
            this.grb_DSLop.TabStop = false;
            this.grb_DSLop.Text = "DANH SÁCH LỚP";
            // 
            // dgv_DanhSachLop
            // 
            this.dgv_DanhSachLop.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_DanhSachLop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DanhSachLop.Location = new System.Drawing.Point(22, 31);
            this.dgv_DanhSachLop.Name = "dgv_DanhSachLop";
            this.dgv_DanhSachLop.RowHeadersWidth = 51;
            this.dgv_DanhSachLop.RowTemplate.Height = 24;
            this.dgv_DanhSachLop.Size = new System.Drawing.Size(439, 377);
            this.dgv_DanhSachLop.TabIndex = 32;
            this.dgv_DanhSachLop.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DanhSachLop_CellClick);
            this.dgv_DanhSachLop.SelectionChanged += new System.EventHandler(this.dgv_DanhSachLop_SelectionChanged);
            // 
            // btn_Update
            // 
            this.btn_Update.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_Update.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Update.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn_Update.Location = new System.Drawing.Point(786, 221);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(103, 35);
            this.btn_Update.TabIndex = 63;
            this.btn_Update.Text = "Sửa";
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_Delete.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn_Delete.Location = new System.Drawing.Point(664, 221);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(103, 35);
            this.btn_Delete.TabIndex = 62;
            this.btn_Delete.Text = "Xoá";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_Add.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn_Add.Location = new System.Drawing.Point(542, 221);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(103, 35);
            this.btn_Add.TabIndex = 61;
            this.btn_Add.Text = "Thêm";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_Save.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn_Save.Location = new System.Drawing.Point(908, 221);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(103, 35);
            this.btn_Save.TabIndex = 66;
            this.btn_Save.Text = "Lưu";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // grb_TimKiem
            // 
            this.grb_TimKiem.BackColor = System.Drawing.Color.MediumAquamarine;
            this.grb_TimKiem.Controls.Add(this.chkChuaCoLop);
            this.grb_TimKiem.Controls.Add(this.txt_TTTimKiem);
            this.grb_TimKiem.Controls.Add(this.btn_TimKiem);
            this.grb_TimKiem.Controls.Add(this.cbo_KieuTimKiem);
            this.grb_TimKiem.Controls.Add(this.lbl_TTTK);
            this.grb_TimKiem.Controls.Add(this.lbl_KTK);
            this.grb_TimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_TimKiem.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grb_TimKiem.Location = new System.Drawing.Point(15, 69);
            this.grb_TimKiem.Name = "grb_TimKiem";
            this.grb_TimKiem.Size = new System.Drawing.Size(483, 150);
            this.grb_TimKiem.TabIndex = 69;
            this.grb_TimKiem.TabStop = false;
            this.grb_TimKiem.Text = "TÌM KIẾM";
            // 
            // chkChuaCoLop
            // 
            this.chkChuaCoLop.AutoSize = true;
            this.chkChuaCoLop.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkChuaCoLop.Location = new System.Drawing.Point(176, 105);
            this.chkChuaCoLop.Name = "chkChuaCoLop";
            this.chkChuaCoLop.Size = new System.Drawing.Size(113, 23);
            this.chkChuaCoLop.TabIndex = 73;
            this.chkChuaCoLop.Text = "Chưa có lớp";
            this.chkChuaCoLop.UseVisualStyleBackColor = true;
            // 
            // txt_TTTimKiem
            // 
            this.txt_TTTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TTTimKiem.Location = new System.Drawing.Point(176, 64);
            this.txt_TTTimKiem.Name = "txt_TTTimKiem";
            this.txt_TTTimKiem.Size = new System.Drawing.Size(296, 27);
            this.txt_TTTimKiem.TabIndex = 32;
            // 
            // btn_TimKiem
            // 
            this.btn_TimKiem.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_TimKiem.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TimKiem.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn_TimKiem.Location = new System.Drawing.Point(350, 98);
            this.btn_TimKiem.Name = "btn_TimKiem";
            this.btn_TimKiem.Size = new System.Drawing.Size(122, 35);
            this.btn_TimKiem.TabIndex = 72;
            this.btn_TimKiem.Text = "Tìm Kiếm";
            this.btn_TimKiem.UseVisualStyleBackColor = false;
            this.btn_TimKiem.Click += new System.EventHandler(this.btn_TimKiem_Click);
            // 
            // cbo_KieuTimKiem
            // 
            this.cbo_KieuTimKiem.FormattingEnabled = true;
            this.cbo_KieuTimKiem.Location = new System.Drawing.Point(176, 28);
            this.cbo_KieuTimKiem.Name = "cbo_KieuTimKiem";
            this.cbo_KieuTimKiem.Size = new System.Drawing.Size(296, 28);
            this.cbo_KieuTimKiem.TabIndex = 30;
            // 
            // lbl_TTTK
            // 
            this.lbl_TTTK.AutoSize = true;
            this.lbl_TTTK.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TTTK.Location = new System.Drawing.Point(14, 65);
            this.lbl_TTTK.Name = "lbl_TTTK";
            this.lbl_TTTK.Size = new System.Drawing.Size(95, 21);
            this.lbl_TTTK.TabIndex = 19;
            this.lbl_TTTK.Text = "Thông Tin";
            // 
            // lbl_KTK
            // 
            this.lbl_KTK.AutoSize = true;
            this.lbl_KTK.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_KTK.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbl_KTK.Location = new System.Drawing.Point(14, 31);
            this.lbl_KTK.Name = "lbl_KTK";
            this.lbl_KTK.Size = new System.Drawing.Size(132, 21);
            this.lbl_KTK.TabIndex = 11;
            this.lbl_KTK.Text = "Kiểu Tìm Kiếm";
            // 
            // lbl_SiSo
            // 
            this.lbl_SiSo.AutoSize = true;
            this.lbl_SiSo.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SiSo.ForeColor = System.Drawing.Color.Red;
            this.lbl_SiSo.Location = new System.Drawing.Point(1160, 311);
            this.lbl_SiSo.Name = "lbl_SiSo";
            this.lbl_SiSo.Size = new System.Drawing.Size(67, 26);
            this.lbl_SiSo.TabIndex = 73;
            this.lbl_SiSo.Text = "Sĩ số:";
            // 
            // lbl_SiSoResult
            // 
            this.lbl_SiSoResult.AutoSize = true;
            this.lbl_SiSoResult.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SiSoResult.ForeColor = System.Drawing.Color.Red;
            this.lbl_SiSoResult.Location = new System.Drawing.Point(1230, 306);
            this.lbl_SiSoResult.Name = "lbl_SiSoResult";
            this.lbl_SiSoResult.Size = new System.Drawing.Size(29, 32);
            this.lbl_SiSoResult.TabIndex = 74;
            this.lbl_SiSoResult.Text = "0";
            // 
            // btn_Reset
            // 
            this.btn_Reset.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_Reset.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reset.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn_Reset.Location = new System.Drawing.Point(1156, 221);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(103, 35);
            this.btn_Reset.TabIndex = 75;
            this.btn_Reset.Text = "Làm mới";
            this.btn_Reset.UseVisualStyleBackColor = false;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_Cancel.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn_Cancel.Location = new System.Drawing.Point(1030, 221);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(103, 35);
            this.btn_Cancel.TabIndex = 76;
            this.btn_Cancel.Text = "Huỷ";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // PhanCongLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.lbl_SiSoResult);
            this.Controls.Add(this.lbl_SiSo);
            this.Controls.Add(this.grb_TimKiem);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.grb_DSLop);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.grb_TTCT);
            this.Controls.Add(this.grb_DSHS);
            this.Controls.Add(this.lb_Title);
            this.Name = "PhanCongLop";
            this.Size = new System.Drawing.Size(1286, 800);
            this.Load += new System.EventHandler(this.QuanLyLop_Load);
            this.grb_DSHS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSachHS)).EndInit();
            this.grb_TTCT.ResumeLayout(false);
            this.grb_TTCT.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grb_DSLop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSachLop)).EndInit();
            this.grb_TimKiem.ResumeLayout(false);
            this.grb_TimKiem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_Title;
        private System.Windows.Forms.GroupBox grb_DSHS;
        private System.Windows.Forms.DataGridView dgv_DanhSachHS;
        private System.Windows.Forms.GroupBox grb_TTCT;
        private System.Windows.Forms.TextBox txt_TenHS;
        private System.Windows.Forms.Label lblTenHS;
        private System.Windows.Forms.Label lbl_TenNV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbo_TenLop;
        private System.Windows.Forms.Label lbl_TenLop;
        private System.Windows.Forms.Label lbl_Khoi;
        private System.Windows.Forms.GroupBox grb_DSLop;
        private System.Windows.Forms.DataGridView dgv_DanhSachLop;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.ComboBox cbo_TenKhoi;
        private System.Windows.Forms.GroupBox grb_TimKiem;
        private System.Windows.Forms.ComboBox cbo_KieuTimKiem;
        private System.Windows.Forms.Label lbl_TTTK;
        private System.Windows.Forms.Label lbl_KTK;
        private System.Windows.Forms.Button btn_TimKiem;
        private System.Windows.Forms.Label lbl_SiSo;
        private System.Windows.Forms.Label lbl_SiSoResult;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.TextBox txt_TTTimKiem;
        private System.Windows.Forms.CheckBox chkChuaCoLop;
        private System.Windows.Forms.ComboBox cbo_MaHS;
        private System.Windows.Forms.Button btn_Cancel;
    }
}
