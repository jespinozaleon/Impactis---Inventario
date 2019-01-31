using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventory.Web.Models.Query
{
    public class PopUpModel
    {
        [Display(Name = "Número de Parte:")]
        public string VDR_PARTNB { get; set; }

        [Display(Name = "SKU:")]
        public int SKU { get; set; }

        [Display(Name = "SKU Descripción:")]
        public string SKU_DESC { get; set; }

        [Display(Name = "Proveedor:")]
        public string VDR_NAME { get; set; }

        [Display(Name = "Stock Actual:")]
        public decimal? STOCK { get; set; }

        [Display(Name = "Valor Neto:")]
        public decimal? NET_AMOUNT { get; set; }

        [Display(Name = "Valor IVA:")]
        public decimal? TAX_AMOUNT { get; set; }

        [Display(Name = "precio:")]
        public decimal? TOTAL_AMOUNT { get; set; }

        [Display(Name = "Fecha consulta:")]
        public DateTime? TIMESTAMP { get; set; }

        public List<Domain.TBL_DATA_ARTICLES> Result { get; set; }
    }
}