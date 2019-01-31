using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Data.Management
{
    public class TBL_DATA_ARTICLES
    {
        public static List<Domain.TBL_DATA_ARTICLES> GetQueryHistory(string vdr, int sku)
        {
            var db = new Data.Access.Context();

            var result = db.TBL_DATA_ARTICLES.Where(d => d.VDR_PARTNB.ToUpper() == vdr.ToUpper() &&
            d.SKU == sku.ToString()).OrderByDescending(d => d.TIMESTAMP).Take(10).ToList();

            return result;
        }

        public static Domain.TBL_DATA_ARTICLES GetDetail(string vdr, int sku)
        {
            var db = new Data.Access.Context();

            var result = db.TBL_DATA_ARTICLES.SingleOrDefault(d => d.VDR_PARTNB.ToUpper() == vdr.ToUpper() &&
            d.SKU == sku.ToString()  && d.LAST == (byte)Domain.Enums.LAST_REGISTER.ENABLED);

            return result;
        }

        public static Domain.TBL_DATA_ARTICLES GetDetail(long id)
        {
            var db = new Data.Access.Context();

            var result = db.TBL_DATA_ARTICLES.SingleOrDefault(d => d.CDG_ID == id);

            return result;
        }

        public static int Save(Domain.TBL_DATA_ARTICLES detail)
        {
            try
            {
                var db = new Data.Access.Context();
                detail.LAST = (byte)Domain.Enums.LAST_REGISTER.ENABLED;
                detail.TIMESTAMP = DateTime.Now;
                db.TBL_DATA_ARTICLES.Add(detail);

                db.SaveChanges();

                var id = db.TBL_DATA_ARTICLES.OrderByDescending(d => d.CDG_ID).First().CDG_ID;

                return id;
            }
            catch (Exception ex)
            {
                TBL_ERROR.Create(ex, Utilities.Basic.GetCurrentMethod(), "Inventory.Data.Management.TBL_DATA_ARTICLES");
                return 0;
            }
        }

        public static bool UpdateLast(int id)
        {
            try
            {
                var db = new Data.Access.Context();
                var data = db.TBL_DATA_ARTICLES.SingleOrDefault(d => d.CDG_ID == id);

                if (data != null)
                {
                    data.LAST = (byte)Domain.Enums.LAST_REGISTER.DISABLED;
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                TBL_ERROR.Create(ex, Utilities.Basic.GetCurrentMethod(), "Inventory.Data.Management.TBL_DATA_ARTICLES");
                return false;
            }
        }


        public static bool DeleteAll()
        {
            try
            {
                var db = new Data.Access.Context();
                var data = db.TBL_DATA_ARTICLES.ToList();

                //db.TBL_DATA_ARTICLES.
                foreach (var d in data)
                {
                    db.TBL_DATA_ARTICLES.Remove(d);
                }

                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                TBL_ERROR.Create(ex, Utilities.Basic.GetCurrentMethod(), "Inventory.Data.Management.TBL_DATA_ARTICLES");
                return false;
            }
        }
    }
}
