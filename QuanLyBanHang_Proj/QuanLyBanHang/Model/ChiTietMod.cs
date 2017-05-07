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
    class ChiTietMod
    {
        ConnecToSql con = new ConnecToSql();
        SqlCommand cmd = new SqlCommand();
        public DataTable GetData(string ma)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = @"select ct.MaHoaDon,hh.TenHang, ct.DonGia, ct.SoLuong from CTHD ct,HangHoa hh where ct.MaHang=hh.MaHang and MaHoaDon='"+ma+"'";
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
        public bool AddData(DataTable dt)
        {
            
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmd.CommandText = "insert into CTHD values('" + dt.Rows[1][0].ToString() + "','" + dt.Rows[1][1].ToString() + "','" + dt.Rows[1][2].ToString() + "','" + dt.Rows[1][3].ToString() + "')";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con.Connection;
                    con.OpenConn();
                    cmd.ExecuteNonQuery();
                    con.CloseConn();
                }
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
            cmd.CommandText = "delete CTHD where MaHD='" + ma + "'";
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
