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
            if (txtHoten.Text.Length <= 0 || txtDiaChi.Text.Length <= 0 ||
                txtTaiKhoan.Text.Length <= 0 || txtMatKhau.Text.Length <= 0)
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
            if (selectedStaff == null)
            {
                if (db.nhan_vien.SingleOrDefault(x => x.tai_khoan.Equals(txtTaiKhoan.Text)) != null)
                {
                    MessageBox.Show("Tài khoản đã tồn tại!", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                nhan_vien entity = new nhan_vien();
                entity.ho_ten = txtHoten.Text;
                entity.dia_chi = txtDiaChi.Text;
                entity.so_dien_thoai = txtSoDienThoai.Text;
                entity.tai_khoan = txtTaiKhoan.Text;
                entity.mat_khau = Encryptor.MD5Hash(txtMatKhau.Text);
                entity.trang_thai = (cbTrangThai.SelectedValue.ToString().Equals("1")) ? true : false;
                entity.phan_quyen = int.Parse(cbPhanQuyen.SelectedValue.ToString());
                db.nhan_vien.Add(entity);
                db.SaveChanges();
                MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                nhan_vien entity = db.nhan_vien.Find(selectedStaff.ma_nhan_vien);
                entity.ho_ten = txtHoten.Text;
                entity.dia_chi = txtDiaChi.Text;
                entity.so_dien_thoai = txtSoDienThoai.Text;
                if (!entity.mat_khau.Equals(txtMatKhau.Text))
                {
                    entity.mat_khau = Encryptor.MD5Hash(txtMatKhau.Text);
                }
                entity.trang_thai = (cbTrangThai.SelectedValue.ToString().Equals("1")) ? true : false;
                entity.phan_quyen = int.Parse(cbPhanQuyen.SelectedValue.ToString());
                db.SaveChanges();
                MessageBox.Show("Chỉnh sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            this.Hide();
        }
        }

    }

