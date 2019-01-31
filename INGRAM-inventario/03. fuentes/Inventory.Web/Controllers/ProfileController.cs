using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory.Web.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Password()
        {
            var model = new Models.Profile.PasswordModel();
            model.UserId = Sesion.Manager.User.CDG_ID;
            return View("Password", model);
        }

        [HttpPost]
        public ActionResult Password(Models.Profile.PasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                //model.Validation = true;
                return View("Password", model);
            }

            var user = Business.Web.User.GetUser(model.UserId);

            if (Business.Tools.comparePassword(user.CAR_PASSWORD, model.OldPassword))//valida que password actual este bien ingresada
            {
                if (model.NewPassword.Equals(model.ConfirmNewPassword))//valida que las password's nuevas sean iguales
                {
                    var success = Business.Web.User.User_UpdatePassword(model.UserId, model.NewPassword);

                    if (success == true)
                    {
                        model.MessageSuccess = "La contraseña del Usuario ha sido correctamente actualizada.";
                    }
                    else
                    {
                        model.MessageError = "Ha ocurrido un error, no se ha actualizado la contraseña  del Usuario.";
                    }
                }
                else
                {
                    model.MessageError = "Ha ocurrido un error, las nuevas contraseñas ingresadas son distintas.";
                }
            }
            else
            {
                model.MessageError = "Ha ocurrido un error, la contraseña  del Usuario actual es inválida.";
            }

            return View("Password", model);
        }

    }
}