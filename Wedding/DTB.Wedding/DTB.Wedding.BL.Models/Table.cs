using System;
using System.Collections.Generic;
using System.Text;

namespace DTB.Wedding.BL.Models
{
    public class Table
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

        private int numberChairs;

        public int NumberChairs
        {
            get { return numberChairs; }
            set { numberChairs = value; }
        }


    }
}
