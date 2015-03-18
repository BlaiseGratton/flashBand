using System;
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
    public class PlayersController : ApiController
    {
        private AppRepository repo = new AppRepository();
        //private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Players
        [Authorize]
        [Route("api/Players")]
        [HttpGet]
        public List<UserHash> GetPlayers()
        {
            List<UserHash> players = new List<UserHash>();
            players = repo.GetAllPlayers().ToList();
            return players;
            //return db.Players;
        }

        // GET: api/Players/5
        [Authorize]
        [Route("api/Players/{id}")]
        [HttpGet]
        [ResponseType(typeof(UserHash))]
        public Models.UserHash GetPlayer(int id)
        {
            UserHash player = repo.GetPlayerById(id);
            return player;
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
        public async Task<IHttpActionResult> PutPlayer(int id, UserHash player)
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
        [ResponseType(typeof(UserHash))]
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