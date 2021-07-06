using System;
using System.Collections.Generic;
using System.Text;

namespace DTB.Wedding.PL
{
    public partial class TblFamily
    {

        public TblFamily()
        {
            TblGuests = new HashSet<TblGuest>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<TblGuest> TblGuests { get; set; }
    }
}
