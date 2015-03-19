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
        public virtual ICollection<Models.Profile> Profiles { get; set; }

        public Instrument() { }

        public Instrument(string name)
        {
            this.name = name;
        }
    }
}