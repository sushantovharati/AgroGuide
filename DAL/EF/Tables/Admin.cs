using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Admin
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public DateOnly DoB { get; set; }

    public string Address { get; set; } = null!;
}
