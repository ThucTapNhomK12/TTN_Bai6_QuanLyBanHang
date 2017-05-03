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

        private void btnTim_Click(object sender, EventArgs e)
        {

        }
    }
}
