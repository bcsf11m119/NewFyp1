using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationFyp.Models;

namespace WebApplicationFyp.Controllers
{
    public class ValuesController : ApiController
    {
        Database1Entities db = new Database1Entities();
        //public List<Child> Get()
        //{
        //    //return db.Children.ToList();
        //    return db.Children.ToList();

        //}
        public IQueryable<ChildDTO> Get()
        //public IEnumerable<Child> Get()
        {
            //return db.Children.ToList();
            var child = from x in db.Children
                        select new ChildDTO() { 
                            Name=x.Name,
                            Cid=x.Cid,
                            Pid=x.Pid,
                            Number=x.Number,
                            Status=x.Status
                        };
            return child;
        }


        public IQueryable<ChildDTO> GetcHILD(int id)
        {
            var c = from x in db.Children
                    //where x.Number.Equals(id.ToString())
                    where x.Cid==id
                    select new ChildDTO() { 
                            Name=x.Name,
                            Cid=x.Cid,
                            Pid=x.Pid,
                            Number=x.Number,
                            Status=x.Status
                        };
            return c;            
        }

        
        
        
        
        //// POST api/values
        //public void Post([FromBody]string value)
        public string Post(Child c)
        {
            //var c1 = from x in db.Children
              //       where x.Number.Equals(c.Number)
                //     select x;
                
                //db.Children.FirstOrDefault(x=>x.Number.Equals(c.Number));
            //if (c1==null)
            //{
                /*Child child = new Child();
                child.Name = c.Name;
                child.Number = c.Number;
                child.Pid = c.Pid;
                child.Status = c.Status;*/
                db.Children.Add(c);
                db.SaveChanges();
                string check = "child successfully added";
                return check;
            //}
            //else
              //  return "An error occured";
        }

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        public void Put(int id, Child c)
        {
            var q = db.Children.Find(id);

            q.Name = c.Name;
            q.Number = c.Number;
            q.Status = c.Status;
            db.SaveChanges();

        }

        
        //public void PostCall(CallLog m)
        //{
        //    var c = db.Children.Find(m.Cid);
        //    if (!c.Equals(null))
        //    {
        //        //c.MessageLogs.Add(m);
        //        c.CallLogs.Add(m);
        //    }
        //    db.SaveChanges();
        //    //var c = from x in db.Children
        //    //        where x.Cid == m.Cid
        //    //        select x;

        //    //foreach (var s in c)
        //    //{
        //    //    s.MessageLogs.Add(m);
        //    //}

        //}

        //public void PostLocation(Location m)
        //{
        //    var c = db.Children.Find(m.Cid);
        //    if (!c.Equals(null))
        //    {
        //        //c.Location.Add(m);
        //        //c.Locations.Add(m);
        //        db.Locations.Add(m);
        //    }
        //    db.SaveChanges();
        //    //var c = from x in db.Children
        //    //        where x.Cid == m.Cid
        //    //        select x;

        //    //foreach (var s in c)
        //    //{
        //    //    s.MessageLogs.Add(m);
        //    //}

        //}

        //// DELETE api/values/5
        public void Delete(int id)
        {
            var q = db.Children.Find(id);
            db.Children.Remove(q);
            db.SaveChanges();
        }
    }
}
