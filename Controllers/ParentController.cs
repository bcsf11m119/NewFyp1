using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationFyp.Models;

namespace WebApplicationFyp.Controllers
{
    public class ParentController : ApiController
    {
        Database1Entities db = new Database1Entities();
        // GET api/<controller>
        public IQueryable<ParentDTO> Get()
        {
            //return db.Children.ToList();
            var p = from x in db.Parents
                    select new ParentDTO()
                    {
                        Name = x.Name,
                        Pid = x.Pid,
                        Number = x.Number,
                        Email = x.Email,
                        Password = x.Password
                    };
            return p;
        }



        public IQueryable<ParentDTO> Get(int id)
        {
            var p = from x in db.Parents
                    where x.Number==id
                    select new ParentDTO()
                    {
                        Name = x.Name,
                        Pid = x.Pid,
                        Number = x.Number,
                        Email = x.Email,
                        Password = x.Password
                    };
            return p;
        }

        // POST api/<controller>

        //public void Post([FromBody]string value)
        [HttpPost]
        public string  Post(Parent parent )
        {
            if (parent != null)
            {
                Parent p = new Parent();
                p.Name = parent.Name;
                p.Number = parent.Number;
                p.Email = parent.Email;
                p.Password = parent.Password;
                db.Parents.Add(p);
                db.SaveChanges();
                string check="parent successfully added";
                return check;
            }
            else
                return "An error occured";
        }

        // PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        public void Put(int id, Parent p)
        {
            var q = db.Parents.Find(id);
            q.Email = p.Email;
            q.Password = p.Password;
            q.Name = p.Name;
            q.Number = p.Number;
            db.SaveChanges();

            //var pa = from x in db.Parents
            //        where x.Number == id
            //        select new ParentDTO()
            //        {
            //            Name = x.Name,
            //            Pid = x.Pid,
            //            Number = x.Number,
            //            Email = x.Email,
            //            Password = x.Password
            //        };
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var q = db.Parents.Find(id);
            db.Parents.Remove(q);
            db.SaveChanges();
        }
    }
}
        //public IEnumerable<Parent> Get()
        //{
        //    return db.Parents.ToList();
        //}



        // GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}