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
    public partial class ThemNhaCungCap : Form
    {
        db_sale_managementEntities db = new db_sale_managementEntities();
        public ThemNhaCungCap()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtTenNCC.Text.Length <= 0 || txtDiaChi.Text.Length <= 0)
            {
                MessageBox.Show("Yêu cầu nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            try
            {
                double phone_number = double.Parse(txtDienThoai.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Số điện thoại phải là số!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            nha_cung_cap entity = new nha_cung_cap();
            entity.ten_nha_cung_cap = txtTenNCC.Text;
            entity.dia_chi = txtDiaChi.Text;
            entity.so_dien_thoai = txtDienThoai.Text;
            db.nha_cung_cap.Add(entity);
            db.SaveChanges();
            MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
            this.Hide();
        }
    }
}
