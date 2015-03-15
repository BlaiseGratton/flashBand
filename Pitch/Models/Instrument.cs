using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pitch.Models
{
    public class Instrument
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string playerIDs { get; set; }

        public Instrument()
        {

        }

        public Instrument(string name, string playerIDs)
        {
            this.name = name;
            this.playerIDs = playerIDs;
        }
    }
}