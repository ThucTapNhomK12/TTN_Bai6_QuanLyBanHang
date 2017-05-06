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
    class KhachHangMod
    {
        ConnecToSql con = new ConnecToSql();
        SqlCommand cmd = new SqlCommand();
        public DataTable GetData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "select * from KhachHang";
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
        public bool AddData(KhachHangObj khObj)
        {
            cmd.CommandText = "Insert into KhachHang values ('" + khObj.Ma + "',N'" + khObj.Ten + "',N'" + khObj.GioiTinh + "',CONVERT(DATE,'" + khObj.NamSinh + "',103),N'" + khObj.DiaChi + "','" + khObj.Sdt + "'," + khObj.Diem + ",'" + khObj.Email + "')";
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
        public bool UpdateData(KhachHangObj khObj)
        {
            cmd.CommandText = "update KhachHang set  TenKH=N'" + khObj.Ten + "',GioiTinh=N'" + khObj.GioiTinh + "',NamSinh=CONVERT(DATE,'" + khObj.NamSinh + "',103),DiaChi=N'" + khObj.DiaChi + "',SDT='" + khObj.Sdt + "',SoDiem=" + khObj.Diem + ",Email='" + khObj.Email + "'where MaKH='" + khObj.Ma + "'";
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
            cmd.CommandText = "delete KhachHang where MaKH='" + ma + "'";
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
