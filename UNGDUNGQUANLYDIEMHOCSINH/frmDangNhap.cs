using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UNGDUNGQUANLYDIEMHOCSINH.Models;

namespace UNGDUNGQUANLYDIEMHOCSINH
{
    public partial class frmDangNhap : Form
    {
        QL_DiemDataContext data = new QL_DiemDataContext();

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txt_mk.PasswordChar = '\0';
            }
            else
            {
                txt_mk.PasswordChar = '●';
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var conn = data.Logins;

            try
            {
                var tk = txt_tk.Text.Trim();
                var mk = txt_mk.Text.Trim();

                if (!IsValidTaiKhoan(tk))
                {
                    return;
                }

                if (!IsValidMatKhau(mk))
                {
                    return;
                }

                var admin = conn.FirstOrDefault(a => a.TaiKhoan == tk && a.MatKhau == mk);


                if (admin != null)
                {
                    LoadForm(new frm_Home());
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Thông báo",
                                     MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_ChangePassword_Click(object sender, EventArgs e)
        {
            LoadForm(new frmDoiMatKhau());
        }

        private void btn_ForgotPassword_Click(object sender, EventArgs e)
        {
            LoadForm(new frmQuenMatKhau());
        }

        private void LoadForm(Form frm)
        {
            this.Hide();
            frm.ShowDialog();
            frm = null;
            this.Show();
        }

        private void frmDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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
    }
}
