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
    [Table("TBL_USER")]
    public class TBL_USER
    {
        [Key]
        [Column("CDG_ID")]
        public int CDG_ID { get; set; }

        [Column("CAR_USER_NAME")]
        [Required]
        [StringLength(30)]
        public string CAR_USER_NAME { get; set; }

        [Column("CAR_EMAIL")]
        [StringLength(100)]
        public string CAR_EMAIL { get; set; }

        [Column("CAR_NAME")]
        [Required]
        [StringLength(100)]
        public string CAR_NAME { get; set; }
       
        [Column("CAR_PASSWORD")]
        [Required]
        [StringLength(40)]
        public string CAR_PASSWORD { get; set; }

       [Column("DAT_LAST_ENTRY")]
        public DateTime? DAT_LAST_ENTRY { get; set; }

        [Column("DAT_TIMESTAMP")]
        public DateTime DAT_TIMESTAMP { get; set; }

        [Column("COD_PROFILE")]
        public byte COD_PROFILE { get; set; }

        [NotMapped]
        public string CAR_PROFILE { get; set; }

        [Column("COD_STATUS")]
        public byte COD_STATUS { get; set; }

    }
}
