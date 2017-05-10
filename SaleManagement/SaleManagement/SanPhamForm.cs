using SaleManagement.Utils;
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
    public partial class SanPhamForm : Form
    {
        db_sale_managementEntities db = new db_sale_managementEntities();

        public san_pham selectedProduct = QuanLy.selectedProduct;

        public bool actionView = QuanLy.actionView;
        public SanPhamForm()
        {
            InitializeComponent();

            loadForm();
            if (selectedProduct != null)
            {
                if (actionView)
                {
                    enableForm(false);
                    btnSubmit.Visible = false;
                }
                txtTenSanPham.Text = selectedProduct.ten_san_pham;
                txtGiaSP.Text = selectedProduct.gia_san_pham.ToString();
                txtSoLuong.Text = selectedProduct.so_luong.ToString();
                txtDonViTinh.Text = selectedProduct.don_vi_tinh;
                txtThongSoKT.Text = selectedProduct.thong_so_ky_thuat;
                cbTinhTrang.SelectedValue = (selectedProduct.tinh_trang == true) ? 1 : 0;
                cbLoaiSanPham.SelectedValue = selectedProduct.ma_loai_san_pham;
            }
        }

        public void enableForm(bool bl)
        {
            txtTenSanPham.Enabled = bl;
            txtGiaSP.Enabled = bl;
            txtDonViTinh.Enabled = bl;
            txtThongSoKT.Enabled = bl;
            cbLoaiSanPham.Enabled = bl;
        }

        public void loadForm()
        {
            cbTinhTrang.Enabled = false;
            txtSoLuong.Enabled = false;
            List<ComboboxUtils> listStatus = new List<ComboboxUtils>()
            {
                new ComboboxUtils(0, "Hết hàng"),
                new ComboboxUtils(1, "Còn hàng")
                
            };
            ComboboxUtils status = new ComboboxUtils();
            cbTinhTrang.DataSource = listStatus;
            cbTinhTrang.DisplayMember = "text";
            cbTinhTrang.ValueMember = "value";

            List<loai_san_pham> list = db.loai_san_pham.ToList();
            cbLoaiSanPham.DataSource = list;
            cbLoaiSanPham.DisplayMember = "ten_loai_san_pham";
            cbLoaiSanPham.ValueMember = "ma_loai_san_pham";

            selectedProduct = (selectedProduct != null) ? new db_sale_managementEntities().san_pham.Find(selectedProduct.ma_san_pham) : null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtTenSanPham.Text.Length <= 0 || txtDonViTinh.Text.Length <= 0 ||
                txtThongSoKT.Text.Length <= 0)
            {
                MessageBox.Show("Yêu cầu nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            try
            {
                double price = double.Parse(txtGiaSP.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Số điện thoại phải là số!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (selectedProduct == null)
            {
                san_pham entity = new san_pham();
                entity.ten_san_pham = txtTenSanPham.Text;
                entity.gia_san_pham = double.Parse(txtGiaSP.Text);
                entity.so_luong = 0;
                entity.don_vi_tinh = txtDonViTinh.Text;
                entity.thong_so_ky_thuat = txtThongSoKT.Text;
                entity.tinh_trang = false;
                entity.ma_loai_san_pham = int.Parse(cbLoaiSanPham.SelectedValue.ToString());
                db.san_pham.Add(entity);
                db.SaveChanges();
                MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                san_pham entity = db.san_pham.Find(selectedProduct.ma_san_pham);
                entity.ten_san_pham = txtTenSanPham.Text;
                entity.gia_san_pham = double.Parse(txtGiaSP.Text);
                entity.don_vi_tinh = txtDonViTinh.Text;
                entity.thong_so_ky_thuat = txtThongSoKT.Text;
                entity.ma_loai_san_pham = int.Parse(cbLoaiSanPham.SelectedValue.ToString());
                db.SaveChanges();
                MessageBox.Show("Chỉnh sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            this.Hide();
        }

    }
}
