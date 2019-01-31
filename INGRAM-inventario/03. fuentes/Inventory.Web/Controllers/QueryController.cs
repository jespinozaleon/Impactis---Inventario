using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory.Web.Controllers
{
    public class QueryController : Controller
    {
        // GET: Query
        public ActionResult Index(Models.Query.IndexModel model)
        {
            if (model.Sku == null && string.IsNullOrEmpty(model.Vdr))
            {
                Web.Sesion.Manager.VDR = string.Empty;
                Web.Sesion.Manager.SKU = null;
                model.Result = Inventory.Business.Web.Query.GetData(Web.Sesion.Manager.VDR, Web.Sesion.Manager.SKU);
            }

            if (string.IsNullOrEmpty(model.Vdr) == false || model.Sku != null)
            {
                Web.Sesion.Manager.VDR = model.Vdr;
                Web.Sesion.Manager.SKU = model.Sku;

                model.Result = Inventory.Business.Web.Query.GetData(Web.Sesion.Manager.VDR, Web.Sesion.Manager.SKU);

                if (model.Result.Count == 0)
                {
                    model.MessageError = "No se han encontrado productos para la consulta realizada";
                }
            }

            model.Sku = null;
            model.Vdr = string.Empty;
            ModelState.Clear();

            return View("Index", model);
        }


        public ActionResult GetData(string vdrPartNb, int sku)
        {
            var response = Inventory.Business.Web.Query.RefreshData(vdrPartNb, sku, Web.Sesion.Manager.User.CDG_ID, Web.Sesion.Manager.User.CAR_USER_NAME);

            var model = new Models.Query.IndexModel();

            if (response[0] == "CORRECTO")
            {
                model.MessageSuccess = "Información de producto actualizada";
            }
            else if (response[0] == "EXCEPCION" || response[0] == "ERROR")
            {
                model.MessageError = response[1];
            }

            model.Sku = sku;
            model.Vdr = vdrPartNb;

            return RedirectToAction("Index", model);
        }

        public ActionResult ViewDetail(string vdr, int sku)
        {
            var data = Business.Web.Query.GetDataPopUp(vdr, sku);

            Web.Sesion.Manager.VDR = vdr;
            Web.Sesion.Manager.SKU = sku;

            var model = new Models.Query.PopUpModel();

            model.VDR_PARTNB = data.VDR_PARTNB;
            model.SKU = data.SKU;
            model.SKU_DESC = data.SKU_DESC;
            model.VDR_NAME = data.VDR_NAME;
            model.STOCK = data.STOCK;
            model.NET_AMOUNT = data.NET_AMOUNT;
            model.TAX_AMOUNT = data.TAX_AMOUNT;
            model.TOTAL_AMOUNT = data.TOTAL_AMOUNT;
            model.TIMESTAMP = data.TIMESTAMP;
            model.Result = data.Result;

            return PartialView("_ViewDetail", model);
        }

        //[HttpPost]
        //public ActionResult View(Models.Query.PopUpModel model)
        //{
            

        //    var modelOut = new Models.Query.IndexModel();

        //    if (success)//creacion de usuario ok
        //    {
        //        modelOut.MessageSuccess = "El Usuario ha sido habilitado para acceder al sistema.";
        //    }
        //    else
        //    {
        //        modelOut.MessageError = "Error, el Usuario no ha sido habilitado para acceder al sistema.";
        //    }

        //    return RedirectToAction("Index", modelOut);
        //}
    }
}