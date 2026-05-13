using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class CropDisease
{
    public int Id { get; set; }

    public int CropId { get; set; }

    public int DiseaseId { get; set; }
}
