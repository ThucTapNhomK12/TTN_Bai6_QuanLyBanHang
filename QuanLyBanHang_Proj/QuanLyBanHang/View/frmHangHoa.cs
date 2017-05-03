using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.View
{
    public partial class frmHangHoa : Form
    {
        HangHoaController hhctrl = new HangHoaController();
        HangHoaObj hhObj = new HangHoaObj();
        int flag = 0;
        public frmHangHoa()
        {
            InitializeComponent();
        }

        private void frmHangHoa_Load(object sender, EventArgs e)
        {
            DataTable dtHangHoa = new DataTable();
            dtHangHoa = hhctrl.GetData();
            dtgvHangHoa.DataSource = dtHangHoa;
            bingding();
        }
        void bingding()
        {
            txtMa.DataBindings.Clear();
            txtMa.DataBindings.Add("Text", dtgvHangHoa.DataSource, "MaHang");
            txtTenHang.DataBindings.Clear();
            txtTenHang.DataBindings.Add("Text", dtgvHangHoa.DataSource, "TenHang");
            cmbSoLuong.DataBindings.Clear();
            cmbSoLuong.DataBindings.Add("Text", dtgvHangHoa.DataSource, "SoLuong");
            txtDonGia.DataBindings.Clear();
            txtDonGia.DataBindings.Add("Text", dtgvHangHoa.DataSource, "DonGia");
            
        }
        void ganDuLieu(HangHoaObj hhObj)
        {
            hhObj.Ma = txtMa.Text.Trim();
            hhObj.Ten = txtTenHang.Text.Trim();
            hhObj.SoLuong = cmbSoLuong.Text.Trim();
            hhObj.DonGia = txtDonGia.Text.Trim();

        }
        void cleartxt()
        {
            txtMa.Text = "";
            txtTenHang.Text = "";
            cmbSoLuong.Text = "";
            txtDonGia.Text = "";

        }

        void dis_en(bool e)
        {
            txtMa.Enabled = e;
            txtTenHang.Enabled = e;
            cmbSoLuong.Enabled = e;
            txtDonGia.Enabled = e;
            btnHuy.Enabled = e;
            btnLuu.Enabled = e;
            btnThem.Enabled = !e;
            btnSua.Enabled = !e;
            btnXoa.Enabled = !e;
        }


    }
}
