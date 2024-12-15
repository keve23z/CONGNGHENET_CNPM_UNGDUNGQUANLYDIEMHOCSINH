namespace UNGDUNGQUANLYDIEMHOCSINH
{
    partial class QuanLyHocSinh
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
            this.dgv_DanhSachHS = new System.Windows.Forms.DataGridView();
            this.grb_DS = new System.Windows.Forms.GroupBox();
            this.grb_ThongTinHS = new System.Windows.Forms.GroupBox();
            this.lbl_GioiTinh_Required = new System.Windows.Forms.Label();
            this.lbl_NgaySinh_Required = new System.Windows.Forms.Label();
            this.lbl_TenHS_Required = new System.Windows.Forms.Label();
            this.lbl_MaHS_Required = new System.Windows.Forms.Label();
            this.txt_TenHS = new System.Windows.Forms.TextBox();
            this.lbl_TenHS = new System.Windows.Forms.Label();
            this.cbo_GioiTinh = new System.Windows.Forms.ComboBox();
            this.dtp_NgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lbl_GioiTinh = new System.Windows.Forms.Label();
            this.lbl_NgaySinh = new System.Windows.Forms.Label();
            this.lbl_MaHS = new System.Windows.Forms.Label();
            this.txt_MaHS = new System.Windows.Forms.TextBox();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.grb_ThongTinPH = new System.Windows.Forms.GroupBox();
            this.lbl_MQH_Required = new System.Windows.Forms.Label();
            this.lbl_TenPH_Required = new System.Windows.Forms.Label();
            this.lbl_MaPH_Required = new System.Windows.Forms.Label();
            this.cbo_MQH = new System.Windows.Forms.ComboBox();
            this.lbl_MoiQuanHe = new System.Windows.Forms.Label();
            this.txt_TenPH = new System.Windows.Forms.TextBox();
            this.lbl_TenPH = new System.Windows.Forms.Label();
            this.cbo_MaPH = new System.Windows.Forms.ComboBox();
            this.lbl_MaPH = new System.Windows.Forms.Label();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.grb_TimKiem = new System.Windows.Forms.GroupBox();
            this.txt_NhapThongTinTimKiem = new System.Windows.Forms.TextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.cbo_KieuTimKiem = new System.Windows.Forms.ComboBox();
            this.lbl_TT = new System.Windows.Forms.Label();
            this.lbl_KTK = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSachHS)).BeginInit();
            this.grb_DS.SuspendLayout();
            this.grb_ThongTinHS.SuspendLayout();
            this.grb_ThongTinPH.SuspendLayout();
            this.grb_TimKiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_DanhSachHS
            // 
            this.dgv_DanhSachHS.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_DanhSachHS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DanhSachHS.Location = new System.Drawing.Point(22, 31);
            this.dgv_DanhSachHS.Name = "dgv_DanhSachHS";
            this.dgv_DanhSachHS.RowHeadersWidth = 51;
            this.dgv_DanhSachHS.RowTemplate.Height = 24;
            this.dgv_DanhSachHS.Size = new System.Drawing.Size(1072, 343);
            this.dgv_DanhSachHS.TabIndex = 0;
            this.dgv_DanhSachHS.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DanhSachHS_CellClick);
            this.dgv_DanhSachHS.SelectionChanged += new System.EventHandler(this.dgv_DanhSachHS_SelectionChanged);
            // 
            // grb_DS
            // 
            this.grb_DS.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.grb_DS.BackColor = System.Drawing.Color.MediumAquamarine;
            this.grb_DS.Controls.Add(this.dgv_DanhSachHS);
            this.grb_DS.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_DS.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grb_DS.Location = new System.Drawing.Point(78, 417);
            this.grb_DS.Name = "grb_DS";
            this.grb_DS.Size = new System.Drawing.Size(1114, 380);
            this.grb_DS.TabIndex = 10;
            this.grb_DS.TabStop = false;
            this.grb_DS.Text = "DANH SÁCH";
            // 
            // grb_ThongTinHS
            // 
            this.grb_ThongTinHS.BackColor = System.Drawing.Color.MediumAquamarine;
            this.grb_ThongTinHS.Controls.Add(this.lbl_GioiTinh_Required);
            this.grb_ThongTinHS.Controls.Add(this.lbl_NgaySinh_Required);
            this.grb_ThongTinHS.Controls.Add(this.lbl_TenHS_Required);
            this.grb_ThongTinHS.Controls.Add(this.lbl_MaHS_Required);
            this.grb_ThongTinHS.Controls.Add(this.txt_TenHS);
            this.grb_ThongTinHS.Controls.Add(this.lbl_TenHS);
            this.grb_ThongTinHS.Controls.Add(this.cbo_GioiTinh);
            this.grb_ThongTinHS.Controls.Add(this.dtp_NgaySinh);
            this.grb_ThongTinHS.Controls.Add(this.lbl_GioiTinh);
            this.grb_ThongTinHS.Controls.Add(this.lbl_NgaySinh);
            this.grb_ThongTinHS.Controls.Add(this.lbl_MaHS);
            this.grb_ThongTinHS.Controls.Add(this.txt_MaHS);
            this.grb_ThongTinHS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_ThongTinHS.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grb_ThongTinHS.Location = new System.Drawing.Point(78, 131);
            this.grb_ThongTinHS.Name = "grb_ThongTinHS";
            this.grb_ThongTinHS.Size = new System.Drawing.Size(546, 211);
            this.grb_ThongTinHS.TabIndex = 2;
            this.grb_ThongTinHS.TabStop = false;
            this.grb_ThongTinHS.Text = "Thông Tin Học Sinh";
            // 
            // lbl_GioiTinh_Required
            // 
            this.lbl_GioiTinh_Required.AutoSize = true;
            this.lbl_GioiTinh_Required.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_GioiTinh_Required.ForeColor = System.Drawing.Color.Red;
            this.lbl_GioiTinh_Required.Location = new System.Drawing.Point(112, 157);
            this.lbl_GioiTinh_Required.Name = "lbl_GioiTinh_Required";
            this.lbl_GioiTinh_Required.Size = new System.Drawing.Size(37, 21);
            this.lbl_GioiTinh_Required.TabIndex = 10;
            this.lbl_GioiTinh_Required.Text = "(*)";
            // 
            // lbl_NgaySinh_Required
            // 
            this.lbl_NgaySinh_Required.AutoSize = true;
            this.lbl_NgaySinh_Required.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NgaySinh_Required.ForeColor = System.Drawing.Color.Red;
            this.lbl_NgaySinh_Required.Location = new System.Drawing.Point(130, 116);
            this.lbl_NgaySinh_Required.Name = "lbl_NgaySinh_Required";
            this.lbl_NgaySinh_Required.Size = new System.Drawing.Size(37, 21);
            this.lbl_NgaySinh_Required.TabIndex = 7;
            this.lbl_NgaySinh_Required.Text = "(*)";
            // 
            // lbl_TenHS_Required
            // 
            this.lbl_TenHS_Required.AutoSize = true;
            this.lbl_TenHS_Required.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TenHS_Required.ForeColor = System.Drawing.Color.Red;
            this.lbl_TenHS_Required.Location = new System.Drawing.Point(151, 74);
            this.lbl_TenHS_Required.Name = "lbl_TenHS_Required";
            this.lbl_TenHS_Required.Size = new System.Drawing.Size(37, 21);
            this.lbl_TenHS_Required.TabIndex = 4;
            this.lbl_TenHS_Required.Text = "(*)";
            // 
            // lbl_MaHS_Required
            // 
            this.lbl_MaHS_Required.AutoSize = true;
            this.lbl_MaHS_Required.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MaHS_Required.ForeColor = System.Drawing.Color.Red;
            this.lbl_MaHS_Required.Location = new System.Drawing.Point(151, 34);
            this.lbl_MaHS_Required.Name = "lbl_MaHS_Required";
            this.lbl_MaHS_Required.Size = new System.Drawing.Size(37, 21);
            this.lbl_MaHS_Required.TabIndex = 1;
            this.lbl_MaHS_Required.Text = "(*)";
            // 
            // txt_TenHS
            // 
            this.txt_TenHS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TenHS.Location = new System.Drawing.Point(229, 75);
            this.txt_TenHS.Name = "txt_TenHS";
            this.txt_TenHS.Size = new System.Drawing.Size(273, 27);
            this.txt_TenHS.TabIndex = 5;
            // 
            // lbl_TenHS
            // 
            this.lbl_TenHS.AutoSize = true;
            this.lbl_TenHS.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TenHS.Location = new System.Drawing.Point(27, 75);
            this.lbl_TenHS.Name = "lbl_TenHS";
            this.lbl_TenHS.Size = new System.Drawing.Size(122, 21);
            this.lbl_TenHS.TabIndex = 3;
            this.lbl_TenHS.Text = "Tên Học Sinh";
            // 
            // cbo_GioiTinh
            // 
            this.cbo_GioiTinh.FormattingEnabled = true;
            this.cbo_GioiTinh.Location = new System.Drawing.Point(229, 157);
            this.cbo_GioiTinh.Name = "cbo_GioiTinh";
            this.cbo_GioiTinh.Size = new System.Drawing.Size(273, 28);
            this.cbo_GioiTinh.TabIndex = 11;
            // 
            // dtp_NgaySinh
            // 
            this.dtp_NgaySinh.CalendarTitleBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.dtp_NgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtp_NgaySinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_NgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_NgaySinh.Location = new System.Drawing.Point(229, 116);
            this.dtp_NgaySinh.Name = "dtp_NgaySinh";
            this.dtp_NgaySinh.Size = new System.Drawing.Size(273, 27);
            this.dtp_NgaySinh.TabIndex = 8;
            // 
            // lbl_GioiTinh
            // 
            this.lbl_GioiTinh.AutoSize = true;
            this.lbl_GioiTinh.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_GioiTinh.Location = new System.Drawing.Point(27, 157);
            this.lbl_GioiTinh.Name = "lbl_GioiTinh";
            this.lbl_GioiTinh.Size = new System.Drawing.Size(83, 21);
            this.lbl_GioiTinh.TabIndex = 9;
            this.lbl_GioiTinh.Text = "Giới tính";
            // 
            // lbl_NgaySinh
            // 
            this.lbl_NgaySinh.AutoSize = true;
            this.lbl_NgaySinh.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NgaySinh.Location = new System.Drawing.Point(27, 116);
            this.lbl_NgaySinh.Name = "lbl_NgaySinh";
            this.lbl_NgaySinh.Size = new System.Drawing.Size(97, 21);
            this.lbl_NgaySinh.TabIndex = 6;
            this.lbl_NgaySinh.Text = "Ngày Sinh";
            // 
            // lbl_MaHS
            // 
            this.lbl_MaHS.AutoSize = true;
            this.lbl_MaHS.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MaHS.Location = new System.Drawing.Point(27, 34);
            this.lbl_MaHS.Name = "lbl_MaHS";
            this.lbl_MaHS.Size = new System.Drawing.Size(116, 21);
            this.lbl_MaHS.TabIndex = 0;
            this.lbl_MaHS.Text = "Mã Học Sinh";
            // 
            // txt_MaHS
            // 
            this.txt_MaHS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MaHS.Location = new System.Drawing.Point(229, 34);
            this.txt_MaHS.Name = "txt_MaHS";
            this.txt_MaHS.Size = new System.Drawing.Size(273, 27);
            this.txt_MaHS.TabIndex = 2;
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("Tahoma", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.ForeColor = System.Drawing.Color.SeaGreen;
            this.lbl_Title.Location = new System.Drawing.Point(378, 75);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(497, 36);
            this.lbl_Title.TabIndex = 1;
            this.lbl_Title.Text = "QUẢN LÝ THÔNG TIN HỌC SINH";
            // 
            // grb_ThongTinPH
            // 
            this.grb_ThongTinPH.BackColor = System.Drawing.Color.MediumAquamarine;
            this.grb_ThongTinPH.Controls.Add(this.lbl_MQH_Required);
            this.grb_ThongTinPH.Controls.Add(this.lbl_TenPH_Required);
            this.grb_ThongTinPH.Controls.Add(this.lbl_MaPH_Required);
            this.grb_ThongTinPH.Controls.Add(this.cbo_MQH);
            this.grb_ThongTinPH.Controls.Add(this.lbl_MoiQuanHe);
            this.grb_ThongTinPH.Controls.Add(this.txt_TenPH);
            this.grb_ThongTinPH.Controls.Add(this.lbl_TenPH);
            this.grb_ThongTinPH.Controls.Add(this.cbo_MaPH);
            this.grb_ThongTinPH.Controls.Add(this.lbl_MaPH);
            this.grb_ThongTinPH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_ThongTinPH.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grb_ThongTinPH.Location = new System.Drawing.Point(646, 131);
            this.grb_ThongTinPH.Name = "grb_ThongTinPH";
            this.grb_ThongTinPH.Size = new System.Drawing.Size(546, 211);
            this.grb_ThongTinPH.TabIndex = 3;
            this.grb_ThongTinPH.TabStop = false;
            this.grb_ThongTinPH.Text = "Thông Tin Phụ Huynh";
            // 
            // lbl_MQH_Required
            // 
            this.lbl_MQH_Required.AutoSize = true;
            this.lbl_MQH_Required.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MQH_Required.ForeColor = System.Drawing.Color.Red;
            this.lbl_MQH_Required.Location = new System.Drawing.Point(155, 163);
            this.lbl_MQH_Required.Name = "lbl_MQH_Required";
            this.lbl_MQH_Required.Size = new System.Drawing.Size(37, 21);
            this.lbl_MQH_Required.TabIndex = 7;
            this.lbl_MQH_Required.Text = "(*)";
            // 
            // lbl_TenPH_Required
            // 
            this.lbl_TenPH_Required.AutoSize = true;
            this.lbl_TenPH_Required.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TenPH_Required.ForeColor = System.Drawing.Color.Red;
            this.lbl_TenPH_Required.Location = new System.Drawing.Point(112, 96);
            this.lbl_TenPH_Required.Name = "lbl_TenPH_Required";
            this.lbl_TenPH_Required.Size = new System.Drawing.Size(37, 21);
            this.lbl_TenPH_Required.TabIndex = 4;
            this.lbl_TenPH_Required.Text = "(*)";
            // 
            // lbl_MaPH_Required
            // 
            this.lbl_MaPH_Required.AutoSize = true;
            this.lbl_MaPH_Required.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MaPH_Required.ForeColor = System.Drawing.Color.Red;
            this.lbl_MaPH_Required.Location = new System.Drawing.Point(112, 34);
            this.lbl_MaPH_Required.Name = "lbl_MaPH_Required";
            this.lbl_MaPH_Required.Size = new System.Drawing.Size(37, 21);
            this.lbl_MaPH_Required.TabIndex = 1;
            this.lbl_MaPH_Required.Text = "(*)";
            // 
            // cbo_MQH
            // 
            this.cbo_MQH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_MQH.FormattingEnabled = true;
            this.cbo_MQH.Location = new System.Drawing.Point(237, 157);
            this.cbo_MQH.Name = "cbo_MQH";
            this.cbo_MQH.Size = new System.Drawing.Size(273, 33);
            this.cbo_MQH.TabIndex = 8;
            // 
            // lbl_MoiQuanHe
            // 
            this.lbl_MoiQuanHe.AutoSize = true;
            this.lbl_MoiQuanHe.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MoiQuanHe.Location = new System.Drawing.Point(34, 163);
            this.lbl_MoiQuanHe.Name = "lbl_MoiQuanHe";
            this.lbl_MoiQuanHe.Size = new System.Drawing.Size(115, 21);
            this.lbl_MoiQuanHe.TabIndex = 6;
            this.lbl_MoiQuanHe.Text = "Mối quan hệ";
            // 
            // txt_TenPH
            // 
            this.txt_TenPH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TenPH.Location = new System.Drawing.Point(237, 96);
            this.txt_TenPH.Name = "txt_TenPH";
            this.txt_TenPH.Size = new System.Drawing.Size(273, 27);
            this.txt_TenPH.TabIndex = 5;
            // 
            // lbl_TenPH
            // 
            this.lbl_TenPH.AutoSize = true;
            this.lbl_TenPH.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TenPH.Location = new System.Drawing.Point(33, 96);
            this.lbl_TenPH.Name = "lbl_TenPH";
            this.lbl_TenPH.Size = new System.Drawing.Size(70, 21);
            this.lbl_TenPH.TabIndex = 3;
            this.lbl_TenPH.Text = "Tên PH";
            // 
            // cbo_MaPH
            // 
            this.cbo_MaPH.FormattingEnabled = true;
            this.cbo_MaPH.Location = new System.Drawing.Point(237, 34);
            this.cbo_MaPH.Name = "cbo_MaPH";
            this.cbo_MaPH.Size = new System.Drawing.Size(273, 28);
            this.cbo_MaPH.TabIndex = 2;
            this.cbo_MaPH.SelectionChangeCommitted += new System.EventHandler(this.cbo_MaPH_SelectionChangeCommitted);
            // 
            // lbl_MaPH
            // 
            this.lbl_MaPH.AutoSize = true;
            this.lbl_MaPH.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MaPH.Location = new System.Drawing.Point(33, 34);
            this.lbl_MaPH.Name = "lbl_MaPH";
            this.lbl_MaPH.Size = new System.Drawing.Size(64, 21);
            this.lbl_MaPH.TabIndex = 0;
            this.lbl_MaPH.Text = "Mã PH";
            // 
            // btn_Update
            // 
            this.btn_Update.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_Update.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Update.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn_Update.Location = new System.Drawing.Point(482, 358);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(98, 35);
            this.btn_Update.TabIndex = 6;
            this.btn_Update.Text = "Sửa";
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_Delete.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn_Delete.Location = new System.Drawing.Point(280, 358);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(98, 35);
            this.btn_Delete.TabIndex = 5;
            this.btn_Delete.Text = "Xoá";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_Add.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn_Add.Location = new System.Drawing.Point(78, 358);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(98, 35);
            this.btn_Add.TabIndex = 4;
            this.btn_Add.Text = "Thêm";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_Save.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn_Save.Location = new System.Drawing.Point(684, 358);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(98, 35);
            this.btn_Save.TabIndex = 7;
            this.btn_Save.Text = "Lưu";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Reset
            // 
            this.btn_Reset.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_Reset.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reset.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn_Reset.Location = new System.Drawing.Point(1093, 358);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(98, 35);
            this.btn_Reset.TabIndex = 9;
            this.btn_Reset.Text = "Làm mới";
            this.btn_Reset.UseVisualStyleBackColor = false;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
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
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_Cancel.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn_Cancel.Location = new System.Drawing.Point(886, 358);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(103, 35);
            this.btn_Cancel.TabIndex = 8;
            this.btn_Cancel.Text = "Huỷ";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // ThongTinHS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.grb_TimKiem);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.grb_ThongTinPH);
            this.Controls.Add(this.grb_DS);
            this.Controls.Add(this.grb_ThongTinHS);
            this.Controls.Add(this.lbl_Title);
            this.Name = "ThongTinHS";
            this.Size = new System.Drawing.Size(1286, 800);
            this.Load += new System.EventHandler(this.ThongTinHS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSachHS)).EndInit();
            this.grb_DS.ResumeLayout(false);
            this.grb_ThongTinHS.ResumeLayout(false);
            this.grb_ThongTinHS.PerformLayout();
            this.grb_ThongTinPH.ResumeLayout(false);
            this.grb_ThongTinPH.PerformLayout();
            this.grb_TimKiem.ResumeLayout(false);
            this.grb_TimKiem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv_DanhSachHS;
        private System.Windows.Forms.GroupBox grb_DS;
        private System.Windows.Forms.GroupBox grb_ThongTinHS;
        private System.Windows.Forms.ComboBox cbo_GioiTinh;
        internal System.Windows.Forms.DateTimePicker dtp_NgaySinh;
        private System.Windows.Forms.Label lbl_GioiTinh;
        private System.Windows.Forms.Label lbl_NgaySinh;
        private System.Windows.Forms.Label lbl_MaHS;
        private System.Windows.Forms.TextBox txt_MaHS;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.TextBox txt_TenHS;
        private System.Windows.Forms.Label lbl_TenHS;
        private System.Windows.Forms.GroupBox grb_ThongTinPH;
        private System.Windows.Forms.ComboBox cbo_MQH;
        private System.Windows.Forms.Label lbl_MoiQuanHe;
        private System.Windows.Forms.TextBox txt_TenPH;
        private System.Windows.Forms.Label lbl_TenPH;
        private System.Windows.Forms.ComboBox cbo_MaPH;
        private System.Windows.Forms.Label lbl_MaPH;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Label lbl_MaHS_Required;
        private System.Windows.Forms.GroupBox grb_TimKiem;
        private System.Windows.Forms.TextBox txt_NhapThongTinTimKiem;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.ComboBox cbo_KieuTimKiem;
        private System.Windows.Forms.Label lbl_TT;
        private System.Windows.Forms.Label lbl_KTK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lbl_GioiTinh_Required;
        private System.Windows.Forms.Label lbl_NgaySinh_Required;
        private System.Windows.Forms.Label lbl_TenHS_Required;
        private System.Windows.Forms.Label lbl_TenPH_Required;
        private System.Windows.Forms.Label lbl_MaPH_Required;
        private System.Windows.Forms.Label lbl_MQH_Required;
    }
}
