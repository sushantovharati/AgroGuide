using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
    public class FertilizerDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter fertilizer name")]
        [MinLength(2, ErrorMessage = "Fertilizer name must be at least 2 characters")]
        [MaxLength(100, ErrorMessage = "Fertilizer name cannot exceed 100 characters")]
        [RegularExpression(@"^[a-zA-Z\s.]+$", ErrorMessage = "Fertilizer name can only contain letters, spaces, and dots")]
        public string FertilizerName { get; set; }


        [Required(ErrorMessage = "Please enter fertilizer type")]
        [MinLength(3, ErrorMessage = "Type must be at least 3 characters")]
        [MaxLength(50, ErrorMessage = "Type cannot exceed 50 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Type can only contain letters and spaces")]
        public string Type { get; set; }


        [Required(ErrorMessage = "Please enter usage instruction")]
        [MinLength(5, ErrorMessage = "Usage instruction must be at least 5 characters")]
        [MaxLength(150, ErrorMessage = "Usage instruction cannot exceed 150 characters")]
        public string UsageInstruction { get; set; }


        [Required(ErrorMessage = "Please enter quantity per acre")]
        [Range(1, 1000, ErrorMessage = "Quantity per acre must be between 1 and 1000")]
        public float QuantityPerAcre { get; set; }

        [Required(ErrorMessage = "Please enter fertilizer price")]
        [Range(1, 100000, ErrorMessage = "Price must be between 1 and 10000")]
        public float Price { get; set; }

        public bool IsActive { get; set; }

        [Url(ErrorMessage = "Please enter a valid image URL")]
        public string? ImageUrl { get; set; } = null;
    }
}