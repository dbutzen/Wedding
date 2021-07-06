using System;
using System.Collections.Generic;
using System.Text;

namespace DTB.Wedding.BL.Models
{
    public class Family
    {
        private Guid id;

        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string code;

        public string Code
        {
            get { return code; }
            set { code = value; }
        }


    }

    

}
