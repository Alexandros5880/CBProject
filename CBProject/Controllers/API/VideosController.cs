using AutoMapper;
using CBProject.HelperClasses;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
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
            
            return Ok(_unitOfWork.Videos.GetAll());
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
        public IHttpActionResult UploadVideo(Video video)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            if (video.VideoImage == null)
            {

                video.Thumbnail = "no-image.jpg";
            }
            else
            {
                video.Thumbnail = Path.GetFileName(video.VideoImage.FileName);
                string videoImageFilePath = Path.Combine(StaticImfo.VideoImagePath, video.Thumbnail);
                //string videoImageFilePath = HttpContext.Current.Server.MapPath(StaticImfo.VideoImagePath + video.VideoImage.FileName);
                video.VideoImage.SaveAs(videoImageFilePath);

            }


            if (video.VideoFile.ContentLength < 1073741824)
            {
                string videoFilePath = HttpContext.Current.Server.MapPath(StaticImfo.VideoPath + video.VideoFile.FileName);

                

                video.VideoFile.SaveAs(videoFilePath);
                video.VideoPath = video.VideoFile.FileName;

                _unitOfWork.Videos.Add(video);
                _unitOfWork.Videos.Save();

                return Created(new Uri(Request.RequestUri + "/" + video.Id), video);

            }

            return BadRequest();
        }

        [HttpPut]
        public IHttpActionResult UpdateVideo(int id, Video video)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var videoInDb = _unitOfWork.Videos.Get(id);

            if (videoInDb == null)
                return NotFound();


            videoInDb.Title = video.Title;
            videoInDb.Description = video.Description;
            videoInDb.VideoPath = video.VideoPath;
            videoInDb.Url = video.Url;
            videoInDb.Thumbnail = video.Thumbnail;
            videoInDb.CategoryId = video.CategoryId;
            _unitOfWork.Videos.Save();


            
            return StatusCode(HttpStatusCode.NoContent);
        }
        [HttpDelete]
        public IHttpActionResult DeleteVideo(int id)
        {
            var videoInDb = _unitOfWork.Videos.Get(id);
            if (videoInDb == null)
                return NotFound();

            _unitOfWork.Videos.Delete(id);
            _unitOfWork.Videos.Save();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _unitOfWork.Videos.Dispose();
            base.Dispose(disposing);
        }
    }
}
