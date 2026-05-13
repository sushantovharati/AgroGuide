using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Farmer
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string District { get; set; } = null!;

    public string LandSize { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
