using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain
{
    [Serializable]
    [Table("TBL_DATA_ARTICLES")]
    public class TBL_DATA_ARTICLES
    {
        [Key]
        [Column("CDG_ID")]
        public int CDG_ID { get; set; }

        [Column("VDR_PARTNB")]
        public string VDR_PARTNB { get; set; }

        [Column("SKU")]
        public string SKU { get; set; }

        [Column("STOCK")]
        public decimal STOCK { get; set; }

        [Column("NET_AMOUNT")]
        public decimal NET_AMOUNT { get; set; }

        [Column("TAX_AMOUNT")]
        public decimal TAX_AMOUNT { get; set; }

        [Column("TOTAL_AMOUNT")]
        public decimal TOTAL_AMOUNT { get; set; }

        [Column("TIMESTAMP")]
        public DateTime TIMESTAMP { get; set; }

        [Column("LAST")]
        public decimal LAST { get; set; }

        [Column("USER_CDG_ID")]
        public int USER_CDG_ID { get; set; }

        [Column("USER_NAME")]
        public string USER_NAME { get; set; }

    }
}
