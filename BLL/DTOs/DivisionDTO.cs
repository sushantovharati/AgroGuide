using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class DivisionDTO
    {
        public int Id { get; set; }

        public string DivisionName { get; set; } = null!;

        public bool IsActive { get; set; }

        public virtual ICollection<DistrictDTO>? Districts { get; set; } = new List<DistrictDTO>();

        public virtual ICollection<FarmerDTO>? Farmers { get; set; } = new List<FarmerDTO>();
    }
}
