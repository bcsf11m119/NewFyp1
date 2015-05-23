using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationFyp.Models;
namespace WebApplicationFyp.Controllers
{
    public class RestrictController : ApiController
    {
        Database1Entities db = new Database1Entities();
        // GET api/<controller>
        public IQueryable<RestrictDTO> Get(int id)
        {
            var c = from x in db.Restrictions
                    //where x.Number.Equals(id.ToString())
                    where x.Cid == id
                    select new RestrictDTO()
                    {
                        Cid=x.Cid,
                        Id=x.Id,
                        RestrictedArea=x.RestrictedArea
                    };
            return c;
        }

        // GET api/<controller>/5
        public IQueryable<RestrictDTO> Get()
        {
            var c = from x in db.Restrictions
                    //where x.Number.Equals(id.ToString())
                    select new RestrictDTO()
                    {
                        Cid = x.Cid,
                        Id = x.Id,
                        RestrictedArea = x.RestrictedArea
                    };
            return c;
        }
        public void Post(Restriction m)
        {
            var c = db.Children.Find(m.Cid);
            if (!c.Equals(null))
            {
                c.Restrictions.Add(m);
            }
            db.SaveChanges();
            //var c = from x in db.Children
            //        where x.Cid == m.Cid
            //        select x;

            //foreach (var s in c)
            //{
            //    s.MessageLogs.Add(m);
            //}

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