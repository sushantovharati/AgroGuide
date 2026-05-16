using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Please enter your email")]
        [RegularExpression(@"^[a-zA-Z0-9._]+@[a-zA-Z]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
