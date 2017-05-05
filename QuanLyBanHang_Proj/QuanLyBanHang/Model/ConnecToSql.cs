using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyBanHang.Model
{
    class ConnecToSql
    {
        private SqlConnection conn;

        public SqlConnection Connection
        {
            get { return conn; }
        }
        private SqlCommand _cmd;

        public SqlCommand CMD
        {
            get { return _cmd; }
            set { _cmd = value; }
        }
        private string error;

        public string ERROR
        {
            get { return error; }
            set { error = value; }
        }
        string StrCon;

        public ConnecToSql()
        {
            StrCon = @"Data Source=DESKTOP-DOTAGT1\SQLEXPRESS;Initial Catalog=BanHang;Integrated Security=True";
            conn = new SqlConnection(StrCon);
        }

        public bool OpenConn()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
            }
            catch(Exception e)
            {
                error = e.Message;
                return false;
            }
            return true;
        }
        public bool CloseConn()
        {
            try
            {
                if(conn.State==ConnectionState.Open)
                    conn.Close();
            }
            catch(Exception e)
            {
                error=e.Message;
                return false;
            }
            return true;
        }    
    }
}
