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
            txtMa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //xoa
                if (hhctrl.DeleteData(txtMa.Text.Trim()))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                frmHangHoa_Load(sender, e);
            }
            else
                return;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ganDuLieu(hhObj);
            if (flag == 0)
            {
                //them moi
                if (hhctrl.AddData(hhObj))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                frmHangHoa_Load(sender, e);
            }
            else
            {
                //sua
                if (hhctrl.UpdateData(hhObj))
                {
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                frmHangHoa_Load(sender, e);
            }
            dis_en(false);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmHangHoa_Load(sender, e);
            dis_en(false);
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            frmHangHoa_Load(sender, e);
            dis_en(false);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DOTAGT1\SQLEXPRESS;Initial Catalog=BanHang;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"select * from HangHoa where TenHang like '%'+@TenHang+'%'";
            cmd.Parameters.Add("@TenHang", SqlDbType.NVarChar, 50).Value = txtTim.Text;
            SqlDataAdapter sd = new SqlDataAdapter();
            sd.SelectCommand = cmd;
            sd.Fill(dt);
            dtgvHangHoa.DataSource = dt;
            bingding();
        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenHang_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cmbSoLuong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dtgvHangHoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }


    }
}
