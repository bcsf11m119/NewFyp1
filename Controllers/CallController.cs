using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationFyp.Models;

namespace WebApplicationFyp.Controllers
{
    public class CallController : ApiController
    {
        // GET api/<controller>
        Database1Entities db = new Database1Entities();
        public IQueryable<CallDTO> Get()
        {
            var c = from x in db.CallLogs
                    //where x.Number.Equals(id.ToString())
                    select new CallDTO()
                    {
                        CallerName = x.CallerName,
                        CallerNumber = x.CallerNumber,
                        Cid = x.Cid,
                        Date = x.Date,
                        Duration = x.Duration,
                        Id = x.Id,
                        Time = x.Time
                    };
            return c;
        }

        // GET api/<controller>/5
        public IQueryable<CallDTO> Get(int id)
        {
            var c = from x in db.CallLogs
                    //where x.Number.Equals(id.ToString())
                    where x.Cid == id
                    select new CallDTO()
                    {
                        CallerName=x.CallerName,
                        CallerNumber=x.CallerNumber,
                        Cid=x.Cid,
                        Date=x.Date,
                        Duration=x.Duration,
                        Id=x.Id,
                        Time = x.Time
                    };
            return c;
        }

        // POST api/<controller>
        public string PostMessage(CallLog m)
        {
            var c = db.Children.Find(m.Cid);
            if (!c.Equals(null))
            {
                //c.CallLogs.Add(m);
                db.CallLogs.Add(m);
                db.SaveChanges();
                return "call record successfully added";
            }
            return null;
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