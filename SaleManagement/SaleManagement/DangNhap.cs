using SaleManagement.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaleManagement
{
    public partial class DangNhap : Form
    {
        db_sale_managementEntities db = new db_sale_managementEntities();

        public static nhan_vien USER_LOGIN = null;

        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            login();
        }

        public void login()
        {
            if (txtTaiKhoan.Text.Length <= 0 || txtMatKhau.Text.Length <= 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            string username = txtTaiKhoan.Text;
            string password = Encryptor.MD5Hash(txtMatKhau.Text);
            USER_LOGIN = db.nhan_vien.SingleOrDefault(x => x.tai_khoan.Equals(username) &&
                x.mat_khau.Equals(password) && x.trang_thai == true);
            if (USER_LOGIN == null)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            else
            {
                this.Hide();
                QuanLy form = new QuanLy();
                form.Show();
            }
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                login();
            }
        }

        private void txtTaiKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }
    }
}
