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
    [Table("TBL_LOG")]
    public class TBL_LOG
    {
        [Key]
        [Column("CDG_ID")]
        public int CDG_ID { get; set; }

        [Column("CDG_LOAD_ID")]
        public int? CDG_LOAD_ID{ get; set; }

        [Column("CDG_USER_ID")]
        public int? CDG_USER_ID { get; set; }

        [Column("CAR_ACTION")]
        [Required]
        public string CAR_ACTION { get; set; }

        [Column("CAR_DESCRIPTION")]
        public string CAR_DESCRIPTION { get; set; }

        [Column("DAT_TIMESTAMP")]
        public DateTime DAT_TIMESTAMP { get; set; }

    }
}
