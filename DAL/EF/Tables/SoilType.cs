using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class SoilType
{
    public int Id { get; set; }

    public string SoilName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Crop> Crops { get; set; } = new List<Crop>();
}
