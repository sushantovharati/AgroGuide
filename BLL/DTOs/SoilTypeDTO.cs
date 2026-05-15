using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class SoilTypeDTO
    {
        public int Id { get; set; }

        public string SoilName { get; set; } = null!;

        public string Description { get; set; } = null!;

        public virtual ICollection<CropDTO> Crops { get; set; } = new List<CropDTO>();
    }
}
