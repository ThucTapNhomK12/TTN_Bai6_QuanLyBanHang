using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanHang.Controller;
using QuanLyBanHang.Object;
using System.Data.SqlClient;

namespace QuanLyBanHang.View
{
    public partial class frmNhanVien : Form
    {
        NhanVienController nvctrl = new NhanVienController();
        NhanVienObj nvObj = new NhanVienObj();
        int flag = 0;
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            DataTable dtNhanVien = new DataTable();
            dtNhanVien = nvctrl.GetData();
            dgvDanhSachNV.DataSource = dtNhanVien;
            bingding();
            loadControl();
        }
        void bingding()
        {
            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text",dgvDanhSachNV.DataSource,"MaNV");
            txtTenNV.DataBindings.Clear();
            txtTenNV.DataBindings.Add("Text", dgvDanhSachNV.DataSource, "TenNhanVien");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", dgvDanhSachNV.DataSource, "DiaChi");
            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", dgvDanhSachNV.DataSource, "SDT");
            dtNamSinh.DataBindings.Clear();
            dtNamSinh.DataBindings.Add("Text", dgvDanhSachNV.DataSource, "NamSinh");
            cmbGioiTinh.DataBindings.Clear();
            cmbGioiTinh.DataBindings.Add("Text", dgvDanhSachNV.DataSource, "GioiTinh");
        }
        void ganDuLieu(NhanVienObj nvObj)
        {
            nvObj.Ma = txtMaNV.Text.Trim();
            nvObj.Ten = txtTenNV.Text.Trim();
            nvObj.GioiTinh = cmbGioiTinh.Text.Trim();
            nvObj.NamSinh = dtNamSinh.Text.Trim();
            nvObj.Sdt = txtSDT.Text.Trim();
            nvObj.DiaChi = txtDiaChi.Text.Trim();
            nvObj.MatKhau = "";

        }
        void loadControl()
        {
            cmbGioiTinh.Items.Add("Nam");
            cmbGioiTinh.Items.Add("Nữ");
        }
        void cleartxt()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            
        }
        void dis_en(bool e)
        {
            txtTenNV.Enabled = e;
            txtSDT.Enabled = e;
            txtMaNV.Enabled = e;
            txtDiaChi.Enabled = e;
            cmbGioiTinh.Enabled = e;
            dtNamSinh.Enabled = e;
            btnHuy.Enabled = e;
            btnLuu.Enabled = e;
            btnThem.Enabled =!e;
            btnSua.Enabled = !e;
            btnXoa.Enabled = !e;


        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 0;
            cleartxt();
            dis_en(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 1;
            dis_en(true);
            txtMaNV.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //xoa
                if (nvctrl.DeleteData(txtMaNV.Text.Trim()))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                frmNhanVien_Load(sender, e);
            }
            else
                return;

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ganDuLieu(nvObj);
            if(flag==0)
            {
                //them moi
                if(nvctrl.AddData(nvObj))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                frmNhanVien_Load(sender, e);
            }
            else
            {
                //sua
                if (nvctrl.UpdateData(nvObj))
                {
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                frmNhanVien_Load(sender, e);
            }
            dis_en(false);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmNhanVien_Load(sender, e);
            dis_en(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DOTAGT1\SQLEXPRESS;Initial Catalog=BanHang;Integrated Security=True");
            SqlCommand cmd=new SqlCommand();
            cmd.Connection=conn;
            cmd.CommandType=CommandType.Text;
            cmd.CommandText=@"select * from NhanVien where TenNhanVien like '%'+@TenNhanVien+'%'";
            cmd.Parameters.Add("@TenNhanVien",SqlDbType.NVarChar,50).Value=txtTimKiem.Text;
            SqlDataAdapter sd = new SqlDataAdapter();
            sd.SelectCommand = cmd;
            sd.Fill(dt);
            dgvDanhSachNV.DataSource = dt;
            bingding();

        }
    }
}
