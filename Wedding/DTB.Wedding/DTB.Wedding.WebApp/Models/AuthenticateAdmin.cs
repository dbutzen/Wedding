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
        public static bool IsAuthenticated()
        {
            if (HttpContext.Current.Session == null) return false;
            else return HttpContext.Current.Session["user"] != null;
        }
    }
}
