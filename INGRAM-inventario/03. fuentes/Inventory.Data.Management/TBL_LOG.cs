using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Data.Management
{
    public class TBL_LOG
    {

        public static List<Domain.TBL_LOG> GetLogs(long loadId)
        {
            var db = new Data.Access.Context();

            var result = db.TBL_LOG.Where(d => d.CDG_LOAD_ID == loadId).OrderBy(d => d.CDG_ID).ToList();

            return result;
        }

        public static Domain.TBL_LOG GetLog(long id)
        {
            var db = new Data.Access.Context();

            var result = db.TBL_LOG.SingleOrDefault(d => d.CDG_ID == id);

            return result;
        }

        public static int Save(Domain.TBL_LOG log)
        {
            try
            {
                var db = new Data.Access.Context();
                log.DAT_TIMESTAMP = DateTime.Now;
                db.TBL_LOG.Add(log);

                db.SaveChanges();

                var id = db.TBL_LOG.OrderByDescending(d => d.CDG_ID).First().CDG_ID;

                return id;
            }
            catch (Exception ex)
            {
                TBL_ERROR.Create(ex, Utilities.Basic.GetCurrentMethod(), "Inventory.Data.Management.TBL_LOG");
                return 0;
            }
        }

        public static void Create(int? loadId, int? userId, string action, string description)
        {
            var log = new Domain.TBL_LOG()
            {
                CAR_ACTION = action,
                CAR_DESCRIPTION = description,
                CDG_LOAD_ID = loadId,
                CDG_USER_ID = userId
            };

            Save(log);
        }
    }
}
