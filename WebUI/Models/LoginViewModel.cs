﻿using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} caracters long", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
