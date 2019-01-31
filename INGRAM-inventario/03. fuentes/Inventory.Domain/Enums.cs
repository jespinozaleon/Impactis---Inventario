using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain
{
    public class Enums
    {
        public enum USER_PROFILE
        {
            ADMIN = 1, 
            BASIC= 2
        }

        public enum LAST_REGISTER
        {
            ENABLED = 1,
            DISABLED = 0
        }

        public static string GetProfileUser(byte profileId)
        {
            switch (profileId)
            {
                case (byte)USER_PROFILE.ADMIN: return "ADMINISTRADOR";
                case (byte)USER_PROFILE.BASIC: return "CONSULTA";
                default: return "";
            }
        }
    }
}
