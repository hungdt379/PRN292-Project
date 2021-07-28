using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using AssignRoom.DataAccess;

namespace AssignRoom.Logic
{
    class Matrix
    {
        public int ID { get; set; }

        public int ButtonLocationI { get; set; }

        public int ButtonLocationJ { get; set; }

        public int ISlotOfColumn { get; set; }

        public int JDayOfWeek { get; set; }

        public static void Insert(int buttonLocationI, int buttonLocationJ, int iSlotOfColumn, int jDayOfWeek)
        {
            DAO.InsertButtonLocation(buttonLocationI, buttonLocationJ, iSlotOfColumn, jDayOfWeek);
        }

        public static Matrix GetOne(int buttonLocationI, int buttonLocationJ)
        {
            DataTable dt = DAO.GetOneMatrix(buttonLocationI, buttonLocationJ);
            Matrix matrix = new Matrix();
            foreach (DataRow dr in dt.Rows)
            {
                matrix.ID = Convert.ToInt32(dr["ID"]);
                matrix.ButtonLocationI = Convert.ToInt32(dr["ButtonLocationI"]);
                matrix.ButtonLocationJ = Convert.ToInt32(dr["ButtonLocationJ"]);
                matrix.ISlotOfColumn = Convert.ToInt32(dr["ISlotOfColumn"]);
                matrix.JDayOfWeek = Convert.ToInt32(dr["JDayOfWeek"]);
            }
            return matrix;
        }
    }
}
