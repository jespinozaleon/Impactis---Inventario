using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Utilities
{
    public class Parameter
    {
        public static string GetValue(string key)
        {
            var value = "";

            try
            {
                value = System.Configuration.ConfigurationManager.ConnectionStrings[key].ConnectionString;// from web.config 
            }
            catch
            {
                value = System.Configuration.ConfigurationManager.AppSettings[key]; //from app.config
            }

            //        this.Connection = System.Configuration.ConfigurationManager.
            //ConnectionStrings["ExtDatabase"].ConnectionString;
            //        //

            return value;
        }
    }
}
