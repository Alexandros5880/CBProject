using CBProject.Models;
using CBProject.Models.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CBProject.Areas.DashBoard.Controllers
{  
    [Authorize(Roles ="")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly string userID;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            userID = User.Identity.GetUserId();
        }

        // GET: DashBoard/Home
        public ActionResult Index()
        {
            return View();
        }

        #region LoggedInUser

        public ActionResult AllVideos() // 
        {
            return View();
        }

        public ActionResult MyVideos() // 
        {
            return View();
        }

        #endregion

        #region Content Creator


        [Authorize(Roles ="ContentCreator")]
        public ActionResult MyVideosCC() // Content Creator -> Add Video, Edit Video, Delete Video
        {

            return View();
        }

        [Authorize(Roles = "ContentCreator")]
        public ActionResult EditVideo(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var video = _unitOfWork.Videos.Get(id);

            if (video == null)
                return HttpNotFound();

            var viewModel = new VideoViewModel()
            {
                Video = video,
                Ratings = _unitOfWork.Ratings.GetAll()
            };
            return View(viewModel);
        }

        [Authorize(Roles = "ContentCreator")]
        [HttpPost]
        public ActionResult EditVideo(Video video)
        {
            return View(video);
        }

        [Authorize(Roles = "ContentCreator")]
        public ActionResult DeleteVideo(int? id)
        {
            return RedirectToAction("Index");
        }

        #endregion


    }
}