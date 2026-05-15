using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class CropDTO
    {
        public int Id { get; set; }

        public string CropName { get; set; } = null!;

        public string ScientificName { get; set; } = null!;

        public int CategoryId { get; set; }

        public int SeasonId { get; set; }

        public int SoilTypeId { get; set; }

        public int WaterRequirementId { get; set; }

        public string Description { get; set; } = null!;

        public string GrowthDurationDays { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public DateTime? CreatedAt { get; set; }

        public virtual CategoryDTO? Category { get; set; }

        public virtual SeasonDTO? Season { get; set; }

        public virtual SoilTypeDTO? SoilType { get; set; }

        public virtual WaterRequirementDTO? WaterRequirement { get; set; }
    }
}