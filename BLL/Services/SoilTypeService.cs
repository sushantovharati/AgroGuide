using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class SoilTypeService
    {
        SoilTypeRepo repo;
        Mapper mapper;

        public SoilTypeService(SoilTypeRepo repo)
        {
            this.repo = repo;
            mapper = MapperConfig.GetMapper();
        }

        public List<SoilTypeDTO> Get()
        {
            var data = repo.Get();
            return mapper.Map<List<SoilTypeDTO>>(data);
        }
        public SoilTypeDTO Get(int id)
        {
            var data = repo.Get(id);
            return mapper.Map<SoilTypeDTO>(data);
        }

        public bool Create(SoilTypeDTO SoilType)
        {
            var mapped = mapper.Map<SoilType>(SoilType);
            return repo.Create(mapped);
        }

        public bool Update(SoilTypeDTO SoilType)
        {
            var mapped = mapper.Map<SoilType>(SoilType);
            return repo.Update(mapped);
        }
        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
