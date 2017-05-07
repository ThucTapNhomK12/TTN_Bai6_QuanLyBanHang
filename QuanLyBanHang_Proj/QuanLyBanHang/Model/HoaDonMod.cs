using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanHang.Object;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyBanHang.Model
{
    class HoaDonMod
    {
        ConnecToSql con = new ConnecToSql();
        SqlCommand cmd = new SqlCommand();
        public DataTable GetData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = @"select hd.MaHoaDon,hd.NgayLap,nv.TenNhanVien,kh.TenKH from HoaDon hd, KhachHang kh,NhanVien nv where kh.MaKH=hd.KhachHang and nv.MaNV=hd.NhanVienLap";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                con.CloseConn();
            }
            catch (Exception e)
            {
                string mess = e.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return dt;
        }
        public bool AddData(HoaDonObj hdObj)
        {
            cmd.CommandText = "insert into HoaDon values('"+hdObj.Ma+"','"+hdObj.KhachHang+"','"+hdObj.NguoiLap+"',CONVERT(date,'"+hdObj.NgayLap+"',103))";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                con.CloseConn();
                return true;
            }
            catch (Exception ex)
            {
                string mess = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }
        
        public bool DeleteData(String ma)
        {
            cmd.CommandText = "delete HoaDon where MaHoaDon='" + ma + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                con.CloseConn();
                return true;
            }
            catch (Exception e)
            {
                string mess = e.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }
    }
}
