using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject_PasteBook
{
    public class RegistrationModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        public int CountryID { get; set; }
        public SelectList Countries { get; set; }
        public string MobileNumber { get; set; }
    }
}