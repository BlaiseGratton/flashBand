using Pitch;
using Pitch.Models;
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
    public class AppRepository
    {
        private AppContext _dbContext;

        public AppRepository()
        {
            _dbContext = new AppContext();
            _dbContext.Players.Load();
            _dbContext.Instruments.Load();
            _dbContext.Songs.Load();
        }

        public AppContext Context()
        {
            return _dbContext;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public int GetPlayersCount()
        {
            return _dbContext.Players.Count<Models.Player>();
        }

        public int GetInstrumentsCount()
        {
            return _dbContext.Instruments.Count<Models.Instrument>();
        }

        public int GetSongsCount()
        {
            return _dbContext.Songs.Count<Models.Song>();
        }

        public IEnumerable<Models.Player> GetAllPlayers()
        {
            var query = from Player in _dbContext.Players select Player;
            return query.ToList<Models.Player>();
        }

        public Models.Player GetPlayerById(int id)
        {
            var query = from Player in _dbContext.Players
                        where Player.ID == id
                        select Player;
            return query.First<Models.Player>();
        }

        public void AddPlayer(Models.Player P)
        {
            _dbContext.Players.Add(P);
            _dbContext.SaveChanges();
        }

        public void DeletePlayer(Models.Player P)
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

        public IEnumerable<Models.Song> GetAllSongs()
        {
            var query = from Song in _dbContext.Songs select Song;
            return query.ToList<Models.Song>();
        }

        public Models.Song GetSongById(int id)
        {
            var query = from Song in _dbContext.Songs
                        where Song.ID == id
                        select Song;
            return query.First<Models.Song>();
        }

        public void AddSong(Models.Song S)
        {
            _dbContext.Songs.Add(S);
            _dbContext.SaveChanges();
        }

        public void DeleteSong(Models.Song S)
        {
            _dbContext.Songs.Remove(S);
            _dbContext.SaveChanges();
        }
    }
}