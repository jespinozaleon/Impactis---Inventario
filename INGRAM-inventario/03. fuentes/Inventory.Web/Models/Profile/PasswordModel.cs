using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventory.Web.Models.Profile
{
    public class PasswordModel
    {
        public int UserId { get; set; }

        [Display(Name = "Contraseña actual")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Contraseña actual es requerido.")]
        public string OldPassword { get; set; }

        [Display(Name = "Nueva Contraseña")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Nueva Contraseña es requerido.")]
        public string NewPassword { get; set; }

        [Display(Name = "Confirmar nueva Contraseña")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Confirmar nueva Contraseña es requerido.")]
        public string ConfirmNewPassword { get; set; }

        public string MessageSuccess { get; set; }

        public string MessageError { get; set; }
    }
}