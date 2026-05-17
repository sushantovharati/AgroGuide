using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
    public class DiseaseDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter disease name")]
        [MinLength(2, ErrorMessage = "Disease name must be at least 2 characters")]
        [MaxLength(100, ErrorMessage = "Disease name cannot exceed 100 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Disease name can only contain letters and spaces")]
        public string DiseaseName { get; set; } = null!;

        [Required(ErrorMessage = "Please enter symptoms")]
        [MinLength(5, ErrorMessage = "Symptoms must be at least 5 characters")]
        [MaxLength(500, ErrorMessage = "Symptoms cannot exceed 500 characters")]
        public string Symptoms { get; set; } = null!;

        [Required(ErrorMessage = "Please enter causes")]
        [MinLength(5, ErrorMessage = "Causes must be at least 5 characters")]
        [MaxLength(500, ErrorMessage = "Causes cannot exceed 500 characters")]
        public string Causes { get; set; } = null!;

        [Required(ErrorMessage = "Please enter solution")]
        [MinLength(5, ErrorMessage = "Solution must be at least 5 characters")]
        [MaxLength(500, ErrorMessage = "Solution cannot exceed 500 characters")]
        public string Solution { get; set; } = null!;

        [Required(ErrorMessage = "Please enter prevention method")]
        [MinLength(5, ErrorMessage = "Prevention must be at least 5 characters")]
        [MaxLength(500, ErrorMessage = "Prevention cannot exceed 500 characters")]
        public string Prevention { get; set; } = null!;

        [Url(ErrorMessage = "Please enter a valid image URL")]
        public string? ImageUrl { get; set; }

        public bool IsActive { get; set; } = false;

        public DateTime? CreatedAt { get; set; }
    }
}