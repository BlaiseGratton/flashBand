using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pitch.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string userName { get; set; }
        private string email { get; set; }
        public int[] instrumentIDs { get; set; }
        public int[] songIDs { get; set; }

        public Player() { }

        public Player(string userName, string email, int[] instrumentIDs, int[] songIDs)
        {
            this.userName = userName;
            this.email = email;
            this.instrumentIDs = instrumentIDs;
            this.songIDs = songIDs;
        }
    }
}