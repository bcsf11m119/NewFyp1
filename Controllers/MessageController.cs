using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationFyp.Models;
namespace WebApplicationFyp.Controllers
{
    public class MessageController : ApiController
    {
        Database1Entities db = new Database1Entities();
        // GET api/<controller>
        public IQueryable<MessageDTO> GetMessage(int id)
        {
            var c = from x in db.MessageLogs
                    //where x.Number.Equals(id.ToString())
                    where x.Cid == id
                    select new MessageDTO()
                    {
                        SenderName = x.SenderName,
                        SenderNumber = x.SenderNumber,
                        Cid = x.Cid,
                        Id = x.Id,
                        Date = x.Date,
                        Content = x.Content,
                        Time = x.Time
                    };
            return c;
        }

        public IQueryable<MessageDTO> GetMessage()
        {
            var c = from x in db.MessageLogs
                    //where x.Number.Equals(id.ToString())
                    select new MessageDTO()
                    {
                        SenderName = x.SenderName,
                        SenderNumber = x.SenderNumber,
                        Cid = x.Cid,
                        Id = x.Id,
                        Date = x.Date,
                        Content = x.Content,
                        Time = x.Time
                    };
            return c;
        }

        public string PostMessage(MessageLog m)
        {
            var c = db.Children.Find(m.Cid);
            if (!c.Equals(null))
            {
                //c.MessageLogs.Add(m);
                db.MessageLogs.Add(m);
                db.SaveChanges();
                return "message successfully added";
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


    }
}