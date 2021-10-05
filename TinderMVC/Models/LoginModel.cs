using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TinderMVC.Models
{
    public class LoginModel
    {
        [DisplayName("User Name")]
        [Required(ErrorMessage = "{0} is not empty")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "{0} is not empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Remember Me")]
        public bool RememberMe { get; set; }
    }
}
