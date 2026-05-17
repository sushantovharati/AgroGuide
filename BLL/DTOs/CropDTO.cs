using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
    public class CropDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter crop name")]
        [MinLength(2, ErrorMessage = "Crop name must be at least 2 characters")]
        [MaxLength(100, ErrorMessage = "Crop name cannot exceed 100 characters")]
        [RegularExpression(@"^[a-zA-Z\s\-]+$", ErrorMessage = "Crop name can only contain letters, spaces, and hyphens")]
        public string CropName { get; set; } = null!;


        [Required(ErrorMessage = "Please enter scientific name")]
        [MinLength(3, ErrorMessage = "Scientific name must be at least 3 characters")]
        [MaxLength(150, ErrorMessage = "Scientific name cannot exceed 150 characters")]
        [RegularExpression(@"^[a-zA-Z\s.]+$", ErrorMessage = "Scientific name can only contain letters, spaces, and dots")]
        public string ScientificName { get; set; } = null!;


        [Required(ErrorMessage = "Please select crop category")]
        public int CategoryId { get; set; }


        [Required(ErrorMessage = "Please select season")]
        public int SeasonId { get; set; }


        [Required(ErrorMessage = "Please select soil type")]
        public int SoilTypeId { get; set; }


        [Required(ErrorMessage = "Please select water requirement")]
        public int WaterRequirementId { get; set; }


        [Required(ErrorMessage = "Please enter crop description")]
        [MinLength(5, ErrorMessage = "Description must be at least 5 characters")]
        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; } = null!;


        [Required(ErrorMessage = "Please enter growth duration")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only numbers are allowed")]
        public string GrowthDurationDays { get; set; } = null!;


        [Url(ErrorMessage = "Please enter a valid image URL")]
        public string? ImageUrl { get; set; }

        public DateTime? CreatedAt { get; set; }

        public virtual CategoryDTO? Category { get; set; }

        public virtual SeasonDTO? Season { get; set; }

        public virtual SoilTypeDTO? SoilType { get; set; }

        public virtual WaterRequirementDTO? WaterRequirement { get; set; }
    }
}