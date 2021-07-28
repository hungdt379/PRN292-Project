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
    public partial class AssignRoomToClass : Form
    {
        List<Slot> slots;
        List<Room> rooms;
        List<Lecturer> lecturers;
        List<ClassObj> classObjs;
        public AssignRoomToClass(string roomValue)
        {
            InitializeComponent();
            LoadData(roomValue, -1);
        }

        public AssignRoomToClass(string roomValue, int slotID, DateTime time)
        {
            InitializeComponent();
            comboBoxRoom.SelectedValue = roomValue;
            
            dateTimeFrom.Value = time;
            dateTimeTo.Value = time;
            LoadData(roomValue, slotID);
        }

        void LoadData(string roomValue, int slotID)
        {
            slots = Slot.GetAll();
            comboBoxSlot.DisplayMember = "SlotName";
            comboBoxSlot.ValueMember = "SlotID";
            comboBoxSlot.DataSource = slots;
            if(slotID!=-1) comboBoxSlot.SelectedValue = slotID;

            rooms = Room.GetAllRoom();
            comboBoxRoom.DisplayMember = "RoomName";
            comboBoxRoom.ValueMember = "RoomID";
            comboBoxRoom.DataSource = rooms;
            comboBoxRoom.SelectedValue = Convert.ToInt32(roomValue);

            lecturers = Lecturer.GetAll();
            comboBoxLecturers.DisplayMember = "LecturerName";
            comboBoxLecturers.ValueMember = "LecturerID";
            comboBoxLecturers.DataSource = lecturers;

            classObjs = ClassObj.GetAll();
            comboBoxClasses.DisplayMember = "ClassName"; 
            comboBoxClasses.ValueMember = "ClassID";
            comboBoxClasses.DataSource = classObjs;

            ClassObj classObj = ClassObj.GetClassByID(Convert.ToInt32(comboBoxClasses.SelectedValue));
            if (classObj.SlotRemain == classObj.TotalSlot) txtNotification.Text = "Class has not been assigned yet";
            else txtNotification.Text = String.Format("Class assigned {0} of total {1} slots", classObj.TotalSlot - classObj.SlotRemain, classObj.TotalSlot);
            txtNotification.ForeColor = Color.Red;
            txtSlotRemain.Text = classObj.SlotRemain.ToString();

            GetCheckedCheckBox(dateTimeFrom.Value, dateTimeTo.Value);
        }

        List<string> GetCheckedCheckBox(DateTime startDate, DateTime endDate)
        {
            List<string> listDayOfWeeks = new List<string>();
            List<string> dayOfWeeks = new List<string>();

            for (DateTime dt = startDate; dt <= endDate; dt = dt.AddDays(1))
            {
                listDayOfWeeks.Add(dt.DayOfWeek.ToString());
            }

            if (listDayOfWeeks.Contains(DayOfWeek.Monday.ToString()))
            {
                checkBoxMonday.Enabled = true;
            }else checkBoxMonday.Enabled = false;
            if (checkBoxMonday.Checked)
            {
                dayOfWeeks.Add(DayOfWeek.Monday.ToString());
            }

            if (listDayOfWeeks.Contains(DayOfWeek.Tuesday.ToString()))
            {
                checkBoxTuesday.Enabled = true;
            }else checkBoxTuesday.Enabled = false;
            if (checkBoxTuesday.Checked)
            {
                dayOfWeeks.Add(DayOfWeek.Tuesday.ToString());
            }

            if (listDayOfWeeks.Contains(DayOfWeek.Wednesday.ToString()))
            {
                checkBoxWednesday.Enabled = true;
            } else checkBoxWednesday.Enabled = false;
            if (checkBoxWednesday.Checked)
            {
                dayOfWeeks.Add(DayOfWeek.Wednesday.ToString());
            }

            if (listDayOfWeeks.Contains(DayOfWeek.Thursday.ToString()))
            {
                checkBoxThursday.Enabled = true;
            } else checkBoxThursday.Enabled = false;
            if (checkBoxThursday.Checked)
            {
                dayOfWeeks.Add(DayOfWeek.Thursday.ToString());
            }

            if (listDayOfWeeks.Contains(DayOfWeek.Friday.ToString()))
            {
                checkBoxFriday.Enabled = true;
            } else checkBoxFriday.Enabled = false;
            if (checkBoxFriday.Checked)
            {
                dayOfWeeks.Add(DayOfWeek.Friday.ToString());
            }

            if (listDayOfWeeks.Contains(DayOfWeek.Saturday.ToString()))
            {
                checkBoxSaturday.Enabled = true;
            }else checkBoxSaturday.Enabled = false;
            if (checkBoxSaturday.Checked)
            {
                dayOfWeeks.Add(DayOfWeek.Saturday.ToString());
            }

            if (listDayOfWeeks.Contains(DayOfWeek.Sunday.ToString()))
            {
                checkBoxSunday.Enabled = true;
            }
            else checkBoxSunday.Enabled = false;
            if (checkBoxSunday.Checked)
            {
                dayOfWeeks.Add(DayOfWeek.Sunday.ToString());
            }
            return dayOfWeeks;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {

            List<string> listDayOfWeeks = GetCheckedCheckBox(dateTimeFrom.Value, dateTimeTo.Value);
            if (listDayOfWeeks.Count == 0) { MessageBox.Show("Check day of week"); }
            else
            {
                int classID = Convert.ToInt32(comboBoxClasses.SelectedValue);
                ClassObj classObj = ClassObj.GetClassByID(Convert.ToInt32(comboBoxClasses.SelectedValue));
                DateTime startDate = dateTimeFrom.Value;
                DateTime endDate;
                if (classObj.TotalSlot == classObj.SlotRemain)
                {
                    endDate = dateTimeTo.Value.AddDays(1);
                }
                else
                {
                    endDate = dateTimeTo.Value;
                }

                int roomID = Convert.ToInt32(comboBoxRoom.SelectedValue);
                int slotID = Convert.ToInt32(comboBoxSlot.SelectedValue);
                int lecturerID = Convert.ToInt32(comboBoxLecturers.SelectedValue);
                List<RoomAssign> roomAssigns = RoomAssign.GetAllRoomAssignFromTo(roomID, slotID, startDate, endDate);
                if (roomAssigns.Count != 0) MessageBox.Show("Room in this time had been assigned");
                else {
                    if(RoomAssign.CheckLecturersFree(lecturerID, slotID, startDate, endDate, listDayOfWeeks))
                    {
                        int count = RoomAssign.Insert(roomID, classID, lecturerID, slotID, startDate, endDate, listDayOfWeeks);
                        
                        if (classObj.StartDate != null && classObj.EndDate != null && classObj.DayOfWeeks != null && classObj.SlotStudy != null && lecturers != null)
                        {
                            lecturerID = classObj.LecturerID;
                            ClassObj.Update(classID, startDate, endDate, roomID, lecturerID);
                        }
                        else
                        {
                            ClassObj.Update(classID, startDate, endDate.AddDays(-1), roomID, lecturerID);
                        }
                        ClassObj.UpdateSlotRemain(classID, count);
                        MessageBox.Show("Assign room successful");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Lecturer does not free this time");
                    }
                    
                }

            }
        }

        private void dateTimeFrom_ValueChanged(object sender, EventArgs e)
        {
            
            ClassObj classObj = ClassObj.GetClassByID(Convert.ToInt32(comboBoxClasses.SelectedValue));
            //MessageBox.Show(classObj.StartDate.ToString());
            if (dateTimeFrom.Value.AddDays(1) < DateTime.Now && classObj.SlotRemain==classObj.TotalSlot)
            {
                MessageBox.Show("Can not choose time to start class in the past");
                dateTimeFrom.Value = DateTime.Now;
            }
            GetCheckedCheckBox(dateTimeFrom.Value, dateTimeTo.Value);
        }

        private void dateTimeTo_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimeTo.Value < dateTimeFrom.Value)
            {
                MessageBox.Show("Can not choose time to finish sooner than time to start");
                dateTimeTo.Value = dateTimeFrom.Value;
            }
            GetCheckedCheckBox(dateTimeFrom.Value, dateTimeTo.Value);
        }

        private void comboBoxClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassObj classObj = ClassObj.GetClassByID(Convert.ToInt32(comboBoxClasses.SelectedValue));
            if (classObj.SlotRemain == classObj.TotalSlot) txtNotification.Text = "Class has not been assigned yet";
            else txtNotification.Text = String.Format("Class assigned {0} of total {1} slots", classObj.TotalSlot - classObj.SlotRemain, classObj.TotalSlot);
            txtNotification.ForeColor = Color.Red;
            if (classObj.StartDate != null && classObj.EndDate != null && classObj.DayOfWeeks != null && classObj.SlotStudy != null && lecturers != null)
            {
                comboBoxRoom.SelectedValue = classObj.RoomID;
                dateTimeFrom.Value = classObj.StartDate;
                dateTimeTo.Value = classObj.EndDate.AddDays(-1);
                comboBoxRoom.SelectedValue = classObj.RoomID;
                comboBoxLecturers.SelectedValue = classObj.LecturerID;
            }
            else
            {
                comboBoxRoom.SelectedIndex = 0;
                dateTimeFrom.Value = DateTime.Now;
                dateTimeTo.Value = DateTime.Now;
                comboBoxLecturers.SelectedIndex = 0;
            }
            txtSlotRemain.Text = classObj.SlotRemain.ToString();
        }
    }
}
