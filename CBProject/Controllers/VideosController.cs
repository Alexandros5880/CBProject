using CBProject.Controllers;
using CBProject.Models.ViewModels;
using CBProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CBProject.HelperClasses.Interfaces;
using Microsoft.AspNet.Identity;

namespace CBProject.Controllers
{
    public class VideosController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        

        public VideosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
           
        }



        // GET: DashBoard/Video
        public ActionResult Index()
        {
            return View();
        }

        #region LoggedInUser


        public ActionResult AllVideos()
        {
            return View();
        }

        public ActionResult MyVideos() // 
        {
            return View();
        }

        #endregion

        #region Content Creator

        [Authorize(Roles = "Admin, ContentCreator")]
        public ActionResult MyVideosCC() // Content Creator -> Add Video, Edit Video, Delete Video
        {
            var userId = User.Identity.GetUserId();

            var viewModel = new VideoViewModel()
            {
                Videos = _unitOfWork.Videos.GetVideosCC(userId).ToList(),
                Categories = _unitOfWork.Categories.GetAll()
            };
            return View(viewModel);
        }

        [Authorize(Roles = "Admin, ContentCreator")]
       //[ChildActionOnly]
        public ActionResult UploadVideo()
        {

            var viewModel = new VideoViewModel()
            {                
                Video = new Video(),
                Categories = _unitOfWork.Categories.GetAll()
        };
            return PartialView("_UploadVideo",viewModel);
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
                Video = video
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