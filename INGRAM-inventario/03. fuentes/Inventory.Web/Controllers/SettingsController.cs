using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory.Web.Controllers
{
    public class SettingsController : Controller
    {
        // GET: Settings
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DeleteHistory()
        {

            return View("DeleteHistory");
        }

        public ActionResult DeleteOk()
        {
            Business.Web.Settings.DeleteHistory();
            return View("DeleteOk");
        }

        public ActionResult DeleteCancel()
        {

            return RedirectToAction("Index", "Query");
        }
    }
}