using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Crop
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

    public DateTime CreatedAt { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Season Season { get; set; } = null!;

    public virtual SoilType SoilType { get; set; } = null!;

    public virtual WaterRequirement WaterRequirement { get; set; } = null!;
}
