using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Treading.ViewModel
{
    public class AuthenticationViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string  Password { get; set; }

        [Required]
        public string Name { get; set; }



    }
}