﻿using Pitch;
using Pitch.Models;
using Pitch.Providers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Pitch.Repository
{
    public class AppRepository : IAppRepository
    {
        private AppContext _dbContext;

        public AppRepository()
        {
            _dbContext = new AppContext();
            _dbContext.Database.CreateIfNotExists();
            _dbContext.Players.Load();
            _dbContext.Instruments.Load();
            _dbContext.Songs.Load();
            _dbContext.UserSongs.Load();
            _dbContext.UserInstruments.Load();
        }

        public AppContext Context()
        {
            return _dbContext;
        }

        public AppRepository(AppContext context)
        {
            _dbContext = context;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void Clear()
        {
            var a = this.GetAllPlayers();
            _dbContext.Players.RemoveRange(a);
            var b = this.GetAllInstruments();
            _dbContext.Instruments.RemoveRange(b);
            var c = this.GetAllSongs();
            _dbContext.Songs.RemoveRange(c);
            var d = this.GetAllSongProfiles();
            _dbContext.UserSongs.RemoveRange(d);
            var e = this.GetAllInstrumentProfiles();
            _dbContext.UserInstruments.RemoveRange(e);
            _dbContext.SaveChanges();

        }

        public int GetPlayersCount()
        {
            return _dbContext.Players.Count<Models.Profile>();
        }

        public int GetInstrumentsCount()
        {
            return _dbContext.Instruments.Count<Models.Instrument>();
        }

        public int GetSongsCount()
        {
            return _dbContext.Songs.Count<Models.Song>();
        }

        public IEnumerable<Models.Profile> GetAllPlayers()
        {
            var query = from UserHash in _dbContext.Players select UserHash;
            return query.ToList<Models.Profile>();
        }

        public int GetPlayerIdByName(string userName)
        {
            var query = from UserHash in _dbContext.Players
                        where UserHash.userName == userName 
                        select UserHash;
            return query.First<Models.Profile>().ID;
        }

        public Models.Profile GetUserById(int id)
        {
            var query = from UserHash in _dbContext.Players
                        where UserHash.ID == id
                        select UserHash;
            return query.First<Models.Profile>();
        }

        public void AddUser(Models.Profile U)
        {
            _dbContext.Players.Add(U);
            _dbContext.SaveChanges();
        }

        public void DeletePlayer(Models.Profile P)
        {
            _dbContext.Players.Remove(P);
            _dbContext.SaveChanges();
        }
        
        public IEnumerable<Models.Instrument> GetAllInstruments()
        {
            var query = from Instrument in _dbContext.Instruments select Instrument;
            return query.ToList<Models.Instrument>();
        }

        public Models.Instrument GetInstrumentById(int id)
        {
            var query = from Instrument in _dbContext.Instruments
                        where Instrument.ID == id
                        select Instrument;
            return query.First<Models.Instrument>();
        }

        public void AddInstrument(Models.Instrument I)
        {
            _dbContext.Instruments.Add(I);
            _dbContext.SaveChanges();
        }

        public void DeleteInstrument(Models.Instrument I)
        {
            _dbContext.Instruments.Remove(I);
            _dbContext.SaveChanges();
        }

        public List<Models.Song> GetAllSongs()
        {
            var query = from Song in _dbContext.Songs select Song;
            return query.ToList<Models.Song>();
        }

        public List<Models.SongProfile> GetAllSongProfiles()
        {
            var query = from UserSong in _dbContext.UserSongs select UserSong;
            return query.ToList<Models.SongProfile>();
        }

        public List<Models.InstrumentProfile> GetAllInstrumentProfiles()
        {
            var query = from UserInstrument in _dbContext.UserInstruments select UserInstrument;
            return query.ToList<Models.InstrumentProfile>();
        }

        public Models.Song GetSongById(int id)
        {
            var query = from Song in _dbContext.Songs
                        where Song.ID == id
                        select Song;
            return query.First<Models.Song>();
        }

        public void CreateSong(Models.Song S)
        {
            _dbContext.Songs.Add(S);
            _dbContext.SaveChanges();
        }

        public void AddSongToUser(int profileId, int songId)
        {
            SongProfile userSong = new SongProfile(profileId, songId);
            _dbContext.UserSongs.Add(userSong);
            _dbContext.SaveChanges();
        }

        public void AddSongsToUser(int profileId, List<int> songIds)
        {
            Profile profile = GetUserById(profileId);
            foreach (int songId in songIds)
            {
                SongProfile userSong = new SongProfile(profileId, songId);
                _dbContext.UserSongs.Add(userSong);
            }
            _dbContext.SaveChanges();
        }

        public void AddInstrumentToUser(int profileId, int instrumentId)
        {
            InstrumentProfile profInst = new InstrumentProfile(profileId, instrumentId);
            _dbContext.UserInstruments.Add(profInst);
            _dbContext.SaveChanges();
        }

        public void DeleteSong(Models.Song S)
        {
            _dbContext.Songs.Remove(S);
            _dbContext.SaveChanges();
        }

        public int GetSongIdByName(string songTitle)
        {
            var query = from Song in _dbContext.Songs
                        where Song.title == songTitle 
                        select Song;
            return query.First<Models.Song>().ID;
        }

        public void DeleteSongFromPlayer(int userId, int songId)
        {
            var query = from ProfileSong in _dbContext.UserSongs
                        where (ProfileSong.ProfileID == userId &&
                               ProfileSong.SongId == songId)
                        select ProfileSong;
            foreach (var item in query)
            {
                _dbContext.UserSongs.Remove(item);
            }
            _dbContext.SaveChanges();
        }

        public void DeleteInstrumentFromPlayer(int userId, int instrumentId)
        {
            var query = from ProfileInstrument in _dbContext.UserInstruments
                        where (ProfileInstrument.ProfileID == userId &&
                               ProfileInstrument.InstrumentId == instrumentId)
                        select ProfileInstrument;
            foreach (var item in query)
            {
                _dbContext.UserInstruments.Remove(item);
            }
            _dbContext.SaveChanges();
        }

        public List<Song> GetUserSongs(int userId)
        {
            var songIDs = from SongProfile in _dbContext.UserSongs
                                       where SongProfile.ProfileID == userId
                                       select SongProfile.SongId;
            List<Models.Song> songs = new List<Models.Song>();
            foreach (int songId in songIDs.ToList())
            {
                songs.Add(GetSongById(songId));
            }
            return songs;
        }
        
        public List<Instrument> GetUserInstruments(int userId)
        {
            var instrumentIDs = from InstrumentProfile in _dbContext.UserInstruments
                                       where InstrumentProfile.ProfileID == userId
                                       select InstrumentProfile.InstrumentId;
            List<Models.Instrument> instruments = new List<Models.Instrument>();
            foreach (int instrumentId in instrumentIDs.ToList())
            {
                instruments.Add(GetInstrumentById(instrumentId));
            }
            return instruments;
        }

        public List<int> GetSongPlayers(int songId)
        {
            var query = from SongProfile in _dbContext.UserSongs
                        where SongProfile.SongId == songId
                        select SongProfile.ProfileID;
            return query.ToList<int>();
        }

        public List<int> GetInstrumentPlayers(int instId)
        {
            var query = from InstrumentProfile in _dbContext.UserInstruments
                        where InstrumentProfile.InstrumentId == instId
                        select InstrumentProfile.ProfileID;
            return query.ToList<int>();
        }

        public List<int> MatchInstrumentPlayersToSongPlayers(List<int> instrumentPlayers, List<int> songPlayers)
        {
            List<int> matchSet = instrumentPlayers.Intersect(songPlayers).ToList<int>();
            return matchSet;
        }

        public List<int> GetInstrumentPlayersOfSetOfSongs(int instId, List<int> songIDs)
        {
            List<int> instPlayers = GetInstrumentPlayers(instId);
            List<int> playerSet = GetSongPlayers(songIDs[0]);
            foreach (int songID in songIDs)
            {
                List<int> songPlayers = GetSongPlayers(songID);
                playerSet = songPlayers.Intersect(playerSet).ToList<int>();
            }
            return MatchInstrumentPlayersToSongPlayers(instPlayers, playerSet);
        }

        public List<Models.Profile> GetSetOfProfilesByIds(List<int> profIDs)
        {
            List<Models.Profile> profileSet = new List<Models.Profile>();
            foreach (int ID in profIDs)
            {
                profileSet.Add(GetUserById(ID));
            }
            return profileSet;
        }

        public List<Models.Song> fuzzySearchSongs(string searchString)
        {
            searchString = searchString.ToLower();
            int srchLen = searchString.Count();
            List<Models.Song> allSongs = GetAllSongs();
            List<Models.Song> matchedSongs = new List<Models.Song>();
            foreach (Song song in allSongs)
            {
                string songTitle = song.title.ToLower();
                if(songTitle.Contains(searchString) || LevenshteinDistance.Compute(string.Join(string.Empty,songTitle.Take(srchLen)), searchString) <= 3 )
                {
                    matchedSongs.Add(song);
                }
            }
            return matchedSongs;
        }
        
        public List<Models.Instrument> fuzzySearchInstruments(string searchString)
        {
            searchString = searchString.ToLower();
            int srchLen = searchString.Count();
            List<Models.Instrument> allInstruments = GetAllInstruments().ToList();
            List<Models.Instrument> matchedInstruments = new List<Models.Instrument>();
            foreach (Instrument instrument in allInstruments)
            {
                string instrumentName = instrument.name.ToLower();
                if(instrumentName.Contains(searchString) || LevenshteinDistance.Compute(string.Join(string.Empty,instrumentName.Take(srchLen)), searchString) <= 3 )
                {
                    matchedInstruments.Add(instrument);
                }
            }
            return matchedInstruments;
        }
    }
}