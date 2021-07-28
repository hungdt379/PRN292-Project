using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ViewRoomAssign.DataAccess
{
    class DAO
    {
        public static SqlConnection GetConnection()
        {
            string ConStr = ConfigurationManager.ConnectionStrings["DBName"].ToString();
            //string ConStr = "server=DESKTOP-CL9UIGQ;database=PRN292_Demo;Integrated Security = true";
            return new SqlConnection(ConStr);
        }

        public static DataTable GetDataBySql(string sql)
        {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(ds); // thuc thi sql la du lieu fill vao data set
            return ds.Tables[0];
        }

        public static DataTable GetDataBySqlParameter(string sql, SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            command.Parameters.AddRange(parameters);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(ds); // thuc thi sql la du lieu fill vao data set
            return ds.Tables[0];
        }

        public static int ExecuteSQL(string sql, SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            command.Connection.Open();
            command.Parameters.AddRange(parameters);
            int k = command.ExecuteNonQuery();
            command.Connection.Close();
            return k;
        }

        public static DataTable Login(string username, string password)
        {
            string sql = "select * from users where username = @username and password = @password";
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@username", SqlDbType.NVarChar);
            parameters[0].Value = username;
            parameters[1] = new SqlParameter("@password", SqlDbType.NVarChar);
            parameters[1].Value = password;
            return GetDataBySqlParameter(sql, parameters);
        }

        
    }
}
