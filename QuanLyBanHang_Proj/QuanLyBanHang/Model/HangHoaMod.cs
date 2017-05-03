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
    class HangHoaMod
    {
        ConnecToSql con = new ConnecToSql();
        SqlCommand cmd = new SqlCommand();
        public DataTable GetData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "select * from HangHoa";
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
        public bool AddData(HangHoaObj hhObj)
        {
            cmd.CommandText = "Insert into HangHoa values ('" + hhObj.Ma + "',N'" + hhObj.Ten + "','" + hhObj.DonGia + "','" + hhObj.SoLuong + "')";
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
        public bool UpdateData(HangHoaObj hhObj)
        {
            cmd.CommandText = "update HangHoa set  TenHang=N'" + hhObj.Ten + "',DonGia='" + hhObj.DonGia + "',SoLuong='" + hhObj.SoLuong + "'where MaHang='" + hhObj.Ma + "'";
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
            cmd.CommandText = "delete HangHoa where MaHang='" + ma + "'";
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
