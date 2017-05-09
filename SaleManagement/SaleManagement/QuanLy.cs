using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SaleManagement.Utils;
using SaleManagement.Common;
using System.IO;
using System.Data.Entity;

namespace SaleManagement
{
    public partial class QuanLy : Form
    {
        db_sale_managementEntities db = new db_sale_managementEntities();

        private static int check = 0;

        public static nhan_vien USER_LOGIN = DangNhap.USER_LOGIN;

        public static int nha_cung_cap_id = 0;

        public static khach_hang selectedCustomer = null;

        public static nhan_vien selectedStaff = null;

        public static san_pham selectedProduct = null;

        public static bool actionView = false;

        public static hoa_don_mua selectedBuyInvoice = null;

        public static hoa_don_ban selectedSaleInvoice = null;

        public QuanLy()
        {
            InitializeComponent();
        }

        private void loadLoaiSanPham()
        {
            btnThemDanhMuc.Enabled = false;
            if (USER_LOGIN.phan_quyen != 3)
            {
                btnThemDanhMuc.Enabled = true;
            }
            btnLuuDanhMuc.Enabled = false;
            btnXoaDanhMuc.Enabled = false;
            txtTenDanhMuc.Enabled = false;
            dgvDanhMuc.DataSource = db.loai_san_pham.ToList();
            dgvDanhMuc.Columns.Remove("san_pham");
        }

        public void loadNhaCungCap()
        {
            btnThemNCC.Enabled = false;
            if (USER_LOGIN.phan_quyen != 3)
            {
                btnThemNCC.Enabled = true;
            }
            btnXoaNCC.Enabled = false;
            dgvNhaCungCap.DataSource = db.nha_cung_cap.ToList();
            dgvNhaCungCap.Columns.Remove("hoa_don_mua");
        }

        public void loadKhachHang()
        {
            selectedCustomer = null;
            List<ActionForm> listAction = new List<ActionForm>()
            {
                new ActionForm("choose", "Chọn thao tác"),
                new ActionForm("create", "Thêm mới"),
                new ActionForm("update", "Sửa thông tin"),
                new ActionForm("delete", "Xóa khách hàng")
            };
            cbActionCustomer.DataSource = listAction;
            cbActionCustomer.DisplayMember = "action";
            cbActionCustomer.ValueMember = "key";
            dgvKhachHang.DataSource = new db_sale_managementEntities().khach_hang.ToList();
        }

        public void loadNhanVien()
        {
            selectedStaff = null;
            List<ActionForm> listAction = new List<ActionForm>()
            {
                new ActionForm("choose", "Chọn thao tác"),
                new ActionForm("create", "Thêm mới"),
                new ActionForm("update", "Sửa thông tin"),
                new ActionForm("delete", "Xóa nhân viên")
            };
            cbActionStaff.DataSource = listAction;
            cbActionStaff.DisplayMember = "action";
            cbActionStaff.ValueMember = "key";
            dgvNhanVien.DataSource = new db_sale_managementEntities().nhan_vien.ToList();
        }

        public void loadSanPham()
        {
            selectedProduct = null;
            actionView = false;
            List<ActionForm> listAction = new List<ActionForm>()
            {
                new ActionForm("choose", "Chọn thao tác"),
                new ActionForm("view", "Xem chi tiết"),
                new ActionForm("create", "Thêm sản phẩm"),
                new ActionForm("update", "Sửa thông tin"),
                new ActionForm("delete", "Xóa sản phẩm")
            };
            cbActionProduct.DataSource = listAction;
            cbActionProduct.DisplayMember = "action";
            cbActionProduct.ValueMember = "key";
            dgvSanPham.DataSource = new db_sale_managementEntities().san_pham.ToList();
        }

        public void loadBuyInvoice()
        {
            selectedBuyInvoice = null;
            List<ActionForm> listAction = new List<ActionForm>()
            {
                new ActionForm("choose", "Chọn thao tác"),
                new ActionForm("view", "Xem chi tiết"),
                new ActionForm("create", "Thêm hóa đơn"),
                new ActionForm("delete", "Xóa hóa đơn")
            };
            cbActionBuyInvoice.DataSource = listAction;
            cbActionBuyInvoice.DisplayMember = "action";
            cbActionBuyInvoice.ValueMember = "key";
            dgvHoaDonMua.DataSource = new db_sale_managementEntities().hoa_don_mua.ToList();

            List<nha_cung_cap> listSupplier = new db_sale_managementEntities().nha_cung_cap.ToList();
            cbNhaCungCap.DataSource = listSupplier;
            cbNhaCungCap.DisplayMember = "ten_nha_cung_cap";
            cbNhaCungCap.ValueMember = "ma_nha_cung_cap";
        }

        public void loadSaleInvoice()
        {
            selectedSaleInvoice = null;
            List<ActionForm> listAction = new List<ActionForm>()
            {
                new ActionForm("choose", "Chọn thao tác"),
                new ActionForm("view", "Xem chi tiết"),
                new ActionForm("create", "Thêm hóa đơn"),
                new ActionForm("delete", "Xóa hóa đơn")
            };
            cbActionSaleInvoice.DataSource = listAction;
            cbActionSaleInvoice.DisplayMember = "action";
            cbActionSaleInvoice.ValueMember = "key";
            dgvHoaDonBan.DataSource = new db_sale_managementEntities().hoa_don_ban.ToList();

            List<khach_hang> listCustomer = new db_sale_managementEntities().khach_hang.ToList();
            cbKhachHang.DataSource = listCustomer;
            cbKhachHang.DisplayMember = "ho_ten";
            cbKhachHang.ValueMember = "ma_khach_hang";

            List<nhan_vien> listStaff = new db_sale_managementEntities().nhan_vien.ToList();
            cbNhanVien.DataSource = listStaff;
            cbNhanVien.DisplayMember = "ho_ten";
            cbNhanVien.ValueMember = "ma_nhan_vien";
        }

        public void refresh()
        {
            loadLoaiSanPham();
            loadNhaCungCap();
            if(USER_LOGIN.phan_quyen < 3)
            {
                loadKhachHang();
                tabCustomer.Visible = true;
                loadSaleInvoice();
                tabInvoice.Visible = true;
            }
            if(USER_LOGIN.phan_quyen == 1)
            {
                loadNhanVien();
                tabStaff.Visible = true;
            }
            if (USER_LOGIN.phan_quyen == 1 || USER_LOGIN.phan_quyen == 4)
            {
                loadSanPham();
                tabProduct.Visible = true;
            }
            if (USER_LOGIN.phan_quyen == 1 || USER_LOGIN.phan_quyen == 3)
            {
                loadBuyInvoice();
                tabInvoice.Visible = true;
                tabStatistic.Visible = true;
            }
        }

        private void QuanLy_Load(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabHome;
            refresh();
            check = 1;
        }

        private void btnThemDanhMuc_Click(object sender, EventArgs e)
        {
            txtTenDanhMuc.Text = null;
            txtTenDanhMuc.Enabled = true;
            btnThemDanhMuc.Enabled = true;
            btnLuuDanhMuc.Enabled = true;
            btnXoaDanhMuc.Enabled = false;
        }

        private void btnLuuDanhMuc_Click(object sender, EventArgs e)
        {
            if (txtTenDanhMuc.Text.Length <= 0)
            {
                MessageBox.Show("Yêu cầu điền thông tin danh mục!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            List<loai_san_pham> list = db.loai_san_pham.ToList();
            foreach (loai_san_pham item in list)
            {
                if (item.ten_loai_san_pham.Equals(txtTenDanhMuc.Text))
                {
                    MessageBox.Show("Loại sản phẩm này đã tồn tại!", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
            }
            loai_san_pham entity = new loai_san_pham();
            entity.ten_loai_san_pham = txtTenDanhMuc.Text;
            db.loai_san_pham.Add(entity);
            db.SaveChanges();
            MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
            refresh();
        }

        private void dgvDanhMuc_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtTenDanhMuc.Text = dgvDanhMuc.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (USER_LOGIN.phan_quyen != 3)
                {
                    btnXoaDanhMuc.Enabled = true;
                }
                btnLuuDanhMuc.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Click chuột sai vị trí", "Lỗi", MessageBoxButtons.OK);
            }
        }

        private void btnXoaDanhMuc_Click(object sender, EventArgs e)
        {
            try
            {
                if (db.san_pham.Where(x => x.loai_san_pham.ten_loai_san_pham.Equals(txtTenDanhMuc.Text)).ToList().Count > 0)
                {
                    MessageBox.Show("Danh mục có sản phẩm, không thể xóa!", "Chúc mừng", MessageBoxButtons.OK);
                    return;
                }
                if (MessageBox.Show(null, "Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    loai_san_pham entity = new loai_san_pham();
                    entity = db.loai_san_pham.SingleOrDefault(x => x.ten_loai_san_pham.Equals(txtTenDanhMuc.Text));
                    db.loai_san_pham.Remove(entity);
                    db.SaveChanges();
                    refresh();
                    MessageBox.Show("Xóa dữ liệu thành công!", "Chúc mừng", MessageBoxButtons.OK);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK);
            }
        }

        private void dgvNhaCungCap_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (USER_LOGIN.phan_quyen != 3)
                {
                    btnXoaNCC.Enabled = true;
                }
                nha_cung_cap_id = int.Parse(dgvNhaCungCap.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Click chuột sai vị trí", "Lỗi", MessageBoxButtons.OK);
            }
        }

        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            try
            {
                if (db.hoa_don_mua.Where(x => x.ma_nha_cung_cap == nha_cung_cap_id).ToList().Count > 0)
                {
                    MessageBox.Show("Nhà cung cấp này liên quan đến nhiều dữ liệu khác, không thể xóa!", "Chúc mừng", MessageBoxButtons.OK);
                    return;
                }
                if (MessageBox.Show(null, "Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    nha_cung_cap entity = new nha_cung_cap();
                    entity = db.nha_cung_cap.SingleOrDefault(x => x.ma_nha_cung_cap == nha_cung_cap_id);
                    db.nha_cung_cap.Remove(entity);
                    db.SaveChanges();
                    refresh();
                    MessageBox.Show("Xóa dữ liệu thành công!", "Chúc mừng", MessageBoxButtons.OK);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK);
            }
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            ThemNhaCungCap x = new ThemNhaCungCap();
            x.ShowDialog(this);
            refresh();
        }

        private void cbActionCustomer_SelectedValueChanged(object sender, EventArgs e)
        {
            if (USER_LOGIN.phan_quyen > 2 && check == 1)
            {
                MessageBox.Show("Bạn không có quyền thực hiện thao tác này!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            string selectedAction = cbActionCustomer.SelectedValue.ToString();
            switch (selectedAction)
            {
                case "create":
                    selectedCustomer = null;
                    KhachHangForm form = new KhachHangForm();
                    form.ShowDialog(this);
                    refresh();
                    break;
                case "update":
                    if (selectedCustomer == null)
                    {
                        MessageBox.Show("Chọn bản ghi cần sửa!", "Thông báo", MessageBoxButtons.OK);
                        loadKhachHang();
                        return;
                    }
                    else
                    {
                        KhachHangForm x = new KhachHangForm();
                        x.ShowDialog(this);
                        refresh();
                    }
                    break;
                case "delete":
                    if (USER_LOGIN.phan_quyen != 1 && check == 1)
                    {
                        MessageBox.Show("Bạn không có quyền thực hiện thao tác này!", "Thông báo", MessageBoxButtons.OK);
                        break;
                    }
                    try
                    {
                        if (selectedCustomer == null)
                        {
                            MessageBox.Show("Chọn bản ghi cần xóa!", "Thông báo", MessageBoxButtons.OK);
                            refresh();
                            return;
                        }
                        else
                        {
                            if (db.hoa_don_ban.Where(x => x.ma_khach_hang == selectedCustomer.ma_khach_hang).ToList().Count > 0)
                            {
                                MessageBox.Show("Khách hàng này liên quan đến nhiều dữ liệu khác, không thể xóa!", "Chúc mừng", MessageBoxButtons.OK);
                                return;
                            }
                            if (MessageBox.Show(null, "Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {
                                db.khach_hang.Remove(selectedCustomer);
                                db.SaveChanges();
                                refresh();
                                MessageBox.Show("Xóa dữ liệu thành công!", "Chúc mừng", MessageBoxButtons.OK);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK);
                    }
                    break;
            }
        }

        private void dgvKhachHang_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                selectedCustomer = db.khach_hang.Find(dgvKhachHang.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception)
            {
                MessageBox.Show("Click chuột sai vị trí", "Lỗi", MessageBoxButtons.OK);
            }
        }

        private void cbActionStaff_SelectedValueChanged(object sender, EventArgs e)
        {
            if (USER_LOGIN.phan_quyen != 1 && check == 1)
            {
                MessageBox.Show("Bạn không có quyền thực hiện thao tác này!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            string selectedAction = cbActionStaff.SelectedValue.ToString();
            switch (selectedAction)
            {
                case "create":
                    selectedStaff = null;
                    NhanVienForm form = new NhanVienForm();
                    form.ShowDialog(this);
                    refresh();
                    break;
                case "update":
                    if (selectedStaff == null)
                    {
                        MessageBox.Show("Chọn bản ghi cần sửa!", "Thông báo", MessageBoxButtons.OK);
                        refresh();
                        return;
                    }
                    else
                    {
                        NhanVienForm x = new NhanVienForm();
                        x.ShowDialog(this);
                        refresh();
                    }
                    break;
                case "delete":
                    try
                    {
                        if (USER_LOGIN.ma_nhan_vien == selectedStaff.ma_nhan_vien)
                        {
                            MessageBox.Show("Không thể tự xóa chính mình!", "Thông báo", MessageBoxButtons.OK);
                            return;
                        }
                        if (selectedStaff == null)
                        {
                            MessageBox.Show("Chọn bản ghi cần xóa!", "Thông báo", MessageBoxButtons.OK);
                            refresh();
                            return;
                        }
                        else
                        {
                            if (db.hoa_don_ban.Where(x => x.ma_nhan_vien == selectedStaff.ma_nhan_vien).ToList().Count > 0)
                            {
                                MessageBox.Show("Nhân viên này liên quan đến nhiều dữ liệu khác, không thể xóa!", "Chúc mừng", MessageBoxButtons.OK);
                                return;
                            }
                            if (MessageBox.Show(null, "Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {
                                db.nhan_vien.Remove(selectedStaff);
                                db.SaveChanges();
                                refresh();
                                MessageBox.Show("Xóa dữ liệu thành công!", "Chúc mừng", MessageBoxButtons.OK);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK);
                    }
                    break;
            }
        }

        private void dgvNhanVien_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                selectedStaff = db.nhan_vien.Find(dgvNhanVien.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception)
            {
                MessageBox.Show("Click chuột sai vị trí", "Lỗi", MessageBoxButtons.OK);
            }
        }

        private void dgvNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvNhanVien.Columns[e.ColumnIndex].Name == "trang_thai")
            {
                if (e.Value != null)
                {
                    e.Value = ((bool)e.Value == true) ? "Bình thường" : "Đang khóa";
                }
            }
            if (this.dgvNhanVien.Columns[e.ColumnIndex].Name == "phan_quyen")
            {
                if (e.Value != null)
                {
                    if (e.Value.ToString().Equals("1"))
                        e.Value = "Admin";
                    if (e.Value.ToString().Equals("2"))
                        e.Value = "NV bán hàng";
                    if (e.Value.ToString().Equals("3"))
                        e.Value = "Kế toán";
                    if (e.Value.ToString().Equals("4"))
                        e.Value = "Thủ kho";
                }
            }
        }

        private void cbActionProduct_SelectedValueChanged(object sender, EventArgs e)
        {
            string selectedAction = cbActionProduct.SelectedValue.ToString();
            switch (selectedAction)
            {
                case "view":
                    if (selectedProduct == null)
                    {
                        MessageBox.Show("Chọn sản phẩm muốn xem chi tiết!", "Thông báo", MessageBoxButtons.OK);
                        refresh();
                        return;
                    }
                    else
                    {
                        actionView = true;
                        SanPhamForm xform = new SanPhamForm();
                        xform.ShowDialog(this);
                        refresh();
                    }
                    break;
                case "create":
                    if (USER_LOGIN.phan_quyen == 1 || USER_LOGIN.phan_quyen == 4)
                    {
                        selectedProduct = null;
                        SanPhamForm form = new SanPhamForm();
                        form.ShowDialog(this);
                        refresh();
                    }
                    else
                    {
                        MessageBox.Show("Bạn không có quyền thực hiện thao tác này!", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    break;
                case "update":
                    if (USER_LOGIN.phan_quyen == 1 || USER_LOGIN.phan_quyen == 4)
                    {
                        if (selectedProduct == null)
                        {
                            MessageBox.Show("Chọn bản ghi cần sửa!", "Thông báo", MessageBoxButtons.OK);
                            refresh();
                            return;
                        }
                        else
                        {
                            SanPhamForm x = new SanPhamForm();
                            x.ShowDialog(this);
                            refresh();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn không có quyền thực hiện thao tác này!", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    break;
                case "delete":
                    try
                    {
                        if (USER_LOGIN.phan_quyen == 1 || USER_LOGIN.phan_quyen == 4)
                        {
                            if (selectedProduct == null)
                            {
                                MessageBox.Show("Chọn bản ghi cần xóa!", "Thông báo", MessageBoxButtons.OK);
                                refresh();
                                return;
                            }
                            else
                            {
                                if (db.chi_tiet_hoa_don_ban.Where(x => x.ma_san_pham == selectedProduct.ma_san_pham).ToList().Count > 0 ||
                                    db.chi_tiet_hoa_don_mua.Where(x => x.ma_san_pham == selectedProduct.ma_san_pham).ToList().Count > 0)
                                {
                                    MessageBox.Show("Sản phẩm này liên quan đến nhiều dữ liệu khác, không thể xóa!", "Chúc mừng", MessageBoxButtons.OK);
                                    return;
                                }
                                if (MessageBox.Show(null, "Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    db.san_pham.Remove(selectedProduct);
                                    db.SaveChanges();
                                    refresh();
                                    MessageBox.Show("Xóa dữ liệu thành công!", "Chúc mừng", MessageBoxButtons.OK);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Bạn không có quyền thực hiện thao tác này!", "Thông báo", MessageBoxButtons.OK);
                            return;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK);
                    }
                    break;
            }
        }

        private void dgvSanPham_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                selectedProduct = db.san_pham.Find(dgvSanPham.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception)
            {
                MessageBox.Show("Click chuột sai vị trí", "Lỗi", MessageBoxButtons.OK);
            }
        }

        private void dgvSanPham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvSanPham.Columns[e.ColumnIndex].Name == "danh_muc")
            {
                if (e.Value != null)
                {
                    loai_san_pham category = db.loai_san_pham.Find(e.Value);
                    e.Value = category.ten_loai_san_pham;
                }
            }
            if (this.dgvSanPham.Columns[e.ColumnIndex].Name == "tinh_trang")
            {
                if (e.Value != null)
                {
                    e.Value = ((bool)e.Value == true) ? "Còn hàng" : "Hết hàng";
                }
            }
        }

        private void dgvHoaDonMua_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                selectedBuyInvoice = db.hoa_don_mua.Find(dgvHoaDonMua.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception)
            {
                MessageBox.Show("Click chuột sai vị trí", "Lỗi", MessageBoxButtons.OK);
            }
        }

        private void dgvHoaDonBan_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                selectedSaleInvoice = db.hoa_don_ban.Find(dgvHoaDonBan.Rows[e.RowIndex].Cells[0].Value);
            }
            catch (Exception)
            {
                MessageBox.Show("Click chuột sai vị trí", "Lỗi", MessageBoxButtons.OK);
            }
        }

        private void dgvHoaDonMua_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvHoaDonMua.Columns[e.ColumnIndex].Name == "nha_cung_cap_mua")
            {
                if (e.Value != null)
                {
                    nha_cung_cap supplier = db.nha_cung_cap.Find(e.Value);
                    e.Value = supplier.ten_nha_cung_cap;
                }
            }
            if (this.dgvHoaDonMua.Columns[e.ColumnIndex].Name == "tong_tien_mua")
            {
                if (e.Value != null)
                {
                    e.Value = String.Format("{0:0,0}", e.Value);
                }
            }
        }

        private void dgvHoaDonBan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvHoaDonBan.Columns[e.ColumnIndex].Name == "khach_hang_duoc_ban")
            {
                if (e.Value != null)
                {
                    khach_hang customer = db.khach_hang.Find(e.Value);
                    e.Value = customer.ho_ten;
                }
            }
            if (this.dgvHoaDonBan.Columns[e.ColumnIndex].Name == "nhan_vien_ban")
            {
                if (e.Value != null)
                {
                    nhan_vien staff = db.nhan_vien.Find(e.Value);
                    e.Value = staff.ho_ten;
                }
            }
            if (this.dgvHoaDonBan.Columns[e.ColumnIndex].Name == "tong_tien_ban")
            {
                if (e.Value != null)
                {
                    e.Value = String.Format("{0:0,0}", e.Value);
                }
            }
        }

        private void cbActionBuyInvoice_SelectedValueChanged(object sender, EventArgs e)
        {
            if (USER_LOGIN.phan_quyen != 1 && USER_LOGIN.phan_quyen != 3 && check == 1)
            {
                MessageBox.Show("Bạn không có quyền thực hiện thao tác này!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            string selectedAction = cbActionBuyInvoice.SelectedValue.ToString();
            switch (selectedAction)
            {
                case "view":
                    if (selectedBuyInvoice == null)
                    {
                        MessageBox.Show("Chọn hóa đơn muốn xem chi tiết!", "Thông báo", MessageBoxButtons.OK);
                        refresh();
                        return;
                    }
                    else
                    {
                        ChiTietHoaDonMua xform = new ChiTietHoaDonMua();
                        xform.ShowDialog(this);
                        refresh();
                    }
                    break;
                case "create":
                    hoa_don_mua entity = new hoa_don_mua();
                    entity.ngay_lap = DateTime.Now;
                    entity.tong_tien = 0;
                    entity.ma_nha_cung_cap = int.Parse(cbNhaCungCap.SelectedValue.ToString());
                    db.hoa_don_mua.Add(entity);
                    db.SaveChanges();
                    MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                    refresh();
                    break;
                case "delete":
                    try
                    {
                        if (selectedBuyInvoice == null)
                        {
                            MessageBox.Show("Chọn hóa đơn cần xóa!", "Thông báo", MessageBoxButtons.OK);
                            refresh();
                            return;
                        }
                        else
                        {
                            if (MessageBox.Show(null, "Việc xóa hóa đơn này sẽ làm mất đi cả các thông tin chi tiết của hóa đơn. Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {
                                List<chi_tiet_hoa_don_mua> listDetail = db.chi_tiet_hoa_don_mua.Where(x => x.ma_hoa_don == selectedBuyInvoice.ma_hoa_don).ToList();
                                foreach (chi_tiet_hoa_don_mua item in listDetail)
                                {
                                    db.chi_tiet_hoa_don_mua.Remove(item);
                                    db.SaveChanges();
                                }
                                db.hoa_don_mua.Remove(selectedBuyInvoice);
                                db.SaveChanges();
                                refresh();
                                MessageBox.Show("Xóa dữ liệu thành công!", "Chúc mừng", MessageBoxButtons.OK);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK);
                    }
                    break;
            }
        }

        private void cbActionSaleInvoice_SelectedValueChanged(object sender, EventArgs e)
        {
            if (USER_LOGIN.phan_quyen > 2 && check == 1)
            {
                MessageBox.Show("Bạn không có quyền thực hiện thao tác này!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            string selectedAction = cbActionSaleInvoice.SelectedValue.ToString();
            switch (selectedAction)
            {
                case "view":
                    if (selectedSaleInvoice == null)
                    {
                        MessageBox.Show("Chọn hóa đơn muốn xem chi tiết!", "Thông báo", MessageBoxButtons.OK);
                        refresh();
                        return;
                    }
                    else
                    {
                        ChiTietHoaDonBan xform = new ChiTietHoaDonBan();
                        xform.ShowDialog(this);
                        refresh();
                    }
                    break;
                case "create":
                    hoa_don_ban entity = new hoa_don_ban();
                    entity.ngay_lap = DateTime.Now;
                    entity.tong_tien = 0;
                    entity.ma_khach_hang = int.Parse(cbKhachHang.SelectedValue.ToString());
                    entity.ma_nhan_vien = int.Parse(cbNhanVien.SelectedValue.ToString());
                    db.hoa_don_ban.Add(entity);
                    db.SaveChanges();
                    MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                    refresh();
                    break;
                case "delete":
                    try
                    {
                        if (selectedSaleInvoice == null)
                        {
                            MessageBox.Show("Chọn hóa đơn cần xóa!", "Thông báo", MessageBoxButtons.OK);
                            refresh();
                            return;
                        }
                        else
                        {
                            if (MessageBox.Show(null, "Việc xóa hóa đơn này sẽ làm mất đi cả các thông tin chi tiết của hóa đơn. Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {
                                List<chi_tiet_hoa_don_ban> listDetail = db.chi_tiet_hoa_don_ban.Where(x => x.ma_hoa_don == selectedSaleInvoice.ma_hoa_don).ToList();
                                foreach (chi_tiet_hoa_don_ban item in listDetail)
                                {
                                    db.chi_tiet_hoa_don_ban.Remove(item);
                                    db.SaveChanges();
                                }
                                db.hoa_don_ban.Remove(selectedSaleInvoice);
                                db.SaveChanges();
                                refresh();
                                MessageBox.Show("Xóa dữ liệu thành công!", "Chúc mừng", MessageBoxButtons.OK);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK);
                    }
                    break;
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (USER_LOGIN.phan_quyen != 1 && USER_LOGIN.phan_quyen != 3)
            {
                MessageBox.Show("Bạn không có quyền thực hiện thao tác này!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            DateTime start = dtFromDay.Value;
            DateTime end = dtToDay.Value;
            List<hoa_don_ban> list = new db_sale_managementEntities().hoa_don_ban.Where(x => x.ngay_lap.CompareTo(start) == 1 && x.ngay_lap.CompareTo(end) == -1).ToList();
            dgvHoaDon.DataSource = list;
            double sum = 0;
            foreach (hoa_don_ban item in list)
            {
                sum += item.tong_tien;
            }
            lblTotalSales.Text = "Tổng doanh thu: " + String.Format("{0:0,0}",sum) + " VNĐ";
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvHoaDon.Columns[e.ColumnIndex].Name == "khach_hang")
            {
                if (e.Value != null)
                {
                    khach_hang customer = db.khach_hang.Find(e.Value);
                    e.Value = customer.ho_ten;
                }
            }
            if (this.dgvHoaDon.Columns[e.ColumnIndex].Name == "nhan_vien")
            {
                if (e.Value != null)
                {
                    nhan_vien staff = db.nhan_vien.Find(e.Value);
                    e.Value = staff.ho_ten;
                }
            }
            if (this.dgvHoaDon.Columns[e.ColumnIndex].Name == "tong_tien")
            {
                if (e.Value != null)
                {
                    e.Value = String.Format("{0:0,0}", e.Value);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtExPassword.Text = null;
            txtNewPassword.Text = null;
            txtConfirmPassword.Text = null;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtExPassword.Text.Length <= 0)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cũ!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (txtNewPassword.Text.Length <= 0)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (!USER_LOGIN.mat_khau.Equals(Encryptor.MD5Hash(txtExPassword.Text)))
            {
                MessageBox.Show("Mật khẩu cũ không đúng!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (txtExPassword.Text.Equals(txtNewPassword.Text))
            {
                MessageBox.Show("Mật khẩu mới không thể trùng mật khẩu cũ!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (!txtNewPassword.Text.Equals(txtConfirmPassword.Text))
            {
                MessageBox.Show("Mật khẩu không trùng khớp!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            db_sale_managementEntities db = new db_sale_managementEntities();
            nhan_vien user = db.nhan_vien.Find(USER_LOGIN.ma_nhan_vien);
            user.mat_khau = Encryptor.MD5Hash(txtNewPassword.Text);
            db.SaveChanges();
            MessageBox.Show("Thay đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK);
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (USER_LOGIN.phan_quyen != 1)
            {
                MessageBox.Show("Bạn không có quyền thực hiện thao tác này!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (txtFileNameBackup.Text.Length <= 0)
            {
                MessageBox.Show("Vui lòng nhập tên file!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            string fileName = txtFileNameBackup.Text;
            bool bBackUpStatus = true;

            Cursor.Current = Cursors.WaitCursor;

            if (Directory.Exists(@"c:\SQLBackup"))
            {
                if (File.Exists(@"c:\SQLBackup\" + fileName + ".bak"))
                {
                    if (MessageBox.Show(@"File Name này đã tồn tại, bạn có muốn ghi đè không?", "Back", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        File.Delete(@"c:\SQLBackup\" + fileName + ".bak");
                    }
                    else
                        bBackUpStatus = false;
                }
            }
            else
                Directory.CreateDirectory(@"c:\SQLBackup");
            if(bBackUpStatus)
            {
                db.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, "backup database db_sale_management to disk ='c:/SQLBackup/" + fileName + ".bak'");
                MessageBox.Show("Dữ liệu đã được lưu ở đường dẫn: " + "'C:/SQLBackup/" + fileName + ".bak'" + "!", "Thông báo", MessageBoxButtons.OK);
                txtFileNameBackup.Text = null;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (USER_LOGIN.phan_quyen != 1)
            {
                MessageBox.Show("Bạn không có quyền thực hiện thao tác này!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            
            string fileName = txtFileNameRestore.Text;

            if (fileName.Length <= 0)
            {
                MessageBox.Show("Vui lòng chọn file .bak để restore!", "Thông báo", MessageBoxButtons.OK);
            }
            try
            {
                db.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, @"use master restore database db_sale_management from disk='" + fileName + "'");
                MessageBox.Show("Khôi phục dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                refresh();
                txtFileNameRestore.Text = null;
            }
            catch (Exception)
            {
                MessageBox.Show("File không đúng đuôi mở rộng!", "Thông báo", MessageBoxButtons.OK);
            }
            
        }

        private void txtFileNameRestore_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            txtFileNameRestore.Text = openFileDialog.FileName;
        }

    }
}
