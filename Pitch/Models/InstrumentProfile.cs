using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pitch.Models
{
    public class InstrumentProfile
    {
        public int ID { get; set; }
        public int ProfileID { get; set; }
        public int InstrumentId { get; set; }

        public InstrumentProfile() { }

        public InstrumentProfile(int profId, int instrumentId)
        {
            this.ProfileID = profId;
            this.InstrumentId = instrumentId;
        }
    }
}