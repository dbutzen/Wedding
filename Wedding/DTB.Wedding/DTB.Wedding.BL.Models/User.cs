using System;
using System.Collections.Generic;
using System.Text;

namespace DTB.Wedding.BL.Models
{
    public class User
    {
        private Guid id;

        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }


        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private Guid? sessionKey;

        public Guid? SessionKey
        {
            get { return sessionKey; }
            set { sessionKey = value; }
        }

        private Guid uniqueKey;

        public Guid UniqueKey
        {
            get { return uniqueKey; }
            set { uniqueKey = value; }
        }


    }
}
