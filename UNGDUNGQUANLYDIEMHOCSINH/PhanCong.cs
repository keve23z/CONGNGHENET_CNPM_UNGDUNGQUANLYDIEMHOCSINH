using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UNGDUNGQUANLYDIEMHOCSINH
{
    public partial class PhanCong : UserControl
    {
        private string connectionString = Config.ConnectionString;

        public PhanCong()
        {
            InitializeComponent();
        }

        // Sự kiện khi form được tải
        private void PhanCong_Load(object sender, EventArgs e)
        {
            LoadData();  // Tải dữ liệu vào DataGridView
            LoadComboBoxData();  // Tải dữ liệu vào các ComboBox
            LoadKieuTimKiem();  // Tải kiểu tìm kiếm vào ComboBox
        }

        // Hàm tải dữ liệu vào DataGridView
        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM PhanCong";  // Truy vấn lấy tất cả dữ liệu từ bảng PhanCong
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;  // Gán dữ liệu vào DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);  // Hiển thị thông báo lỗi nếu có
            }
        }

        // Hàm tải dữ liệu vào các ComboBox
        private void LoadComboBoxData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Tải dữ liệu vào ComboBox Mã Phân Công
                    string queryPhanCong = "SELECT MaPhanCong FROM PhanCong";
                    SqlDataAdapter adapterPC = new SqlDataAdapter(queryPhanCong, conn);
                    DataTable dtPC = new DataTable();
                    adapterPC.Fill(dtPC);
                    cmb_MaPhanCong.DataSource = dtPC;
                    cmb_MaPhanCong.DisplayMember = "MaPhanCong";

                    // Tải dữ liệu vào ComboBox Mã Giáo Viên
                    string queryGiaoVien = "SELECT MaGiaoVien FROM GiaoVien";
                    SqlDataAdapter adapterGV = new SqlDataAdapter(queryGiaoVien, conn);
                    DataTable dtGV = new DataTable();
                    adapterGV.Fill(dtGV);
                    cmb_MaGV.DataSource = dtGV;
                    cmb_MaGV.DisplayMember = "MaGiaoVien";

                    // Tải dữ liệu vào ComboBox Mã Lớp
                    string queryLop = "SELECT MaLop FROM Lop";
                    SqlDataAdapter adapterLop = new SqlDataAdapter(queryLop, conn);
                    DataTable dtLop = new DataTable();
                    adapterLop.Fill(dtLop);
                    cmb_MaLop.DataSource = dtLop;
                    cmb_MaLop.DisplayMember = "MaLop";

                    // Tải dữ liệu vào ComboBox Mã Môn Học
                    string queryMonHoc = "SELECT MaMonHoc FROM MonHoc";
                    SqlDataAdapter adapterMH = new SqlDataAdapter(queryMonHoc, conn);
                    DataTable dtMH = new DataTable();
                    adapterMH.Fill(dtMH);
                    cmb_MaMH.DataSource = dtMH;
                    cmb_MaMH.DisplayMember = "MaMonHoc";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu combobox: " + ex.Message);  // Hiển thị thông báo lỗi nếu có
            }
        }

        // Hàm tải kiểu tìm kiếm vào ComboBox
        private void LoadKieuTimKiem()
        {
            cmb_KieuTimKiem.Items.Clear();  // Xóa các mục cũ trong ComboBox
            cmb_KieuTimKiem.Items.Add("Mã Giáo Viên");  // Thêm mục tìm kiếm theo Mã Giáo Viên
            cmb_KieuTimKiem.Items.Add("Mã Lớp");  // Thêm mục tìm kiếm theo Mã Lớp
            cmb_KieuTimKiem.Items.Add("Mã Môn Học");  // Thêm mục tìm kiếm theo Mã Môn Học
            cmb_KieuTimKiem.SelectedIndex = 0;  // Chọn mặc định là "Mã Giáo Viên"
        }

        // Sự kiện thêm mới dữ liệu vào bảng PhanCong
        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO PhanCong (MaPhanCong, MaGiaoVien, MaLop, MaMonHoc) VALUES (@MaPhanCong, @MaGiaoVien, @MaLop, @MaMonHoc)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaPhanCong", cmb_MaPhanCong.Text);
                    cmd.Parameters.AddWithValue("@MaGiaoVien", cmb_MaGV.Text);
                    cmd.Parameters.AddWithValue("@MaLop", cmb_MaLop.Text);
                    cmd.Parameters.AddWithValue("@MaMonHoc", cmb_MaMH.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();  // Thực thi câu lệnh SQL để thêm dữ liệu
                    MessageBox.Show("Thêm mới thành công!");  // Hiển thị thông báo thành công
                    LoadData();  // Tải lại dữ liệu sau khi thêm
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm mới: " + ex.Message);  // Hiển thị thông báo lỗi nếu có
            }
        }

        // Sự kiện xóa dữ liệu khỏi bảng PhanCong
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM PhanCong WHERE MaPhanCong = @MaPhanCong";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaPhanCong", cmb_MaPhanCong.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();  // Thực thi câu lệnh SQL để xóa dữ liệu
                    MessageBox.Show("Xóa thành công!");  // Hiển thị thông báo thành công
                    LoadData();  // Tải lại dữ liệu sau khi xóa
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);  // Hiển thị thông báo lỗi nếu có
            }
        }

        // Sự kiện sửa dữ liệu trong bảng PhanCong
        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE PhanCong SET MaGiaoVien = @MaGiaoVien, MaLop = @MaLop, MaMonHoc = @MaMonHoc WHERE MaPhanCong = @MaPhanCong";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaPhanCong", cmb_MaPhanCong.Text);
                    cmd.Parameters.AddWithValue("@MaGiaoVien", cmb_MaGV.Text);
                    cmd.Parameters.AddWithValue("@MaLop", cmb_MaLop.Text);
                    cmd.Parameters.AddWithValue("@MaMonHoc", cmb_MaMH.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();  // Thực thi câu lệnh SQL để sửa dữ liệu
                    MessageBox.Show("Cập nhật thành công!");  // Hiển thị thông báo thành công
                    LoadData();  // Tải lại dữ liệu sau khi cập nhật
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);  // Hiển thị thông báo lỗi nếu có
            }
        }

        // Sự kiện làm mới các ComboBox
        private void button1_Click(object sender, EventArgs e)
        {
            cmb_MaPhanCong.SelectedIndex = -1;
            cmb_MaGV.SelectedIndex = -1;
            cmb_MaLop.SelectedIndex = -1;
            cmb_MaMH.SelectedIndex = -1;
            cmb_MaPhanCong.Focus();  // Đưa con trỏ vào ComboBox Mã Phân Công
        }

        // Sự kiện tìm kiếm dữ liệu
        private void btn_TK_Click(object sender, EventArgs e)
        {
            try
            {
                string kieuTimKiem = cmb_KieuTimKiem.Text;
                string thongTinTimKiem = cmb_ThongTInTImKIem.Text;

                // Kiểm tra điều kiện đầu vào
                if (string.IsNullOrEmpty(kieuTimKiem) || string.IsNullOrEmpty(thongTinTimKiem))
                {
                    MessageBox.Show("Vui lòng chọn kiểu tìm kiếm và nhập thông tin tìm kiếm.");
                    return;
                }

                string columnName = "";
                switch (kieuTimKiem)
                {
                    case "Mã Giáo Viên":
                        columnName = "MaGiaoVien";
                        break;
                    case "Mã Lớp":
                        columnName = "MaLop";
                        break;
                    case "Mã Môn Học":
                        columnName = "MaMonHoc";
                        break;
                    default:
                        MessageBox.Show("Kiểu tìm kiếm không hợp lệ.");
                        return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = $"SELECT * FROM PhanCong WHERE {columnName} = @ThongTinTimKiem";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@ThongTinTimKiem", thongTinTimKiem);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dt;  // Hiển thị kết quả tìm kiếm trong DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy kết quả phù hợp.");  // Thông báo không tìm thấy kết quả
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);  // Hiển thị thông báo lỗi nếu có
            }
        }

        // Sự kiện khi người dùng click vào một dòng trong DataGridView
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                cmb_MaPhanCong.Text = row.Cells["MaPhanCong"].Value.ToString();
                cmb_MaGV.Text = row.Cells["MaGiaoVien"].Value.ToString();
                cmb_MaLop.Text = row.Cells["MaLop"].Value.ToString();
                cmb_MaMH.Text = row.Cells["MaMonHoc"].Value.ToString();
            }
        }

        // Sự kiện khi chọn kiểu tìm kiếm trong ComboBox
        private void cmb_KieuTimKiem_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string kieuTimKiem = cmb_KieuTimKiem.Text;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "";

                switch (kieuTimKiem)
                {
                    case "Mã Giáo Viên":
                        query = "SELECT DISTINCT MaGiaoVien FROM PhanCong";
                        break;
                    case "Mã Lớp":
                        query = "SELECT DISTINCT MaLop FROM PhanCong";
                        break;
                    case "Mã Môn Học":
                        query = "SELECT DISTINCT MaMonHoc FROM PhanCong";
                        break;
                }

                if (!string.IsNullOrEmpty(query))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmb_ThongTInTImKIem.DataSource = dt;
                    cmb_ThongTInTImKIem.DisplayMember = dt.Columns[0].ColumnName;
                }
            }
        }
    }
}
