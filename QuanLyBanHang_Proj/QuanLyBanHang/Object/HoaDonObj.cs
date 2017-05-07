using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Object
{
    class HoaDonObj
    {
        string ma, khachhang, nguoilap, ngaylap;
        public string Ma
        {
            get
            {
                return ma;
            }
            set
            {
                this.ma = value;
            }
        }
        public string KhachHang
        {
            get
            {
                return khachhang;
            }
            set
            {
                this.khachhang = value;
            }
        }
        public string NguoiLap
        {
            get
            {
                return nguoilap;
            }
            set
            {
                this.nguoilap = value;
            }
        }
        public string NgayLap
        {
            get
            {
                return ngaylap;
            }
            set
            {
                this.ngaylap = value;
            }
        }
        public HoaDonObj() { }
        public HoaDonObj(string ma, string khachhang, string nguoilap, string ngaylap)
        {
            this.ma = ma;
            this.khachhang = khachhang;
            this.nguoilap = nguoilap;
            this.ngaylap = ngaylap;
        }
    }
}
