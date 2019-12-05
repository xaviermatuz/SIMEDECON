using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SIMEDECON.Models
{
    public class UserEdit
    {
       
        [Display(Name = "Usuario")]
        public string UserName { get; set; }
       
        [Display(Name = "Correo")]
        public string Email { get; set; }
        
        
    }
}