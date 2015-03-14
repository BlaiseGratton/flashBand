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
        public int[] playerIDs { get; set; }

        public Instrument()
        {

        }

        public Instrument(string name, int[] playerIDs)
        {
            this.name = name;
            this.playerIDs = playerIDs;
        }
    }
}