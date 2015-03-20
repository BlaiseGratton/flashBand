using Pitch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitch.Repository
{
    interface IAppRepository
    {
        void SaveChanges();
        void Dispose();
        void Clear();
        int GetPlayersCount();
        int GetInstrumentsCount();
        int GetSongsCount();
        IEnumerable<Models.Profile> GetAllPlayers();
        int GetPlayerIdByName(string userName);
        Models.Profile GetUserById(int id);
        void AddUser(Models.Profile U);
        void DeletePlayer(Models.Profile P);
        IEnumerable<Models.Instrument> GetAllInstruments();
        Models.Instrument GetInstrumentById(int id);
        void AddInstrument(Models.Instrument I);
        void DeleteInstrument(Models.Instrument I);
        List<Models.Song> GetAllSongs();
        Models.Song GetSongById(int id);
        void CreateSong(Models.Song S);
        void AddSongToUser(int profileId, int songId);
        void AddInstrumentToUser(int profileId, int instrumentId);
        void DeleteSong(Models.Song S);
    }
}
