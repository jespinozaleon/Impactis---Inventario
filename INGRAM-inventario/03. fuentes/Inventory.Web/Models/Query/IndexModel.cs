using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventory.Web.Models.Query
{
    public class IndexModel
    {
        public string MessageError { get; set; }

        public string MessageSuccess { get; set; }

        public List<Domain.APPLE_SP_ARTICULOS> Result { get; set; }

        [Display(Name = "NÚMERO DE PARTE:")]
        public string Vdr { get; set; }

        [Display(Name = "SKU:")]
        public int? Sku { get; set; }

        public IndexModel()
        { }
    }
}