﻿using System;
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
    public partial class frmDoiMatKhau : Form
    {
        QL_DiemDataContext data = new QL_DiemDataContext();

        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LoadForm(new frmDangNhap());
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
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
                    var strMatKhauMoi = txt_mkm.Text.Trim();

                    if (!IsValidMatKhauMoi(strMatKhauMoi))
                    {
                        return;
                    }

                    admin.MatKhau = strMatKhauMoi;
                    data.SubmitChanges();

                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadForm(new frmDangNhap());
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối!", "Thông báo",
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

        private bool IsValidMatKhauMoi(string matKhau)
        {
            if (string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu moi.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txt_mkm.Focus();
                return false;
            }

            return true;
        }

        private void frmDoiMatKhau_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
