using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Business.Web
{
    public class Security
    {
        public static Domain.TBL_USER User_Authenticate(string userName, string password)
        {
            var user = Data.Management.TBL_USER.Authenticate(userName, password);

            return user;
        }
    }
}
