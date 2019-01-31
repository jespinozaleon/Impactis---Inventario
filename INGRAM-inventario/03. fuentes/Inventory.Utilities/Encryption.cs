using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Utilities
{
    public class Encryption
    {
        public static string StringToMD5Hash(string inputString)
        {
            var md5 = new MD5CryptoServiceProvider();
            var encryptedBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(inputString));
            var sb = new StringBuilder();

            foreach (var t in encryptedBytes)
            {
                sb.AppendFormat("{0:x2}", t);
            }

            return sb.ToString();
        }
    }
}
