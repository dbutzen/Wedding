using DTB.Wedding.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTB.Wedding.WebApp.ViewModels
{
    public class WeddingViewModel
    {
        public Guid Id { get; set; }
        public List<FamilyGuestViewModel> families { get; set; }
        public int TotalGuests { get; set; }
        public int GuestsResponded { get; set; }
        public int PercentResponded
        {
            get
            {
                return Convert.ToInt32(GuestsResponded / TotalGuests);
            }
        }
        public int RespondedYes { get; set; }
        public int RespondedNo {
            get
            {
                return GuestsResponded - RespondedYes;
            }
        }
        public double PercentYes { 
            get { 
                if(RespondedYes != 0 && RespondedNo != 0)
                {
                    return Convert.ToInt32(RespondedYes / (RespondedNo + RespondedYes));
                }
                else
                {
                    return 0;
                }
            
            } 
        }

    }
}
