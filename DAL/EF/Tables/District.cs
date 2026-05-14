using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class District
{
    public int Id { get; set; }

    public string DistrictName { get; set; } = null!;

    public int DivisionId { get; set; }

    public bool IsActive { get; set; }

    public virtual Division Division { get; set; } = null!;

    public virtual ICollection<Farmer> Farmers { get; set; } = new List<Farmer>();
}
