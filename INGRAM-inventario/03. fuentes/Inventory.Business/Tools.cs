using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Business
{
    public class Tools
    {
        public static bool comparePassword(string encrPassword, string textPassword)
        {
            return encrPassword.Equals(Utilities.Encryption.StringToMD5Hash(textPassword));
        }
    }
}
