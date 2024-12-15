using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UNGDUNGQUANLYDIEMHOCSINH.Models;

namespace UNGDUNGQUANLYDIEMHOCSINH
{
    public partial class frmQuenMatKhau : Form
    {
        QL_DiemDataContext data = new QL_DiemDataContext();

        public frmQuenMatKhau()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmDangNhap frm = new frmDangNhap();
            this.Hide();
            frm.ShowDialog();
            frm = null;
            this.Show();
        }

        private void btn_ChangePassword_Click(object sender, EventArgs e)
        {
            var conn = data.Logins;

            try
            {
                var tk = txt_tk.Text.Trim();
                var mkMoi = txt_mk.Text.Trim();
                var mkXN = txt_xn.Text.Trim();
                var sdt = txt_sdt.Text.Trim();

                if (!IsValidTaiKhoan(tk))
                {
                    return;
                }

                if (!IsValidMatKhau(mkMoi))
                {
                    return;
                }

                if (!IsValidMatKhauXacNhan(mkXN))
                {
                    return;
                }

                if (!IsValidSDT(sdt))
                {
                    return;
                }

                var admin = conn.FirstOrDefault(a => a.TaiKhoan == tk && a.sdt == sdt);

                if (admin != null)
                {

                    if (mkMoi == mkXN)
                    {
                        admin.MatKhau = mkMoi;
                        data.SubmitChanges();

                        MessageBox.Show("Mật khẩu đã được cập nhật thành công!", "Thông báo",
                                         MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadForm(new frmDangNhap());
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu mới và xác nhận không khớp!", "Thông báo",
                                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại hoặc số điện thoại chưa đúng!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối hoặc cập nhật mật khẩu: ", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadForm(Form frm)
        {
            this.Hide();
            frm.ShowDialog();
            frm = null;
            this.Show();
        }

        private void txt_sdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool IsValidTaiKhoan(string taiKhoan)
        {
            if (string.IsNullOrEmpty(taiKhoan))
            {
                MessageBox.Show("Vui lòng nhập tài khoản.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txt_tk.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidMatKhau(string matKhau)
        {
            if (string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txt_mk.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidMatKhauXacNhan(string matKhau)
        {
            if (string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu xác nhận.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txt_xn.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidSDT(string sdt)
        {
            if (string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txt_sdt.Focus();
                return false;
            }

            if (sdt.Length > 10)
            {
                MessageBox.Show("Độ dài số điện thoại vượt quá giới hạn.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }
            return true;
        }

        private void frmQuenMatKhau_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
