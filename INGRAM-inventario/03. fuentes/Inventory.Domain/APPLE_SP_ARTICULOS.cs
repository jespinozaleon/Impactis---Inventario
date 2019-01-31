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
    [Table("APPLE_SP_ARTICULOS")]
    public class APPLE_SP_ARTICULOS
    {
        [Key]
        [Column("VDR_PARTNB")]
        public string VDR_PARTNB { get; set; }

        [Column("SKU")]
        public int SKU { get; set; }

        [Column("SKU_DESC")]
        public string SKU_DESC { get; set; }

        [Column("VDR_NAME")]
        public string VDR_NAME { get; set; }

        [NotMapped]
        public decimal? STOCK { get; set; }

        [NotMapped]
        public decimal? NET_AMOUNT { get; set; }

        [NotMapped]
        public decimal? TAX_AMOUNT { get; set; }


        [NotMapped]
        public decimal? TOTAL_AMOUNT { get; set; }

        [NotMapped]
        public DateTime? TIMESTAMP { get; set; }

        //public virtual TBL_DATA_ARTICLES TBL_DATA_ARTICLES { get; set; }

    }
}
