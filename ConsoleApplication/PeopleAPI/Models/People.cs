using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleAPI.Models
{
    public class People
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string gender;

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        private string age;

        public string Age
        {
            get { return age; }
            set { age = value; }
        }

    }
}