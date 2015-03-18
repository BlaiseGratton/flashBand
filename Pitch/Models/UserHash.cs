using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pitch.Models
{
    public class UserHash
    {
        public int ID { get; set; }
        public string userName { get; set; }

        public UserHash() { }


        public UserHash(string userName)
        {
            this.userName = userName;
        }
    }
}