
namespace UNGDUNGQUANLYDIEMHOCSINH
{
    partial class QuanLyLop
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
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.txt_NhapThongTinTimKiem = new System.Windows.Forms.TextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.cbo_KieuTimKiem = new System.Windows.Forms.ComboBox();
            this.lbl_TT = new System.Windows.Forms.Label();
            this.grb_TimKiem = new System.Windows.Forms.GroupBox();
            this.lbl_KTK = new System.Windows.Forms.Label();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.dgv_DanhSachLop = new System.Windows.Forms.DataGridView();
            this.grb_DS = new System.Windows.Forms.GroupBox();
            this.grb_ThongTinLop = new System.Windows.Forms.GroupBox();
            this.cbo_Khoi = new System.Windows.Forms.ComboBox();
            this.lbl_NienKhoa_Required = new System.Windows.Forms.Label();
            this.lbl_Khoi_Required = new System.Windows.Forms.Label();
            this.lbl_TenLop_Required = new System.Windows.Forms.Label();
            this.lbl_MaLop_Required = new System.Windows.Forms.Label();
            this.txt_TenLop = new System.Windows.Forms.TextBox();
            this.lbl_TenLop = new System.Windows.Forms.Label();
            this.cbo_NienKhoa = new System.Windows.Forms.ComboBox();
            this.lbl_NienKhoa = new System.Windows.Forms.Label();
            this.lbl_Khoi = new System.Windows.Forms.Label();
            this.lbl_MaLop = new System.Windows.Forms.Label();
            this.txt_MaLop = new System.Windows.Forms.TextBox();
            this.grb_TimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSachLop)).BeginInit();
            this.grb_DS.SuspendLayout();
            this.grb_ThongTinLop.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_Cancel.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn_Cancel.Location = new System.Drawing.Point(886, 360);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(103, 35);
            this.btn_Cancel.TabIndex = 6;
            this.btn_Cancel.Text = "Huỷ";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // txt_NhapThongTinTimKiem
            // 
            this.txt_NhapThongTinTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NhapThongTinTimKiem.Location = new System.Drawing.Point(704, 22);
            this.txt_NhapThongTinTimKiem.Name = "txt_NhapThongTinTimKiem";
            this.txt_NhapThongTinTimKiem.Size = new System.Drawing.Size(330, 27);
            this.txt_NhapThongTinTimKiem.TabIndex = 3;
            // 
            // btn_Search
            // 
            this.btn_Search.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_Search.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Search.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn_Search.Location = new System.Drawing.Point(1070, 18);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(122, 35);
            this.btn_Search.TabIndex = 4;
            this.btn_Search.Text = "Tìm Kiếm";
            this.btn_Search.UseVisualStyleBackColor = false;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // cbo_KieuTimKiem
            // 
            this.cbo_KieuTimKiem.FormattingEnabled = true;
            this.cbo_KieuTimKiem.Location = new System.Drawing.Point(224, 22);
            this.cbo_KieuTimKiem.Name = "cbo_KieuTimKiem";
            this.cbo_KieuTimKiem.Size = new System.Drawing.Size(293, 28);
            this.cbo_KieuTimKiem.TabIndex = 1;
            // 
            // lbl_TT
            // 
            this.lbl_TT.AutoSize = true;
            this.lbl_TT.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TT.Location = new System.Drawing.Point(579, 26);
            this.lbl_TT.Name = "lbl_TT";
            this.lbl_TT.Size = new System.Drawing.Size(95, 21);
            this.lbl_TT.TabIndex = 2;
            this.lbl_TT.Text = "Thông Tin";
            // 
            // grb_TimKiem
            // 
            this.grb_TimKiem.BackColor = System.Drawing.Color.MediumAquamarine;
            this.grb_TimKiem.Controls.Add(this.txt_NhapThongTinTimKiem);
            this.grb_TimKiem.Controls.Add(this.btn_Search);
            this.grb_TimKiem.Controls.Add(this.cbo_KieuTimKiem);
            this.grb_TimKiem.Controls.Add(this.lbl_TT);
            this.grb_TimKiem.Controls.Add(this.lbl_KTK);
            this.grb_TimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.grb_TimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_TimKiem.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grb_TimKiem.Location = new System.Drawing.Point(0, 0);
            this.grb_TimKiem.Name = "grb_TimKiem";
            this.grb_TimKiem.Size = new System.Drawing.Size(1286, 62);
            this.grb_TimKiem.TabIndex = 0;
            this.grb_TimKiem.TabStop = false;
            this.grb_TimKiem.Text = "TÌM KIẾM";
            // 
            // lbl_KTK
            // 
            this.lbl_KTK.AutoSize = true;
            this.lbl_KTK.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_KTK.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbl_KTK.Location = new System.Drawing.Point(74, 26);
            this.lbl_KTK.Name = "lbl_KTK";
            this.lbl_KTK.Size = new System.Drawing.Size(132, 21);
            this.lbl_KTK.TabIndex = 0;
            this.lbl_KTK.Text = "Kiểu Tìm Kiếm";
            // 
            // btn_Reset
            // 
            this.btn_Reset.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_Reset.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reset.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn_Reset.Location = new System.Drawing.Point(1093, 360);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(98, 35);
            this.btn_Reset.TabIndex = 7;
            this.btn_Reset.Text = "Làm mới";
            this.btn_Reset.UseVisualStyleBackColor = false;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_Save.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn_Save.Location = new System.Drawing.Point(684, 360);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(98, 35);
            this.btn_Save.TabIndex = 5;
            this.btn_Save.Text = "Lưu";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_Update.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Update.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn_Update.Location = new System.Drawing.Point(482, 360);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(98, 35);
            this.btn_Update.TabIndex = 4;
            this.btn_Update.Text = "Sửa";
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_Delete.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn_Delete.Location = new System.Drawing.Point(280, 360);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(98, 35);
            this.btn_Delete.TabIndex = 3;
            this.btn_Delete.Text = "Xoá";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_Add.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn_Add.Location = new System.Drawing.Point(78, 360);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(98, 35);
            this.btn_Add.TabIndex = 2;
            this.btn_Add.Text = "Thêm";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.ForeColor = System.Drawing.Color.SeaGreen;
            this.lbl_Title.Location = new System.Drawing.Point(420, 75);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(404, 36);
            this.lbl_Title.TabIndex = 12;
            this.lbl_Title.Text = "QUẢN LÝ THÔNG TIN LỚP";
            // 
            // dgv_DanhSachLop
            // 
            this.dgv_DanhSachLop.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_DanhSachLop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DanhSachLop.Location = new System.Drawing.Point(22, 31);
            this.dgv_DanhSachLop.Name = "dgv_DanhSachLop";
            this.dgv_DanhSachLop.RowHeadersWidth = 51;
            this.dgv_DanhSachLop.RowTemplate.Height = 24;
            this.dgv_DanhSachLop.Size = new System.Drawing.Size(1072, 343);
            this.dgv_DanhSachLop.TabIndex = 0;
            this.dgv_DanhSachLop.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DanhSachLop_CellClick);
            this.dgv_DanhSachLop.SelectionChanged += new System.EventHandler(this.dgv_DanhSachLop_SelectionChanged);
            // 
            // grb_DS
            // 
            this.grb_DS.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.grb_DS.BackColor = System.Drawing.Color.MediumAquamarine;
            this.grb_DS.Controls.Add(this.dgv_DanhSachLop);
            this.grb_DS.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_DS.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grb_DS.Location = new System.Drawing.Point(78, 419);
            this.grb_DS.Name = "grb_DS";
            this.grb_DS.Size = new System.Drawing.Size(1114, 380);
            this.grb_DS.TabIndex = 8;
            this.grb_DS.TabStop = false;
            this.grb_DS.Text = "DANH SÁCH";
            // 
            // grb_ThongTinLop
            // 
            this.grb_ThongTinLop.BackColor = System.Drawing.Color.MediumAquamarine;
            this.grb_ThongTinLop.Controls.Add(this.cbo_Khoi);
            this.grb_ThongTinLop.Controls.Add(this.lbl_NienKhoa_Required);
            this.grb_ThongTinLop.Controls.Add(this.lbl_Khoi_Required);
            this.grb_ThongTinLop.Controls.Add(this.lbl_TenLop_Required);
            this.grb_ThongTinLop.Controls.Add(this.lbl_MaLop_Required);
            this.grb_ThongTinLop.Controls.Add(this.txt_TenLop);
            this.grb_ThongTinLop.Controls.Add(this.lbl_TenLop);
            this.grb_ThongTinLop.Controls.Add(this.cbo_NienKhoa);
            this.grb_ThongTinLop.Controls.Add(this.lbl_NienKhoa);
            this.grb_ThongTinLop.Controls.Add(this.lbl_Khoi);
            this.grb_ThongTinLop.Controls.Add(this.lbl_MaLop);
            this.grb_ThongTinLop.Controls.Add(this.txt_MaLop);
            this.grb_ThongTinLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_ThongTinLop.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grb_ThongTinLop.Location = new System.Drawing.Point(374, 127);
            this.grb_ThongTinLop.Name = "grb_ThongTinLop";
            this.grb_ThongTinLop.Size = new System.Drawing.Size(511, 211);
            this.grb_ThongTinLop.TabIndex = 1;
            this.grb_ThongTinLop.TabStop = false;
            this.grb_ThongTinLop.Text = "Thông Tin Lớp";
            // 
            // cbo_Khoi
            // 
            this.cbo_Khoi.FormattingEnabled = true;
            this.cbo_Khoi.Location = new System.Drawing.Point(198, 116);
            this.cbo_Khoi.Name = "cbo_Khoi";
            this.cbo_Khoi.Size = new System.Drawing.Size(273, 28);
            this.cbo_Khoi.TabIndex = 8;
            // 
            // lbl_NienKhoa_Required
            // 
            this.lbl_NienKhoa_Required.AutoSize = true;
            this.lbl_NienKhoa_Required.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NienKhoa_Required.ForeColor = System.Drawing.Color.Red;
            this.lbl_NienKhoa_Required.Location = new System.Drawing.Point(129, 157);
            this.lbl_NienKhoa_Required.Name = "lbl_NienKhoa_Required";
            this.lbl_NienKhoa_Required.Size = new System.Drawing.Size(37, 21);
            this.lbl_NienKhoa_Required.TabIndex = 10;
            this.lbl_NienKhoa_Required.Text = "(*)";
            // 
            // lbl_Khoi_Required
            // 
            this.lbl_Khoi_Required.AutoSize = true;
            this.lbl_Khoi_Required.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Khoi_Required.ForeColor = System.Drawing.Color.Red;
            this.lbl_Khoi_Required.Location = new System.Drawing.Point(88, 116);
            this.lbl_Khoi_Required.Name = "lbl_Khoi_Required";
            this.lbl_Khoi_Required.Size = new System.Drawing.Size(37, 21);
            this.lbl_Khoi_Required.TabIndex = 7;
            this.lbl_Khoi_Required.Text = "(*)";
            // 
            // lbl_TenLop_Required
            // 
            this.lbl_TenLop_Required.AutoSize = true;
            this.lbl_TenLop_Required.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TenLop_Required.ForeColor = System.Drawing.Color.Red;
            this.lbl_TenLop_Required.Location = new System.Drawing.Point(111, 77);
            this.lbl_TenLop_Required.Name = "lbl_TenLop_Required";
            this.lbl_TenLop_Required.Size = new System.Drawing.Size(37, 21);
            this.lbl_TenLop_Required.TabIndex = 4;
            this.lbl_TenLop_Required.Text = "(*)";
            // 
            // lbl_MaLop_Required
            // 
            this.lbl_MaLop_Required.AutoSize = true;
            this.lbl_MaLop_Required.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MaLop_Required.ForeColor = System.Drawing.Color.Red;
            this.lbl_MaLop_Required.Location = new System.Drawing.Point(111, 34);
            this.lbl_MaLop_Required.Name = "lbl_MaLop_Required";
            this.lbl_MaLop_Required.Size = new System.Drawing.Size(37, 21);
            this.lbl_MaLop_Required.TabIndex = 1;
            this.lbl_MaLop_Required.Text = "(*)";
            // 
            // txt_TenLop
            // 
            this.txt_TenLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TenLop.Location = new System.Drawing.Point(198, 75);
            this.txt_TenLop.Name = "txt_TenLop";
            this.txt_TenLop.Size = new System.Drawing.Size(273, 27);
            this.txt_TenLop.TabIndex = 5;
            // 
            // lbl_TenLop
            // 
            this.lbl_TenLop.AutoSize = true;
            this.lbl_TenLop.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TenLop.Location = new System.Drawing.Point(27, 75);
            this.lbl_TenLop.Name = "lbl_TenLop";
            this.lbl_TenLop.Size = new System.Drawing.Size(78, 21);
            this.lbl_TenLop.TabIndex = 3;
            this.lbl_TenLop.Text = "Tên Lớp";
            // 
            // cbo_NienKhoa
            // 
            this.cbo_NienKhoa.FormattingEnabled = true;
            this.cbo_NienKhoa.Location = new System.Drawing.Point(198, 157);
            this.cbo_NienKhoa.Name = "cbo_NienKhoa";
            this.cbo_NienKhoa.Size = new System.Drawing.Size(273, 28);
            this.cbo_NienKhoa.TabIndex = 11;
            // 
            // lbl_NienKhoa
            // 
            this.lbl_NienKhoa.AutoSize = true;
            this.lbl_NienKhoa.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NienKhoa.Location = new System.Drawing.Point(27, 157);
            this.lbl_NienKhoa.Name = "lbl_NienKhoa";
            this.lbl_NienKhoa.Size = new System.Drawing.Size(98, 21);
            this.lbl_NienKhoa.TabIndex = 9;
            this.lbl_NienKhoa.Text = "Niên Khoá";
            // 
            // lbl_Khoi
            // 
            this.lbl_Khoi.AutoSize = true;
            this.lbl_Khoi.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Khoi.Location = new System.Drawing.Point(27, 116);
            this.lbl_Khoi.Name = "lbl_Khoi";
            this.lbl_Khoi.Size = new System.Drawing.Size(49, 21);
            this.lbl_Khoi.TabIndex = 6;
            this.lbl_Khoi.Text = "Khối";
            // 
            // lbl_MaLop
            // 
            this.lbl_MaLop.AutoSize = true;
            this.lbl_MaLop.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MaLop.Location = new System.Drawing.Point(27, 34);
            this.lbl_MaLop.Name = "lbl_MaLop";
            this.lbl_MaLop.Size = new System.Drawing.Size(72, 21);
            this.lbl_MaLop.TabIndex = 0;
            this.lbl_MaLop.Text = "Mã Lớp";
            // 
            // txt_MaLop
            // 
            this.txt_MaLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MaLop.Location = new System.Drawing.Point(198, 34);
            this.txt_MaLop.Name = "txt_MaLop";
            this.txt_MaLop.Size = new System.Drawing.Size(273, 27);
            this.txt_MaLop.TabIndex = 2;
            // 
            // QuanLyLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.grb_TimKiem);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.grb_DS);
            this.Controls.Add(this.grb_ThongTinLop);
            this.Name = "QuanLyLop";
            this.Size = new System.Drawing.Size(1286, 800);
            this.Load += new System.EventHandler(this.QuanLyLop_Load);
            this.grb_TimKiem.ResumeLayout(false);
            this.grb_TimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSachLop)).EndInit();
            this.grb_DS.ResumeLayout(false);
            this.grb_ThongTinLop.ResumeLayout(false);
            this.grb_ThongTinLop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.TextBox txt_NhapThongTinTimKiem;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.ComboBox cbo_KieuTimKiem;
        private System.Windows.Forms.Label lbl_TT;
        private System.Windows.Forms.GroupBox grb_TimKiem;
        private System.Windows.Forms.Label lbl_KTK;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.DataGridView dgv_DanhSachLop;
        private System.Windows.Forms.GroupBox grb_DS;
        private System.Windows.Forms.GroupBox grb_ThongTinLop;
        private System.Windows.Forms.Label lbl_NienKhoa_Required;
        private System.Windows.Forms.Label lbl_Khoi_Required;
        private System.Windows.Forms.Label lbl_TenLop_Required;
        private System.Windows.Forms.Label lbl_MaLop_Required;
        private System.Windows.Forms.TextBox txt_TenLop;
        private System.Windows.Forms.Label lbl_TenLop;
        private System.Windows.Forms.ComboBox cbo_NienKhoa;
        private System.Windows.Forms.Label lbl_NienKhoa;
        private System.Windows.Forms.Label lbl_Khoi;
        private System.Windows.Forms.Label lbl_MaLop;
        private System.Windows.Forms.TextBox txt_MaLop;
        private System.Windows.Forms.ComboBox cbo_Khoi;
    }
}
