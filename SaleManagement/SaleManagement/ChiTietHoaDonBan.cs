﻿using System;
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
    public partial class ChiTietHoaDonBan : Form
    {
        db_sale_managementEntities db = new db_sale_managementEntities();

        public static hoa_don_ban selectedSaleInvoice = null;

        public ChiTietHoaDonBan()
        {
            InitializeComponent();
        }

        public void load()
        {
            selectedSaleInvoice = QuanLy.selectedSaleInvoice;
            dgvDetail.DataSource = db.chi_tiet_hoa_don_ban.Where(x => x.ma_hoa_don == selectedSaleInvoice.ma_hoa_don).ToList();
            lblTitle.Text = "Mã hóa đơn: " + selectedSaleInvoice.ma_hoa_don;

            cbProduct.DataSource = db.san_pham.ToList();
            cbProduct.DisplayMember = "ten_san_pham";
            cbProduct.ValueMember = "ma_san_pham";

            cbProduct.Enabled = false;
            txtQuantity.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ChiTietHoaDonBan_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<chi_tiet_hoa_don_ban> listDetail = db.chi_tiet_hoa_don_ban.Where(x => x.ma_hoa_don == selectedSaleInvoice.ma_hoa_don).ToList();
            List<int> listProductId = new List<int>();
            foreach (chi_tiet_hoa_don_ban item in listDetail)
            {
                listProductId.Add(item.ma_san_pham);
            }
            List<san_pham> list = db.san_pham.Where(x => !listProductId.Contains(x.ma_san_pham)).ToList();
            if (list.Count > 0)
            {
                cbProduct.DataSource = list;
                cbProduct.DisplayMember = "ten_san_pham";
                cbProduct.ValueMember = "ma_san_pham";
            } 
            else
            {
                cbProduct.Text = null;
            }
            txtQuantity.Text = null;
            cbProduct.Enabled = true;
            txtQuantity.Enabled = true;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int quantity = txtQuantity.Value;
                if (quantity <= 0)
                {
                    MessageBox.Show("Số lượng phải là số nguyên dương!", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Yêu cầu nhập đúng định dạng của thông tin!", "Thông báo", MessageBoxButtons.OK);
            }
            try
            {
                san_pham product = db.san_pham.Find(int.Parse(cbProduct.SelectedValue.ToString()));
                if (txtQuantity.Value > product.so_luong)
                {
                    MessageBox.Show("Số lượng sản phẩm không đủ!", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                //Thêm chi tiết hóa đơn
                chi_tiet_hoa_don_ban entity = new chi_tiet_hoa_don_ban();
                entity.ma_hoa_don = selectedSaleInvoice.ma_hoa_don;
                entity.ma_san_pham = product.ma_san_pham;
                entity.so_luong = txtQuantity.Value;
                entity.don_gia = product.gia_san_pham;
                entity.thanh_tien = entity.so_luong * entity.don_gia;
                db.chi_tiet_hoa_don_ban.Add(entity);
                db.SaveChanges();
                //Cập nhật số lượng sản phẩm
                product.so_luong -= entity.so_luong;
                product.tinh_trang = (product.so_luong > 0) ? true : false;
                db.SaveChanges();
                //Cập nhật tổng tiền của hóa đơn
                hoa_don_ban saleInvoice = db.hoa_don_ban.Find(selectedSaleInvoice.ma_hoa_don);
                List<chi_tiet_hoa_don_ban> listDetail = db.chi_tiet_hoa_don_ban.Where(x => x.ma_hoa_don == selectedSaleInvoice.ma_hoa_don).ToList();
                double sum = 0;
                foreach (chi_tiet_hoa_don_ban item in listDetail)
                {
                    sum += item.thanh_tien;
                }
                saleInvoice.tong_tien = sum;
                db.SaveChanges();
                load();
            }
            catch (Exception)
            {
                MessageBox.Show("Sản phẩm không tồn tại hoặc đã có trong hóa đơn!", "Thông báo", MessageBoxButtons.OK);
            }
            
            
        }

        private void dgvDetail_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                load();
                cbProduct.SelectedValue = dgvDetail.Rows[e.RowIndex].Cells[1].Value;
                txtQuantity.Text = dgvDetail.Rows[e.RowIndex].Cells[2].Value.ToString();
                btnDelete.Enabled = true;
                btnSave.Enabled = false;
                cbProduct.Enabled = false;
                txtQuantity.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Click chuột sai vị trí", "Lỗi", MessageBoxButtons.OK);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            san_pham product = db.san_pham.Find(int.Parse(cbProduct.SelectedValue.ToString()));
            chi_tiet_hoa_don_ban entity = db.chi_tiet_hoa_don_ban.SingleOrDefault(x => x.ma_hoa_don == selectedSaleInvoice.ma_hoa_don && x.ma_san_pham == product.ma_san_pham);
            db.chi_tiet_hoa_don_ban.Remove(entity);
            db.SaveChanges();
            //Cập nhật tổng tiền của hóa đơn
            hoa_don_ban saleInvoice = db.hoa_don_ban.Find(selectedSaleInvoice.ma_hoa_don);
            List<chi_tiet_hoa_don_ban> listDetail = db.chi_tiet_hoa_don_ban.Where(x => x.ma_hoa_don == selectedSaleInvoice.ma_hoa_don).ToList();
            double sum = 0;
            foreach (chi_tiet_hoa_don_ban item in listDetail)
            {
                sum += item.thanh_tien;
            }
            saleInvoice.tong_tien = sum;
            db.SaveChanges();
            MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
            load();
        }

        private void dgvDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvDetail.Columns[e.ColumnIndex].Name == "ma_san_pham")
            {
                if (e.Value != null)
                {
                    san_pham product = db.san_pham.Find(e.Value);
                    e.Value = product.ten_san_pham;
                }
            }
        }

    }
}
