using DTB.Wedding.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTB.Wedding.WebApp.ViewModels
{
    public class GuestFamilyTableViewModel
    {
        public Guid Id { get; set; }
        public Guest Guest { get; set; }
        public List<Family> Families { get; set; }
        public List<Table> Tables { get; set; }
    }
}
