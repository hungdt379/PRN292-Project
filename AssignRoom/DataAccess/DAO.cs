using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;

namespace AssignRoom.DataAccess
{
    class DAO
    {
        public static SqlConnection GetConnection()
        {
            string ConStr = ConfigurationManager.ConnectionStrings["DBName"].ToString();
            //string ConStr = "server=DESKTOP-CL9UIGQ;database=PRN292_Demo;Integrated Security = true";
            return new SqlConnection(ConStr);
        }

        public static DataTable GetDataBySql(string sql)
        {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(ds); // thuc thi sql la du lieu fill vao data set
            return ds.Tables[0];
        }


        public static DataTable GetDataBySqlParameter(string sql, SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            command.Parameters.AddRange(parameters);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(ds); // thuc thi sql la du lieu fill vao data set
            return ds.Tables[0];
        }

        public static int ExecuteSQL(string sql, SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            command.Connection.Open();
            command.Parameters.AddRange(parameters);
            int k = command.ExecuteNonQuery();
            command.Connection.Close();
            return k;
        }

        // table users
        public static DataTable Login(string username, string password)
        {
            string sql = "select * from users where username = @username and password = @password";
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@username", SqlDbType.NVarChar);
            parameters[0].Value = username;
            parameters[1] = new SqlParameter("@password", SqlDbType.NVarChar);
            parameters[1].Value = password;
            return GetDataBySqlParameter(sql, parameters);
        }


        //table rooms
        public static DataTable GetAllRoom()
        {
            string sql = "select * from Rooms ";
            return GetDataBySql(sql);
        }

        //table slot
        public static DataTable GetAllSlot()
        {
            string sql = "select * from Slots ";
            return GetDataBySql(sql);
        }

        //table lecturer
        public static DataTable GetAllLecturer()
        {
            string sql = "select * from Lecturers ";
            return GetDataBySql(sql);
        }


        //table classes
        public static DataTable GetAllClassObj()
        {
            string sql = "select * from Classes where SlotRemain > 0";
            return GetDataBySql(sql);
        }

        public static DataTable GetClassObjByID(int classID)
        {
            string sql = "select * from Classes where ClassID = @classID";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@classID", SqlDbType.Int);
            parameters[0].Value = classID;
            return GetDataBySqlParameter(sql, parameters);
        }


        public static int UpdateClassObj(int classID, DateTime startDate, DateTime endDate, string dayOfWeeks, int roomID, string slotStudy, int lecturerID)
        {
            string sql = "update Classes set StartDate=@startDate, EndDate=@endDate, DayOfWeeks=@dayOfWeeks, RoomID=@roomID, SlotStudy=@slotStudy, LecturerID=@lecturerID where ClassID=@classID";
            SqlParameter[] parameters = new SqlParameter[7];
            parameters[0] = new SqlParameter("@startDate", SqlDbType.Date);
            parameters[0].Value = startDate;
            parameters[1] = new SqlParameter("@endDate", SqlDbType.NVarChar);
            parameters[1].Value = endDate;
            parameters[2] = new SqlParameter("@dayOfWeeks", SqlDbType.NVarChar);
            parameters[2].Value = dayOfWeeks;
            parameters[3] = new SqlParameter("@roomID", SqlDbType.Int);
            parameters[3].Value = roomID;
            parameters[4] = new SqlParameter("@slotStudy", SqlDbType.NVarChar);
            parameters[4].Value = slotStudy;
            parameters[5] = new SqlParameter("@lecturerID", SqlDbType.Int);
            parameters[5].Value = lecturerID;
            parameters[6] = new SqlParameter("@classID", SqlDbType.Int);
            parameters[6].Value = classID;
            return ExecuteSQL(sql, parameters);
        }

        public static void UpdateSlotRemain(int classID, int count)
        {
            string sql = "update classes set SlotRemain = SlotRemain - @count where ClassID = @classID";
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@count", SqlDbType.Int);
            parameters[0].Value = count;
            parameters[1] = new SqlParameter("@classID", SqlDbType.Int);
            parameters[1].Value = classID;
            ExecuteSQL(sql, parameters);
        }

        // table roomassign
        public static void InsertRoomAssign(int roomID, int classID, int lecturerID, int slotID, DateTime time)
        {
            string sql = "insert into RoomAssign (RoomID, ClassID, LecturerID, SlotID, Time) values(@roomID, @classID, @lecturerID, @slotID, @time)";
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@roomID", SqlDbType.Int);
            parameters[0].Value = roomID;
            parameters[1] = new SqlParameter("@classID", SqlDbType.Int);
            parameters[1].Value = classID;
            parameters[2] = new SqlParameter("@lecturerID", SqlDbType.Int);
            parameters[2].Value = lecturerID;
            parameters[3] = new SqlParameter("@slotID", SqlDbType.Int);
            parameters[3].Value = slotID;
            parameters[4] = new SqlParameter("@time", SqlDbType.Date);
            parameters[4].Value = time;
            ExecuteSQL(sql, parameters);
        }


        public static void UpdateRoomAssignDateTimeRoom(int roomAssignID, int roomID, int slotID, DateTime time)
        {
            string sql = "update RoomAssign set RoomID=@roomID, SlotID=@slotID, Time=@time where ID=@roomAssignID";
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@roomID", SqlDbType.Int);
            parameters[0].Value = roomID;
            parameters[1] = new SqlParameter("@slotID", SqlDbType.Int);
            parameters[1].Value = slotID;
            parameters[2] = new SqlParameter("@time", SqlDbType.Date);
            parameters[2].Value = time;
            parameters[3] = new SqlParameter("@roomAssignID", SqlDbType.Int);
            parameters[3].Value = roomAssignID;
            ExecuteSQL(sql, parameters);
        }

        public static DataTable GetAllRoomAssignFromTo(int roomID, int slotID, DateTime startDate, DateTime endDate)
        {
            string sql = "select * from RoomAssign where RoomID=@roomID and SlotID=@slotID and Time BETWEEN @startDate AND @endDate";
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@roomID", SqlDbType.Int);
            parameters[0].Value = roomID;
            parameters[1] = new SqlParameter("@slotID", SqlDbType.Int);
            parameters[1].Value = slotID;
            parameters[2] = new SqlParameter("@startDate", SqlDbType.Date);
            parameters[2].Value = startDate;
            parameters[3] = new SqlParameter("@endDate", SqlDbType.Date);
            parameters[3].Value = endDate;
            return GetDataBySqlParameter(sql, parameters);
        }

        public static DataTable GetRoomAssignByID(int roomAssignID)
        {
            string sql = " select ra.ID, ra.SlotID, ra.RoomID ,ra.Time, L.LecturerID ,L.LecturerName ,c.ClassName, c.StartDate, c.EndDate from "
                         + " (select * from RoomAssign where ID = @roomAssignID) as ra "
                         + " inner join Classes as c on c.ClassID = ra.ClassID "
                         +" inner join Lecturers as L on L.LecturerID = ra.LecturerID";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@roomAssignID", SqlDbType.Int);
            parameters[0].Value = roomAssignID;
            return GetDataBySqlParameter(sql, parameters);

        }

        public static DataTable GetRoomAssign(int roomID, int slotID, DateTime time)
        {
            string sql = "select ra.ID, r.RoomName, l.LecturerName, s.SlotName, c.ClassName , c.DayOfWeeks, c.SlotStudy ,ra.Time, c.StartDate, c.EndDate "
                        + " from RoomAssign RA "
                        + " inner join Classes c on c.ClassID = ra.ClassID "
                        + " inner join Lecturers l on l.LecturerID = ra.LecturerID "
                        + " inner join Rooms r on r.RoomID = RA.RoomID "
                        + " inner join Slots s on s.SlotID = RA.SlotID "
                        + " where ra.RoomID=@roomID and ra.SlotID=@slotID and ra.Time=@time";
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@roomID", SqlDbType.Int);
            parameters[0].Value = roomID;
            parameters[1] = new SqlParameter("@slotID", SqlDbType.Int);
            parameters[1].Value = slotID;
            parameters[2] = new SqlParameter("@time", SqlDbType.Date);
            parameters[2].Value = time;
            return GetDataBySqlParameter(sql, parameters);
        }

        public static DataTable GetDayOfWeekAndSlotStudyFromClassAssign(int classID)
        {
            string sql = "select * from RoomAssign where ClassID = @classID";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@classID", SqlDbType.Int);
            parameters[0].Value = classID;
            return GetDataBySqlParameter(sql, parameters);
        }


        public static DataTable GetAllLecturerSchedule(int lecturerID, int slotID, DateTime time)
        {
            string sql = "select ra.ID, ra.Time, c.ClassName, c.StartDate, c.EndDate, c.DayOfWeeks, c.SlotStudy, r.RoomName from "
                        + " (select * from RoomAssign where lecturerID = @lecturerID and SlotID=@slotID and Time=@time) as ra "
                        + " inner join Classes as c on c.ClassID = ra.ClassID "
                        + " inner join Rooms as r  on r.RoomID=ra.RoomID ";
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@lecturerID", SqlDbType.Int);
            parameters[0].Value = lecturerID;
            parameters[1] = new SqlParameter("@slotID", SqlDbType.Int);
            parameters[1].Value = slotID;
            parameters[2] = new SqlParameter("@time", SqlDbType.Date);
            parameters[2].Value = time;
            return GetDataBySqlParameter(sql, parameters);
        }

        // table matrix
        public static void InsertButtonLocation(int buttonLocationI, int buttonLocationJ, int iSlotOfColumn, int jDayOfWeek)
        {
            string sql = "insert into Matrix (ButtonLocationI, ButtonLocationJ, ISlotOfColumn, JDayOfWeek) values (@buttonLocationI, @buttonLocationJ, @iSlotOfColumn, @jDayOfWeek)";
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@buttonLocationI", SqlDbType.Int);
            parameters[0].Value = buttonLocationI;
            parameters[1] = new SqlParameter("@buttonLocationJ", SqlDbType.Int);
            parameters[1].Value = buttonLocationJ;
            parameters[2] = new SqlParameter("@iSlotOfColumn", SqlDbType.Int);
            parameters[2].Value = iSlotOfColumn;
            parameters[3] = new SqlParameter("@jDayOfWeek", SqlDbType.Int);
            parameters[3].Value = jDayOfWeek;
            ExecuteSQL(sql, parameters);
        }


        public static DataTable GetOneMatrix(int buttonLocationI, int buttonLocationJ)
        {
            string sql = "select * from Matrix where buttonLocationI=@buttonLocationI and buttonLocationJ=@buttonLocationJ";
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@buttonLocationI", SqlDbType.Int);
            parameters[0].Value = buttonLocationI;
            parameters[1] = new SqlParameter("@buttonLocationJ", SqlDbType.Int);
            parameters[1].Value = buttonLocationJ;
            return GetDataBySqlParameter(sql, parameters);
        }

    }
}
