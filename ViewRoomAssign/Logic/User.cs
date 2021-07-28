using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ViewRoomAssign.DataAccess;

namespace ViewRoomAssign.Logic
{
    class User
    {
        public static string user;
        public static string userrole;
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Role { get; set; }

        public static List<User> Login(string username, string password)
        {
            List<User> users = new List<User>();
            DataTable dt = DAO.Login(username, password);
            foreach (DataRow dr in dt.Rows)
            {
                User u = new User();
                u.UserID = Convert.ToInt32(dr["ID"]);
                u.UserName = dr["UserName"].ToString();
                u.PassWord = dr["Password"].ToString();
                u.Role = dr["Role"].ToString();
                users.Add(u);
            }
            return users;
        }
    }
}
