using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Treading.ViewModel
{
    public class AuthenticationViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }

        [Required]
        public string  Password { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }
        [Required]
        public string Mobile { get; set; }

        public bool Status { get; set; }


    }
}