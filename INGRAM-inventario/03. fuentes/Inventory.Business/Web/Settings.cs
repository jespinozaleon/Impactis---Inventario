using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Business.Web
{
    public class Settings
    {
        public static bool DeleteHistory()
        {
            return Data.Management.TBL_DATA_ARTICLES.DeleteAll();
        }
    }
}
