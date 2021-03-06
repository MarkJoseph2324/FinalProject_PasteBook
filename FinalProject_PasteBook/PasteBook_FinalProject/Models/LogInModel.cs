﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PasteBook_FinalProject
{
    public class LogInModel
    {
        [Required(ErrorMessage = "Please enter your email address.")]
        [DisplayName("Email:")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        [DataType(DataType.Password)]
        [DisplayName("Password:")]
        public string Password { get; set; }

        public string Salt { get; set; }

        public string FirstName { get; set; }

        public int UserID { get; set; }
    }
}