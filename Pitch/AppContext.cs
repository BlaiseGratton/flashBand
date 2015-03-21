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
        //public AppContext()
        //    : base("name=AppContext")
        //{
        //    this.Configuration.LazyLoadingEnabled = false;
        //}

        public AppContext(string connectionString)
            : base(connectionString)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public AppContext(DbConnection connection) : base(connection, true)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public AppContext() { }
        
        public DbSet<Profile> Players { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongProfile> UserSongs { get; set; }
        public DbSet<InstrumentProfile> UserInstruments { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Profile>().ToTable("Profile");
        //    modelBuilder.Entity<Instrument>().ToTable("Instrument");
        //    modelBuilder.Entity<Song>().ToTable("Song");
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}