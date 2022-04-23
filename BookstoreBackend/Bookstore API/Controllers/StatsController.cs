using Bookstore_API.Models;
using Bookstore_API.Repository;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Bookstore_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("")]
    public class StatsController : ApiController
    {
        private Log logger = new Log();
        string apiResult;
        StatsRepository statsRepository = new StatsRepository();
        public StatsController()
        {

        }

        [HttpPost]
        [ActionName("RegisterStatline")]
        public IHttpActionResult RegisterStatline(StatlineModel statlineModel)
        {
            try
            {
                statsRepository.RegisterStatline(statlineModel);
                apiResult = "ReggadBok";
                return Ok(apiResult);
            }

            catch (Exception e)
            {
                this.logger.WriteException(e);
                throw;
            }
        }
    }
}
