using Bookstore_API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bookstore_API.DataContext
{
    public class DataContext : DbContext
    {
        public DataContext() : base("Data")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<DataContext>());
        }

        public DbSet<StatlineModel> Statlines { get; set; }
        public DbSet<PlayerModel> Players { get; set; }
        public DbSet<Player_StatlineModel> PlayersStatlines { get; set; }

    }
}