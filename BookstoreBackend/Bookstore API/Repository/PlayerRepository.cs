using Bookstore_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookstore_API.Repository
{
    public class PlayerRepository
    {
        DataContext.DataContext dbContext = new DataContext.DataContext();
        public PlayerRepository()
        {

        }

        public List<PlayerModel> GetPlayers()
        {
            List<PlayerModel> playerList = new List<PlayerModel>();
            playerList = dbContext.Players.ToList();

            return playerList;
        }
    }
}