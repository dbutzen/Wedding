using System;
using System.Collections.Generic;
using System.Text;

namespace DTB.Wedding.PL
{
    public partial class TblTable
    {
        public TblTable()
        {
            TblGuests = new HashSet<TblGuest>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int NumberChairs { get; set; }

        public virtual ICollection<TblGuest> TblGuests { get; set; }
        
    }
}
