using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Object
{
    class KhachHangObj
    {
        string ma, ten, gioitinh, diachi, sdt, namsinh, email;
        int diem;

        public int Diem
        {
            get { return diem; }
            set { diem = value; }
        }


        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }

        public string DiaChi
        {
            get { return diachi; }
            set { diachi = value; }
        }

        public string GioiTinh
        {
            get { return gioitinh; }
            set { gioitinh = value; }
        }

        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }

        public string Ma
        {
            get { return ma; }
            set { ma = value; }
        }

        public string NamSinh
        {
            get { return namsinh; }
            set { namsinh = value; }
        }
        public KhachHangObj(){}
        public KhachHangObj(string ma, string ten, string gioitinh, string diachi, string sdt, string email, string namsinh,int diem)
        {
            this.ma = ma;
            this.ten = ten;
            this.gioitinh = gioitinh;
            this.diachi = diachi;
            this.sdt = sdt;
            this.email = email;
            this.namsinh = namsinh;
            this.diem = diem;
        }
    }
}
