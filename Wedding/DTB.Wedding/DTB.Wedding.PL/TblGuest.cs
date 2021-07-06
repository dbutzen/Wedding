using System;
using System.Collections.Generic;
using System.Text;

namespace DTB.Wedding.PL
{
    public partial class TblGuest
    {

        public TblGuest()
        {
            
        }

        public Guid Id { get; set; }
        public Guid FamilyId { get; set; }
        public Guid TableId { get; set; }
        public string Name { get; set; }
        public bool PlusOne { get; set; }
        public bool Attendance { get; set; }
        public bool PlusOneAttendance { get; set; }
        public bool Responded { get; set; }

        public virtual TblFamily Family { get; set; }
        public virtual TblTable Table { get; set; }
    }
}
