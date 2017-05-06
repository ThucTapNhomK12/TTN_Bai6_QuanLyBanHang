using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLyBanHang.Model;
using QuanLyBanHang.Object;

namespace QuanLyBanHang.Controller
{
    class KhachHangController
    {
        KhachHangMod khMod = new KhachHangMod();
        public DataTable GetData()
        {
            return khMod.GetData();
        }
        public bool AddData(KhachHangObj khObj)
        {
            return khMod.AddData(khObj);
        }
        public bool UpdateData(KhachHangObj khObj)
        {
            return khMod.UpdateData(khObj);
        }
        public bool DeleteData(String ma)
        {
            return khMod.DeleteData(ma);
        }
    }
}
