using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class FertilizerDTO
    {
        public int Id { get; set; }

        public string FertilizerName { get; set; }

        public string Type { get; set; }

        public string UsageInstruction { get; set; }

        public float QuantityPerAcre { get; set; }

        public float Price { get; set; }

        public bool IsActive { get; set; }

        public string? ImageUrl { get; set; } = null;
    }
}