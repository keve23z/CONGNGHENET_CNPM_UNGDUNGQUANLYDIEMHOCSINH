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

namespace UNGDUNGQUANLYDIEMHOCSINH
{
    using System.Data.SqlClient;
    using UNGDUNGQUANLYDIEMHOCSINH.Services;

    public partial class PhanCongLop : UserControl
    {
        private DBConnect db;
        private bool _isAdding = false;

        public PhanCongLop()
        {
            InitializeComponent();
        }


        private void QuanLyLop_Load(object sender, EventArgs e)
        {
            db = new DBConnect(Config.ConnectionString);

            LoadComboBox_Khoi();
            LoadComboBox_TenLop();
            LoadComboBox_MaHS();
            LoadComboBox_TimKiem();

            if (cbo_TenKhoi.SelectedValue != null)
            {
                string strMaKhoi = cbo_TenKhoi.SelectedValue.ToString();

                LoadDataGridView_Lop(strMaKhoi);
            }

            DisableInfoControls();

            SelectFirstRowDataGridView(dgv_DanhSachLop);

            dgv_DanhSachHS.ReadOnly = true;
            dgv_DanhSachLop.ReadOnly = true;

            cbo_MaHS.Enabled = txt_TenHS.Enabled = false;
            btn_Delete.Enabled = btn_Update.Enabled = btn_Save.Enabled = false;

            lbl_SiSoResult.Text = "0";
        }


        private void btn_Add_Click(object sender, EventArgs e)
        {
            btn_Save.Enabled = true;

            btn_Delete.Enabled = false;
            btn_Update.Enabled = false;

            EnableInfoControls();
            EnableStudentInfoControls();

            txt_TenHS.Enabled = false;

            _isAdding = true;

            cbo_MaHS.Focus();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xoá học sinh này khỏi lớp này không?", "Thông báo",
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                                   MessageBoxDefaultButton.Button2);

            if (result == DialogResult.No)
            {
                return;
            }

            DeleteStudentFromClass();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            btn_Save.Enabled = true;

            btn_Delete.Enabled = false;
            btn_Update.Enabled = false;

            EnableInfoControls();
            EnableStudentInfoControls();

            cbo_MaHS.Enabled = false;
            txt_TenHS.Enabled = false;

            _isAdding = false;

            cbo_TenKhoi.Focus();
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
                DisableInfoControls();

                _isAdding = false;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string action = "";

            if (cbo_MaHS.Enabled)
            {
                action = "phân công học sinh vào lớp này không";
            }
            else
            {
                action = "cập nhật lại lớp này không";
            }

            var result = MessageBox.Show($"Bạn có muốn {action}?", "Thông báo",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.No)
            {
                return;
            }

            if (cbo_MaHS.Enabled)
            {
                AddClass();
                return;
            }

            UpdateClass();
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            if (dgv_DanhSachLop.Rows.Count > 0)
            {
                dgv_DanhSachLop.Rows[0].Selected = true;
                string strMaLop = dgv_DanhSachLop.SelectedRows[0].Cells["MaLop"].Value.ToString();

                LoadDataGridView_HocSinhByLop(strMaLop);
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txt_TTTimKiem.Text.Trim();

            if (!chkChuaCoLop.Checked && !IsValidSearchValue(keyword))
            {
                return;
            }

            string searchColumn = GetSearchColumn();

            string strSQL = $"SELECT MaHocSinh, HoTen, GioiTinh, NgaySinh FROM {Config.HOCSINH_TABLE} " +
                          $"WHERE {searchColumn} LIKE @Keyword";

            if (chkChuaCoLop.Checked)
            {
                strSQL += " AND MaLop IS NULL";
            }

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

            LoadDataGridViewColumn_HocSinh();

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


        private void cbo_MaHS_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbo_MaHS.SelectedValue != null)
            {
                string strMaHS = cbo_MaHS.SelectedValue.ToString();

                LoadTenHS(strMaHS);
            }
        }

        private void cbo_TenKhoi_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbo_TenKhoi.SelectedValue != null)
            {
                string strMaKhoi = cbo_TenKhoi.SelectedValue.ToString();

                LoadDataGridView_Lop(strMaKhoi);

                SelectFirstRowDataGridView(dgv_DanhSachLop);

                SelectFirstRowDataGridView(dgv_DanhSachHS);
            }
        }


        private void dgv_DanhSachHS_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_DanhSachHS.SelectedRows.Count > 0)
            {
                DataGridViewRow currentRow = dgv_DanhSachHS.CurrentRow;

                DataBindingDanhSach_HocSinh(currentRow);
            }
        }

        private void dgv_DanhSachHS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgv_DanhSachHS.Rows[e.RowIndex] != null)
            {
                DataGridViewRow selectedRow = dgv_DanhSachHS.Rows[e.RowIndex];

                DataBindingDanhSach_HocSinh(selectedRow);
            }
        }

        private void dgv_DanhSachLop_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_DanhSachLop.SelectedRows.Count > 0)
            {
                DataGridViewRow currentRow = dgv_DanhSachLop.CurrentRow;

                DataBindingDanhSach_Lop(currentRow);
            }
        }

        private void dgv_DanhSachLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgv_DanhSachLop.Rows[e.RowIndex] != null)
            {
                DataGridViewRow selectedRow = dgv_DanhSachLop.Rows[e.RowIndex];

                DataBindingDanhSach_Lop(selectedRow);
            }
        }


        private void LoadDataGridView_Lop(string maKhoi)
        {
            string strSQL = $@"
                                SELECT 
                                    l.MaLop, 
                                    l.TenLop, 
                                    k.TenKhoi, 
                                    k.MaKhoi
                                FROM {Config.LOP_TABLE} l
                                LEFT JOIN {Config.KHOI_TABLE} k ON l.MaKhoi = k.MaKhoi
                                WHERE k.MaKhoi = '{maKhoi}'";

            dgv_DanhSachLop.DataSource = null;

            if (db.DataSet.Tables.Contains(Config.LOP_TABLE))
            {
                db.DataSet.Tables[Config.LOP_TABLE].Clear();
            }

            DataTable dt = db.GetDataTable(strSQL, Config.LOP_TABLE);
            dgv_DanhSachLop.DataSource = dt;

            LoadDataGridViewColumn_Lop();
        }

        private void LoadDataGridView_Lop()
        {
            string strSQL = $@"
                                SELECT 
                                    l.MaLop, 
                                    l.TenLop, 
                                    k.TenKhoi, 
                                    k.MaKhoi
                                FROM {Config.LOP_TABLE} l
                                LEFT JOIN {Config.KHOI_TABLE} k ON l.MaKhoi = k.MaKhoi";

            dgv_DanhSachLop.DataSource = null;

            if (db.DataSet.Tables.Contains(Config.LOP_TABLE))
            {
                db.DataSet.Tables[Config.LOP_TABLE].Clear();
            }

            DataTable dt = db.GetDataTable(strSQL, Config.LOP_TABLE);
            dgv_DanhSachLop.DataSource = dt;

            LoadDataGridViewColumn_Lop();
        }

        private void LoadDataGridViewColumn_HocSinh()
        {
            dgv_DanhSachHS.Columns.Clear();

            dgv_DanhSachHS.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã Học Sinh",
                Name = "MaHocSinh",
                DataPropertyName = "MaHocSinh",
                Width = 100
            });

            dgv_DanhSachHS.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Họ Tên",
                Name = "HoTen",
                DataPropertyName = "HoTen",
                Width = 160
            });

            dgv_DanhSachHS.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Giới Tính",
                Name = "GioiTinh",
                DataPropertyName = "GioiTinh",
                Width = 80
            });

            dgv_DanhSachHS.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Ngày Sinh",
                Name = "NgaySinh",
                DataPropertyName = "NgaySinh",
                Width = 125
            });

            dgv_DanhSachHS.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaLop",
                DataPropertyName = "MaLop",
                Visible = false
            });

            dgv_DanhSachHS.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaPH",
                DataPropertyName = "MaPH",
                Visible = false
            });
        }

        private void LoadDataGridViewColumn_Lop()
        {
            dgv_DanhSachLop.Columns.Clear();

            dgv_DanhSachLop.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã Lớp",
                Name = "MaLop",
                DataPropertyName = "MaLop",
                Width = 100
            });

            dgv_DanhSachLop.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên Lớp",
                Name = "TenLop",
                DataPropertyName = "TenLop",
                Width = 180
            });

            dgv_DanhSachLop.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên Khối",
                Name = "TenKhoi",
                DataPropertyName = "TenKhoi",
                Visible = false
            });

            dgv_DanhSachLop.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaKhoi",
                DataPropertyName = "MaKhoi",
                Visible = false
            });

            dgv_DanhSachLop.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaGVCN",
                DataPropertyName = "MaGVCN",
                Visible = false
            });

            dgv_DanhSachLop.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaNienKhoa",
                DataPropertyName = "MaNienKhoa",
                Visible = false
            });
        }

        private void DataBindingDanhSach_Lop(DataGridViewRow row)
        {
            cbo_TenKhoi.Text = row.Cells["TenKhoi"].Value.ToString();
            cbo_TenLop.Text = row.Cells["TenLop"].Value.ToString();

            string strMaLop = row.Cells["MaLop"].Value.ToString();

            LoadSiSoLop(strMaLop);

            LoadDataGridView_HocSinhByLop(strMaLop);
        }

        private void DataBindingDanhSach_HocSinh(DataGridViewRow row)
        {
            cbo_MaHS.Text = row.Cells["MaHocSinh"].Value.ToString();
            txt_TenHS.Text = row.Cells["HoTen"].Value.ToString();

            if (!_isAdding)
            {
                btn_Delete.Enabled = btn_Update.Enabled = true;
            }
        }

        private void LoadComboBox_TenLop()
        {
            string strSQL = $"SELECT * FROM {Config.LOP_TABLE}";

            DataTable dt = db.GetDataTable(strSQL, Config.LOP_TABLE);

            cbo_TenLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_TenLop.Items.Clear();
            cbo_TenLop.DataSource = dt;
            cbo_TenLop.DisplayMember = "TenLop";
            cbo_TenLop.ValueMember = "MaLop";

            if (dt.Rows.Count > 0)
            {
                cbo_TenLop.SelectedIndex = 0;
            }
        }

        private void LoadComboBox_Khoi()
        {
            string strSQL = $"SELECT * FROM {Config.KHOI_TABLE}";

            DataTable dt = db.GetDataTable(strSQL, Config.KHOI_TABLE);

            cbo_TenKhoi.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_TenKhoi.Items.Clear();
            cbo_TenKhoi.DataSource = dt;
            cbo_TenKhoi.DisplayMember = "TenKhoi";
            cbo_TenKhoi.ValueMember = "MaKhoi";

            if (dt.Rows.Count > 0)
            {
                cbo_TenKhoi.SelectedIndex = 0;
            }
        }

        private void LoadComboBox_MaHS()
        {
            string strSQL = $"SELECT * FROM {Config.HOCSINH_TABLE}";

            DataTable dt = db.GetDataTable(strSQL, Config.HOCSINH_TABLE);

            cbo_MaHS.Items.Clear();

            //cbo_MaHS.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_MaHS.DataSource = dt;
            cbo_MaHS.DisplayMember = "MaHocSinh";
            cbo_MaHS.ValueMember = "MaHocSinh";

            if (dt.Rows.Count > 0)
            {
                cbo_MaHS.SelectedIndex = 0;
            }
        }

        private void LoadComboBox_TimKiem()
        {
            string[] searchOptions = new string[] { "Mã Học Sinh", "Tên Học Sinh" };

            cbo_KieuTimKiem.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_KieuTimKiem.DataSource = searchOptions;
            cbo_KieuTimKiem.SelectedIndex = 0;
        }

        private void LoadDataGridView_HocSinhByLop(string maLop)
        {
            if (db.DataSet.Tables.Contains(Config.HOCSINH_TABLE))
            {
                db.DataSet.Tables[Config.HOCSINH_TABLE].Clear();
            }

            DataTable dtHocSinh = GetHocSinhByLop(maLop);
            dgv_DanhSachHS.DataSource = dtHocSinh;

            LoadDataGridViewColumn_HocSinh();

            if (dtHocSinh.Rows.Count > 0)
            {
                dgv_DanhSachHS.Rows[0].Selected = true;
            }
        }

        public DataTable GetHocSinhByLop(string maLop)
        {
            string strSQL = $"SELECT MaHocSinh, HoTen, GioiTinh, NgaySinh FROM {Config.HOCSINH_TABLE} " +
                            $"WHERE MaLop = '{maLop}'";

            return db.GetDataTable(strSQL, Config.HOCSINH_TABLE);
        }

        private void LoadSiSoLop(string maLop)
        {
            string strSQL = $"SELECT COUNT(*) FROM {Config.HOCSINH_TABLE} WHERE MaLop = '{maLop}'";

            int count = db.GetCount(strSQL);

            lbl_SiSoResult.Text = count.ToString();
        }

        private void LoadTenHS(string strMaHS)
        {
            string strSQL = "SELECT HoTen FROM " + Config.HOCSINH_TABLE +
                              " WHERE MaHocSinh = @MaHocSinh";

            SqlParameter[] parameters =
            {
                    new SqlParameter("@MaHocSinh", strMaHS)
                };

            DataTable dt = db.ExecuteQuery(strSQL, parameters);

            if (dt.Rows.Count > 0)
            {
                txt_TenHS.Text = dt.Rows[0]["HoTen"].ToString();
            }
            else
            {
                txt_TenHS.Text = "";
            }
        }

        private void SelectFirstRowDataGridView(DataGridView dgv)
        {
            if (dgv.Rows.Count > 0)
            {
                dgv.Rows[0].Selected = true;
            }
        }


        private void AddClass()
        {
            string strMaHS = cbo_MaHS.SelectedValue.ToString();

            if (!IsValidComboBox_MaHS())
            {
                return;
            }

            if (!IsValidComboBox_Khoi())
            {
                return;
            }

            if (!IsValidComboBox_Lop())
            {
                return;
            }

            string strMaKhoi = cbo_TenKhoi.SelectedValue.ToString();

            string strMaLop = cbo_TenLop.SelectedValue.ToString();

            try
            {
                if (!db.CheckExist(Config.HOCSINH_TABLE, "MaHocSinh", strMaHS))
                {
                    MessageBox.Show("Mã học sinh này chưa tồn tại.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbo_MaHS.Focus();
                    return;
                }

                string queryCheckMaLop = $@"
                                            SELECT MaLop 
                                            FROM {Config.HOCSINH_TABLE} 
                                            WHERE MaHocSinh = '{strMaHS}' AND MaLop IS NOT NULL";

                string existingMaLop = db.ExecuteScalar(queryCheckMaLop)?.ToString();

                if (!string.IsNullOrEmpty(existingMaLop))
                {
                    MessageBox.Show("Học sinh này đã có lớp rồi.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbo_MaHS.Focus();
                    return;
                }

                if (!db.CheckExist(Config.KHOI_TABLE, "MaKhoi", strMaKhoi))
                {
                    MessageBox.Show("Khối này chưa tồn tại.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbo_TenKhoi.Focus();
                    return;
                }

                if (!db.CheckExist(Config.LOP_TABLE, "MaLop", strMaLop))
                {
                    MessageBox.Show("Lớp này chưa tồn tại.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbo_TenLop.Focus();
                    return;
                }

                string strSQL = $@"UPDATE {Config.HOCSINH_TABLE}
                                   SET MaLop = '{strMaLop}'
                                   WHERE MaHocSinh = '{strMaHS}'";

                db.UpdateToDataBase(strSQL);

                MessageBox.Show("Thêm thành công.", "Thông báo",
                             MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDataGridView_Lop();
                LoadDataGridView_HocSinhByLop(strMaLop);

                DisableInfoControls();
                DisableStudentInfoControls();

                LoadSiSoLop(strMaLop);

                _isAdding = false;
            }
            catch
            {
                MessageBox.Show("Thêm thất bại.", "Thông báo",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteStudentFromClass()
        {
            string strMaHS = cbo_MaHS.SelectedValue.ToString();

            if (!IsValidComboBox_Lop())
            {
                return;
            }

            string strMaLop = cbo_TenLop.SelectedValue.ToString();

            try
            {
                if (!db.CheckExist(Config.HOCSINH_TABLE, "MaHocSinh", strMaHS))
                {
                    MessageBox.Show("Mã học sinh này chưa tồn tại.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (!db.CheckExist(Config.LOP_TABLE, "MaLop", strMaLop))
                {
                    MessageBox.Show("Lớp này chưa tồn tại.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string strSQL = $@"UPDATE {Config.HOCSINH_TABLE}
                                   SET MaLop = NULL
                                   WHERE MaHocSinh = '{strMaHS}'";

                db.UpdateToDataBase(strSQL);

                MessageBox.Show("Xoá thành công.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDataGridView_HocSinhByLop(strMaLop);
                LoadSiSoLop(strMaLop);
            }
            catch
            {
                MessageBox.Show("Xoá thất bại.", "Thông báo",
                                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateClass()
        {
            string strMaHS = cbo_MaHS.SelectedValue.ToString();

            if (!IsValidComboBox_MaHS())
            {
                return;
            }

            if (!IsValidComboBox_Khoi())
            {
                return;
            }

            if (!IsValidComboBox_Lop())
            {
                return;
            }

            string strMaKhoi = cbo_TenKhoi.SelectedValue.ToString();

            string strMaLop = cbo_TenLop.SelectedValue.ToString();

            try
            {
                if (!db.CheckExist(Config.HOCSINH_TABLE, "MaHocSinh", strMaHS))
                {
                    MessageBox.Show("Mã học sinh này chưa tồn tại.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbo_MaHS.Focus();
                    return;
                }

                if (!db.CheckExist(Config.KHOI_TABLE, "MaKhoi", strMaKhoi))
                {
                    MessageBox.Show("Khối này chưa tồn tại.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbo_TenKhoi.Focus();
                    return;
                }

                if (!db.CheckExist(Config.LOP_TABLE, "MaLop", strMaLop))
                {
                    MessageBox.Show("Lớp này chưa tồn tại.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbo_TenLop.Focus();
                    return;
                }

                string strSQL = $@"UPDATE {Config.HOCSINH_TABLE}
                                   SET MaLop = '{strMaLop}'
                                   WHERE MaHocSinh = '{strMaHS}'";

                db.UpdateToDataBase(strSQL);

                MessageBox.Show("Cập nhật thành công.", "Thông báo",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDataGridView_Lop();
                LoadDataGridView_HocSinhByLop(strMaLop);

                DisableInfoControls();
                DisableStudentInfoControls();

                LoadSiSoLop(strMaLop);

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


        private void EnableInfoControls()
        {
            cbo_TenLop.Enabled = true;
        }

        private void DisableInfoControls()
        {
            cbo_TenLop.Enabled = false;
        }

        private void EnableStudentInfoControls()
        {
            cbo_MaHS.Enabled = txt_TenHS.Enabled = true;
        }

        private void DisableStudentInfoControls()
        {
            cbo_MaHS.Enabled = txt_TenHS.Enabled = false;
        }

        private void ClearInfoControls()
        {
            if (cbo_TenKhoi.Items.Count > 0)
            {
                cbo_TenKhoi.SelectedIndex = 0;
            }

            if (cbo_TenLop.Items.Count > 0)
            {
                cbo_TenLop.SelectedIndex = 0;
            }
        }


        private bool IsValidComboBox_MaHS()
        {
            if (cbo_MaHS.SelectedIndex == -1)
            {
                MessageBox.Show("Dữ liệu mã học sinh không hợp lệ.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_MaHS.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidComboBox_Khoi()
        {
            if (cbo_TenKhoi.SelectedIndex == -1)
            {
                MessageBox.Show("Dữ liệu tên khối không hợp lệ.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_TenKhoi.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidComboBox_Lop()
        {
            if (cbo_TenLop.SelectedIndex == -1)
            {
                MessageBox.Show("Dữ liệu tên lớp không hợp lệ.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_TenLop.Focus();
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
                txt_TTTimKiem.Focus();
                return false;
            }

            return true;
        }
    }
}
