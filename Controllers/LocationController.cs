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
        public string PostMessage(Location m)
        {

            //var c = db.Children.Find(m.Cid);
            //if (!c.Equals(null))
            //{
            //    //c.CallLogs.Add(m);
            //    db.Locations.Add(m);
            //    db.SaveChanges();
            //    return "location record successfully added";
            //}

            var c = from x in db.Children
                    //where x.Number.Equals(id.ToString())
                    where x.Cid == m.Cid
                    select x;
            
            try
            {
                // Your code...
                // Could also be before try if you know the exception occurs in SaveChanges

                if (c != null)
                {
                    Location l = new Location();
                    l.Cid = m.Cid;
                    l.Date = m.Date;
                    l.Duration = m.Duration;
                    l.Time = m.Time;
                    l.Location1 = m.Location1;
                    db.Locations.Add(l);
                    db.SaveChanges();
                }

                
                return "location record successfully added";
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw e;
            }
                
            
            //return null;
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
