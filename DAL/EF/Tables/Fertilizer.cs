using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Fertilizer
{
    public int Id { get; set; }

    public string FertilizerName { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string UsageInstruction { get; set; } = null!;

    public double QuantityPerAcre { get; set; }

    public double Price { get; set; }

    public bool IsActive { get; set; }
}
