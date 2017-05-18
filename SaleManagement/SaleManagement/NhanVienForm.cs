using SaleManagement.Common;
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
    public partial class NhanVienForm : Form
    {
        db_sale_managementEntities db = new db_sale_managementEntities();

        public nhan_vien selectedStaff = QuanLy.selectedStaff;
        public NhanVienForm()
        {
            InitializeComponent();
            loadForm();
            if (selectedStaff != null)
            {
                txtHoten.Text = selectedStaff.ho_ten;
                txtDiaChi.Text = selectedStaff.dia_chi;
                txtSoDienThoai.Text = selectedStaff.so_dien_thoai;
                txtTaiKhoan.Text = selectedStaff.tai_khoan;
                txtMatKhau.Text = selectedStaff.mat_khau;
                cbTrangThai.SelectedValue = (selectedStaff.trang_thai == true) ? 1 : 0;
                cbPhanQuyen.SelectedValue = selectedStaff.phan_quyen;
                txtTaiKhoan.Enabled = false;
            }
        }

        public void loadForm()
        {
List<ComboboxUtils> listStatus = new List<ComboboxUtils>()
            {
                new ComboboxUtils(1, "Bình thường"),
                new ComboboxUtils(0, "Đang khóa")
            };
            ComboboxUtils status = new ComboboxUtils();
            cbTrangThai.DataSource = listStatus;
            cbTrangThai.DisplayMember = "text";
            cbTrangThai.ValueMember = "value";

            List<ComboboxUtils> listRole = new List<ComboboxUtils>()
            {
                new ComboboxUtils(1, "Admin"),
                new ComboboxUtils(2, "Nhân viên bán hàng"),
                new ComboboxUtils(3, "Kế toán"),
                new ComboboxUtils(4, "Thủ kho")
            };
            ComboboxUtils role = new ComboboxUtils();
            cbPhanQuyen.DataSource = listRole;
            cbPhanQuyen.DisplayMember = "text";
            cbPhanQuyen.ValueMember = "value";

            selectedStaff = (selectedStaff != null) ? new db_sale_managementEntities().nhan_vien.Find(selectedStaff.ma_nhan_vien) : null;
        
           }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            
        }

    }
}
