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
using System.IO;
namespace UNGDUNGQUANLYDIEMHOCSINH
{
    public partial class QuanLyGiaoVien : UserControl
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        public QuanLyGiaoVien()
        {
            InitializeComponent();
        }
        public void LoadData1()
        {
            try
            {
                // Mở kết nối
                conn.Open();

                // Query để lấy dữ liệu cho DataGridView
                string query = @"
                        SELECT 
                            GIAOVIEN.MaGiaoVien, 
                            GIAOVIEN.HoTen, 
                            GIAOVIEN.NgaySinh, 
                            GIAOVIEN.GioiTinh, 
                            GIAOVIEN.DiaChi, 
                            GIAOVIEN.SoDienThoai, 
                            GIAOVIEN.ChucVu, 
                            GIAOVIEN.MaMonHoc,
                            MONHOC.TenMonHoc
                        FROM 
                            GIAOVIEN
                        LEFT JOIN 
                            MONHOC 
                        ON 
                            GIAOVIEN.MaMonHoc = MONHOC.MaMonHoc";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Gán dữ liệu vào DataGridView
                dataGridView1.DataSource = dt;

                // Thêm sự kiện định dạng ngày
                dataGridView1.CellFormatting += (sender, e) =>
                {
                    if (dataGridView1.Columns[e.ColumnIndex].Name == "NgaySinh" && e.Value != null)
                    {
                        DateTime dateValue;
                        if (DateTime.TryParse(e.Value.ToString(), out dateValue))
                        {
                            e.Value = dateValue.ToString("dd-MM-yyyy");
                            e.FormattingApplied = true;
                        }
                    }
                };

                // Ẩn cột MaMonHoc nếu không cần thiết
                if (dataGridView1.Columns.Contains("MaMonHoc"))
                {
                    dataGridView1.Columns["MaMonHoc"].Visible = false;
                }
                if (dataGridView1.Columns.Contains("ChucVu"))
                {
                    dataGridView1.Columns["ChucVu"].Visible = false; 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                // Đảm bảo đóng kết nối
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private DataTable originalDataTable;
        public void LoadData4(string MaGV)
        {
            try
            {
                conn.Open();

                string query = @"
            SELECT 
                Lop.TenLop, 
                MonHoc.TenMonHoc 
            FROM 
                PhanCong
            JOIN Lop ON PhanCong.MaLop = Lop.MaLop
            JOIN MonHoc ON MonHoc.MaMonHoc = PhanCong.MaMonHoc
            WHERE 
                PhanCong.MaGiaoVien = @MaGiaoVien";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaGiaoVien", MaGV);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Lưu bảng gốc
                originalDataTable = dt;

                dataGridView2.DataSource = dt;

                if (dataGridView2.Columns.Contains("TenLop"))
                {
                    dataGridView2.Columns["TenLop"].Width = 100;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public void LoadData3()
        {
            try
            {
                // Mở kết nối
                conn.Open();
                // Truy vấn dữ liệu cho ComboBox
                string query1 = "SELECT DISTINCT TenMonHoc FROM MonHoc"; // Cần xác định bảng chứa 'TenMonHoc'
                SqlCommand cmd1 = new SqlCommand(query1, conn);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);

                // Đổ dữ liệu vào ComboBox
                cbo_NienKhoa.Items.Clear(); // Đảm bảo không lặp lại dữ liệu
                foreach (DataRow dr in dt1.Rows)
                {
                    cbo_NienKhoa.Items.Add(dr["TenMonHoc"].ToString());
                }

                cbo_NienKhoa.Items.Add("ALL");
                string query2 = "SELECT DISTINCT MaMonHoc, TenMonHoc FROM MonHoc";
                SqlCommand cmd2 = new SqlCommand(query2, conn);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);

                // Bind ComboBox with MaMonHoc and TenMonHoc
                comboBox3.Items.Clear(); // Ensure no duplicate items
                comboBox3.DisplayMember = "TenMonHoc";  // What to display in the combo box
                comboBox3.ValueMember = "MaMonHoc";    // The value that will be used (MaMonHoc)

                // Populate the ComboBox with the data from the DataTable
                comboBox3.DataSource = dt2;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                // Đảm bảo đóng kết nối
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public void LoadData2()
        {
            cb_GioiTinh.Items.Add("Nam");
            cb_GioiTinh.Items.Add("Nữ");
            comboBox2.Items.Add("GV");
            comboBox2.Items.Add("Trưởng");
            cbo_KTK.Items.Add("ALL");
            cbo_KTK.Items.Add("Mã Giáo Viên");
            cbo_KTK.Items.Add("Họ Tên");
            cbo_KTK.Items.Add("Môn Học");
            cbo_KTK.Items.Add("Giới Tính");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {

                int i = dataGridView1.CurrentRow.Index;

                txt_MaGV.Text = dataGridView1.Rows[i].Cells[0].Value.ToString().Trim();
                textBox1.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();

                dt_NgaySinh.Value = DateTime.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());

                cb_GioiTinh.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                txt_DiaChi.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                textBox2.Text = dataGridView1.Rows[i].Cells[5].Value.ToString().Trim();

                comboBox3.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
                LoadData4(txt_MaGV.Text);

            }
        }

        private void QuanLyGiaoVien_Load(object sender, EventArgs e)
        {
            LoadData1();
            LoadData2();
            LoadData3();
        }

        private void cbo_NienKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cbo_NienKhoa.Text) || cbo_NienKhoa.Text == "ALL")
                {
                    LoadData4(txt_MaGV.Text);
                    return;
                }

                if (originalDataTable != null)
                {
                    // Lấy giá trị được chọn trong ComboBox
                    string selectedNienKhoa = cbo_NienKhoa.Text;

                    // Lọc dữ liệu
                    DataView dataView = new DataView(originalDataTable);
                    dataView.RowFilter = $"TenMonHoc = '{selectedNienKhoa}'";

                    // Gán lại dữ liệu đã lọc vào DataGridView
                    dataGridView2.DataSource = dataView;
                }
                else
                {
                    MessageBox.Show("Dữ liệu gốc không tồn tại. Vui lòng tải lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private bool checkNgaySinh(string ngaySinh)
        {
            // lơn hơn 18 tuổi
            DateTime now = DateTime.Now;
            DateTime date = DateTime.Parse(ngaySinh);
            if (now.Year - date.Year < 18)
            {
                return false;
            }
            return true;
        }
        private bool checkSoDienThoai(string sdt)
        {
            if (sdt[0] != '0')
            {
                return false;
            }
            if (sdt.Length != 10 && sdt.Length != 11)
            {
                return false;
            }
            return true;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (txt_MaGV.Text == "" || textBox1.Text == "" || cb_GioiTinh.Text == "" || txt_DiaChi.Text == "" || comboBox3.Text == "" || textBox2.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            if (checkSoDienThoai(textBox2.Text) == false)
            {
                MessageBox.Show("Số điện thoại không hợp lệ");
                return;
            }

            // Kiểm tra tuổi của giáo viên
            if (!checkNgaySinh(dt_NgaySinh.Value.ToString("yyyy-MM-dd")))
            {
                MessageBox.Show("Giáo viên phải lớn hơn 18 tuổi");
                return;
            }

            try
            {
                conn.Open();

                // Kiểm tra mã giáo viên đã tồn tại trong bảng GIAOVIEN
                SqlCommand cmdCheck = new SqlCommand("SELECT COUNT(*) FROM GIAOVIEN WHERE MaGiaoVien = @MaGiaoVien", conn);
                cmdCheck.Parameters.AddWithValue("@MaGiaoVien", txt_MaGV.Text);

                int count = (int)cmdCheck.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Mã giáo viên đã tồn tại");
                    return;
                }

                // Thêm mới giáo viên vào bảng GIAOVIEN
                string query = @"
        INSERT INTO GIAOVIEN (MaGiaoVien, HoTen, NgaySinh, GioiTinh, DiaChi, SoDienThoai, ChucVu, MaMonHoc) 
        VALUES (@MaGiaoVien, @HoTen, @NgaySinh, @GioiTinh, @DiaChi, @SoDienThoai, @ChucVu, @MaMonHoc)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaGiaoVien", txt_MaGV.Text);
                cmd.Parameters.AddWithValue("@HoTen", textBox1.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dt_NgaySinh.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@GioiTinh", cb_GioiTinh.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txt_DiaChi.Text);
                cmd.Parameters.AddWithValue("@SoDienThoai", textBox2.Text);
                cmd.Parameters.AddWithValue("@ChucVu", comboBox2.Text);
                cmd.Parameters.AddWithValue("@MaMonHoc", comboBox3.SelectedValue); // Assuming comboBox3 is bound to MaMonHoc

                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm giáo viên thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            // Sau khi thêm thành công, load lại dữ liệu vào DataGridView
            CLEAR();
            LoadData1();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open(); // Open the connection

                string teacherName = textBox1.Text;
                DialogResult dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa giáo viên {teacherName}?", "Xóa giáo viên", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    string query = "DELETE FROM GIAOVIEN WHERE MaGiaoVien = @MaGiaoVien";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaGiaoVien", txt_MaGV.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa giáo viên thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy giáo viên để xóa.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle error
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            CLEAR();
            LoadData1();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string query = @"
            UPDATE GIAOVIEN 
            SET 
                HoTen = @HoTen, 
                NgaySinh = @NgaySinh, 
                GioiTinh = @GioiTinh, 
                DiaChi = @DiaChi, 
                SoDienThoai = @SoDienThoai, 
                ChucVu = @ChucVu, 
                MaMonHoc = @MaMonHoc 
            WHERE 
                MaGiaoVien = @MaGiaoVien";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@MaGiaoVien", txt_MaGV.Text);
                cmd.Parameters.AddWithValue("@HoTen", textBox1.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dt_NgaySinh.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@GioiTinh", cb_GioiTinh.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txt_DiaChi.Text);
                cmd.Parameters.AddWithValue("@SoDienThoai", textBox2.Text);
                cmd.Parameters.AddWithValue("@ChucVu", comboBox2.Text);
                cmd.Parameters.AddWithValue("@MaMonHoc", comboBox3.SelectedValue);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật giáo viên thành công!");

                }
                else
                {
                    MessageBox.Show("Không tìm thấy giáo viên để sửa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            CLEAR();
            LoadData1();
        }
        private void CLEAR()
        {
            txt_MaGV.Text = "";
            textBox1.Text = "";
            dt_NgaySinh.Value = DateTime.Now;
            cb_GioiTinh.SelectedIndex = -1;
            txt_DiaChi.Text = "";
            textBox2.Text = "";
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            cbo_KTK.SelectedIndex = -1;
            cb_TT.SelectedIndex = -1;
        }
        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            CLEAR();
            dataGridView2.DataSource = null;
        }
        private void cbo_KTK_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = string.Empty;
            cb_TT.Items.Clear();
            cb_TT.Text = null;
            // Xác định câu truy vấn dựa trên giá trị được chọn
            switch (cbo_KTK.Text)
            {
                case "Mã Giáo Viên":
                    query = "SELECT DISTINCT MaGiaoVien FROM GiaoVien";
                    break;

                case "Họ Tên":
                    query = "SELECT DISTINCT HoTen FROM GiaoVien";
                    break;

                case "Môn Học":
                    query = "SELECT DISTINCT TenMonHoc FROM MonHoc";
                    break;

                case "Giới Tính":
                    cb_TT.Items.Add("Nam");
                    cb_TT.Items.Add("Nữ");
                    break;

                default:
                    cb_TT.Items.Clear();
                    return;
            }

            if (!string.IsNullOrEmpty(query))
            {

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            foreach (DataRow dr in dt.Rows)
                            {
                                cb_TT.Items.Add(dr[0].ToString());
                            }
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }

            // Thêm tùy chọn "ALL"
            cb_TT.Items.Add("ALL");
        }

        private void btn_TK_Click(object sender, EventArgs e)


        {
            try
            {
                // Lấy tiêu chí tìm kiếm và giá trị tìm kiếm
                string criteria = cbo_KTK.Text.Trim();
                string searchValue = cb_TT.Text.Trim();

                // Khởi tạo câu truy vấn cơ bản
                string query = @"
            SELECT 
                GIAOVIEN.MaGiaoVien, 
                GIAOVIEN.HoTen, 
                GIAOVIEN.NgaySinh, 
                GIAOVIEN.GioiTinh, 
                GIAOVIEN.DiaChi, 
                GIAOVIEN.SoDienThoai, 
                GIAOVIEN.ChucVu, 
                GIAOVIEN.MaMonHoc,
                MONHOC.TenMonHoc
            FROM 
                GIAOVIEN
            LEFT JOIN 
                MONHOC 
            ON 
                GIAOVIEN.MaMonHoc = MONHOC.MaMonHoc";

                // Kiểm tra điều kiện "ALL"
                if (string.Equals(criteria, "ALL", StringComparison.OrdinalIgnoreCase) &&
                    string.IsNullOrEmpty(searchValue))
                {
                    // Không thêm điều kiện, hiển thị toàn bộ dữ liệu
                }
                else if (!string.IsNullOrEmpty(criteria) && !string.Equals(searchValue, "ALL", StringComparison.OrdinalIgnoreCase))
                {
                    // Thêm điều kiện tìm kiếm dựa trên tiêu chí
                    switch (criteria)
                    {
                        case "Mã Giáo Viên":
                            query += " WHERE GIAOVIEN.MaGiaoVien = @SearchValue";
                            break;

                        case "Họ Tên":
                            query += " WHERE GIAOVIEN.HoTen LIKE @SearchValue";
                            searchValue = "%" + searchValue + "%"; // Tìm kiếm gần đúng
                            break;

                        case "Môn Học":
                            query += " WHERE MONHOC.TenMonHoc = @SearchValue";
                            break;

                        case "Giới Tính":
                            query += " WHERE GIAOVIEN.GioiTinh = @SearchValue";
                            break;

                        default:
                            MessageBox.Show("Vui lòng chọn tiêu chí tìm kiếm hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                    }
                }

                // Mở kết nối và thực hiện truy vấn
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(searchValue) && !string.Equals(criteria, "ALL", StringComparison.OrdinalIgnoreCase))
                    {
                        cmd.Parameters.AddWithValue("@SearchValue", searchValue);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Gán dữ liệu vào DataGridView
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
