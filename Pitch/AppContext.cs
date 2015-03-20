using Pitch.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Pitch
{
    public class AppContext : DbContext
    {
        public DbSet<Profile> Players { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Song> Songs { get; set; }

        public AppContext() : base() { }
        public AppContext(DbConnection connection) : base(connection, true)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    }
}