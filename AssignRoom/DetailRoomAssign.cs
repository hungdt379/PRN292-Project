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
    public partial class DetailRoomAssign : Form
    {
        public DetailRoomAssign(int roomID, int slotID, DateTime time)
        {
            InitializeComponent();
            RoomAssign roomAssign = RoomAssign.GetRoomAssign(roomID, slotID, time);
            txtRoomName.Text = roomAssign.Room.RoomName;
            txtLecturerName.Text = roomAssign.Lecturer.LecturerName;
            txtSlotName.Text = roomAssign.Slot.SlotName;
            txtClassName.Text = roomAssign.ClassObj.ClassName;
            txtDayOfWeek.Text = roomAssign.ClassObj.DayOfWeeks;
            txtStartDate.Text = String.Format("{0:d}", roomAssign.ClassObj.StartDate);
            txtEndDate.Text = String.Format("{0:d}", roomAssign.ClassObj.EndDate);
            txtTime.Text = String.Format("{0:D}", roomAssign.Time);
            txtSlotStudy.Text = roomAssign.ClassObj.SlotStudy;
            RoomAssignID.Text = roomAssign.ID.ToString();
            RoomAssignID.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeDateRoom changeDateRoom = new ChangeDateRoom(Convert.ToInt32(RoomAssignID.Text));
            changeDateRoom.Show();
        }
    }
}
