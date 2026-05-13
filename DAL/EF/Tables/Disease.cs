using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Disease
{
    public int Id { get; set; }

    public string? DiseaseName { get; set; }

    public string? Symptoms { get; set; }

    public string? Causes { get; set; }

    public string? Solution { get; set; }

    public string? Prevention { get; set; }

    public string? ImageUrl { get; set; }
}
