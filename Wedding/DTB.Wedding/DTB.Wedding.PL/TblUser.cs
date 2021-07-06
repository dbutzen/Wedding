using System;
using System.Collections.Generic;
using System.Text;

namespace DTB.Wedding.PL
{
    public partial class TblUser
    {
        public TblUser()
        {

        }

        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid UniqueKey { get; set; }
        public Guid? SessionKey { get; set; }
    }
}
