using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Data.Management
{
    public class TBL_ERROR
    {

        public static List<Domain.TBL_ERROR> GetErrors()
        {
            var db = new Data.Access.Context();

            var result = db.TBL_ERROR.OrderBy(d => d.CDG_ID).ToList();

            return result;
        }

        public static Domain.TBL_ERROR GetError(long id)
        {
            var db = new Data.Access.Context();

            var result = db.TBL_ERROR.SingleOrDefault(d => d.CDG_ID == id);

            return result;
        }


        public static int Save(Domain.TBL_ERROR error)
        {
            try
            {
                var db = new Data.Access.Context();
                error.DAT_TIMESTAMP = DateTime.Now;
                db.TBL_ERROR.Add(error);

                db.SaveChanges();

                var id = db.TBL_ERROR.OrderByDescending(d => d.CDG_ID).First().CDG_ID;

                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static void Create(System.Exception ex, string method, string library)
        {
            var error = new Domain.TBL_ERROR()
            {
                CAR_HEADER = ex.ToString(),
                CAR_MESSAGE = ex.Message,
                CAR_STACKTRACE = ex.StackTrace,
                CAR_METHOD = method,
                CAR_LIBRARY = library
            };

            Save(error);
        }

        public static void Create(string message, string header,string trace, string method, string library)
        {
            var error = new Domain.TBL_ERROR()
            {
                CAR_HEADER = header,
                CAR_MESSAGE = message,
                CAR_STACKTRACE = trace,
                CAR_METHOD = method,
                CAR_LIBRARY = library
            };

            Save(error);
        }


    }
}
