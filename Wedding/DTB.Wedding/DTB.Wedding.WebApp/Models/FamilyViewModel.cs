using DTB.Wedding.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTB.Wedding.WebApp.Models
{
    public class FamilyViewModel
    {
        public static string familyCode { get; set; }
        public static Guid guestId { get; set; }
        public static List<Guest> guestsInFamily { get; set; }
    }
}
