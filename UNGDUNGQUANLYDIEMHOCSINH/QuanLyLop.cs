using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNGDUNGQUANLYDIEMHOCSINH
{
    using System.Data.SqlClient;
    using UNGDUNGQUANLYDIEMHOCSINH.Services;

    public partial class QuanLyLop : UserControl
    {
        private DBConnect db;
        private bool _isAdding = false;

        public QuanLyLop()
        {
            InitializeComponent();
        }


        private void QuanLyLop_Load(object sender, EventArgs e)
        {
            db = new DBConnect(Config.ConnectionString);

            LoadComboBox_Khoi();
            LoadComboBox_NienKhoa();
            LoadComboBox_TimKiem();

            LoadDataGridView_Lop();

            DisableInfoControls();

            SelectFirstRowDataGridView(dgv_DanhSachLop);

            dgv_DanhSachLop.ReadOnly = true;
            btn_Delete.Enabled = btn_Update.Enabled = btn_Save.Enabled = btn_Cancel.Enabled = false;
        }


        private void btn_Add_Click(object sender, EventArgs e)
        {
            btn_Save.Enabled = true;
            btn_Cancel.Enabled = true;

            btn_Add.Enabled = btn_Delete.Enabled = btn_Update.Enabled = false;

            EnableInfoControls();

            _isAdding = true;

            ClearInfoControls();

            txt_MaLop.Focus();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xoá lớp này không?", "Thông báo",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                                  MessageBoxDefaultButton.Button2);

            if (result == DialogResult.No)
            {
                return;
            }

            DeleteLop();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            btn_Save.Enabled = true;
            btn_Cancel.Enabled = true;

            btn_Add.Enabled = btn_Delete.Enabled = btn_Update.Enabled = false;

            EnableInfoControls();

            txt_MaLop.Enabled = false;

            _isAdding = false;

            txt_TenLop.Focus();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string action = "";

            if (_isAdding)
            {
                action = "thêm";
            }
            else
            {
                action = "cập nhật";
            }

            var result = MessageBox.Show($"Bạn có muốn {action} lớp?", "Thông báo",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.No)
            {
                return;
            }

            if (_isAdding)
            {
                AddLop();
                return;
            }

            UpdateLop();
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

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            LoadDataGridView_Lop();
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
                        l.MaLop, 
                        l.TenLop, 
                        k.MaKhoi, 
                        nk.MaNienKhoa,
                        k.TenKhoi,
                        nk.TenNienKhoa
                    FROM {Config.LOP_TABLE} l
                    JOIN {Config.KHOI_TABLE} k ON k.MaKhoi = l.MaKhoi
                    JOIN {Config.NIENKHOA_TABLE} nk ON nk.MaNienKhoa = l.MaNienKhoa
                    WHERE " + searchColumn + " LIKE @Keyword";

            if (db.DataSet.Tables.Contains(Config.LOP_TABLE))
            {
                db.DataSet.Tables[Config.LOP_TABLE].Clear();
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

            dgv_DanhSachLop.DataSource = dtSearchResult;

            LoadDataGridViewColumnLop();

            if (dtSearchResult.Rows.Count <= 0)
            {
                MessageBox.Show("Không tìm thấy kết quả phù hợp.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                dgv_DanhSachLop.DataSource = null;
            }
            else
            {
                SelectFirstRowDataGridView(dgv_DanhSachLop);
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


        private void LoadDataGridView_Lop()
        {
            string strSQL = $@"
                    SELECT 
                        l.MaLop, 
                        l.TenLop, 
                        k.MaKhoi, 
                        nk.MaNienKhoa,
                        k.TenKhoi,
                        nk.TenNienKhoa
                    FROM {Config.LOP_TABLE} l
                    JOIN {Config.KHOI_TABLE} k ON k.MaKhoi = l.MaKhoi
                    JOIN {Config.NIENKHOA_TABLE} nk ON nk.MaNienKhoa = l.MaNienKhoa";

            dgv_DanhSachLop.DataSource = null;

            if (db.DataSet.Tables.Contains(Config.LOP_TABLE))
            {
                db.DataSet.Tables[Config.LOP_TABLE].Clear();
            }

            DataTable dt = db.GetDataTable(strSQL, Config.LOP_TABLE);
            dgv_DanhSachLop.DataSource = dt;

            LoadDataGridViewColumnLop();
        }

        private void LoadDataGridViewColumnLop()
        {
            dgv_DanhSachLop.Columns.Clear();

            dgv_DanhSachLop.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã Lớp",
                Name = "MaLop",
                DataPropertyName = "MaLop",
                Width = 140
            });

            dgv_DanhSachLop.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên Lớp",
                Name = "TenLop",
                DataPropertyName = "TenLop",
                Width = 240
            });

            dgv_DanhSachLop.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Khối",
                Name = "TenKhoi",
                DataPropertyName = "TenKhoi",
                Width = 160
            });

            dgv_DanhSachLop.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Niên Khoá",
                Name = "TenNienKhoa",
                DataPropertyName = "TenNienKhoa",
                Width = 200
            });

            dgv_DanhSachLop.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaKhoi",
                DataPropertyName = "MaKhoi",
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
            txt_MaLop.Text = row.Cells["MaLop"].Value.ToString();
            txt_TenLop.Text = row.Cells["TenLop"].Value.ToString();
            cbo_Khoi.Text = row.Cells["TenKhoi"].Value.ToString();
            cbo_NienKhoa.Text = row.Cells["TenNienKhoa"].Value.ToString();

            if (!_isAdding)
            {
                btn_Delete.Enabled = btn_Update.Enabled = true;
            }
        }

        private void LoadComboBox_Khoi()
        {
            string strSQL = $"SELECT * FROM {Config.KHOI_TABLE}";

            DataTable dt = db.GetDataTable(strSQL, Config.KHOI_TABLE);

            cbo_Khoi.Items.Clear();

            cbo_Khoi.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_Khoi.DataSource = dt;
            cbo_Khoi.DisplayMember = "TenKhoi";
            cbo_Khoi.ValueMember = "MaKhoi";

            if (dt.Rows.Count > 0)
            {
                cbo_Khoi.SelectedIndex = 0;
            }
        }

        private void LoadComboBox_NienKhoa()
        {
            string strSQL = $"SELECT * FROM {Config.NIENKHOA_TABLE}";

            DataTable dt = db.GetDataTable(strSQL, Config.NIENKHOA_TABLE);

            cbo_NienKhoa.Items.Clear();

            cbo_NienKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_NienKhoa.DataSource = dt;
            cbo_NienKhoa.DisplayMember = "TenNienKhoa";
            cbo_NienKhoa.ValueMember = "MaNienKhoa";

            if (dt.Rows.Count > 0)
            {
                cbo_NienKhoa.SelectedIndex = 0;
            }
        }

        private void LoadComboBox_TimKiem()
        {
            string[] searchOptions = new string[] { "Mã Lớp", "Tên Lớp" };

            cbo_KieuTimKiem.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_KieuTimKiem.DataSource = searchOptions;
            cbo_KieuTimKiem.SelectedIndex = 0;
        }

        private void SelectFirstRowDataGridView(DataGridView dgv)
        {
            if (dgv.Rows.Count > 0)
            {
                dgv.Rows[0].Selected = true;
            }
        }


        private void AddLop()
        {
            string strMaLop = txt_MaLop.Text.Trim();

            if (!IsValidMaLop(strMaLop))
            {
                return;
            }

            string strTenLop = txt_TenLop.Text.Trim();

            if (!IsValidTenLop(strTenLop))
            {
                return;
            }

            if (!IsValidComboBox_Khoi())
            {
                return;
            }

            if (!IsValidComboBox_NienKhoa())
            {
                return;
            }

            string strMaKhoi = cbo_Khoi.SelectedValue.ToString();

            string strMaNienKhoa = cbo_NienKhoa.SelectedValue.ToString();

            try
            {
                if (db.CheckExist(Config.LOP_TABLE, "MaLop", strMaLop))
                {
                    MessageBox.Show("Mã lớp này đã tồn tại.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    txt_MaLop.Clear();
                    txt_MaLop.Focus();
                    return;
                }

                if (!db.CheckExist(Config.KHOI_TABLE, "MaKhoi", strMaKhoi))
                {
                    MessageBox.Show("Mã khối này chưa tồn tại.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    cbo_Khoi.Focus();
                    return;
                }

                if (!db.CheckExist(Config.NIENKHOA_TABLE, "MaNienKhoa", strMaNienKhoa))
                {
                    MessageBox.Show("Mã niên khoá này chưa tồn tại.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    cbo_NienKhoa.Focus();
                    return;
                }

                string strSQL1 = $@"SELECT COUNT(*) 
                                    FROM Lop
                                    WHERE TenLop = N'{strTenLop}'
                                          AND MaNienKhoa = '{strMaNienKhoa}'";

                if (db.GetCount(strSQL1) > 0)
                {
                    MessageBox.Show("Tên lớp và niên khoá này đã tồn tại.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string strSQL2 = $@"INSERT INTO Lop (MaLop, TenLop, MaKhoi, MaNienKhoa)
                                   VALUES ('{strMaLop}', N'{strTenLop}', '{strMaKhoi}', '{strMaNienKhoa}')";

                db.UpdateToDataBase(strSQL2);

                MessageBox.Show("Thêm thành công.", "Thông báo",
                             MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDataGridView_Lop();

                DisableInfoControls();

                btn_Add.Enabled = true;
                _isAdding = false;
            }
            catch
            {
                MessageBox.Show("Thêm thất bại.", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteLop()
        {
            string strMaLop = txt_MaLop.Text.Trim();

            try
            {
                if (!db.CheckExist(Config.LOP_TABLE, "MaLop", strMaLop))
                {
                    MessageBox.Show("Mã lớp này chưa tồn tại.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (db.CheckExist(Config.HOCSINH_TABLE, "MaLop", strMaLop))
                {
                    MessageBox.Show($"Mã lớp này đã tồn tại trên bảng {Config.HOCSINH_TABLE} nên không thể xoá được.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (db.CheckExist(Config.PHANCONG_TABLE, "MaLop", strMaLop))
                {
                    MessageBox.Show($"Mã lớp này đã tồn tại trên bảng {Config.PHANCONG_TABLE} nên không thể xoá được.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string strSQL = "DELETE FROM " + Config.LOP_TABLE +
                                " WHERE MaLop = '" + strMaLop + "'";

                db.UpdateToDataBase(strSQL);

                MessageBox.Show("Xoá thành công.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDataGridView_Lop();
            }
            catch
            {
                MessageBox.Show("Xoá thất bại.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateLop()
        {
            string strTenLop = txt_TenLop.Text.Trim();

            if (!IsValidTenLop(strTenLop))
            {
                return;
            }

            if (!IsValidComboBox_Khoi())
            {
                return;
            }

            if (!IsValidComboBox_NienKhoa())
            {
                return;
            }

            string strMaKhoi = cbo_Khoi.SelectedValue.ToString();

            string strMaNienKhoa = cbo_NienKhoa.SelectedValue.ToString();

            string strMaLop = txt_MaLop.Text;

            try
            {
                if (!db.CheckExist(Config.LOP_TABLE, "MaLop", strMaLop))
                {
                    MessageBox.Show("Mã lớp này chưa tồn tại.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (!db.CheckExist(Config.KHOI_TABLE, "MaKhoi", strMaKhoi))
                {
                    MessageBox.Show("Mã khối này chưa tồn tại.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    cbo_Khoi.Focus();
                    return;
                }

                if (!db.CheckExist(Config.NIENKHOA_TABLE, "MaNienKhoa", strMaNienKhoa))
                {
                    MessageBox.Show("Mã niên khoá này chưa tồn tại.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    cbo_NienKhoa.Focus();
                    return;
                }


                string strSQL = $@"UPDATE {Config.LOP_TABLE} 
                                   SET TenLop = N'{strTenLop}', 
                                       MaKhoi = N'{strMaKhoi}', 
                                       MaNienKhoa = '{strMaNienKhoa}' 
                                   WHERE MaLop = '{strMaLop}'";

                db.UpdateToDataBase(strSQL);

                MessageBox.Show("Cập nhật thành công.", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDataGridView_Lop();

                DisableInfoControls();

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
            return cbo_KieuTimKiem.SelectedItem.ToString() == "Mã Lớp" ? "MaLop" : "TenLop";
        }


        private void EnableInfoControls()
        {
            txt_MaLop.Enabled = txt_TenLop.Enabled = true;

            cbo_Khoi.Enabled = cbo_NienKhoa.Enabled = true;
        }

        private void DisableInfoControls()
        {
            txt_MaLop.Enabled = txt_TenLop.Enabled = false;

            cbo_Khoi.Enabled = cbo_NienKhoa.Enabled = false;
        }

        private void ClearInfoControls()
        {
            txt_MaLop.Clear();
            txt_TenLop.Clear();

            if (cbo_Khoi.Items.Count > 0)
            {
                cbo_Khoi.SelectedIndex = 0;
            }

            if (cbo_NienKhoa.Items.Count > 0)
            {
                cbo_NienKhoa.SelectedIndex = 0;
            }
        }


        private bool IsValidMaLop(string maLop)
        {
            if (maLop == "")
            {
                MessageBox.Show("Vui lòng nhập mã lớp.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_MaLop.Focus();
                return false;
            }

            if (maLop.Length > 10)
            {
                MessageBox.Show("Độ dài mã lớp vượt quá giới hạn.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_MaLop.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidTenLop(string tenLop)
        {
            if (tenLop == "")
            {
                MessageBox.Show("Vui lòng nhập tên lớp.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_TenLop.Focus();
                return false;
            }

            if (tenLop.Length > 50)
            {
                MessageBox.Show("Độ dài tên lớp vượt quá giới hạn.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_TenLop.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidComboBox_Khoi()
        {
            if (cbo_Khoi.SelectedIndex == -1)
            {
                MessageBox.Show("Dữ liệu khối không hợp lệ.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_Khoi.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidComboBox_NienKhoa()
        {
            if (cbo_NienKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Dữ liệu niên khoá không hợp lệ.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_NienKhoa.Focus();
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

        private void txt_TenLop_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
