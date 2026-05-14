using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Farmer
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? DivisionId { get; set; }

    public int DistrictId { get; set; }

    public string Address { get; set; } = null!;

    public string LandSize { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string Password { get; set; } = null!;

    public virtual District District { get; set; } = null!;

    public virtual Division? Division { get; set; }
}
