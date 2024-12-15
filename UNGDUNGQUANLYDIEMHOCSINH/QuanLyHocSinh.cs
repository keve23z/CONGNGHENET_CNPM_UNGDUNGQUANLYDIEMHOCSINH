using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace UNGDUNGQUANLYDIEMHOCSINH
{
    using UNGDUNGQUANLYDIEMHOCSINH.Services;

    public partial class QuanLyHocSinh : UserControl
    {
        private DBConnect db;
        private bool _isAdding = false;

        public QuanLyHocSinh()
        {
            InitializeComponent();
        }


        private void ThongTinHS_Load(object sender, EventArgs e)
        {
            db = new DBConnect(Config.ConnectionString);

            LoadComboBox_GioiTinh();
            LoadComboBox_MoiQuanHe();
            LoadComboBox_MaPH();
            LoadComboBox_TimKiem();

            LoadDataGridView_HocSinh_PhuHuynh();

            DisableInfoControls();
            DisableParentInfoControls();

            SelectFirstRowDataGridView(dgv_DanhSachHS);

            dgv_DanhSachHS.ReadOnly = true;
            txt_TenPH.Enabled = false;
            dtp_NgaySinh.Format = DateTimePickerFormat.Short;
            btn_Delete.Enabled = btn_Update.Enabled = btn_Save.Enabled = false;
        }


        private void btn_Add_Click(object sender, EventArgs e)
        {
            btn_Save.Enabled = true;
            btn_Cancel.Enabled = true;

            btn_Add.Enabled = btn_Delete.Enabled = btn_Update.Enabled = false;

            EnableInfoControls();
            EnableParentInfoControls();

            _isAdding = true;
            txt_TenPH.Enabled = false;

            ClearInfoControls();
            ClearParentInfoControls();

            if (cbo_MaPH.Items.Count > 0)
            {
                string strTenPH = cbo_MaPH.SelectedValue.ToString();

                LoadTenPhuHuynh(strTenPH);
            }

            txt_MaHS.Focus();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xoá học sinh này không?", "Thông báo",
                                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                                            MessageBoxDefaultButton.Button2);

            if (result == DialogResult.No)
            {
                return;
            }

            DeleteStudent();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            btn_Save.Enabled = true;
            btn_Cancel.Enabled = true;

            btn_Add.Enabled = btn_Delete.Enabled = btn_Update.Enabled = false;

            EnableInfoControls();
            EnableParentInfoControls();

            _isAdding = false;

            txt_MaHS.Enabled = false;
            txt_TenPH.Enabled = false;

            txt_TenHS.Focus();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string action = "";

            if (txt_MaHS.Enabled)
            {
                action = "thêm";
            }
            else
            {
                action = "cập nhật";
            }

            var result = MessageBox.Show($"Bạn có muốn {action} học sinh?", "Thông báo",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.No)
            {
                return;
            }


            if (txt_MaHS.Enabled)
            {
                AddStudent();
                return;
            }

            UpdateStudent();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn huỷ hành động hiện tại?", "Thông báo",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                btn_Add.Enabled = true;
                btn_Delete.Enabled = btn_Update.Enabled = btn_Save.Enabled = btn_Cancel.Enabled = false;

                ClearInfoControls();
                ClearParentInfoControls();

                DisableInfoControls();
                DisableParentInfoControls();

                _isAdding = false;
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            LoadDataGridView_HocSinh_PhuHuynh();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string keyword = txt_NhapThongTinTimKiem.Text.Trim();

            if (!IsValidSearchValue(keyword))
            {
                return;
            }

            string searchColumn = GetSearchColumn();

            string strSQL = $@"
                            SELECT 
                                hs.MaHocSinh, 
                                hs.HoTen, 
                                hs.GioiTinh, 
                                hs.NgaySinh, 
                                ph.DiaChi, 
                                hs.MaPH, 
                                ph.HoTenPH,
                                ph.SoDienThoai,
                                ph.MoiQuanHe
                            FROM HocSinh hs
                            LEFT JOIN PhuHuynh ph ON hs.MaPH = ph.MaPH
                            WHERE {searchColumn} LIKE @Keyword";

            if (db.DataSet.Tables.Contains(Config.HOCSINH_TABLE))
            {
                db.DataSet.Tables[Config.HOCSINH_TABLE].Clear();
            }

            DataTable dtSearchResult = new DataTable();
            using (SqlCommand cmd = new SqlCommand(strSQL, db.Conn))
            {
                cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                db.OpenConnect();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtSearchResult);

                db.CloseConnect();
            }

            dgv_DanhSachHS.DataSource = dtSearchResult;

            LoadDataGridViewColumn_HocSinh_PhuHuynh();

            if (dtSearchResult.Rows.Count <= 0)
            {
                MessageBox.Show("Không tìm thấy kết quả phù hợp.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                dgv_DanhSachHS.DataSource = null;
            }
            else
            {
                SelectFirstRowDataGridView(dgv_DanhSachHS);
            }
        }


        private void txt_SDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void cbo_MaPH_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbo_MaPH.SelectedValue != null)
            {
                string strTenPH = cbo_MaPH.SelectedValue.ToString();

                LoadTenPhuHuynh(strTenPH);
            }
        }


        private void dgv_DanhSachHS_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_DanhSachHS.SelectedRows.Count > 0)
            {
                DataGridViewRow currentRow = dgv_DanhSachHS.CurrentRow;

                DataBindingDanhSach_HocSinh_PhuHuynh(currentRow);
            }
        }

        private void dgv_DanhSachHS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgv_DanhSachHS.Rows[e.RowIndex] != null)
            {
                DataGridViewRow selectedRow = dgv_DanhSachHS.Rows[e.RowIndex];

                DataBindingDanhSach_HocSinh_PhuHuynh(selectedRow);
            }
        }


        private void LoadDataGridView_HocSinh_PhuHuynh()
        {
            string strSQL = @"
                    SELECT 
                        hs.MaHocSinh, 
                        hs.HoTen, 
                        hs.GioiTinh, 
                        hs.NgaySinh, 
                        hs.MaPH, 
                        ph.HoTenPH,
                        ph.MoiQuanHe
                    FROM HocSinh hs
                    LEFT JOIN PhuHuynh ph ON hs.MaPH = ph.MaPH";

            dgv_DanhSachHS.DataSource = null;

            if (db.DataSet.Tables.Contains(Config.HOCSINH_TABLE))
            {
                db.DataSet.Tables[Config.HOCSINH_TABLE].Clear();
            }

            DataTable dtHocSinh = db.GetDataTable(strSQL, Config.HOCSINH_TABLE);
            dgv_DanhSachHS.DataSource = dtHocSinh;

            LoadDataGridViewColumn_HocSinh_PhuHuynh();
        }

        private void LoadDataGridViewColumn_HocSinh_PhuHuynh()
        {
            dgv_DanhSachHS.Columns.Clear();

            dgv_DanhSachHS.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã Học Sinh",
                Name = "MaHocSinh",
                DataPropertyName = "MaHocSinh",
                Width = 140
            });

            dgv_DanhSachHS.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Họ Tên",
                Name = "HoTen",
                DataPropertyName = "HoTen",
                Width = 220
            });

            dgv_DanhSachHS.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Ngày Sinh",
                Name = "NgaySinh",
                DataPropertyName = "NgaySinh",
                Width = 140
            });

            dgv_DanhSachHS.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Giới Tính",
                Name = "GioiTinh",
                DataPropertyName = "GioiTinh",
                Width = 120
            });

            dgv_DanhSachHS.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã Phụ Huynh",
                Name = "MaPH",
                DataPropertyName = "MaPH",
                Width = 120
            });

            dgv_DanhSachHS.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HoTenPH",
                DataPropertyName = "HoTenPH",
                Visible = false
            });

            dgv_DanhSachHS.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MoiQuanHe",
                DataPropertyName = "MoiQuanHe",
                Visible = false
            });
        }

        private void DataBindingDanhSach_HocSinh_PhuHuynh(DataGridViewRow row)
        {
            txt_MaHS.Text = row.Cells["MaHocSinh"].Value.ToString();
            txt_TenHS.Text = row.Cells["HoTen"].Value.ToString();
            cbo_GioiTinh.Text = row.Cells["GioiTinh"].Value.ToString();
            dtp_NgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);

            cbo_MaPH.Text = row.Cells["MaPH"].Value.ToString();
            txt_TenPH.Text = row.Cells["HoTenPH"].Value.ToString();
            cbo_MQH.Text = row.Cells["MoiQuanHe"].Value.ToString();

            if (!_isAdding)
            {
                btn_Delete.Enabled = btn_Update.Enabled = true;
            }
        }

        private void LoadTenPhuHuynh(string strMaPH)
        {
            string strSQL = "SELECT HoTenPH FROM " + Config.PHUHUYNH_TABLE +
                              " WHERE MaPH = @MaPH";

            SqlParameter[] parameters =
            {
                    new SqlParameter("@MaPH", strMaPH)
                };

            DataTable dt = db.ExecuteQuery(strSQL, parameters);

            if (dt.Rows.Count > 0)
            {
                txt_TenPH.Text = dt.Rows[0]["HoTenPH"].ToString();
            }
            else
            {
                txt_TenPH.Text = "";
            }
        }

        private void LoadComboBox_GioiTinh()
        {
            string[] gioiTinh = new string[] { "Nam", "Nữ" };

            cbo_GioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_GioiTinh.Items.Clear();
            cbo_GioiTinh.DataSource = gioiTinh;
            cbo_GioiTinh.SelectedIndex = 0;
        }

        private void LoadComboBox_MoiQuanHe()
        {
            string[] moiQuanHe = new string[] { "Người giám hộ", "Cha", "Mẹ" };

            cbo_MQH.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_MQH.Items.Clear();
            cbo_MQH.DataSource = moiQuanHe;
            cbo_MQH.SelectedIndex = 0;
        }

        private void LoadComboBox_TimKiem()
        {
            string[] searchOptions = new string[] { "Mã Học Sinh", "Tên Học Sinh" };

            cbo_KieuTimKiem.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_KieuTimKiem.DataSource = searchOptions;
            cbo_KieuTimKiem.SelectedIndex = 0;
        }

        private void LoadComboBox_MaPH()
        {
            string strSQL = $"SELECT * FROM {Config.PHUHUYNH_TABLE}";

            DataTable dt = db.GetDataTable(strSQL, Config.PHUHUYNH_TABLE);

            cbo_MaPH.Items.Clear();

            cbo_MaPH.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_MaPH.DataSource = dt;
            cbo_MaPH.DisplayMember = "MaPH";
            cbo_MaPH.ValueMember = "MaPH";

            if (dt.Rows.Count > 0)
            {
                cbo_MaPH.SelectedIndex = 0;
            }
        }

        private void SelectFirstRowDataGridView(DataGridView dgv)
        {
            if (dgv.Rows.Count > 0)
            {
                dgv.Rows[0].Selected = true;
            }
        }


        private void AddStudent()
        {
            string strMaHS = txt_MaHS.Text.Trim();

            if (!IsValidMaHS(strMaHS))
            {
                return;
            }

            string strTenHS = txt_TenHS.Text.Trim();

            if (!IsValidTenHS(strTenHS))
            {
                return;
            }

            if (!IsValidComboBox_GioiTinh())
            {
                return;
            }

            if (!IsValidNgaySinh(dtp_NgaySinh))
            {
                return;
            }

            string strGioiTinh = cbo_GioiTinh.Text;

            string strMaPH = cbo_MaPH.Text;

            if (!IsValidComboBox_MaPH())
            {
                return;
            }

            string strTenPH = txt_TenPH.Text.Trim();

            if (!IsValidTenPH(strTenPH))
            {
                return;
            }

            string strNgaySinh = GetNgaySinh();

            if (!IsValidComboBox_MQH())
            {
                return;
            }

            string strMQH = cbo_MQH.SelectedValue.ToString();

            try
            {
                if (db.CheckExist(Config.HOCSINH_TABLE, "MaHocSinh", strMaHS))
                {
                    MessageBox.Show("Mã học sinh này đã tồn tại.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    txt_MaHS.Clear();
                    txt_MaHS.Focus();
                    return;
                }

                if (!db.CheckExist(Config.PHUHUYNH_TABLE, "MaPH", strMaPH))
                {
                    MessageBox.Show("Mã phụ huynh này chưa tồn tại.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    cbo_MaPH.Focus();
                    return;
                }

                string strSQL1 = $@"UPDATE {Config.PHUHUYNH_TABLE}
                                   SET MoiQuanHe = N'{strMQH}' 
                                   WHERE MaPH = '{strMaPH}'";

                db.UpdateToDataBase(strSQL1);

                string strSQL2 = $@"INSERT INTO HocSinh (MaHocSinh, HoTen, GioiTinh, NgaySinh, MaPH)
                                   VALUES ('{strMaHS}', N'{strTenHS}', N'{strGioiTinh}', '{strNgaySinh}', '{strMaPH}')";

                db.UpdateToDataBase(strSQL2);

                MessageBox.Show("Thêm thành công.", "Thông báo",
                             MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDataGridView_HocSinh_PhuHuynh();

                DisableInfoControls();
                DisableParentInfoControls();

                btn_Add.Enabled = true;
                _isAdding = false;
            }
            catch
            {
                MessageBox.Show("Thêm thất bại.", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteStudent()
        {
            string strMaHS = txt_MaHS.Text.Trim();

            try
            {
                if (db.CheckExist(Config.DIEM_TABLE, "MaHocSinh", strMaHS))
                {
                    MessageBox.Show($"Mã học sinh này đã tồn tại trên bảng {Config.DIEM_TABLE} nên không thể xoá được.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (db.CheckExist(Config.DanhGiaHanhKiem_TABLE, "MaHocSinh", strMaHS))
                {
                    MessageBox.Show($"Mã học sinh này đã tồn tại trên bảng {Config.DanhGiaHanhKiem_TABLE} nên không thể xoá được.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (db.CheckExist(Config.DanhGiaHocLuc_TABLE, "MaHocSinh", strMaHS))
                {
                    MessageBox.Show($"Mã học sinh này đã tồn tại trên bảng {Config.DanhGiaHocLuc_TABLE} nên không thể xoá được.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string strSQL = "DELETE FROM " + Config.HOCSINH_TABLE +
                                " WHERE MaHocSinh = '" + strMaHS + "'";

                db.UpdateToDataBase(strSQL);

                MessageBox.Show("Xoá thành công.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDataGridView_HocSinh_PhuHuynh();
            }
            catch
            {
                MessageBox.Show("Xoá thất bại.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStudent()
        {
            string strTenHS = txt_TenHS.Text.Trim();

            if (!IsValidTenHS(strTenHS))
            {
                return;
            }

            if (!IsValidComboBox_GioiTinh())
            {
                return;
            }

            if (!IsValidNgaySinh(dtp_NgaySinh))
            {
                return;
            }

            string strGioiTinh = cbo_GioiTinh.Text;

            string strNgaySinh = GetNgaySinh();

            string strMaHS = txt_MaHS.Text;

            string strMaPH = cbo_MaPH.SelectedValue.ToString();

            if (!IsValidComboBox_MaPH())
            {
                return;
            }

            string strTenPH = txt_TenPH.Text.Trim();

            if (!IsValidTenPH(strTenPH))
            {
                return;
            }

            if (!IsValidComboBox_MQH())
            {
                return;
            }

            string strMQH = cbo_MQH.SelectedValue.ToString();

            try
            {
                if (!db.CheckExist(Config.HOCSINH_TABLE, "MaHocSinh", strMaHS))
                {
                    MessageBox.Show("Mã học sinh này chưa tồn tại.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (!db.CheckExist(Config.PHUHUYNH_TABLE, "MaPH", strMaPH))
                {
                    MessageBox.Show("Mã phụ huynh này chưa tồn tại.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string strSQL1 = $@"UPDATE {Config.PHUHUYNH_TABLE}
                                   SET  MoiQuanHe = N'{strMQH}' 
                                   WHERE MaPH = '{strMaPH}'";

                db.UpdateToDataBase(strSQL1);

                string strSQL2 = $@"UPDATE {Config.HOCSINH_TABLE} 
                                   SET HoTen = N'{strTenHS}', 
                                       GioiTinh = N'{strGioiTinh}', 
                                       NgaySinh = '{strNgaySinh}', 
                                       MaPH = '{strMaPH}' 
                                   WHERE MaHocSinh = '{strMaHS}'";

                db.UpdateToDataBase(strSQL2);

                MessageBox.Show("Cập nhật thành công.", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDataGridView_HocSinh_PhuHuynh();

                DisableInfoControls();
                DisableParentInfoControls();

                btn_Add.Enabled = true;
                _isAdding = false;
            }
            catch
            {
                MessageBox.Show("Cập nhật thất bại.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetSearchColumn()
        {
            return cbo_KieuTimKiem.SelectedItem.ToString() == "Mã Học Sinh" ? "MaHocSinh" : "HoTen";
        }

        private string GetNgaySinh()
        {
            return dtp_NgaySinh.Value.ToString("yyyy-MM-dd");
        }


        private void EnableInfoControls()
        {
            txt_MaHS.Enabled = txt_TenHS.Enabled = true;

            dtp_NgaySinh.Enabled = true;
            cbo_GioiTinh.Enabled = true;
        }

        private void DisableInfoControls()
        {
            txt_MaHS.Enabled = txt_TenHS.Enabled = false;

            dtp_NgaySinh.Enabled = false;
            cbo_GioiTinh.Enabled = false;
        }

        private void EnableParentInfoControls()
        {
            txt_TenPH.Enabled = true;

            cbo_MaPH.Enabled = cbo_MQH.Enabled = true;
        }

        private void DisableParentInfoControls()
        {
            txt_TenPH.Enabled = false;

            cbo_MaPH.Enabled = cbo_MQH.Enabled = false;
        }

        private void ClearInfoControls()
        {
            txt_MaHS.Clear();
            txt_TenHS.Clear();
            dtp_NgaySinh.Value = DateTime.Now;

            cbo_GioiTinh.SelectedIndex = 0;
        }

        private void ClearParentInfoControls()
        {
            txt_TenPH.Clear();

            if (cbo_MaPH.Items.Count > 0)
            {
                cbo_MaPH.SelectedIndex = 0;
            }

            cbo_MQH.SelectedIndex = 0;
        }


        private bool IsValidMaHS(string maHS)
        {
            if (maHS == "")
            {
                MessageBox.Show("Vui lòng nhập mã học sinh.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_MaHS.Focus();
                return false;
            }

            if (maHS.Length > 10)
            {
                MessageBox.Show("Độ dài mã học sinh vượt quá giới hạn.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_MaHS.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidTenHS(string tenHS)
        {
            if (tenHS == "")
            {
                MessageBox.Show("Vui lòng nhập tên học sinh.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_TenHS.Focus();
                return false;
            }

            if (tenHS.Length > 30)
            {
                MessageBox.Show("Độ dài tên học sinh vượt quá giới hạn.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_TenHS.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidComboBox_GioiTinh()
        {
            if (cbo_GioiTinh.SelectedIndex == -1)
            {
                MessageBox.Show("Dữ liệu giới tính không hợp lệ.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_GioiTinh.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidNgaySinh(DateTimePicker datePicker)
        {
            DateTime selectedDate = datePicker.Value;

            if (selectedDate >= DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không được lớn hơn hoặc bằng ngày hiện tại.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtp_NgaySinh.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidComboBox_MaPH()
        {
            if (cbo_MaPH.SelectedIndex == -1)
            {
                MessageBox.Show("Dữ liệu mã phụ huynh không hợp lệ.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_MaPH.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidTenPH(string tenPH)
        {
            if (tenPH == "")
            {
                MessageBox.Show("Dữ liệu tên phụ huynh không hợp lệ.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private bool IsValidComboBox_MQH()
        {
            if (cbo_MQH.SelectedIndex == -1)
            {
                MessageBox.Show("Dữ liệu mối quan hệ không hợp lệ.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_MQH.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidSearchValue(string keyword)
        {
            if (keyword == "")
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_NhapThongTinTimKiem.Focus();
                return false;
            }

            return true;
        }
    }
}

