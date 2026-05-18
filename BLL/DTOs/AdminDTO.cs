using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class AdminDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public DateOnly DoB { get; set; }

        public string Address { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
