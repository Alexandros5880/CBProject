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
    }
}
