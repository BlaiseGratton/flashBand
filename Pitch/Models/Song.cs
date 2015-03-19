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
        public virtual ICollection<Models.Profile> Profiles { get; set; }

        public Song() { }

        public Song(string title)
        {
            this.title = title;
        }
    }
}