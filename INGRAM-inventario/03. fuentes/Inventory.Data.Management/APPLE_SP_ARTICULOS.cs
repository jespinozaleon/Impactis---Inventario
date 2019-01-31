using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Data.Management
{
    public class APPLE_SP_ARTICULOS
    {
        public static List<Domain.APPLE_SP_ARTICULOS> GetData(string vdr, int? sku)
        {
            try
            {
                var db = new Data.Access.Context();

                //var result = db.APPLE_SP_ARTICULOS.Where(d => d.VDR_PARTNB == loadId).OrderBy(d => d.CDG_ID).ToList();
                var result = db.APPLE_SP_ARTICULOS.Where(d =>
                ((d.VDR_PARTNB.Contains(vdr) || string.IsNullOrEmpty(vdr)) &&
                (d.SKU == sku || sku == null))).OrderBy(d => d.VDR_PARTNB).ToList();

                //result.ForEach(ua => ua.TBL_DATA_ARTICLES = db.TBL_DATA_ARTICLES.SingleOrDefault(d => d.VDR_PARTNB == ua.VDR_PARTNB &&
                //d.SKU == ua.SKU && d.LAST == (byte)Domain.Enums.LAST_REGISTER.ENABLED));

                foreach (var dato in result)
                {
                    var query = TBL_DATA_ARTICLES.GetDetail(dato.VDR_PARTNB, dato.SKU);

                    if (query != null)
                    {
                        dato.STOCK = query.STOCK;
                        dato.NET_AMOUNT = query.NET_AMOUNT;
                        dato.TAX_AMOUNT = query.TAX_AMOUNT;
                        dato.TOTAL_AMOUNT = query.TOTAL_AMOUNT;
                        dato.TIMESTAMP = query.TIMESTAMP.AddHours(int.Parse(Utilities.Parameter.GetValue("TIMESTAMP")));
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                return new List<Domain.APPLE_SP_ARTICULOS>();
            }
           
        }
    }
}
