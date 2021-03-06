﻿using Effort;
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

        [TestMethod]
        public void TestRetrievingSongPlayers()
        {
            _repo.AddSongsToUser(1, new List<int> { 1, 2, 3, 4, 5 });
            _repo.AddSongsToUser(2, new List<int> { 2, 3, 4, 5, 6 });
            _repo.AddSongsToUser(3, new List<int> { 1, 3, 5 });
            List<int> list1 = new List<int> { 1, 3 };
            List<int> list2 = new List<int> { 1, 2 };
            List<int> list3 = new List<int> { 1, 2, 3 };
            List<int> list4 = new List<int> { 1, 2 };
            List<int> list5 = new List<int> { 1, 2, 3 };
            List<int> list6 = new List<int> { 2 };
            CollectionAssert.AreEquivalent(list1, _repo.GetSongPlayers(1));
            CollectionAssert.AreEquivalent(list2, _repo.GetSongPlayers(2));
            CollectionAssert.AreEquivalent(list3, _repo.GetSongPlayers(3));
            CollectionAssert.AreEquivalent(list4, _repo.GetSongPlayers(4));
            CollectionAssert.AreEquivalent(list5, _repo.GetSongPlayers(5));
            CollectionAssert.AreEquivalent(list6, _repo.GetSongPlayers(6));
        }

        [TestMethod]
        public void TestRetrievingInstrumentPlayers()
        {
            _repo.AddInstrumentToUser(1, 1);
            _repo.AddInstrumentToUser(1, 3);
            _repo.AddInstrumentToUser(2, 2);
            _repo.AddInstrumentToUser(2, 3);
            _repo.AddInstrumentToUser(3, 4);
            _repo.AddInstrumentToUser(6, 2);
            _repo.AddInstrumentToUser(6, 3);
            _repo.AddInstrumentToUser(3, 1);
            CollectionAssert.AreEquivalent(new List<int> { 1, 3 }, _repo.GetInstrumentPlayers(1));            
            CollectionAssert.AreEquivalent(new List<int> { 2, 6 }, _repo.GetInstrumentPlayers(2));            
            CollectionAssert.AreEquivalent(new List<int> { 1, 2, 6 }, _repo.GetInstrumentPlayers(3));            
            CollectionAssert.AreEquivalent(new List<int> { 3 }, _repo.GetInstrumentPlayers(4));            
        }

        [TestMethod]
        public void TestGettingMatchSetOfPlayersAndInstruments()
        {
            _repo.AddInstrumentToUser(1, 1);
            _repo.AddInstrumentToUser(1, 2);
            _repo.AddInstrumentToUser(1, 3);
            _repo.AddInstrumentToUser(1, 4);
            _repo.AddInstrumentToUser(2, 2);
            _repo.AddInstrumentToUser(2, 3);
            _repo.AddInstrumentToUser(3, 2);
            _repo.AddInstrumentToUser(4, 3);
            _repo.AddInstrumentToUser(5, 4);
            _repo.AddSongsToUser(1, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });
            _repo.AddSongsToUser(2, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            _repo.AddSongsToUser(2, new List<int> { 11, 12, 13,14, 15, 16, 17, 18, 19, 20 });
            _repo.AddSongsToUser(3, new List<int> { 1, 2, 3, 4, 5, 16, 17, 18, 19, 20 });
            _repo.AddSongsToUser(4, new List<int> { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15});
            CollectionAssert.AreEquivalent(new List<int> { 1 }, _repo.MatchInstrumentPlayersToSongPlayers(_repo.GetInstrumentPlayers(1), _repo.GetSongPlayers(1)));
            CollectionAssert.AreEquivalent(new List<int> { 1, 2, 3 }, _repo.MatchInstrumentPlayersToSongPlayers(_repo.GetInstrumentPlayers(2), _repo.GetSongPlayers(2)));
            CollectionAssert.AreEquivalent(new List<int> { 1, 2, 4 }, _repo.MatchInstrumentPlayersToSongPlayers(_repo.GetInstrumentPlayers(3), _repo.GetSongPlayers(10)));
            CollectionAssert.AreEquivalent(new List<int> { 1 }, _repo.MatchInstrumentPlayersToSongPlayers(_repo.GetInstrumentPlayers(4), _repo.GetSongPlayers(8)));
            CollectionAssert.AreEquivalent(new List<int> { 1, 2 }, _repo.MatchInstrumentPlayersToSongPlayers(_repo.GetInstrumentPlayers(2), _repo.GetSongPlayers(12)));
        }

        [TestMethod]
        public void TestMatchingSetOfInstrumentPlayersToManySongs()
        {
            _repo.AddInstrumentToUser(1, 1);
            _repo.AddInstrumentToUser(1, 2);
            _repo.AddInstrumentToUser(2, 2);
            _repo.AddInstrumentToUser(2, 3);
            _repo.AddInstrumentToUser(3, 1);
            _repo.AddInstrumentToUser(3, 3);
            _repo.AddSongsToUser(1, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            _repo.AddSongsToUser(2, new List<int> { 1, 2, 3, 4, 5, 6 });
            _repo.AddSongsToUser(3, new List<int> { 4, 5, 6, 7, 8, 9, 10 });
            CollectionAssert.AreEquivalent(new List<int> { 1 }, _repo.GetInstrumentPlayersOfSetOfSongs(1, new List<int> { 1, 2, 3, 4, 5 }));
            CollectionAssert.AreEquivalent(new List<int> { 1, 3 }, _repo.GetInstrumentPlayersOfSetOfSongs(1, new List<int> { 4, 5 }));
            CollectionAssert.AreEquivalent(new List<int> { 1, 2 }, _repo.GetInstrumentPlayersOfSetOfSongs(2, new List<int> { 4, 5, 6 }));
            CollectionAssert.AreEquivalent(new List<int> { 1, 2 }, _repo.GetInstrumentPlayersOfSetOfSongs(2, new List<int> { 1, 4 }));
            CollectionAssert.AreEquivalent(new List<int> { 3 }, _repo.GetInstrumentPlayersOfSetOfSongs(3, new List<int> { 7, 8, 9 }));
        }

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
                Instrument piano = new Instrument("Piano");
                Instrument guitar = new Instrument("Guitar");
                Instrument bass = new Instrument("Bass");
                Instrument drums = new Instrument("Drums");
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
                context.Instruments.Add(piano);
                context.Instruments.Add(guitar);
                context.Instruments.Add(bass);
                context.Instruments.Add(drums);
                context.SaveChanges();
            }
            _repo = new AppRepository(new AppContext(connection));
        }

        [TestCleanup]
        public void ClearRepo()
        {
            _repo.Clear();
        }
    }
}
