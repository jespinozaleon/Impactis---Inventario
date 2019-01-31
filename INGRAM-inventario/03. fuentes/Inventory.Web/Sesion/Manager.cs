using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory.Web.Sesion
{
    public class Manager
    {
        public static Domain.TBL_USER User
        {
            get
            {
                if (HttpContext.Current.Session["User"] != null)
                {
                    return HttpContext.Current.Session["User"] as Domain.TBL_USER;
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session["User"] = value;
            }
        }

        public static string VDR
        {
            get
            {
                if (HttpContext.Current.Session["VDR"] != null)
                {
                    return HttpContext.Current.Session["VDR"] as string;
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session["VDR"] = value;
            }
        }

        public static int? SKU
        {
            get
            {
                if (HttpContext.Current.Session["SKU"] != null)
                {
                    return HttpContext.Current.Session["SKU"] as int?;
                }

                return null;
            }
            set
            {
                HttpContext.Current.Session["SKU"] = value;
            }
        }
    }
}