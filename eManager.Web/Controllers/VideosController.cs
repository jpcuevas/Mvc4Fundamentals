using eManager.Domain;
using eManager.Web.Infrastructure;
using System;
using System.Collections.Generic;
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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/video
        public Video Post(Video video)
        {
            return video;
        }

        // PUT api/video/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/video/5
        public void Delete(int id)
        {
        }
    }
}
