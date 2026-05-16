using BLL.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Please enter your first name")]
        [MinLength(3, ErrorMessage = "First Name must be at least 3 characters")]
        [RegularExpression(@"^[a-zA-Z.\s]+$", ErrorMessage = "First Name can only contain letters, spaces, and dots")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Please enter your last name")]
        //[MinLength(3, ErrorMessage = "Last Name must be at least 3 characters")]
        [RegularExpression(@"^[a-zA-Z.\s]+$", ErrorMessage = "Last Name can only contain letters, spaces, and dots")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Please enter your phone number")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only numbers are allowed")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Phone number must be exactly 11 digits")]
        [PhoneUnique]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Please enter your email")]
        [RegularExpression(@"^[a-zA-Z0-9._]+@[a-zA-Z]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid email")]
        [EmailUnique]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please select your division")]
        public int DivisionId { get; set; }


        [Required(ErrorMessage = "Please select your district")]
        public int DistrictId { get; set; }


        [Required(ErrorMessage = "Please enter your address")]
        [MinLength(5, ErrorMessage = "Address must be at least 5 characters")]
        [MaxLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Please enter your land size")]
        public string LandSize { get; set; }


        public DateTime? CreatedAt { get; set; }


        [Required(ErrorMessage = "Please enter your password")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        [MaxLength(32, ErrorMessage = "Password cannot exceed 32 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Please enter your confirm password")]
        [Compare("Password",
            ErrorMessage = "Password and Confirm Password do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}