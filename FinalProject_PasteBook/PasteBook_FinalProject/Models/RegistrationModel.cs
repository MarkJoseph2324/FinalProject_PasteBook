using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PasteBook_FinalProject
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Username is a required field.")]
        [DisplayName("Username:")]
        public string Username { get; set; }

        [Required(ErrorMessage = "First Name is a required field.")]
        [DisplayName("First Name:")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is a required field.")]
        [DisplayName("Last Name:")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is a required field.")]
        [DisplayName("Email:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is a required field.")]
        [DataType(DataType.Password)]
        [DisplayName("Password:")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is a required field.")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password do not match.")]
        [DisplayName("Confirm Password:")]
        public string ConfirmPassword { get; set; }

        public string Gender { get; set; }

        [Required(ErrorMessage = "Birth Date is a required field.")]
        [DisplayName("Birth Date:")]
        public DateTime Birthday { get; set; }

        public int CountryID { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Mobile Number:")]
        public string MobileNumber { get; set; }
    }
}