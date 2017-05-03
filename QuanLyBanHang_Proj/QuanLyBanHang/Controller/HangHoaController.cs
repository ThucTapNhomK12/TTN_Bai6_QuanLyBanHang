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
    class HangHoaController
    {
        HangHoaMod hhMod = new HangHoaMod();
        public DataTable GetData()
        {
            return hhMod.GetData();
        }
        public bool AddData(HangHoaObj hhObj)
        {
            return hhMod.AddData(hhObj);
        }
        public bool UpdateData(HangHoaObj hhObj)
        {
            return hhMod.UpdateData(hhObj);
        }
        public bool DeleteData(String ma)
        {
            return hhMod.DeleteData(ma);
        }
    }
}
