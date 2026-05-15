using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class DistrictDTO
    {
        public int Id { get; set; }

        public string DistrictName { get; set; } = null!;

        public int DivisionId { get; set; }

        public bool IsActive { get; set; }

        public virtual DivisionDTO? Division { get; set; }

        public virtual ICollection<FarmerDTO> Farmers { get; set; } = new List<FarmerDTO>();
    }
}
