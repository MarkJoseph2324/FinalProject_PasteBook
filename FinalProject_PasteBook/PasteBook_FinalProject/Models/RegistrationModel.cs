using Entities;
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
        [DisplayName("Username:")]
        [Required(ErrorMessage = "Username is a required field.")]
        [StringLength(50, ErrorMessage = "Username should be less than 50 characters only")]
        [RegularExpression(@"^((([_.]?)[a-zA-Z0-9]+)+([_.]?)*)$", ErrorMessage = "Username may contains any letters, numbers and special characters (._). Special characters shouldn't be in consecutive order.")]
        public string Username { get; set; }

        [DisplayName("First Name:")]
        [Required(ErrorMessage = "First Name is a required field.")]
        [StringLength(50, ErrorMessage = "First name should be less than 50 characters only")]
        [RegularExpression(@"^((\s*[ '.-]?\s*[a-zA-Z0-9]+)+[ '.-]?\s*)$", ErrorMessage = "Invalid format. First name may contains any letters, numbers and special characters ('._). Special characters shouldn't be in consecutive order.")]
        public string FirstName { get; set; }

        [DisplayName("Last Name:")]
        [Required(ErrorMessage = "Last Name is a required field.")]
        [StringLength(50, ErrorMessage = "Last name should be less than 50 characters only")]
        [RegularExpression(@"^((\s*[ '.-]?\s*[a-zA-Z0-9]+)+[ '.-]?\s*)$", ErrorMessage = "Invalid format. Last name may contains any letters, numbers and special characters ('._). Special characters shouldn't be in consecutive order.")]
        public string LastName { get; set; }

        [DisplayName("Email:")]
        [Required(ErrorMessage = "Email is a required field.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [DisplayName("Password:")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is a required field.")]
        public string Password { get; set; }

        [DisplayName("Confirm Password:")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password do not match.")]
        [Required(ErrorMessage = "Confirm Password is a required field.")]
        public string ConfirmPassword { get; set; }

        public string Gender { get; set; }

        [DisplayName("Birth Date:")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Birth Date is a required field.")]
        public DateTime Birthday { get; set; }

        [DisplayName("Country:")]
        public int? CountryID { get; set; }

        [DisplayName("Mobile Number:")]
        [DataType(DataType.PhoneNumber)]
        [Phone(ErrorMessage = "Invalid format. ex. 09xxxxxxxxx / 000-0000")]
        public string MobileNumber { get; set; }
    }
}