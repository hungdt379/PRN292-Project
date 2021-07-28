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
    public partial class LecturerShedule : Form
    {
        DateTime monday;
        DateTime tuesday;
        DateTime wednesday;
        DateTime thursday;
        DateTime friday;
        DateTime saturday;
        DateTime sunday;

        public LecturerShedule()
        {
            InitializeComponent();

            txtUser.Text = String.Format("User:{0}", User.user);
            txtRole.Text = String.Format("UserRole:{0}", User.userrole);
            LoadDayOfWeek();
            List<Lecturer> lectureres = Lecturer.GetAll();
            comboBox1.DisplayMember = "LecturerName";
            comboBox1.ValueMember = "UserID";
            comboBox1.DataSource = lectureres;

            LoadMatrix();
            if (User.userrole == "CB")
            {
                btnLogout.Hide();
            }
        }

        void LoadDayOfWeek()
        {
            textBox1.Text = String.Format("{0:d}", DateTime.Now.FirstDayOfWeek());
            textBox2.Text = String.Format("{0:d}", DateTime.Now.TuesdayOfWeek());
            textBox3.Text = String.Format("{0:d}", DateTime.Now.WednesdayOfWeek());
            textBox4.Text = String.Format("{0:d}", DateTime.Now.ThursdayOfWeek());
            textBox5.Text = String.Format("{0:d}", DateTime.Now.FridayOfWeek());
            textBox6.Text = String.Format("{0:d}", DateTime.Now.SaturdayOfWeek());
            textBox7.Text = String.Format("{0:d}", DateTime.Now.LastDayOfWeek());

        }

        void InputDataToMatrix( int slotID, DateTime time, Button button, int i, int j)
        {
            Lecturer lecturer = (Lecturer)comboBox1.SelectedItem;
            RoomAssign room = RoomAssign.GetLecturerScheduleFromRoomAssign(slotID, lecturer.LecturerID, time);
            if (room.ID != 0)
            {
                button.Text = room.ClassObj.ClassName + "\n" + room.Room.RoomName;
                button.BackColor = Color.FromArgb(154, 255, 154);
            }
            else
            {
                button.BackColor = Color.FromArgb(255, 106, 106);
            }
        }

        void LoadMatrix()
        {
            Button oldBtn = new Button() { Width = 0, Height = 0, Location = new Point(-Const.margin, 0) };
            for (int i = 0; i < Const.SlotOfColumn; i++)
            {
                for (int j = 0; j < Const.DayOfWeek; j++)
                {

                    Button btn = new Button() { Width = Const.dateButtonWidth, Height = Const.dateButtonHeight };
                    btn.Location = new Point(oldBtn.Location.X + oldBtn.Width + Const.margin, oldBtn.Location.Y);

                    if (j == 0)
                    {
                        monday = dateTimePicker1.Value.FirstDayOfWeek();
                        InputDataToMatrix(i + 1, monday, btn, i, j);
                    }
                    else if (j == 1)
                    {
                        tuesday = dateTimePicker1.Value.TuesdayOfWeek();
                        InputDataToMatrix( i + 1, tuesday, btn, i, j);
                    }
                    else if (j == 2)
                    {
                        wednesday = dateTimePicker1.Value.WednesdayOfWeek();
                        InputDataToMatrix( i + 1, wednesday, btn, i, j);
                    }
                    else if (j == 3)
                    {
                        thursday = dateTimePicker1.Value.ThursdayOfWeek();
                        InputDataToMatrix( i + 1, thursday, btn, i, j);
                    }
                    else if (j == 4)
                    {
                        friday = dateTimePicker1.Value.FridayOfWeek();
                        InputDataToMatrix( i + 1, friday, btn, i, j);
                    }
                    else if (j == 5)
                    {
                        saturday = dateTimePicker1.Value.SaturdayOfWeek();
                        InputDataToMatrix( i + 1, saturday, btn, i, j);
                    }
                    else if (j == 6)
                    {
                        sunday = dateTimePicker1.Value.LastDayOfWeek();
                        InputDataToMatrix( i + 1, sunday, btn, i, j);
                    }

                    panel1.Controls.Add(btn);
                    oldBtn = btn;
                }
                oldBtn = new Button() { Width = 0, Height = 0, Location = new Point(-Const.margin, oldBtn.Location.Y + Const.dateButtonHeight) };
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(User.userrole == "GV")
            {
                comboBox1.SelectedValue = User.userid;
                comboBox1.Enabled = false;
            }
            else
            {
                panel1.Controls.Clear();
                LoadMatrix();
            }
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            textBox1.Text = String.Format("{0:d}", dateTimePicker1.Value.FirstDayOfWeek());
            textBox2.Text = String.Format("{0:d}", dateTimePicker1.Value.TuesdayOfWeek());
            textBox3.Text = String.Format("{0:d}", dateTimePicker1.Value.WednesdayOfWeek());
            textBox4.Text = String.Format("{0:d}", dateTimePicker1.Value.ThursdayOfWeek());
            textBox5.Text = String.Format("{0:d}", dateTimePicker1.Value.FridayOfWeek());
            textBox6.Text = String.Format("{0:d}", dateTimePicker1.Value.SaturdayOfWeek());
            textBox7.Text = String.Format("{0:d}", dateTimePicker1.Value.LastDayOfWeek());

            LoadMatrix();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (User.userrole == "GV")
            {
                Login login = new Login();
                login.Show();
                this.Close();
                User.user = "";
                User.userrole = "";
            }
        }
    }
}
