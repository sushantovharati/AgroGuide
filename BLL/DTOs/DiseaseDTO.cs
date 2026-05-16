using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class DiseaseDTO
    {
        public int Id { get; set; }

        public string DiseaseName { get; set; } = null!;

        public string Symptoms { get; set; } = null!;

        public string Causes { get; set; } = null!;

        public string Solution { get; set; } = null!;

        public string Prevention { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public bool IsActive { get; set; } = false;

        public DateTime? CreatedAt { get; set; }
    }
}
