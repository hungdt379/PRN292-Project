using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using AssignRoom.DataAccess;

namespace AssignRoom.Logic
{
    class ClassObj
    {
        public int ClassID { get; set; }

        public string ClassName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string DayOfWeeks { get; set; }

        public int RoomID { get; set; }

        public string SlotStudy { get; set; }

        public int TotalSlot { get; set; }

        public int SlotRemain { get; set; }

        public int LecturerID { get; set; }

        public static List<ClassObj> GetAll()
        {
            List<ClassObj> classObjs = new List<ClassObj>();
            DataTable dt = DAO.GetAllClassObj();
            foreach (DataRow dr in dt.Rows)
            {
                ClassObj classObj = new ClassObj();
                classObj.ClassID = Convert.ToInt32(dr["ClassID"]);
                classObj.ClassName = dr["ClassName"].ToString();
                classObj.TotalSlot = Convert.ToInt32(dr["TotalSlot"]);
                classObj.SlotRemain = Convert.ToInt32(dr["SlotRemain"]);
                classObjs.Add(classObj);
            }
            return classObjs;
        }

        public static int Update(int classID, DateTime startDate, DateTime endDate, int roomID, int lecturerID)
        {
            List<string> listOfSlotStudy = new List<string>();
            List<string> listOfDayOfWeek = new List<string>();
            DataTable dt = DAO.GetDayOfWeekAndSlotStudyFromClassAssign(classID);
            foreach(DataRow dr in dt.Rows)
            {
                if (!listOfDayOfWeek.Contains(Convert.ToDateTime(dr["Time"]).DayOfWeek.ToString())) listOfDayOfWeek.Add(Convert.ToDateTime(dr["Time"]).DayOfWeek.ToString());
                if (!listOfSlotStudy.Contains(dr["SlotID"].ToString())) listOfSlotStudy.Add(dr["SlotID"].ToString()); 
            }

            string dayOfWeeks = "";
            for (int i = 0; i < listOfDayOfWeek.Count; i++)
            {
                dayOfWeeks += listOfDayOfWeek[i];
                if (i != listOfDayOfWeek.Count - 1) dayOfWeeks += ", ";
            }

            string slotStudy = "";
            for (int i = 0; i < listOfSlotStudy.Count; i++)
            {
                slotStudy += listOfSlotStudy[i];
                if (i != listOfSlotStudy.Count - 1) slotStudy += ", ";
            }

            return DAO.UpdateClassObj(classID, startDate, endDate, dayOfWeeks, roomID, slotStudy, lecturerID);
        }

        public static ClassObj GetClassByID(int classID)
        {
            ClassObj classObj = new ClassObj();
            DataTable dt = DAO.GetClassObjByID(classID);
            foreach (DataRow dr in dt.Rows)
            {
                classObj.ClassID = Convert.ToInt32(dr["ClassID"]);
                classObj.ClassName = dr["ClassName"].ToString();

                if (!(dr["StartDate"] is DBNull) && !(dr["EndDate"] is DBNull) && !(dr["RoomID"] is DBNull) && !(dr["DayOfWeeks"] is DBNull) && !(dr["SlotStudy"] is DBNull) && !(dr["LecturerID"] is DBNull))
                {
                    classObj.StartDate = Convert.ToDateTime(dr["StartDate"]);
                    classObj.EndDate = Convert.ToDateTime(dr["EndDate"]);
                    classObj.RoomID = Convert.ToInt32(dr["RoomID"]);
                    classObj.DayOfWeeks = dr["DayOfWeeks"].ToString();
                    classObj.SlotStudy = dr["SlotStudy"].ToString();
                    classObj.LecturerID = Convert.ToInt32(dr["LecturerID"]);
                }

                classObj.TotalSlot = Convert.ToInt32(dr["TotalSlot"]);
                classObj.SlotRemain = Convert.ToInt32(dr["SlotRemain"]);
                
            }
            return classObj;
        }

        public static void UpdateSlotRemain(int classID, int count)
        {
            DAO.UpdateSlotRemain(classID, count);
        }
    }
}
