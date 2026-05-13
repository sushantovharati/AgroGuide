using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Season
{
    public int Id { get; set; }

    public string SeasonName { get; set; } = null!;

    public virtual ICollection<Crop> Crops { get; set; } = new List<Crop>();
}
