using DTB.Wedding.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTB.Wedding.WebApp.ViewModels
{
    public class FamilyGuestViewModel
    {
        public Guid id { get; set; }
        public Family family { get; set; }
        public List<Guest> guests { get; set; }

    }
}
