using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AssignRoom.Logic;

namespace AssignRoom
{
    public partial class ListRoom : Form
    {
        List<Room> rooms;

        DateTime monday;
        DateTime tuesday;
        DateTime wednesday;
        DateTime thursday;
        DateTime friday;
        DateTime saturday;
        DateTime sunday;

        public ListRoom()
        {
            InitializeComponent();
            LoadData();
            LoadMatrix();
            LoadDayOfWeek();
        }

        void LoadData()
        {
            txtUser.Text = String.Format("User:{0}",User.user);
            txtRole.Text = String.Format("Role:{0}", User.userrole);
            rooms = Room.GetAllRoom();
            comboBox1.DisplayMember = "RoomName";
            comboBox1.ValueMember = "RoomID";
            comboBox1.DataSource = rooms;
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

        void InputDataToMatrix(int roomID, int slotID, DateTime time, Button button, int i, int j)
        {
            RoomAssign room = RoomAssign.GetRoomAssign(roomID, slotID, time);
            if(room.ID != 0)
            {
                button.Text = room.ClassObj.ClassName + "\n" + room.Lecturer.LecturerName;
                button.BackColor = Color.FromArgb(154, 255, 154);
                button.Click += button_Click;
            }
            else
            {
                button.Text = "Unassign";
                button.BackColor = Color.FromArgb(255, 106, 106);
                button.Click += button_Click;
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Matrix matrix = Matrix.GetOne(button.Location.X, button.Location.Y);
            int i = matrix.ISlotOfColumn;
            int j = matrix.JDayOfWeek;
            int slotID = 0;
            DateTime dayOfWeek = DateTime.Now;
            if (i > -1 && i < 7) slotID = i + 1;
            if (j == 0) dayOfWeek = monday;
            if (j == 1) dayOfWeek = tuesday;
            if (j == 2) dayOfWeek = wednesday;
            if (j == 3) dayOfWeek = thursday;
            if (j == 4) dayOfWeek = friday;
            if (j == 5) dayOfWeek = saturday;
            if (j == 6) dayOfWeek = sunday;

            if(button.BackColor == Color.FromArgb(154, 255, 154))
            {
                DetailRoomAssign detailRoomAssign = new DetailRoomAssign(Convert.ToInt32(comboBox1.SelectedValue), slotID, dayOfWeek);
                detailRoomAssign.Show();
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
                        InputDataToMatrix(Convert.ToInt32(comboBox1.SelectedValue), i + 1, monday, btn, i,j);
                    }
                    else if (j == 1)
                    {
                        tuesday = dateTimePicker1.Value.TuesdayOfWeek();
                        InputDataToMatrix(Convert.ToInt32(comboBox1.SelectedValue), i + 1, tuesday, btn, i, j);
                    }
                    else if (j == 2)
                    {
                        wednesday = dateTimePicker1.Value.WednesdayOfWeek();
                        InputDataToMatrix(Convert.ToInt32(comboBox1.SelectedValue), i + 1, wednesday, btn, i, j);
                    }
                    else if (j == 3)
                    {
                        thursday = dateTimePicker1.Value.ThursdayOfWeek();
                        InputDataToMatrix(Convert.ToInt32(comboBox1.SelectedValue), i + 1, thursday, btn, i, j);
                    }
                    else if (j == 4)
                    {
                        friday = dateTimePicker1.Value.FridayOfWeek();
                        InputDataToMatrix(Convert.ToInt32(comboBox1.SelectedValue), i + 1, friday, btn, i, j);
                    }
                    else if (j == 5)
                    {
                        saturday = dateTimePicker1.Value.SaturdayOfWeek();
                        InputDataToMatrix(Convert.ToInt32(comboBox1.SelectedValue), i + 1, saturday, btn, i, j);
                    }
                    else if (j == 6)
                    {
                        sunday = dateTimePicker1.Value.LastDayOfWeek();
                        InputDataToMatrix(Convert.ToInt32(comboBox1.SelectedValue), i + 1, sunday, btn, i, j);
                    }

                    panel1.Controls.Add(btn);
                    oldBtn = btn;
                }
                oldBtn = new Button() { Width = 0, Height = 0, Location = new Point(-Const.margin, oldBtn.Location.Y + Const.dateButtonHeight) };
            }
        }

       

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
            User.user = "";
            User.userrole = "";

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

        private void btnAssign_Click(object sender, EventArgs e)
        {
            AssignRoomToClass assign = new AssignRoomToClass(comboBox1.SelectedValue.ToString());
            assign.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            LoadMatrix();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LecturerShedule lecturerShedule = new LecturerShedule();
            lecturerShedule.Show();
        }
    }
}
