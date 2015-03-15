using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pitch.Models
{
    public class Song
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string playerIDs { get; set; }

        public Song() { }

        public Song(string title, string playerIDs)
        {
            this.title = title;
            this.playerIDs = playerIDs;
        }
    }
}