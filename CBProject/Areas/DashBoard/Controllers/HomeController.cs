using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Models.ViewModels;
using Microsoft.AspNet.Identity;
using System.Net;
using System.Web.Mvc;

namespace CBProject.Areas.DashBoard.Controllers
{
    [Authorize(Roles ="")]
    public class HomeController : Controller
    {
             

        // GET: DashBoard/Home
        public ActionResult Index()
        {
            return View();
        }         


    }
}