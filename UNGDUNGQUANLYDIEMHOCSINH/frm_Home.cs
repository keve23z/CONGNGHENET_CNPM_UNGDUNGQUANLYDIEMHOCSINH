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
    public partial class frm_Home : Form
    {
        public frm_Home()
        {
            InitializeComponent();
        }
        
        
        private void btn_QuanLyHS_Click(object sender, EventArgs e)
        {
            LoadUserControl(new QuanLyHocSinh());
        }

        private void btn_QuanLyGV_Click(object sender, EventArgs e)
        {
            LoadUserControl(new QuanLyGiaoVien());
        }


        private void btn_PhanCongGV_Click(object sender, EventArgs e)
        {
            LoadUserControl(new PhanCong());
        }

        private void btn_PhanCongLop_Click(object sender, EventArgs e)
        {
            LoadUserControl(new PhanCongLop());
        }

        private void btn_QuanLyLop_Click(object sender, EventArgs e)
        {
            LoadUserControl(new QuanLyLop());
        }

        private void btn_QuanLyDiem_Click(object sender, EventArgs e)
        {
            LoadUserControl(new QuanLyDiem());
        }

        private void btn_QuanLyPhuHuynh_Click(object sender, EventArgs e)
        {
            LoadUserControl(new QuanLyPhuHuynh());
        }


        private void LoadUserControl(UserControl userControl)
        {
            pn_bg3.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
            userControl.BringToFront();
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất tài khoản?", "Logout",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                     MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                frmDangNhap frm = new frmDangNhap();
                this.Hide();
                frm.ShowDialog();
                frm = null;
                this.Show();
            }
        }

        private void frm_Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
