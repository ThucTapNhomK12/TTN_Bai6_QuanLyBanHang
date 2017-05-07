using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Object
{
    class ChiTietObj
    {
        string mahd, mahh;
        int dongia, soluong;
        public string MaHD
        {
            get
            {
                return mahd;
            }
            set
            {
                this.mahd = value;
            }
        }
        public string MaHH
        {
            get
            {
                return mahh;
            }
            set
            {
                this.mahh = value;
            }
        }
        public int DonGia
        {
            get
            {
                return dongia;
            }
            set
            {
                this.dongia = value;
            }
        }
        public int SoLuong
        {
            get
            {
                return soluong;
            }
            set
            {
                this.soluong = value;
            }
        }
        public ChiTietObj() { }
        public ChiTietObj(string mahd, string mahh, int dongia, int soluong)
        {
            this.mahd = mahd;
            this.mahh = mahh;
            this.dongia = dongia;
            this.soluong = soluong;
        }
    }
}
