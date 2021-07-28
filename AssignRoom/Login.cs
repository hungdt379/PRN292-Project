using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AssignRoom.Logic;

namespace AssignRoom
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        void login()
        {
            List<User> users = new List<User>();
            string username = textBox1.Text;
            string password = textBox2.Text;
            users = User.Login(username, password);
            if (users.Count == 0)
            {
                MessageBox.Show("Login failed, UserName and PassWord doesn't exist");
            }else if (users.Count == 1)
            {
                if (users[0].Role.Equals("CB"))
                {
                    User.user = textBox1.Text;
                    User.userrole = users[0].Role;
                    ListRoom listRoom = new ListRoom();
                    listRoom.Show();
                    this.Hide();
                }
                else
                {
                    User.user = textBox1.Text;
                    User.userrole = users[0].Role;
                    User.userid = users[0].UserID;
                    LecturerShedule lecturerShedule = new LecturerShedule();
                    lecturerShedule.Show();
                    this.Hide();
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login();
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }
    }
}
