using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationFyp.Models;

namespace WebApplicationFyp.Controllers
{
    public class LocationController : ApiController
    {
        Database1Entities db = new Database1Entities();
        // GET api/<controller>
        public IQueryable<LocationDTO> Get(int id)
        {
            var c = from x in db.Locations
                    //where x.Number.Equals(id.ToString())
                    where x.Cid == id
                    select new LocationDTO()
                    {
                        Cid = x.Cid,
                        Id = x.Id,
                        Date = x.Date,
                        Time = x.Time,
                        Duration=x.Duration,
                        Location1=x.Location1
                    };
            return c;
        }
        // GET api/<controller>/5
        public IQueryable<LocationDTO> Get()
        {
            var c = from x in db.Locations
                    //where x.Number.Equals(id.ToString())
                    select new LocationDTO()
                    {
                        Cid = x.Cid,
                        Id = x.Id,
                        Date = x.Date,
                        Time = x.Time,
                        Duration = x.Duration,
                        Location1 = x.Location1
                    };
            return c;
        }
        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}