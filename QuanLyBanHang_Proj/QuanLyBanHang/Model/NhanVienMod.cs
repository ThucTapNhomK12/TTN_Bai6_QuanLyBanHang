using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyBanHang.Object;

namespace QuanLyBanHang.Model
{
    class NhanVienMod
    {
        ConnecToSql con = new ConnecToSql();
        SqlCommand cmd = new SqlCommand();
        public DataTable GetData()
        {
            DataTable dt=new DataTable();
            cmd.CommandText = "select * from NhanVien";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                con.CloseConn();
            }
            catch(Exception e)
            {
                string mess = e.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return dt;
        }
        public bool AddData(NhanVienObj nvObj)
        {
            cmd.CommandText = "Insert into NhanVien values ('" + nvObj.Ma + "',N'" + nvObj.Ten + "',N'" + nvObj.GioiTinh + "',CONVERT(DATE,'" + nvObj.NamSinh + "',103),N'" + nvObj.DiaChi + "','" + nvObj.Sdt + "','" + nvObj.MatKhau + "')";
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
        public bool UpdateData(NhanVienObj nvObj)
        {
            cmd.CommandText = "update NhanVien set  TenNhanVien=N'" + nvObj.Ten + "',GioiTinh=N'" + nvObj.GioiTinh + "',NamSinh=CONVERT(DATE,'" + nvObj.NamSinh + "',103),DiaChi=N'" + nvObj.DiaChi + "',SDT='" + nvObj.Sdt + "',MatKhau='" + nvObj.MatKhau + "'where MaNV='" + nvObj.Ma + "'";
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
        public bool DeleteData(String ma)
        {
            cmd.CommandText = "delete NhanVien where MaNV='"+ma+"'";
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
