using System.Web.Mvc;

namespace CBProject.Areas.DashBoard.Controllers
{
    public class RatingsController : Controller
    {
        // GET: DashBoard/Ratings
        public ActionResult Index()
        {
            return View();
        }

        // GET: DashBoard/Ratings/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DashBoard/Ratings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DashBoard/Ratings/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DashBoard/Ratings/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DashBoard/Ratings/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DashBoard/Ratings/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DashBoard/Ratings/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
