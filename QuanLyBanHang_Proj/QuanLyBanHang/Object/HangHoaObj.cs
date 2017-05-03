using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Object
{
    class HangHoaObj
    {
        string ma, ten, soluong, dongia;

        public string Ma
        {
            get { return ma; }
            set { ma = value; }
        }

        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }

        public string SoLuong
        {
            get { return soluong; }
            set { soluong = value; }
        }

        public string DonGia
        {
            get { return dongia; }
            set { dongia = value; }
        }

        
        public HangHoaObj(){}
        public HangHoaObj(string ma, string ten,string soluong, string dongia)
        {
            this.ma = ma;
            this.ten = ten;
            this.soluong = soluong;
            this.dongia = dongia;
        }

    }
}
