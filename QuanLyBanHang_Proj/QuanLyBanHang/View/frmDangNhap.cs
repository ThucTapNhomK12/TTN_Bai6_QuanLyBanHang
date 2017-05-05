using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanHang.Model;
using QuanLyBanHang.Controller;
using QuanLyBanHang.Object;
using System.Data.SqlClient;

namespace QuanLyBanHang.View
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        string strCon = @"Data Source=DESKTOP-DOTAGT1\SQLEXPRESS;Initial Catalog=BanHang;Integrated Security=True";
        SqlCommand cmd;
        SqlConnection con;
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(strCon);
                con.Open();
                string sql = "select COunt(*) from NhanVien where MaNV=@manv and MatKhau=@matkhau";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@manv", textBox1.Text));
                cmd.Parameters.Add(new SqlParameter("@matkhau", textBox2.Text));
                int x = (int)cmd.ExecuteScalar();
                if (x == 1)
                {
                    frmMain f = new frmMain();
                    this.Hide();
                    f.ShowDialog();
                }
                else
                {
                    label3.Text = "Tên đăng nhập hoặc mật khẩu không đúng!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult r= MessageBox.Show("Bạn muốn thoát phải không?", "Thông báo", MessageBoxButtons.YesNo);
            if (r==DialogResult.Yes)
                this.Close();

        }
    }
}
