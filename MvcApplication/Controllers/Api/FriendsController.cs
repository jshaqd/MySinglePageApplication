using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MongoDB.Bson;
using MongoDB.Driver;
using MvcApplication.Models;
using MongoDB.Driver.Builders;

namespace MvcApplication.Controllers.Api
{
    public class FriendsController : ApiController
    {
        private readonly MongoDatabase _mongoDb;
        private readonly MongoCollection<Friend> _repository;

        public FriendsController()
        {
            var connectionString = ConfigurationManager.AppSettings["MONGOHQ_URL"];
            _mongoDb = MongoDatabase.Create(connectionString);

            _repository = _mongoDb.GetCollection<Friend>(typeof(Friend).Name);
        }

        // GET /api/friends
        public HttpResponseMessage Get()
        {
            var friends = _repository.FindAll().ToList();
            var response = Request.CreateResponse(HttpStatusCode.OK, friends);
            string uri = Url.Route(null, null);
            response.Headers.Location = new Uri(Request.RequestUri, uri);
            return response;
        }

        // GET /api/friends/4fd63a86f65e0a0e84e510de
        [HttpGet]
        public Friend Get(string id)
        {
            var query = Query.EQ("_id", new ObjectId(id));
            return _repository.Find(query).Single();
        }

        // POST /api/friends
        [HttpPost]
        public HttpResponseMessage Post(Friend friend)
        {
            _repository.Insert(friend);
            string uri = Url.Route(null, new { id = friend.Id }); // Where is the new timesheet?
            var response = Request.CreateResponse(HttpStatusCode.Created, friend);
            response.Headers.Location = new Uri(Request.RequestUri, uri);
            return response;
        }

        // PUT /api/friends
        [HttpPut]
        public HttpResponseMessage Put(Friend friend)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, friend);
            _repository.Save(friend);
            string uri = Url.Route(null, new { id = friend.Id }); // Where is the modified timesheet?
            response.Headers.Location = new Uri(Request.RequestUri, uri);
            return response;
        }

        // DELETE /api/timesheets/4fd63a86f65e0a0e84e510de
        public HttpResponseMessage Delete(params string[] ids)
        {
            foreach (var id in ids)
            {
                _repository.Remove(Query.EQ("_id", new ObjectId(id)));
            }
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
