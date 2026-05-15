using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class FarmerDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int DivisionId { get; set; }

        public int DistrictId { get; set; }

        public string Address { get; set; } = null!;

        public string LandSize { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

        public string Password { get; set; } = null!;

        public virtual DistrictDTO? District { get; set; }

        public virtual DivisionDTO? Division { get; set; }
    }
}
