using CBProject.HelperClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CBProject.Controllers.API
{
    public class VideosController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;


        public VideosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        public IHttpActionResult GetVideos()
        {
            
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetVideo(int id)
        {
            var video = _unitOfWork.Videos.Get(id);

            if (video == null)
                return NotFound();


            return Ok(video);
        }

        [HttpPost]
        public IHttpActionResult UploadVideo()
        {
            var video = 0;
            return Created("",video);
        }

        [HttpPut]
        public IHttpActionResult UpdateVideo()
        {
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteVideo()
        {
            return Ok();
        }
    }
}
