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

    public partial class QuanLyPhuHuynh : UserControl
    {
        private DBConnect db;
        private bool _isAdding = false;

        public QuanLyPhuHuynh()
        {
            InitializeComponent();
        }


        private void QuanLyPhuHuynh_Load(object sender, EventArgs e)
        {
            db = new DBConnect(Config.ConnectionString);

            LoadComboBox_TimKiem();

            LoadDataGridView_PhuHuynh();

            DisableInfoControls();

            SelectFirstRowDataGridView(dgv_DanhSachPH);

            dgv_DanhSachPH.ReadOnly = true;
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
            txt_MaPH.Focus();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xoá phụ huynh này không?", "Thông báo",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                                  MessageBoxDefaultButton.Button2);

            if (result == DialogResult.No)
            {
                return;
            }

            DeletePhuHuynh();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            btn_Save.Enabled = true;
            btn_Cancel.Enabled = true;

            btn_Add.Enabled = btn_Delete.Enabled = btn_Update.Enabled = false;

            EnableInfoControls();

            txt_MaPH.Enabled = false;

            _isAdding = false;

            txt_TenPH.Focus();
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

            var result = MessageBox.Show($"Bạn có muốn {action} phụ huynh?", "Thông báo",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.No)
            {
                return;
            }

            if (_isAdding)
            {
                AddPhuHuynh();
                return;
            }

            UpdatePhuHuynh();
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
            LoadDataGridView_PhuHuynh();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string keyword = txt_NhapThongTinTimKiem.Text.Trim();

            if (!IsValidSearchValue(keyword))
            {
                return;
            }

            string searchColumn = GetSearchColumn();

            string strSQL = @"SELECT MaPH, HoTenPH, SoDienThoai, DiaChi
                              FROM " + Config.PHUHUYNH_TABLE + @" 
                              WHERE " + searchColumn + " LIKE @Keyword";

            if (db.DataSet.Tables.Contains(Config.PHUHUYNH_TABLE))
            {
                db.DataSet.Tables[Config.PHUHUYNH_TABLE].Clear();
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

            dgv_DanhSachPH.DataSource = dtSearchResult;

            LoadDataGridViewColumn_PhuHuynh();

            if (dtSearchResult.Rows.Count <= 0)
            {
                MessageBox.Show("Không tìm thấy kết quả phù hợp.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                dgv_DanhSachPH.DataSource = null;
            }
            else
            {
                SelectFirstRowDataGridView(dgv_DanhSachPH);
            }
        }


        private void txt_SDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void dgv_DanhSachPH_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_DanhSachPH.SelectedRows.Count > 0)
            {
                DataGridViewRow currentRow = dgv_DanhSachPH.CurrentRow;

                DataBindingDanhSachPhuHuynh(currentRow);
            }
        }

        private void dgv_DanhSachPH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgv_DanhSachPH.Rows[e.RowIndex] != null)
            {
                DataGridViewRow selectedRow = dgv_DanhSachPH.Rows[e.RowIndex];

                DataBindingDanhSachPhuHuynh(selectedRow);
            }
        }


        private void LoadDataGridView_PhuHuynh()
        {
            string strSQL = @"SELECT MaPH, HoTenPH, SoDienThoai, DiaChi
                              FROM " + Config.PHUHUYNH_TABLE;

            dgv_DanhSachPH.DataSource = null;

            if (db.DataSet.Tables.Contains(Config.PHUHUYNH_TABLE))
            {
                db.DataSet.Tables[Config.PHUHUYNH_TABLE].Clear();
            }

            DataTable dt = db.GetDataTable(strSQL, Config.PHUHUYNH_TABLE);
            dgv_DanhSachPH.DataSource = dt;

            LoadDataGridViewColumn_PhuHuynh();
        }

        private void LoadDataGridViewColumn_PhuHuynh()
        {
            dgv_DanhSachPH.Columns.Clear();

            dgv_DanhSachPH.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã Phụ Huynh",
                Name = "MaPH",
                DataPropertyName = "MaPH",
                Width = 180
            });

            dgv_DanhSachPH.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Họ Tên",
                Name = "HoTenPH",
                DataPropertyName = "HoTenPH",
                Width = 200
            });

            dgv_DanhSachPH.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Số Điện Thoại",
                Name = "SoDienThoai",
                DataPropertyName = "SoDienThoai",
                Width = 180
            });

            dgv_DanhSachPH.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Địa Chỉ",
                Name = "DiaChi",
                DataPropertyName = "DiaChi",
                Width = 220
            });
        }

        private void DataBindingDanhSachPhuHuynh(DataGridViewRow row)
        {
            txt_MaPH.Text = row.Cells["MaPH"].Value.ToString();
            txt_TenPH.Text = row.Cells["HoTenPH"].Value.ToString();
            txt_SDT.Text = row.Cells["SoDienThoai"].Value.ToString();
            txt_DiaChi.Text = row.Cells["DiaChi"].Value.ToString();

            if (!_isAdding)
            {
                btn_Delete.Enabled = btn_Update.Enabled = true;
            }
        }

        private void LoadComboBox_TimKiem()
        {
            string[] searchOptions = new string[]
            {
                "Mã phụ huynh",
                "Tên phụ huynh"
            };

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


        private void AddPhuHuynh()
        {
            string strMaPH = txt_MaPH.Text.Trim();

            if (!IsValidMaPH(strMaPH))
            {
                return;
            }

            string strTenPH = txt_TenPH.Text.Trim();

            if (!IsValidTenPH(strTenPH))
            {
                return;
            }

            string strSDT = txt_SDT.Text.Trim();

            if (!IsValidSDT(strSDT))
            {
                return;
            }

            string strDiaChi = txt_DiaChi.Text.Trim();

            if (!IsValidDiaChi(strDiaChi))
            {
                return;
            }

            if (string.IsNullOrEmpty(strDiaChi))
            {
                strDiaChi = null;
            }

            try
            {
                if (db.CheckExist(Config.PHUHUYNH_TABLE, "MaPH", strMaPH))
                {
                    MessageBox.Show("Mã phụ huynh này đã tồn tại.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string strSQL = "INSERT INTO " + Config.PHUHUYNH_TABLE +
                                " (MaPH, HoTenPH, SoDienThoai, DiaChi) VALUES " +
                                " ('" + strMaPH + "', N'" + strTenPH + "', '" + strSDT + "', N'" + strDiaChi +
                                "')";

                db.UpdateToDataBase(strSQL);

                MessageBox.Show("Thêm thành công.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDataGridView_PhuHuynh();

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

        private void DeletePhuHuynh()
        {
            string strMaPH = txt_MaPH.Text.Trim();

            try
            {
                if (db.CheckExist(Config.HOCSINH_TABLE, "MaPH", strMaPH))
                {
                    MessageBox.Show($"Mã phụ huynh này đã tồn tại trên bảng {Config.HOCSINH_TABLE} nên không thể xoá được.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (!db.CheckExist(Config.PHUHUYNH_TABLE, "MaPH", strMaPH))
                {
                    MessageBox.Show("Phụ huynh này chưa tồn tại.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string strSQL = "DELETE FROM " + Config.PHUHUYNH_TABLE +
                                " WHERE MaPH = '" + strMaPH + "'";

                db.UpdateToDataBase(strSQL);

                MessageBox.Show("Xoá thành công.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDataGridView_PhuHuynh();
                DisableInfoControls();

                btn_Delete.Enabled = false;
                btn_Update.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Xoá thất bại.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePhuHuynh()
        {
            string strTenPH = txt_TenPH.Text.Trim();

            if (!IsValidTenPH(strTenPH))
            {
                return;
            }

            string strSDT = txt_SDT.Text.Trim();

            if (!IsValidSDT(strSDT))
            {
                return;
            }

            string strDiaChi = txt_DiaChi.Text.Trim();

            if (!IsValidDiaChi(strDiaChi))
            {
                return;
            }

            if (string.IsNullOrEmpty(strDiaChi))
            {
                strDiaChi = null;
            }

            string strMaPH = txt_MaPH.Text;

            try
            {
                if (!db.CheckExist(Config.PHUHUYNH_TABLE, "MaPH", strMaPH))
                {
                    MessageBox.Show("Phụ huynh này chưa tồn tại.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string strSQL = "UPDATE " + Config.PHUHUYNH_TABLE + " " +
                                "SET HoTenPH = N'" + strTenPH + "', " +
                                "    SoDienThoai = '" + strSDT + "', " +
                                "    DiaChi = N'" + strDiaChi + "' " +
                                "WHERE MaPH = " + strMaPH;

                db.UpdateToDataBase(strSQL);

                MessageBox.Show("Cập nhật thành công.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDataGridView_PhuHuynh();

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
            return cbo_KieuTimKiem.SelectedItem.ToString() == "Mã phụ huynh" ? "MaPH" : "HoTenPH";
        }


        private void EnableInfoControls()
        {
            txt_MaPH.Enabled = txt_TenPH.Enabled = txt_SDT.Enabled = txt_DiaChi.Enabled = true;
        }

        private void DisableInfoControls()
        {
            txt_MaPH.Enabled = txt_TenPH.Enabled = txt_SDT.Enabled = txt_DiaChi.Enabled = false;
        }

        private void ClearInfoControls()
        {
            txt_MaPH.Clear();
            txt_TenPH.Clear();
            txt_SDT.Clear();
            txt_DiaChi.Clear();
        }


        private bool IsValidMaPH(string maPH)
        {
            if (maPH == "")
            {
                MessageBox.Show("Vui lòng nhập mã phụ huynh.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_MaPH.Focus();
                return false;
            }

            if (maPH.Length > 10)
            {
                MessageBox.Show("Độ dài mã phụ huynh vượt quá giới hạn.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_MaPH.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidTenPH(string tenPH)
        {
            if (tenPH == "")
            {
                MessageBox.Show("Vui lòng nhập tên phụ huynh.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_TenPH.Focus();
                return false;
            }

            if (tenPH.Length > 30)
            {
                MessageBox.Show("Độ dài tên phụ huynh vượt quá giới hạn.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_TenPH.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidSDT(string sdt)
        {
            if (sdt == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_SDT.Focus();
                return false;
            }

            if (!int.TryParse(sdt, out int result))
            {
                MessageBox.Show("Dữ liệu nhập số điện thoại phải là số.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_SDT.Focus();
                return false;
            }

            if (sdt.Length > 12)
            {
                MessageBox.Show("Độ dài số điện thoại vượt quá giới hạn.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_SDT.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidDiaChi(string diaChi)
        {
            if (diaChi.Length > 50)
            {
                MessageBox.Show("Độ dài địa chỉ vượt quá giới hạn.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_DiaChi.Focus();
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
