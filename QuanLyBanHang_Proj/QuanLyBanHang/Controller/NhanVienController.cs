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
    class NhanVienController
    {
        NhanVienMod nvMod = new NhanVienMod();
        public DataTable GetData()
        {
            return nvMod.GetData();
        }
        public bool AddData(NhanVienObj nvObj)
        {
            return nvMod.AddData(nvObj);
        }
        public bool UpdateData(NhanVienObj nvObj)
        {
            return nvMod.UpdateData(nvObj);
        }
        public bool DeleteData(String ma)
        {
            return nvMod.DeleteData(ma);
        }

    }
}
