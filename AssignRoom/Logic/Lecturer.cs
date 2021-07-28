using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using AssignRoom.DataAccess;

namespace AssignRoom.Logic
{
    class Lecturer
    {
        public int LecturerID { get; set; }

        public string LecturerName { get; set; }

        public int UserID { get; set; }

        public static List<Lecturer> GetAll()
        {
            List<Lecturer> lecturers = new List<Lecturer>();
            DataTable dt = DAO.GetAllLecturer();
            foreach (DataRow dr in dt.Rows)
            {
                Lecturer lecturer = new Lecturer();
                lecturer.LecturerID = Convert.ToInt32(dr["LecturerID"]);
                lecturer.LecturerName = dr["LecturerName"].ToString();
                lecturer.UserID = Convert.ToInt32(dr["UserID"]);
                lecturers.Add(lecturer);
            }
            return lecturers;
        }
    }
}
