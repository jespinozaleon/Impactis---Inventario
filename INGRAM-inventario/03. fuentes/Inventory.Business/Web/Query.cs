using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Business.Web
{
    public class Query
    {
        public static List<Domain.APPLE_SP_ARTICULOS> GetData(string vdr, int? sku)
        {
            if (string.IsNullOrEmpty(vdr) && sku == null)
            {
                return new List<Domain.APPLE_SP_ARTICULOS>();
            }

            return Data.Management.APPLE_SP_ARTICULOS.GetData(vdr, sku);
        }


        public static ResponseQueryPopUp GetDataPopUp(string vdr, int? sku)
        {
            if (string.IsNullOrEmpty(vdr) && sku == null)
            {
                return null;
            }

            var result = new ResponseQueryPopUp();

            var list = Data.Management.APPLE_SP_ARTICULOS.GetData(vdr, sku);

            if (list.Count == 0)
                return null;

            result.VDR_PARTNB = list[0].VDR_PARTNB;
            result.SKU = list[0].SKU;
            result.SKU_DESC = list[0].SKU_DESC;
            result.VDR_NAME = list[0].VDR_NAME;
            result.STOCK = list[0].STOCK;
            result.NET_AMOUNT = list[0].NET_AMOUNT;
            result.TAX_AMOUNT = list[0].TAX_AMOUNT;
            result.TOTAL_AMOUNT = list[0].TOTAL_AMOUNT;

            if (list[0].TIMESTAMP != null)
            {
                result.TIMESTAMP = list[0].TIMESTAMP.Value.AddHours(int.Parse(Utilities.Parameter.GetValue("TIMESTAMP_CAB")));
            }
            else
            {
                result.TIMESTAMP = null;
            }

            var resultList = Data.Management.TBL_DATA_ARTICLES.GetQueryHistory(result.VDR_PARTNB, result.SKU);

            result.Result = new List<Domain.TBL_DATA_ARTICLES>();

            foreach (var r in resultList)
            {
                var nr = new Domain.TBL_DATA_ARTICLES();
                nr.CDG_ID = r.CDG_ID;
                nr.LAST = r.LAST;
                nr.NET_AMOUNT = r.NET_AMOUNT;
                nr.SKU = r.SKU;
                nr.STOCK = r.STOCK;
                nr.TAX_AMOUNT = r.TAX_AMOUNT;
                nr.TIMESTAMP = r.TIMESTAMP.AddHours(int.Parse(Utilities.Parameter.GetValue("TIMESTAMP")));
                nr.TOTAL_AMOUNT = r.TOTAL_AMOUNT;
                nr.USER_CDG_ID = r.USER_CDG_ID;
                nr.USER_NAME = r.USER_NAME;
                nr.VDR_PARTNB = r.VDR_PARTNB;
                result.Result.Add(nr);
            }

            return result;
        }

        public static string[] RefreshData(string vdr, int sku, int usuarioId, string userName)
        {
            var response = Services.LoadData.QueryStock(vdr, sku);

            var update = Data.Management.TBL_DATA_ARTICLES.GetDetail(vdr, sku);

            if (update != null)
            {
                Data.Management.TBL_DATA_ARTICLES.UpdateLast(update.CDG_ID);
            }

            var dataNew = new Domain.TBL_DATA_ARTICLES();
            dataNew.SKU = sku.ToString();
            dataNew.VDR_PARTNB = vdr;
            dataNew.NET_AMOUNT = response.NetAmount;
            dataNew.TAX_AMOUNT = response.TaxAmount;
            dataNew.TOTAL_AMOUNT = response.TotalAmount;
            dataNew.STOCK = response.Stock;
            dataNew.USER_CDG_ID = usuarioId;
            dataNew.USER_NAME = userName;
            int dataId = Data.Management.TBL_DATA_ARTICLES.Save(dataNew);
            var estado = "";

            if (response.Error == (byte)Services.Response.ErrorType.CORRECTO)
            {
                Data.Management.TBL_LOG.Create(dataId, usuarioId, "Consulta producto: vdr(" + vdr + ") sku(" + sku + ") Resultado: " + Services.Response.ErrorType.CORRECTO.ToString(), "");
                estado = Services.Response.ErrorType.CORRECTO.ToString();
            }
            else if (response.Error == (byte)Services.Response.ErrorType.EXCEPCION)
            {
                Data.Management.TBL_LOG.Create(dataId, usuarioId, "Consulta producto: vdr(" + vdr + ") sku(" + sku + ") Resultado: " + Services.Response.ErrorType.EXCEPCION.ToString(), response.Message);
                estado = Services.Response.ErrorType.EXCEPCION.ToString();
            }
            else if (response.Error == (byte)Services.Response.ErrorType.ERROR)
            {
                Data.Management.TBL_LOG.Create(dataId, usuarioId, "Consulta producto: vdr(" + vdr + ") sku(" + sku + ") Resultado: " + Services.Response.ErrorType.ERROR.ToString(),response.Message);
                estado = Services.Response.ErrorType.ERROR.ToString();
            }

            return new string[2] { estado, response.Message };
        }

    }
}
