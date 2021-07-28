using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using AssignRoom.DataAccess;

namespace AssignRoom.Logic
{
    class Room
    {
        public int RoomID { get; set; }
        public string RoomName { get; set; }

        public static List<Room> GetAllRoom()
        {
            List<Room> rooms = new List<Room>();
            DataTable dt = DAO.GetAllRoom();
            foreach (DataRow dr in dt.Rows)
            {
                Room room = new Room();
                room.RoomID = Convert.ToInt32(dr["RoomID"]);
                room.RoomName = dr["RoomName"].ToString();
                rooms.Add(room);
            }
            return rooms;
        }
    }
}
