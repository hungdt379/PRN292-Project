using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using AssignRoom.DataAccess;

namespace AssignRoom.Logic
{
    class RoomAssign
    {
        public int ID { get; set; }

        public int RoomID { get; set; }

        public int ClassID { get; set; }

        public int LecturerID { get; set; }

        public int SlotID { get; set; }

        public DateTime Time { get; set; }

        public ClassObj ClassObj { get; set; }

        public Room Room { get; set; }

        public Lecturer Lecturer { get; set; }

        public Slot Slot { get; set; }

        public int ButtonLocationI { get; set; }

        public int ButtonLocationJ { get; set; }

        public static bool CheckLecturersFree(int lecturerID, int slotID, DateTime startDate, DateTime endDate, List<string> dayOfWeeks)
        {
            List<DateTime> dates = new List<DateTime>();
            for (DateTime dt = startDate; dt <= endDate; dt = dt.AddDays(1))
            {
                if (dayOfWeeks.Contains(dt.DayOfWeek.ToString())) dates.Add(dt);
            }

            bool check = true;
            foreach(DateTime dt in dates)
            {
                DataTable data = DAO.GetAllLecturerSchedule(lecturerID, slotID, dt);
                if (data.Rows.Count > 0)
                {
                    check = false;
                    break;
                }
            }
            if (check == true)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public static int Insert(int roomID, int classID, int lecturerID, int slotID, DateTime startDate, DateTime endDate, List<string> dayOfWeeks)
        {
            List<DateTime> dates = new List<DateTime>();
            for (DateTime dt = startDate; dt <= endDate; dt = dt.AddDays(1))
            {
                if(dayOfWeeks.Contains(dt.DayOfWeek.ToString())) dates.Add(dt);
            }

            DataTable dataTable = DAO.GetClassObjByID(classID);
            int slotRemain = 0;
            foreach(DataRow dr in dataTable.Rows)
            {
                slotRemain = Convert.ToInt32(dr["SlotRemain"]);
            }

            if(slotRemain >= dates.Count)
            {
                foreach (DateTime dt in dates)
                {
                    DAO.InsertRoomAssign(roomID, classID, lecturerID, slotID, dt);
                }
                return dates.Count;
            }
            else
            {
                for(int i = 0; i < slotRemain; i++)
                {
                    DAO.InsertRoomAssign(roomID, classID, lecturerID, slotID, dates[i]);
                }
                return slotRemain;
            }
        }

        public static void UpdateDateTimeRoom(int roomAssignID, int roomID, int slotID, DateTime time)
        {
            DAO.UpdateRoomAssignDateTimeRoom(roomAssignID, roomID, slotID, time);
        }

        public static RoomAssign GetLecturerScheduleFromRoomAssign(int slotID, int lecturerID, DateTime time)
        {
            RoomAssign roomAssign = new RoomAssign();
            ClassObj classObj = new ClassObj();
            Lecturer lecturer = new Lecturer();
            Room room = new Room();
            DataTable dt = DAO.GetAllLecturerSchedule(lecturerID, slotID, time);
            foreach (DataRow dr in dt.Rows)
            {
                roomAssign.ID = Convert.ToInt32(dr["ID"]);

                room.RoomName = dr["RoomName"].ToString();
                roomAssign.Room = room;

                classObj.ClassName = dr["ClassName"].ToString();
                classObj.DayOfWeeks = dr["DayOfWeeks"].ToString();
                classObj.SlotStudy = dr["SlotStudy"].ToString();
                classObj.StartDate = Convert.ToDateTime(dr["StartDate"]);
                classObj.EndDate = Convert.ToDateTime(dr["EndDate"]);
                roomAssign.ClassObj = classObj;

                roomAssign.Time = Convert.ToDateTime(dr["Time"]);
            }
            return roomAssign;
        }

        public static List<RoomAssign> GetAllRoomAssignFromTo(int roomID, int slotID, DateTime startDate, DateTime endDate)
        {
            List<RoomAssign> roomAssigns = new List<RoomAssign>();
            DataTable dt = DAO.GetAllRoomAssignFromTo(roomID, slotID, startDate, endDate);
            foreach (DataRow dr in dt.Rows)
            {
               RoomAssign roomAssign = new RoomAssign();
                roomAssign.ID = Convert.ToInt32(dr["ID"]);
                roomAssign.RoomID = Convert.ToInt32(dr["RoomID"]);
                roomAssign.ClassID = Convert.ToInt32(dr["ClassID"]);
                roomAssign.LecturerID = Convert.ToInt32(dr["LecturerID"]);
                roomAssign.SlotID = Convert.ToInt32(dr["SlotID"]);
                roomAssign.Time = Convert.ToDateTime(dr["Time"]);
                roomAssigns.Add(roomAssign);
            }
            return roomAssigns;
        }


        public static RoomAssign GetRoomAssign(int roomID, int slotID, DateTime time)
        {
            RoomAssign roomAssign = new RoomAssign();
            ClassObj classObj = new ClassObj();
            Lecturer lecturer = new Lecturer();
            Room room = new Room();
            Slot slot = new Slot();
            DataTable dt = DAO.GetRoomAssign(roomID, slotID, time);
            foreach (DataRow dr in dt.Rows)
            {
                roomAssign.ID = Convert.ToInt32(dr["ID"]);

                room.RoomName = dr["RoomName"].ToString();
                roomAssign.Room = room;

                lecturer.LecturerName = dr["LecturerName"].ToString();
                roomAssign.Lecturer = lecturer;

                slot.SlotName = dr["SlotName"].ToString();
                roomAssign.Slot = slot;

                classObj.ClassName = dr["ClassName"].ToString();
                classObj.DayOfWeeks = dr["DayOfWeeks"].ToString();
                classObj.SlotStudy = dr["SlotStudy"].ToString();
                if(!(dr["StartDate"] is DBNull) && !(dr["EndDate"] is DBNull))
                {
                    classObj.StartDate = Convert.ToDateTime(dr["StartDate"]);
                    classObj.EndDate = Convert.ToDateTime(dr["EndDate"]);
                }
                
                roomAssign.ClassObj = classObj;
                
                roomAssign.Time = Convert.ToDateTime(dr["Time"]);
            }
            return roomAssign;
        }


        public static RoomAssign GetRoomAssignByID(int roomAssignID)
        {
            RoomAssign roomAssign = new RoomAssign();
            ClassObj classObj = new ClassObj();
            Lecturer lecturer = new Lecturer();
            DataTable dt = DAO.GetRoomAssignByID(roomAssignID);
            foreach (DataRow dr in dt.Rows)
            {
                roomAssign.ID = Convert.ToInt32(dr["ID"]);
                roomAssign.RoomID = Convert.ToInt32(dr["RoomID"]);

                lecturer.LecturerID = Convert.ToInt32(dr["LecturerID"]);
                lecturer.LecturerName = dr["LecturerName"].ToString();
                roomAssign.Lecturer = lecturer;

                classObj.ClassName = dr["ClassName"].ToString();
                classObj.StartDate = Convert.ToDateTime(dr["StartDate"]);
                classObj.EndDate = Convert.ToDateTime(dr["EndDate"]);
                roomAssign.ClassObj = classObj;

                roomAssign.SlotID = Convert.ToInt32(dr["SlotID"]);
                roomAssign.Time = Convert.ToDateTime(dr["Time"]);
            }
            return roomAssign;
        }
    }
}
