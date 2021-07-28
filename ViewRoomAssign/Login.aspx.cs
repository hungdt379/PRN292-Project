using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ViewRoomAssign
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<Logic.User> users = new List<Logic.User>();
            string username = TextBox1.Text;
            string password = TextBox2.Text;
            users = Logic.User.Login(username, password);
            if (users.Count == 1)
            {
                Label1.Text = "Login Success";
            }
            else
            {
                Label1.Text = "Login Failed, Account doesn't exist";
            }
        }
    }
}