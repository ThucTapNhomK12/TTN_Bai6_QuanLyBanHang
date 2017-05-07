using System;
using System.Data;
using System.Windows.Forms;
using QuanLyBanHang.Controller;
using QuanLyBanHang.Object;

namespace QuanLyBanHang.View
{
    public partial class frmHoaDon : Form
    {
        HoaDonController hdctr = new HoaDonController();
        ChiTietController ctctr = new ChiTietController();
        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            dis_en(false);
            DataTable dt = new DataTable();
            dt = hdctr.GetData();
            dtgvDSHD.DataSource = dt;
            BingDing(); 
        }
        private void BingDing()
        {
            txtMaHD.DataBindings.Clear();
            txtMaHD.DataBindings.Add("Text",dtgvDSHD.DataSource,"MaHoaDon");
            cmbKH.DataBindings.Clear();
            cmbKH.DataBindings.Add("Text", dtgvDSHD.DataSource, "TenKH");
            cmbNV.DataBindings.Clear();
            cmbNV.DataBindings.Add("Text", dtgvDSHD.DataSource, "TenNhanVien");
            dtngay.DataBindings.Clear();
            dtngay.DataBindings.Add("Text", dtgvDSHD.DataSource, "NgayLap");
        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new System.Data.DataTable();
                dt = ctctr.GetData(txtMaHD.Text.Trim());
                dtgvDSHH.DataSource = dt;
                BingDing1();
            }
            catch
            {
                dtgvDSHH.DataSource = null;
            }
            BingDing1();
        }
        private void BingDing1()
        {
            
            cmbHangHoa.DataBindings.Clear();
            cmbHangHoa.DataBindings.Add("Text", dtgvDSHH.DataSource, "TenHang");
            txtDonGia.DataBindings.Clear();
            txtDonGia.DataBindings.Add("Text", dtgvDSHH.DataSource, "DonGia");
            txtSoLuong.DataBindings.Clear();
            txtSoLuong.DataBindings.Add("Text", dtgvDSHH.DataSource, "SoLuong");
        }

        private void dtgvDSHH_DataSourceChanged(object sender, EventArgs e)
        {
            BingDing1();
        }
        private void dis_en(bool e)
        {
            txtMaHD.Enabled = e;
            cmbNV.Enabled = e;
            cmbHangHoa.Enabled = e;
            btnTao.Enabled = !e;
            btnXoa.Enabled = !e;
            btnIn.Enabled = !e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
            btncham.Enabled = e;
            btnThem.Enabled = e;
            btnBot.Enabled = e;
        }
        private void loadcmbKH()
        {
            KhachHangController khctr = new KhachHangController();
            cmbKH.DataSource = khctr.GetData();
            cmbKH.DisplayMember = "TenKH";
            cmbKH.ValueMember = "MaKH";
        }
        private void loadcmbHH()
        {
            HangHoaController hhctr = new HangHoaController();
            cmbHangHoa.DataSource = hhctr.GetData();
            cmbHangHoa.DisplayMember="TenHang";
            cmbHangHoa.ValueMember="MaHang";
        }
        private void loadcmbnv()
        {
            NhanVienController nvctr = new NhanVienController();
            cmbNV.DataSource = nvctr.GetData();
            cmbNV.DisplayMember = "TenNhanVien";
            cmbNV.ValueMember = "MaNV";
        }
        private void clearData()
        {
            txtMaHD.Text = "";
            cmbNV.Text = "";
            cmbKH.Text = "";
            dtngay.Text = DateTime.Now.Date.ToShortDateString();
            loadcmbKH();
            loadcmbnv();

        }
        private void btnTao_Click(object sender, EventArgs e)
        {
            dis_en(true);
            clearData();
        }

        private void btncham_Click(object sender, EventArgs e)
        {
            dtngay.Enabled = true;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //xoa
                if (hdctr.DeleteData(txtMaHD.Text.Trim()))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                frmHoaDon_Load(sender, e);
            }
            else
                return;
        }
        private void addData(HoaDonObj hdObj)
        {
            hdObj.Ma = txtMaHD.Text.Trim();
            hdObj.NgayLap = dtngay.Text.Trim();
            hdObj.NguoiLap = cmbNV.SelectedValue.ToString();
            hdObj.KhachHang = cmbKH.SelectedValue.ToString();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            HoaDonObj hdObj = new HoaDonObj();
            addData(hdObj);
            if (hdctr.AddData(hdObj))
            {
                DataTable dt = new System.Data.DataTable();
                dt = (DataTable)dtgvDSHH.DataSource;
                if(ctctr.AddData(dt))
                MessageBox.Show("Thêm hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm chi tiết hóa đơn thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Thêm hóa đơn thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            frmHoaDon_Load(sender, e);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn hủy thao tác?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr==DialogResult.Yes)
            {
                frmHoaDon_Load(sender, e);
            }
            else return;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang được nâng cấp");    
        }
    }
}
