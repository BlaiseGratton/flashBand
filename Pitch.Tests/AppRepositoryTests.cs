using Effort;
using Pitch;
using Pitch.Models;
using Pitch.Repository;
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.EntityClient;

namespace Pitch.Tests
{
    [TestClass]
    public class AppRepositoryTests
    {
        private AppRepository _repo;

        [TestInitialize]
        public void SetUpTest()
        {
            DbConnection connection = Effort.DbConnectionFactory.CreateTransient();
            using(var context = new AppContext(connection))
            {
                context.Database.CreateIfNotExists();
                Profile blaise = new Profile("Blaise");
                Profile adam = new Profile("Adam");
                Profile colby = new Profile("Colby");
                Profile leon = new Profile("Leon");
                Profile jackie = new Profile("Jackie");
                Profile spencer = new Profile("Spencer");
                Profile gerald = new Profile("Gerald");
                Profile alex = new Profile("Alex");
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
                context.Players.Add(blaise);
                context.Players.Add(colby);
                context.Players.Add(adam);
                context.Players.Add(jackie);
                context.Players.Add(leon);
                context.Players.Add(spencer);
                context.Players.Add(gerald);
                context.Players.Add(alex);
                context.SaveChanges();
            }
            _repo = new AppRepository(new AppContext(connection));
        }

        [TestMethod]
        public void TestAddPlayer()
        {
            _repo.Clear();
            Assert.AreEqual(0, _repo.GetPlayersCount());
            Profile profile = new Profile("Blaise");
            _repo.AddUser(profile);
            Assert.AreEqual(1, _repo.GetPlayersCount());
        }

        [TestMethod]
        public void TestAddSongToPlayer()
        {
            Profile testuser = new Profile("testUser");
            _repo.AddUser(testuser);
            Song song = new Song("song");
            _repo.CreateSong(song);
            _repo.AddSongToUser(testuser.ID, song.ID);
            List<Models.Song> usersSongs = _repo.GetUserSongs(testuser.ID);
            Song savedSong = usersSongs.First<Models.Song>();
            Assert.AreEqual("song", savedSong.title);
        }

        [TestMethod]
        public void TestAddingSongsToPlayer()
        {
            Profile adam = new Profile("adam");
            _repo.AddUser(adam);
            List<int> songIds = new List<int> { 1, 2, 3 };
            _repo.AddSongsToUser(adam.ID, songIds);
            List<Models.Song> adamsSongs = _repo.GetUserSongs(adam.ID);
            Assert.AreEqual(3, adamsSongs.Count());
        }

        [TestMethod]
        public void TestRetrievingId()
        {
            Profile dave = new Profile("Dave");
            _repo.AddUser(dave);
            int profileId = _repo.GetPlayerIdByName("Dave");
            Assert.AreEqual(9, profileId);
            Assert.AreEqual(9, _repo.GetPlayersCount());
            Assert.AreEqual(1, _repo.GetPlayerIdByName("Blaise"));
        }
    }
}
