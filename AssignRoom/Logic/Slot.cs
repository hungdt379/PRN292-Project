using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using AssignRoom.DataAccess;

namespace AssignRoom.Logic
{
    class Slot
    {
        public int SlotID { get; set; }

        public string SlotName { get; set; }

        public static List<Slot> GetAll()
        {
            List<Slot> slots = new List<Slot>();
            DataTable dt = DAO.GetAllSlot();
            foreach (DataRow dr in dt.Rows)
            {
                Slot slot = new Slot();
                slot.SlotID = Convert.ToInt32(dr["SlotID"]);
                slot.SlotName = dr["SlotName"].ToString();
                slots.Add(slot);
            }
            return slots;
        }
    }
}
