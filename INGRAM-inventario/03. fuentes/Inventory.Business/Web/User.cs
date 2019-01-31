using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Business.Web
{
    public class User
    {
        //crear usuario
        //listar usuarios
        //retornar usuario

        public static bool User_Create(string userName, string password, string name, string email, byte profileId)
        {
            var user = new Domain.TBL_USER();
            user.CAR_NAME = name;
            user.CAR_PASSWORD = Utilities.Encryption.StringToMD5Hash(password);
            user.CAR_USER_NAME = userName;
            user.CAR_EMAIL = email;
            user.COD_PROFILE = profileId;

            var id = Data.Management.TBL_USER.Save(user);

            return id != 0 ? true : false;
        }

        public static bool User_Update(int userId, string name, string email, byte profileId)
        {
            var user = new Domain.TBL_USER();
            user.CAR_NAME = name;
            user.CAR_EMAIL = email;
            user.COD_PROFILE = profileId;
            user.CDG_ID = userId;

            var success = Data.Management.TBL_USER.Update(user);

            return success;
        }

        public static bool User_UpdatePassword(int userId, string password)
        {
            var ok = Data.Management.TBL_USER.UpdatePassword(userId, Utilities.Encryption.StringToMD5Hash(password));

            if (ok)
            {
                Data.Management.TBL_LOG.Create(null, userId, "Cambio contraseña Usuario", "La contraseña del Usuario ha sido correctamente actualizada.");
            }

            return ok;
        }

        public static bool User_Disabled(int userId)
        {
            var ok = Data.Management.TBL_USER.UpdateStatus(userId, (byte)Domain.Status.TBL_USER.DISABLED);

            if (ok)
            {
                Data.Management.TBL_LOG.Create(null, userId, "Usuario Deshabilitado", "Usuario ha sido deshabilitado, no puede ingresar nuevamente al sistema.");
            }

            return ok;
        }

        public static  bool User_Enabled(int userId)
        {
            var ok = Data.Management.TBL_USER.UpdateStatus(userId, (byte)Domain.Status.TBL_USER.ENABLED);

            if (ok)
            {
                Data.Management.TBL_LOG.Create(null, userId, "Usuario Habilitado", "Usuario ha sido habilitado, puede ingresar nuevamente al sistema.");
            }

            return ok;
        }

        public bool User_LastEntry(int userId)
        {
            var ok = Data.Management.TBL_USER.UpdateLastEntry(userId);

            if (ok)
            {
                Data.Management.TBL_LOG.Create(null, userId, "Login de Usuario", "Ingreso a sistema por parte de Usuario");
            }

            return ok;
        }

        public static List<Domain.TBL_USER> GetUsers()
        {
            var users = Data.Management.TBL_USER.GetUsers();

            for (int i = 0; i < users.Count; i++)
            {
                users[i].CAR_PROFILE = Domain.Enums.GetProfileUser(users[i].COD_PROFILE); 
            }

            return users;
        }

        public static  Domain.TBL_USER GetUser(string userName)
        {
            var user = Data.Management.TBL_USER.GetUser(userName);

            return user;
        }

        public static Domain.TBL_USER GetUser(int userId)
        {
            var user = Data.Management.TBL_USER.GetUser(userId);

            return user;
        }
    }
}
