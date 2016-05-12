using eManager.Domain;
using eManager.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eManager.Web.Controllers
{
   
    public class VideosController : ApiController
    {

        private IDepartmentDataSource _db;

        public VideosController()
        {
            _db = new DepartmentDb();
            _db.ProxyCreationEnable = false;
        }

        public VideosController(IDepartmentDataSource db)
        {
            _db = db;
            _db.ProxyCreationEnable = false;
        }
        // GET api/video
        public IEnumerable<Video> GetAllVideos()
        {
            return _db.Videos;
        }

        // GET api/video/5
        public Video GetVideo(int id)
        {
            var video = _db.Videos.Single(v => v.Id == id);
            if (video == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return video;
        }

        // POST api/video
        public HttpResponseMessage PostVideo(Video video)
        {
            if (ModelState.IsValid)
            {
                _db.Add<Video>(video);
                _db.Save();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, video);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new  { id = video.Id }));
                return response;
            }
            else
            {
               return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/video/5
        public HttpResponseMessage PutVideo(int id, Video video)
        {
            if (ModelState.IsValid && id == video.Id)
            {
                _db.Update<Video>(video);
                try
                {
                    _db.Save();
                }
                catch(DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                return Request.CreateResponse(HttpStatusCode.OK,video);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/video/5
        public HttpResponseMessage DeleteVideo(int id)
        {
            Video video = _db.Query<Video>().Single(v => v.Id == id);
            if(video == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            _db.Delete<Video>(video);

            try
            {
                _db.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, video);
        }
    }
}
