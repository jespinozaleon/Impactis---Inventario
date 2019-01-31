using MvcPaging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventory.Web.Models.Users
{
    public class IndexModel
    {
        public string MessageError { get; set; }

        public string MessageSuccess { get; set; }

        public List<Domain.TBL_USER> Result { get; set; }

        [Display(Name = "Nombre Usuario:")]
        public string Name { get; set; }

        public IndexModel()
        {
        }
    }
}