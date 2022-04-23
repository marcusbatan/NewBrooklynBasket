using Bookstore_API.Models;
using Bookstore_API.Repository;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bookstore_API.Controllers
{
    public class PlayerController : ApiController
    {
        private Log logger = new Log();
        PlayerRepository playerRepository = new PlayerRepository();
        string apiResponse;
        public PlayerController()
        {

        }
        
        [HttpPost]
        [ActionName("GetPlayers")]
        public IHttpActionResult GetPlayers()
        {
            try
            {
               var players = new List<PlayerModel>();
               players = playerRepository.GetPlayers();

                if(players.Count > 0)
                {
                    return Ok(players);
                }

                else
                {
                    apiResponse = "Det fanns inga spelare i databasen!";
                    return Ok(apiResponse);
                }
            }
            catch (Exception e)
            {
                this.logger.WriteException(e);
                throw;
            }
        }
    }
}
