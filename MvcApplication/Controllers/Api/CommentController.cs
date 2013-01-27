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
    public class CommentController : ApiController
    {
        private readonly MongoDatabase _mongoDb;
        private readonly MongoCollection<Comment> _repository;

        public CommentController()
        {
            var connectionString = ConfigurationManager.AppSettings["MONGOHQ_URL"];
            _mongoDb = MongoDatabase.Create(connectionString);

            _repository = _mongoDb.GetCollection<Comment>(typeof(Comment).Name);
        }

        // GET /api/comments
        public HttpResponseMessage Get()
        {
            var comments = _repository.FindAll().ToList();
            var response = Request.CreateResponse(HttpStatusCode.OK, comments);
            string uri = Url.Route(null, null);
            response.Headers.Location = new Uri(Request.RequestUri, uri);
            return response;
        }

        // POST /api/comments
        [HttpPost]
        public HttpResponseMessage Post(Comment comment)
        {
            _repository.Insert(comment);
            string uri = Url.Route(null, new { id = comment.Id }); 
            var response = Request.CreateResponse(HttpStatusCode.Created, comment);
            response.Headers.Location = new Uri(Request.RequestUri, uri);
            return response;
        }
    }
}
