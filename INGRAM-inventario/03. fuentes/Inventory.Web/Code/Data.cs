using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory.Web.Code
{
    public class Data
    {
        public static List<Code.Item> GetProfiles()
        {
            var profiles = new List<Code.Item>();

            profiles.Add(new Code.Item { Id = (byte)Domain.Enums.USER_PROFILE.ADMIN, Description = "Administrador" });
            profiles.Add(new Code.Item { Id = (byte)Domain.Enums.USER_PROFILE.BASIC, Description = "Consultor" });

            return profiles;
        }
    }
}