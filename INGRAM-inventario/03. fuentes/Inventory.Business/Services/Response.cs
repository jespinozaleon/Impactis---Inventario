using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Business.Services
{
    public class Response
    {
        public enum ErrorType
        {
            CORRECTO = 0,
            ERROR = 1, 
            EXCEPCION = 2 
        }

        public byte Error { get; set; }

        public bool Success { get; set; }

        public decimal Stock { get; set; }

        public decimal NetAmount { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal TotalAmount { get; set; }


        public string Message { get; set; }
    }
}
