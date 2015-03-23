using Effort;
using Pitch;
using Pitch.Models;
using Pitch.Providers;
using Pitch.Repository;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.EntityClient;
using System.IO;

namespace Pitch.Tests
{
    [TestClass]
    public class LevenshteinTests
    {
        private AppRepository _repo;

        [TestMethod]
        public void TestReturningLevenshteinNumbersFromStaticClass()
        {
            int first = LevenshteinDistance.Compute("and", "ant");
            Assert.AreEqual(first, 1);
        }

        [TestInitialize]
        public void SetupTest(){
            DbConnection connection = Effort.DbConnectionFactory.CreateTransient();
            using(var context = new AppContext(connection))
            {
                context.Database.CreateIfNotExists();
                Song song1 = new Song("Song1");
                Song song2 = new Song("Song2");
                Song song3 = new Song("Song3");
                Song song4 = new Song("Song4");
                Song song5 = new Song("Song5");
                Song song6 = new Song("Song6");
                Song song7 = new Song("Song7");
                Song song8 = new Song("Song8");
                Song song9 = new Song("Song9");
                Song song10 = new Song("Song10");
                Song song11 = new Song("Song11");
                Song song12 = new Song("Song12");
                Song song13 = new Song("Song13");
                Song song14 = new Song("Song14");
                Song song15 = new Song("Song15");
                Song song16 = new Song("Song16");
                Song song17 = new Song("Song17");
                Song song18 = new Song("Song18");
                Song song19 = new Song("Song19");
                Song song20 = new Song("Song20");
                context.Songs.Add(song1);
                context.Songs.Add(song2);
                context.Songs.Add(song3);
                context.Songs.Add(song4);
                context.Songs.Add(song5);
                context.Songs.Add(song6);
                context.Songs.Add(song7);
                context.Songs.Add(song8);
                context.Songs.Add(song9);
                context.Songs.Add(song10);
                context.Songs.Add(song11);
                context.Songs.Add(song12);
                context.Songs.Add(song13);
                context.Songs.Add(song14);
                context.Songs.Add(song15);
                context.Songs.Add(song16);
                context.Songs.Add(song17);
                context.Songs.Add(song18);
                context.Songs.Add(song19);
                context.Songs.Add(song20);
                context.SaveChanges();
            }
            _repo = new AppRepository(new AppContext(connection));
        }
    }
}