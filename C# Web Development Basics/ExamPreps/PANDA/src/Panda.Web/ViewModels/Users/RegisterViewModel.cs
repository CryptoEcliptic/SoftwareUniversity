﻿using SIS.MvcFramework.Attributes.Validation;

namespace Panda.Web.ViewModels.Users
{
    public class RegisterViewModel
    {
        [RequiredSis]
        [StringLengthSis(5, 20, "Username should be between 5 and 20 characters!")]
        public string Username { get; set; }

        [RequiredSis]
        public string Password { get; set; }

        [RequiredSis]
        public string ConfirmPassword { get; set; }


        [RequiredSis]
        [StringLengthSis(5, 20, "Email should be between 5 and 20 characters!")]
        public string Email { get; set; }
    }
}
