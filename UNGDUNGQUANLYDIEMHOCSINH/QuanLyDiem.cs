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
    using UNGDUNGQUANLYDIEMHOCSINH.Models;

    public partial class QuanLyDiem : UserControl
    {
        public QuanLyDiem()
        {
            InitializeComponent();
        }

        QL_DiemDataContext data;

        private void QuanLyDiem_Load(object sender, EventArgs e)
        {
            data = new QL_DiemDataContext();
            var quyry = from d in data.Diems
                        join a in data.HocSinhs on d.MaHocSinh equals a.MaHocSinh
                        join b in data.Lops on a.MaLop equals b.MaLop
                        join c in data.Khois on b.MaKhoi equals c.MaKhoi
                        join nk in data.NienKhoas on d.MaNienKhoa equals nk.MaNienKhoa
                        join mon in data.MonHocs on d.MaMonHoc equals mon.MaMonHoc


                        select new
                        {
                            Mã_Học_Sinh = a.MaHocSinh,
                            Tên_học_sinh = a.HoTen,
                            Tên_lớp = b.TenLop,
                            Tên_khối = c.TenKhoi,
                            Niên_khóa = nk.TenNienKhoa,
                            Học_kì = d.HocKy,
                            MaMonHoc = d.MaMonHoc,
                            Tên_môn = mon.TenMonHoc,
                            Điểm_GK = d.DiemGiuaKy,
                            Điểm_CK = d.DiemCuoiKy,

                        };
            dataDanhSachSV.DataSource = quyry.ToList();
            dataDanhSachSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            cbo_NienKhoa.DataSource = data.NienKhoas;
            cbo_NienKhoa.DisplayMember = "TenNienKhoa";
            cbo_NienKhoa.ValueMember = "MaNienKhoa";



            cbo_tenmon.DataSource = data.MonHocs;
            cbo_tenmon.DisplayMember = "TenMonHoc";
            cbo_tenmon.ValueMember = "MaMonHoc";

            cbo_TenLop.Enabled = false;
            cbo_TenKhoi.Enabled = false;
            txt_TenHS.Enabled = false;

            cbo_ten.DataSource = data.HocSinhs.ToList();
            cbo_ten.DisplayMember = "HoTen";
            cbo_ten.ValueMember = "MaHocSinh";


            cbo_lop.DataSource = data.Lops.ToList();
            cbo_lop.DisplayMember = "TenLop";
            cbo_lop.ValueMember = "MaLop";


        }

        private void dataDanhSachSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataDanhSachSV.Rows[e.RowIndex];
            txt_diemck.Text = row.Cells["Điểm_CK"].Value.ToString();

            txt_MaHS.Text = row.Cells["Mã_Học_Sinh"].Value.ToString();
            txt_TenHS.Text = row.Cells["Tên_học_sinh"].Value.ToString();
            txt_diemgk.Text = row.Cells["Điểm_GK"].Value.ToString();

            cbo_TenLop.Text = row.Cells["Tên_lớp"].Value.ToString();
            cbo_TenKhoi.Text = row.Cells["Tên_khối"].Value.ToString();
            cbo_NienKhoa.Text = row.Cells["Niên_khóa"].Value.ToString();
            cbo_tenmon.Text = row.Cells["Tên_môn"].Value.ToString();

            if (row.Cells["Học_kì"].Value.ToString() == "1")
            {
                radioButton1.Checked = true;
            }
            else if (row.Cells["Học_kì"].Value.ToString() == "2")
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                Diem m = new Diem();

                m.MaHocSinh = txt_MaHS.Text.ToString();

                var a = (from ass in data.MonHocs
                         where ass.TenMonHoc == cbo_tenmon.Text
                         select ass.MaMonHoc).FirstOrDefault();
                m.MaMonHoc = a;

                var b = (from ass in data.NienKhoas
                         where ass.TenNienKhoa == cbo_NienKhoa.Text
                         select ass.MaNienKhoa).FirstOrDefault();
                m.MaNienKhoa = b;

                if (radioButton1.Checked)
                {
                    m.HocKy = 1;
                }
                else if (radioButton2.Checked)
                {
                    m.HocKy = 2;
                }

                m.DiemGiuaKy = Convert.ToSingle(txt_diemgk.Text.ToString());
                m.DiemCuoiKy = Convert.ToSingle(txt_diemck.Text.ToString());
                m.DiemTB = Convert.ToSingle(txt_diemgk.Text.ToString()) * 0.3
                            + Convert.ToSingle(txt_diemck.Text.ToString()) * 0.7;



                data.Diems.InsertOnSubmit(m);
                data.SubmitChanges();

                MessageBox.Show("Nhập điểm thành công");
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm Thất Bại");
            }
            finally
            {
                var qlpb = data.Diems;
                dataDanhSachSV.DataSource = qlpb;
                QuanLyDiem_Load(sender, e);
            }

        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataDanhSachSV.CurrentRow != null)
                {

                    string maHocSinh = dataDanhSachSV.CurrentRow.Cells["Mã_Học_Sinh"].Value.ToString();
                    string maMonHoc = dataDanhSachSV.CurrentRow.Cells["MaMonHoc"].Value.ToString(); // Đảm bảo sử dụng đúng tên cột
                    int hocKy = Convert.ToInt32(dataDanhSachSV.CurrentRow.Cells["Học_kì"].Value);
                    string maNienKhoa = (from nk in data.NienKhoas
                                         where nk.TenNienKhoa == cbo_NienKhoa.Text
                                         select nk.MaNienKhoa).FirstOrDefault();

                    var m = data.Diems.SingleOrDefault(d => d.MaHocSinh == maHocSinh &&
                                                             d.MaMonHoc == maMonHoc &&
                                                             d.HocKy == hocKy &&
                                                             d.MaNienKhoa == maNienKhoa);
                    if (m != null)
                    {

                        m.DiemGiuaKy = Convert.ToSingle(txt_diemgk.Text);
                        m.DiemCuoiKy = Convert.ToSingle(txt_diemck.Text);
                        m.DiemTB = m.DiemGiuaKy * 0.3f + m.DiemCuoiKy * 0.7f;

                        data.SubmitChanges();
                        MessageBox.Show("Cập nhật điểm thành công");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy điểm để cập nhật");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật thất bại: " + ex.Message);
            }
            finally
            {
                QuanLyDiem_Load(sender, e);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataDanhSachSV.CurrentRow != null)
                {
                    string maHocSinh = dataDanhSachSV.CurrentRow.Cells["Mã_Học_Sinh"].Value.ToString();
                    string maMonHoc = (from g in data.MonHocs
                                       where g.TenMonHoc == cbo_tenmon.Text
                                       select g.MaMonHoc).FirstOrDefault();
                    int hocKy = Convert.ToInt32(dataDanhSachSV.CurrentRow.Cells["Học_kì"].Value);
                    string maNienKhoa = (from nk in data.NienKhoas
                                         where nk.TenNienKhoa == cbo_NienKhoa.Text
                                         select nk.MaNienKhoa).FirstOrDefault();

                    var diemToDelete = data.Diems.SingleOrDefault(d => d.MaHocSinh == maHocSinh &&
                                                                      d.MaMonHoc == maMonHoc &&
                                                                      d.HocKy == hocKy &&
                                                                      d.MaNienKhoa == maNienKhoa);

                    if (diemToDelete != null)
                    {
                        data.Diems.DeleteOnSubmit(diemToDelete);
                        data.SubmitChanges();
                        MessageBox.Show("Xóa điểm thành công");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy điểm để xóa");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thất bại: " + ex.Message);
            }
            finally
            {
                QuanLyDiem_Load(sender, e);
            }
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {

            txt_MaHS.Clear();
            txt_TenHS.Clear();
            txt_diemgk.Clear();
            txt_diemck.Clear();


            cbo_TenLop.SelectedIndex = -1;
            cbo_TenKhoi.SelectedIndex = -1;
            cbo_NienKhoa.SelectedIndex = -1;
            cbo_tenmon.SelectedIndex = -1;


            radioButton1.Checked = false;
            radioButton2.Checked = false;


            QuanLyDiem_Load(sender, e);
        }

        private void btn_TK_Click(object sender, EventArgs e)
        {
            try
            {

                string maHocSinh = cbo_ten.SelectedValue?.ToString();
                string maLop = cbo_lop.SelectedValue?.ToString();


                var query = from d in data.Diems
                            join a in data.HocSinhs on d.MaHocSinh equals a.MaHocSinh
                            join b in data.Lops on a.MaLop equals b.MaLop
                            where (string.IsNullOrEmpty(maHocSinh) || a.MaHocSinh == maHocSinh) &&
                                  (string.IsNullOrEmpty(maLop) || b.MaLop == maLop)
                            select new
                            {
                                Mã_Học_Sinh = a.MaHocSinh,
                                Tên_học_sinh = a.HoTen,
                                Tên_lớp = b.TenLop,
                                Tên_khối = (from c in data.Khois where c.MaKhoi == b.MaKhoi select c.TenKhoi).FirstOrDefault(),
                                Niên_khóa = (from nk in data.NienKhoas where nk.MaNienKhoa == d.MaNienKhoa select nk.TenNienKhoa).FirstOrDefault(),
                                Học_kì = d.HocKy,
                                Tên_môn = (from mon in data.MonHocs where mon.MaMonHoc == d.MaMonHoc select mon.TenMonHoc).FirstOrDefault(),
                                Điểm_GK = d.DiemGiuaKy,
                                Điểm_CK = d.DiemCuoiKy,
                            };


                dataDanhSachSV.DataSource = query.ToList();
                dataDanhSachSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (!query.Any())
                {
                    MessageBox.Show("Không tìm thấy kết quả nào.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tìm kiếm thất bại: " + ex.Message);
            }
        }
    }
}
