using Pitch.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Pitch
{
    public class AppContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}