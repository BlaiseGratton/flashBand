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
                Song song1 = new Song("Song1");
                Song song2 = new Song("Song2");
                Song song3 = new Song("Song3");
                context.Songs.Add(song1);
                context.Songs.Add(song2);
                context.Songs.Add(song3);
                context.Players.Add(blaise);
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
            Profile colby = new Profile("Colby");
            _repo.AddUser(colby);
            Assert.AreEqual(2, colby.ID);
            Song song = new Song("song");
            _repo.CreateSong(song);
            Assert.AreEqual(4, song.ID);
            _repo.AddSongToUser(2, 4);
            List<Models.Song> colbysSongs = _repo.GetUserSongs(colby.ID);
            Song savedSong = colbysSongs.First<Models.Song>();
            Assert.AreEqual("song", savedSong.title);
        }

        [TestMethod]
        public void TestAddingSongsToPlayer()
        {
            Profile adam = new Profile("Adam");
            _repo.AddUser(adam);
            List<int> songIds = new List<int> { 1, 2, 3 };
            _repo.AddSongsToUser(adam.ID, songIds);
            List<Models.Song> adamsSongs = _repo.GetUserSongs(adam.ID);
            Assert.AreEqual(3, adamsSongs.Count());
        }

        [TestMethod]
        public void TestRetrievingId()
        {
            int profileId = _repo.GetPlayerIdByName("Blaise");
            Assert.AreEqual(1, profileId);
            Assert.AreEqual(1, _repo.GetPlayersCount());
        }
    }
}
