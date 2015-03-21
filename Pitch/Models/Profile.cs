using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pitch.Models
{
    public class Profile
    {
        public int ID { get; set; }
        public string userName { get; set; }

        public Profile() { }


        public Profile(string userName)
        {
            this.userName = userName;
        }
    }
}