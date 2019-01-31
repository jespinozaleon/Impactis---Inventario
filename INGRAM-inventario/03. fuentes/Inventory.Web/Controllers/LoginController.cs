using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            var model = new Models.Login.IndexModel();

            return View("Index", model);
        }
       
        [HttpPost]
        public ActionResult Index(Models.Login.IndexModel model)
        {
            var user = Business.Web.Security.User_Authenticate(model.UserName, model.Password);

            if (user != null)
            {
                user.CAR_NAME = user.CAR_NAME;
                user.CAR_EMAIL = user.CAR_EMAIL; ;
                user.CAR_USER_NAME = user.CAR_USER_NAME;
                user.COD_PROFILE = user.COD_PROFILE;
                user.CAR_PROFILE = user.CAR_PROFILE;
                user.CDG_ID = user.CDG_ID;
                Sesion.Manager.User = user;
            }
            else
            {
                model.MessageError = "El nombre de Usuario o Contraseña ingresados son inválidos.";
                model.UserName = string.Empty;
                model.Password = string.Empty;
                ModelState.Clear();

                return View("Index", model);
            }
            
            return RedirectToAction("Index", "Query");
        }

        public ActionResult Logout()
        {
            var model = new Models.Login.IndexModel();

            return RedirectToAction("Index");
        }
    }
}