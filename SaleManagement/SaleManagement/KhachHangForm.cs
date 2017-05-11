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
    public partial class KhachHangForm : Form
    {
        db_sale_managementEntities db = new db_sale_managementEntities();

        public khach_hang selectedCustomer = QuanLy.selectedCustomer;
        public KhachHangForm()
        {
            InitializeComponent();

            if (selectedCustomer != null)
            {
                txtHoten.Text = selectedCustomer.ho_ten;
                txtDiaChi.Text = selectedCustomer.dia_chi;
                txtSoDienThoai.Text = selectedCustomer.so_dien_thoai;
                dtNgaySinh.Value = selectedCustomer.ngay_sinh;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtHoten.Text.Length <= 0 || txtDiaChi.Text.Length <= 0)
            {
                MessageBox.Show("Yêu cầu nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            try
            {
                double phone_number = double.Parse(txtSoDienThoai.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Số điện thoại phải là số!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (selectedCustomer == null)
            {
                khach_hang entity = new khach_hang();
                entity.ho_ten = txtHoten.Text;
                entity.ngay_sinh = dtNgaySinh.Value;
                entity.dia_chi = txtDiaChi.Text;
                entity.so_dien_thoai = txtSoDienThoai.Text;
                db.khach_hang.Add(entity);
                db.SaveChanges();
                MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                khach_hang entity = db.khach_hang.Find(selectedCustomer.ma_khach_hang);
                entity.ho_ten = txtHoten.Text;
                entity.ngay_sinh = dtNgaySinh.Value;
                entity.dia_chi = txtDiaChi.Text;
                entity.so_dien_thoai = txtSoDienThoai.Text;
                db.SaveChanges();
                MessageBox.Show("Chỉnh sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            this.Hide();
        }
    }
}
