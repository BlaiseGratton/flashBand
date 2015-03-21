﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Pitch.Models;
using Newtonsoft.Json;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using Pitch.Repository;
using Newtonsoft.Json.Linq;

namespace Pitch.Controllers
{
    public class AppController : ApiController
    {
        private AppRepository _repo = new AppRepository();

        // GET: api/Songs
        [Authorize]
        [Route("api/Songs")]
        [HttpGet]
        public IEnumerable<Models.Song> GetAllSongs()
        {
            List<Models.Song> songsCollection = new List<Models.Song>();
            songsCollection = _repo.GetAllSongs().ToList();
            return songsCollection;
            //return db.Players;
        }

        // GET: api/Instruments
        [Authorize]
        [Route("api/Instruments")]
        [HttpGet]
        public IEnumerable<Models.Instrument> GetAllInstruments()
        {
            List<Models.Instrument> instrumentsCollection = new List<Models.Instrument>();
            instrumentsCollection = _repo.GetAllInstruments().ToList();
            return instrumentsCollection;
            //return db.Players;
        }

        // GET: api/Users/5
        [Authorize]
        [Route("api/Users/{id}")]
        [HttpGet]
        [ResponseType(typeof(Profile))]
        public Models.Profile GetUser(int id)
        {
            Profile user = _repo.GetUserById(id);
            return user;
        }
        //public async Task<IHttpActionResult> GetPlayer(int id)
        //{
        //    Player player = await db.Players.FindAsync(id);
        //    if (player == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(player);
        //}

        // PUT: api/Players/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPlayer(int id, Profile player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != player.ID)
            {
                return BadRequest();
            }

            //db.Entry(player).State = EntityState.Modified;

            try
            {
                //await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                /*if (!PlayerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }*/
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        //POST: api/Instruments/
        [Route("api/Instruments")]
        [HttpPost]
        public HttpResponseMessage PostInstrument(Instrument instrument)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            _repo.AddInstrument(instrument);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        //POST: api/Songs/
        [Route("api/Songs")]
        [HttpPost]
        public HttpResponseMessage PostSong(Song song)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            _repo.CreateSong(song);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        //POST: api/Users/2/songs/13
        [Route("api/Users/{userId}/songs/{songId}")]
        [Authorize]
        public HttpResponseMessage AddSongToProfile(int userId, int songId)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            _repo.AddSongToUser(userId, songId);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        //POST: api/Users/2/instruments/13
        [Route("api/Users/{userId}/instruments/{instrumentId}")]
        [Authorize]
        public HttpResponseMessage AddInstrumentToProfile(int userId, int instrumentId)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            _repo.AddInstrumentToUser(userId, instrumentId);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        // GET: api/Users/3/Songs
        [Route("api/Users/{userId}/songs")]
        [Authorize]
        [ResponseType(typeof(Models.Song))]
        public List<Models.Song> GetUsersInstruments(int userId)
        {
            List<Models.Song> userSongs = _repo.GetUserSongs(userId);
            return userSongs;
        }
        
        // POST: api/Players
        [Route("api/Players")]
        [HttpPost]
        public HttpResponseMessage PostPlayer(string playerString)
        {
            /*Player deserializedPlayer = JsonConvert.DeserializeObject<UserHash>(playerString);
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            repo.AddPlayer(deserializedPlayer);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, deserializedPlayer);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id=deserializedPlayer.ID }));
            return response;*/
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        // DELETE: api/Players/5
        [ResponseType(typeof(Profile))]
        public async Task<IHttpActionResult> DeletePlayer(int id)
        {
            /*Player player = await db.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            db.Players.Remove(player);
            await db.SaveChangesAsync();

            return Ok(player);*/
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            /*if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);*/
        }

        private bool PlayerExists(int id)
        {
            return true; //db.Players.Count(e => e.ID == id) > 0;
        }
    }
}