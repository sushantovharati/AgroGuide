using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    internal class MapperConfig
    {
        public static MapperConfiguration config = new MapperConfiguration(cfg => {
            cfg.CreateMap<Fertilizer, FertilizerDTO>().ReverseMap();
            cfg.CreateMap<Crop, CropDTO>().ReverseMap();
            cfg.CreateMap<Category, CategoryDTO>().ReverseMap();
            cfg.CreateMap<Season, SeasonDTO>().ReverseMap();
            cfg.CreateMap<SoilType, SoilTypeDTO>().ReverseMap();
            cfg.CreateMap<WaterRequirement, WaterRequirementDTO>().ReverseMap();
        });
        public static Mapper GetMapper()
        {
            return new Mapper(config);
        }
    }
}
