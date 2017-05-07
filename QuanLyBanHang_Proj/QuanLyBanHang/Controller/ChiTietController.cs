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
    class ChiTietController
    {
        ChiTietMod ctMod = new ChiTietMod();
        public DataTable GetData(string ma)
        {
            return ctMod.GetData(ma);
        }
        public bool AddData(DataTable dt)
        {
            return ctMod.AddData(dt);
        }
        public bool DeleteData(String ma)
        {
            return ctMod.DeleteData(ma);
        }
    }
}
