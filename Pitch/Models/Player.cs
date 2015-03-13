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
        public int[] instruments { get; set; }
        public int[] songs { get; set; }

        public Player()
        {

        }

        public Player(string userName, string email, int[] instruments, int[] songs)
        {
            this.userName = userName;
            this.email = email;
            this.instruments = instruments;
            this.songs = songs;
        }
    }
}