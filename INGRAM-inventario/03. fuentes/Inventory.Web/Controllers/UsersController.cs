using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPaging;

namespace Inventory.Web.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index(Models.Users.IndexModel model)
        {
            model.Result = GetUsers(model);

            return View("Index", model);
        }


        private List<Domain.TBL_USER> GetUsers(Models.Users.IndexModel model)
        {
            return Business.Web.User.GetUsers();
        }


        public ActionResult Create()
        {
            var model = new Models.Users.UserModel();
            model.ProfileId = model.Profiles[0].Id;
                        
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult Create(Models.Users.UserModel model)
        {
           if (!ModelState.IsValid)
           {
                model.Profiles = Code.Data.GetProfiles();
                return View("Create", model);
            }

            var success = Business.Web.User.User_Create(model.UserName, model.Password, model.Name, model.Email, model.ProfileId);

            if (success)//creacion de usuario ok
            {
                ModelState.Clear();
                model = new Models.Users.UserModel();
                model.Profiles = Code.Data.GetProfiles();
                model.ProfileId = model.Profiles[0].Id;

                model.MessageSuccess = "El Usuario ingresado ha sido creado.";
            }
            else
            {
                model.Profiles = Code.Data.GetProfiles();
                model.MessageError = "Se ha producido un Error al momento de crear el Usuario, intente nuevamente.";
            }


            return View("Create", model);
        }

        public ActionResult Edit(int userId)
        {
            var user = Business.Web.User.GetUser(userId);

            if (user != null)
            {
                var model = new Models.Users.UserModel();
                model.UserId = user.CDG_ID;
                model.Password = "*********";
                model.Name = user.CAR_NAME;
                model.Email = user.CAR_EMAIL;
                model.UserName = user.CAR_USER_NAME;
                model.ProfileId = user.COD_PROFILE;

                return View("Edit", model);
            }

            return RedirectToAction("Index", new Models.Users.IndexModel());
        }

        [HttpPost]
        public ActionResult Edit(Models.Users.UserModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Profiles = Code.Data.GetProfiles();
                model.MessageError = "Se ha producido un Error al momento de actualizar el Usuario, intente nuevamente.";
                return View("Edit", model);
            }

            var success = Business.Web.User.User_Update(model.UserId, model.Name, model.Email, model.ProfileId);

            if (success)//creacion de usuario ok
            {
                var user = Business.Web.User.GetUser(model.UserId);

                ModelState.Clear();
                model = new Models.Users.UserModel();
                model.Profiles = Code.Data.GetProfiles();
                model.ProfileId = user.COD_PROFILE;
                model.Name = user.CAR_NAME;
                model.Email = user.CAR_EMAIL;
                model.Password = string.Empty;
                model.UserName = user.CAR_USER_NAME;
                model.MessageSuccess = "El Usuario seleccionado ha sido actualizado.";
            }
            else
            {
                model.Profiles = Code.Data.GetProfiles();
                model.MessageError = "Se ha producido un Error al momento de actualizar el Usuario, intente nuevamente.";
            }

            return View("Edit", model);
        }

        public ActionResult Password(int userId)
        {
            var user = Business.Web.User.GetUser(userId);

            if (user != null)
            {
                var model = new Models.Users.UserModel();
                model.UserId = user.CDG_ID;
                model.Password = string.Empty;
                model.Name = user.CAR_NAME;
                model.Email = user.CAR_EMAIL;
                model.UserName = user.CAR_USER_NAME;
                model.Profile = Code.Data.GetProfiles().SingleOrDefault(p => p.Id == user.COD_PROFILE).Description;

                return View("Password", model);
            }

            return RedirectToAction("Index", new Models.Users.IndexModel());
        }

        [HttpPost]
        public ActionResult Password(Models.Users.UserModel model)
        {
            if (!ModelState.IsValid)
            {
                model.MessageError = "Se ha producido un Error al momento de actualizar la contraseña de Usuario, intente nuevamente.";

                return View("Password", model);
            }

            var success = Business.Web.User.User_UpdatePassword(model.UserId,  model.Password);

            if (success)//creacion de usuario ok
            {
                var user = Business.Web.User.GetUser(model.UserId);
                
                ModelState.Clear();
                model = new Models.Users.UserModel();

                model.Profile = Code.Data.GetProfiles().SingleOrDefault(p => p.Id == user.COD_PROFILE).Description;
                model.Name = user.CAR_NAME;
                model.Email = user.CAR_EMAIL;
                model.Password = string.Empty;
                model.UserName = user.CAR_USER_NAME;
                model.UserId = user.CDG_ID;

                model.MessageSuccess = "La contraseña de Usuario seleccionado ha sido actualizado.";
            }
            else
            {
                model.Profiles = Code.Data.GetProfiles();
                model.MessageError = "Se ha producido un Error al momento de actualizar la contraseña de Usuario, intente nuevamente.";
            }

            return View("Password", model);
        }

        public ActionResult Enable(int userId)
        {
            return PartialView("_Enable", new Models.Users.PopUpModel() { UserId = userId });
        }

        [HttpPost]
        public ActionResult Enable(Models.Users.PopUpModel model)
        {
            var success = Business.Web.User.User_Enabled(model.UserId);

            var modelOut = new Models.Users.IndexModel();

            if (success)//creacion de usuario ok
            {
                modelOut.MessageSuccess = "El Usuario ha sido habilitado para acceder al sistema.";
            }
            else
            {
                modelOut.MessageError = "Error, el Usuario no ha sido habilitado para acceder al sistema.";
            }

            return RedirectToAction("Index", modelOut);
        }

        public ActionResult Disable(int userId)
        {
            return PartialView("_Disable", new Models.Users.PopUpModel() { UserId = userId });
        }

        [HttpPost]
        public ActionResult Disable(Models.Users.PopUpModel model)
        {
            var success = Business.Web.User.User_Disabled(model.UserId);

            var modelOut = new Models.Users.IndexModel();

            if (success)//creacion de usuario ok
            {
                modelOut.MessageSuccess = "El Usuario ha sido inhabilitado para acceder al sistema.";
            }
            else
            {
                modelOut.MessageError = "Error, el Usuario no ha sido inhabilitado para acceder al sistema.";
            }

            return RedirectToAction("Index", modelOut);
        }

        public JsonResult SearchUser(string userName)
        {
            var user = Business.Web.User.GetUser(userName);

            var success = 0;

            if (user != null)
            {
               
                if (user.COD_PROFILE == (byte)Domain.Status.TBL_USER.DISABLED)
                {
                    success = 2;
                }
                else if (user.COD_PROFILE == (byte)Domain.Status.TBL_USER.ENABLED)
                {
                    success = 1;
                }
            }

            return Json((object)new
            {
                success = success
            });
        }
    }
}