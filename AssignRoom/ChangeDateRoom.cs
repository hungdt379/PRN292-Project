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
    public partial class ChangeDateRoom : Form
    {
        RoomAssign roomAssign;
        public ChangeDateRoom(int roomAssignID)
        {
            InitializeComponent();
            roomAssign = RoomAssign.GetRoomAssignByID(roomAssignID);
            txtClass.Text = roomAssign.ClassObj.ClassName;
            txtLecturer.Text = roomAssign.Lecturer.LecturerName;
            txtStartDate.Text = String.Format("{0:d}", roomAssign.ClassObj.StartDate);
            txtEndDate.Text = String.Format("{0:d}", roomAssign.ClassObj.EndDate);
            dateTimePicker1.Value = roomAssign.Time;
            RoomAssignID.Text = roomAssign.ID.ToString();
            RoomAssignID.Hide();
            txtLecturerID.Text = roomAssign.Lecturer.LecturerID.ToString();
            txtLecturerID.Hide();

            List<Slot> slots = Slot.GetAll();
            comboBoxSlot.DisplayMember = "SlotName";
            comboBoxSlot.ValueMember = "SlotID";
            comboBoxSlot.DataSource = slots;
            comboBoxSlot.SelectedValue = roomAssign.SlotID;

            List<Room> rooms = Room.GetAllRoom();
            comboBoxRoom.DisplayMember = "RoomName";
            comboBoxRoom.ValueMember = "RoomID";
            comboBoxRoom.DataSource = rooms;
            comboBoxRoom.SelectedValue = roomAssign.RoomID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int roomAssignID = Convert.ToInt32(RoomAssignID.Text);
            int roomID = Convert.ToInt32(comboBoxRoom.SelectedValue);
            int slotID = Convert.ToInt32(comboBoxSlot.SelectedValue);
            DateTime time = dateTimePicker1.Value;

            if (time < roomAssign.ClassObj.StartDate || time > roomAssign.ClassObj.EndDate)
            {
                MessageBox.Show("Time must be between start date and end date");
            }
            else
            {

                List<RoomAssign> roomAssigns = RoomAssign.GetAllRoomAssignFromTo(roomID, slotID, time, time);
                if (roomAssigns.Count != 0) MessageBox.Show("Room in this time had been assigned");
                else
                {
                    List<string> listDayOfWeeks = new List<string>();
                    listDayOfWeeks.Add(time.DayOfWeek.ToString());
                    if (RoomAssign.CheckLecturersFree(Convert.ToInt32(txtLecturerID.Text), slotID, time, time, listDayOfWeeks))
                    {
                        RoomAssign.UpdateDateTimeRoom(roomAssignID, roomID, slotID, time);
                        MessageBox.Show("Change date time successful");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Lecturer does not free this time");
                    }
                }

            }
        }
    }
}
