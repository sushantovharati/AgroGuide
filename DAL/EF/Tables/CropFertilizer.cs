using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class CropFertilizer
{
    public int Id { get; set; }

    public int CropId { get; set; }

    public int FertilizerId { get; set; }
}
