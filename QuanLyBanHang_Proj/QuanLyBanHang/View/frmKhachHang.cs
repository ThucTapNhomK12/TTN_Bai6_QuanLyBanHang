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
    public partial class frmKhachHang : Form
    {
        KhachHangController khctrl = new KhachHangController();
        KhachHangObj khObj = new KhachHangObj();
        int flag = 0;
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            DataTable dtKH = new DataTable();
            dtKH = khctrl.GetData();
            dgvDanhSachKH.DataSource = dtKH;
            bingding(); 
            loadControl();
        }
        void loadControl()
        {
            cmbGioiTinh.Items.Add("Nam");
            cmbGioiTinh.Items.Add("Nữ");
        }
        void bingding()
        {
            txtMaKH.DataBindings.Clear();
            txtMaKH.DataBindings.Add("Text", dgvDanhSachKH.DataSource, "MaKH");
            txtTenKH.DataBindings.Clear();
            txtTenKH.DataBindings.Add("Text", dgvDanhSachKH.DataSource, "TenKH");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", dgvDanhSachKH.DataSource, "DiaChi");
            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", dgvDanhSachKH.DataSource, "SDT");
            dtNamSinh.DataBindings.Clear();
            dtNamSinh.DataBindings.Add("Text", dgvDanhSachKH.DataSource, "NamSinh");
            cmbGioiTinh.DataBindings.Clear();
            cmbGioiTinh.DataBindings.Add("Text", dgvDanhSachKH.DataSource, "GioiTinh");
            txtDiem.DataBindings.Clear();
            txtDiem.DataBindings.Add("Text", dgvDanhSachKH.DataSource, "SoDiem");
            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text", dgvDanhSachKH.DataSource, "Email");

        }
        void ganDuLieu(KhachHangObj khObj)
        {
            khObj.Ma = txtMaKH.Text.Trim();
            khObj.Ten = txtTenKH.Text.Trim();
            khObj.GioiTinh = cmbGioiTinh.Text.Trim();
            khObj.NamSinh = dtNamSinh.Text.Trim();
            khObj.Sdt = txtSDT.Text.Trim();
            khObj.DiaChi = txtDiaChi.Text.Trim();
            khObj.Diem = int.Parse(txtDiem.Text.Trim());
            khObj.Email = txtEmail.Text.Trim();

        }

        void cleartxt()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtDiem.Text = "";
            txtEmail.Text = "";

        }
        void dis_en(bool e)
        {
            txtTenKH.Enabled = e;
            txtSDT.Enabled = e;
            txtMaKH.Enabled = e;
            txtEmail.Enabled = e;
            txtDiem.Enabled = e;
            txtDiaChi.Enabled = e;
            cmbGioiTinh.Enabled = e;
            dtNamSinh.Enabled = e;
            btnHuy.Enabled = e;
            btnLuu.Enabled = e;
            btnThem.Enabled = !e;
            btnSua.Enabled = !e;
            btnXoa.Enabled = !e;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DataTable dtKH = new DataTable();
            dtKH = khctrl.GetData();
            dgvDanhSachKH.DataSource = dtKH;
            bingding(); 
            flag = 0;
            cleartxt();
            dis_en(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 1;
            dis_en(true);
            txtMaKH.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //xoa
                if (khctrl.DeleteData(txtMaKH.Text.Trim()))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                frmKhachHang_Load(sender, e);
            }
            else
                return;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ganDuLieu(khObj);
            if (flag == 0)
            {
                //them moi
                if (khctrl.AddData(khObj))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                frmKhachHang_Load(sender, e);
            }
            else
            {
                //sua
                if (khctrl.UpdateData(khObj))
                {
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                frmKhachHang_Load(sender, e);
            }
            dis_en(false);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmKhachHang_Load(sender, e);
            dis_en(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DOTAGT1\SQLEXPRESS;Initial Catalog=BanHang;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"select * from KhachHang where TenKH like '%'+@TenKH+'%'";
            cmd.Parameters.Add("@TenKH", SqlDbType.NVarChar, 50).Value = txtTim.Text;
            SqlDataAdapter sd = new SqlDataAdapter();
            sd.SelectCommand = cmd;
            sd.Fill(dt);
            dgvDanhSachKH.DataSource = dt;
            bingding();
        }
    }
}
