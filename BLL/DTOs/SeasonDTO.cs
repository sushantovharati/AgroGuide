using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class SeasonDTO
    {
        public int Id { get; set; }

        public string SeasonName { get; set; } = null!;

        public virtual ICollection<CropDTO> Crops { get; set; } = new List<CropDTO>();
    }
}
