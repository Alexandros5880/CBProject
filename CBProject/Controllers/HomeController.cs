<<<<<<< HEAD
﻿using AutoMapper;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Models.EntityModels;
using CBProject.Models.ViewModels;
using CBProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
=======
﻿using System.Web.Mvc;
>>>>>>> 24bfad01bd476523b662bbd8f380dd607b7c08ea

namespace CBProject.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Ebook> _ebooksRepository;
        //private IRepository<Video> _videosRepository;
       // private IRepository<Plans> _plansRepository;

        public HomeController(IUnitOfWork unitOfWork)
        {
            this._ebooksRepository = unitOfWork.Ebooks;
           // this._videosRepository = unitOfWork.Videos;
            //this._plansRepository = unitOfWork.Plans;

        }
        public async Task<ActionResult> Index()
        {

            HomeViewModel viewModel = new HomeViewModel()
            {
                Ebooks = await this._ebooksRepository.GetAllAsync()
            };

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}