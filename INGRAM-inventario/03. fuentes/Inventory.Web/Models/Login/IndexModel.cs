using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventory.Web.Models.Login
{
    public class IndexModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Ingrese su Nombre de Usuario")]
        public string UserName { get; set; }
        public string Rut { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Ingrese su Contraseña")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }

        public string MessageError { get; set; }

        public IndexModel()
        {
            //this.UserName = "usuario-sistema-01";
            //this.Password = "*********";
            this.RememberMe = true;
        }
    }
}