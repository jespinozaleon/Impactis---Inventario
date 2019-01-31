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
    [Table("TBL_ERROR")]
    public class TBL_ERROR
    {
        [Key]
        [Column("CDG_ID")]
        public int CDG_ID { get; set; }

        [Column("CAR_MESSAGE")]
        [StringLength(4000)]
        public string CAR_MESSAGE { get; set; }

        [Column("CAR_HEADER")]
        [StringLength(2500)]
        public string CAR_HEADER { get; set; }

        [Column("CAR_STACKTRACE")]
        [StringLength(2500)]
        public string CAR_STACKTRACE { get; set; }

        [Column("CAR_METHOD")]
        [StringLength(400)]
        public string CAR_METHOD { get; set; }

        [Column("CAR_LIBRARY")]
        [StringLength(400)]
        public string CAR_LIBRARY { get; set; }

        [Column("DAT_TIMESTAMP")]
        public DateTime DAT_TIMESTAMP { get; set; }
    }
}
