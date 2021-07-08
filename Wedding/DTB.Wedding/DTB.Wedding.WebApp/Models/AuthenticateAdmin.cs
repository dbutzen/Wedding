using DTB.Wedding.WebApp.Controllers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DTB.Wedding.WebApp.Models
{
    public static class AuthenticateAdmin
    {
        public static bool IsAuthenticated { get; set; }
    }
}
