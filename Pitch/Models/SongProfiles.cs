using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pitch
{
    class SongProfiles
    {
        public int ID { get; set; }
        public int SongId { get; set; }
        public int ProfileId { get; set; }

        public SongProfiles() { }

        public SongProfiles(int songId, int profileId)
        {
            this.SongId = songId;
            this.ProfileId = profileId;
        }
    }
}
