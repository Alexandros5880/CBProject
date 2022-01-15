using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CBProject.Areas.Messenger.Controllers
{
    public class MessengerController : Controller
    {
        // GET: Messenger/Messenger
        public ActionResult Index()
        {
            return View();
        }
    }
}