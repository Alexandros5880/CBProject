using System.Web.Mvc;

namespace CBProject.Areas.Forum.Controllers
{
    public class ForumController : Controller
    {
        // GET: Forum/Forum
        public ActionResult Index()
        {
            return View();
        }
    }
}