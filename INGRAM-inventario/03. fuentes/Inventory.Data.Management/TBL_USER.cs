using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Data.Management
{
    public class TBL_USER
    {

        public static List<Domain.TBL_USER> GetUsers()
        {
            var db = new Data.Access.Context();

            //var result = db.TBL_USER.Where(c => c.COD_STATUS == (byte) Domain.Status.TBL_USER.ENABLED).ToList();
            var result = db.TBL_USER.ToList();

            return result;
        }

        public static Domain.TBL_USER GetUser(string userName)
        {
            var db = new Data.Access.Context();

            var result = db.TBL_USER.SingleOrDefault(c => c.CAR_USER_NAME.ToLower() == userName.ToLower());

            return result;
        }

        public static Domain.TBL_USER GetUser(int id)
        {
            var db = new Data.Access.Context();

            var result = db.TBL_USER.SingleOrDefault(c => c.CDG_ID == id);

            return result;
        }

        public static int Save(Domain.TBL_USER user)
        {
            try
            {
                var db = new Data.Access.Context();

                user.DAT_TIMESTAMP = DateTime.Now;
                //este estado variar en un futuro si varia la forma de activacion 
                user.COD_STATUS = (byte)Domain.Status.TBL_USER.ENABLED;

                db.TBL_USER.Add(user);

                db.SaveChanges();

                var id = db.TBL_USER.OrderByDescending(d => d.CDG_ID).First().CDG_ID;

                return id;
            }
            catch (Exception ex)
            {
                TBL_ERROR.Create(ex, Utilities.Basic.GetCurrentMethod(), "Inventory.Data.Management.TBL_USER");
                return 0;
            }
        }

        public static bool Update(Domain.TBL_USER user)
        {
            try
            {
                var db = new Data.Access.Context();

                var value = db.TBL_USER.SingleOrDefault(a => a.CDG_ID == user.CDG_ID);

                if (value == null) return false;

                value.CAR_EMAIL = user.CAR_EMAIL;
                value.CAR_NAME = user.CAR_NAME;
                value.COD_PROFILE = user.COD_PROFILE;

                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                TBL_ERROR.Create(ex, Utilities.Basic.GetCurrentMethod(), "Inventory.Data.Management.TBL_USER");
                return false;
            }
        }

        public static bool UpdatePassword(int id, string password)
        {
            try
            {
                var db = new Data.Access.Context();

                var value = db.TBL_USER.SingleOrDefault(a => a.CDG_ID == id);

                if (value == null) return false;

                value.CAR_PASSWORD = password;

                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                TBL_ERROR.Create(ex, Utilities.Basic.GetCurrentMethod(), "Inventory.Data.Management.TBL_USER");
                return false;
            }
        }

        public static bool UpdateStatus(int id, byte statusId)
        {
            try
            {
                var db = new Data.Access.Context();

                var value = db.TBL_USER.SingleOrDefault(a => a.CDG_ID == id);

                if (value == null) return false;

                value.COD_STATUS = statusId;

                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                TBL_ERROR.Create(ex, Utilities.Basic.GetCurrentMethod(), "Inventory.Data.Management.TBL_USER");
                return false;
            }
        }


        public static bool UpdateLastEntry(int id)
        {
            try
            {
                var db = new Data.Access.Context();

                var value = db.TBL_USER.SingleOrDefault(a => a.CDG_ID == id);

                if (value == null) return false;

                value.DAT_LAST_ENTRY = DateTime.Now;

                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                TBL_ERROR.Create(ex, Utilities.Basic.GetCurrentMethod(), "Inventory.Data.Management.TBL_USER");
                return false;
            }
        }

        public static Domain.TBL_USER Authenticate(string userName, string password)
        {
            var db = new Data.Access.Context();

            password = Utilities.Encryption.StringToMD5Hash(password);

            var user = (from u in db.TBL_USER
                        where (u.CAR_USER_NAME.ToLower() == userName.ToLower()) && (u.CAR_PASSWORD == password) && (u.COD_STATUS == (int)Domain.Status.TBL_USER.ENABLED)
                        select u).SingleOrDefault();

            if (user != null)
            {
                user.CAR_PROFILE = Domain.Enums.GetProfileUser(user.COD_PROFILE);
            }

            return user;
        }
    }
}
