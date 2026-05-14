using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Division
{
    public int Id { get; set; }

    public string DivisionName { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<District> Districts { get; set; } = new List<District>();

    public virtual ICollection<Farmer> Farmers { get; set; } = new List<Farmer>();
}
