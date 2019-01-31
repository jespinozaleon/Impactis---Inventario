using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Business.Web
{
    public class ResponseQueryPopUp
    {
        public string VDR_PARTNB { get; set; }

        public int SKU { get; set; }

        public string SKU_DESC { get; set; }

        public string VDR_NAME { get; set; }

        public decimal? STOCK { get; set; }

        public decimal? NET_AMOUNT { get; set; }

        public decimal? TAX_AMOUNT { get; set; }

        public decimal? TOTAL_AMOUNT { get; set; }

        public DateTime? TIMESTAMP { get; set; }

        public List<Domain.TBL_DATA_ARTICLES> Result { get; set; }
    }
}
