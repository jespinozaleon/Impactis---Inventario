using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventory.Web.Models.Users
{
    public class UserModel
    {
        public int UserId { get; set; }

        [Display(Name = "Nombre de Usuario:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Nombre de Usuario es requerido.")]
        public string UserName { get; set; }

        [Display(Name = "Nombre:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Nombre es requerido.")]
        public string Name { get; set; }

        [Display(Name = "Email de Usuario:")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Password es requerido.")]
        public string Password { get; set; }

        [Display(Name = "Perfil de Usuario:")]
        public byte ProfileId { get; set; }

        [Display(Name = "Perfil de Usuario:")]
        public string Profile { get; set; }

        public List<Code.Item> Profiles { get; set; }

        public string MessageSuccess { get; set; }

        public string MessageError { get; set; }

        public UserModel()
        {
            this.Profiles = Code.Data.GetProfiles();
        }

    }
}