using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pitch.Models
{
    public class SongProfile
    {
        public int ID { get; set; }
        public int ProfileID { get; set; }
        public int SongId { get; set; }

        public SongProfile() { }

        public SongProfile(int profId, int songId)
        {
            this.ProfileID = profId;
            this.SongId = songId;
        }
    }
}