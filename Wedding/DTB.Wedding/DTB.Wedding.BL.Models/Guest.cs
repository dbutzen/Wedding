using System;
using System.Collections.Generic;
using System.Text;

namespace DTB.Wedding.BL.Models
{
    public class Guest
    {
        private Guid id;

        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        private Guid familyId;

        public Guid FamilyId
        {
            get { return familyId; }
            set { familyId = value; }
        }

        private Guid tableId;

        public Guid TableId
        {
            get { return tableId; }
            set { tableId = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private bool plusOne;

        public bool PlusOne
        {
            get { return plusOne; }
            set { plusOne = value; }
        }

        private bool attendance;

        public bool Attendance
        {
            get { return attendance; }
            set { attendance = value; }
        }

        private bool plusOneAttendance;

        public bool PlusOneAttendance
        {
            get { return plusOneAttendance; }
            set { plusOneAttendance = value; }
        }

        private bool responded;

        public bool Responded
        {
            get { return responded; }
            set { responded = value; }
        }


    }
}
