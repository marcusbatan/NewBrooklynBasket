using Bookstore_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookstore_API.DataContext;
using System.Data.Entity;

namespace Bookstore_API.Repository
{
    public class StatsRepository
    {
        DataContext.DataContext dbContext = new DataContext.DataContext();
        public StatsRepository()
        {

        }

        public void RegisterStatline(StatlineModel statlineModel)
        {
            statlineModel.RegLineDate = DateTime.Now.ToString("yyyy-MM-dd");
            dbContext.Statlines.Add(statlineModel);
            dbContext.SaveChanges();
        }
    }
}