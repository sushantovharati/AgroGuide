using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class WaterRequirementService
    {
        WaterRequirementRepo repo;
        Mapper mapper;

        public WaterRequirementService(WaterRequirementRepo repo)
        {
            this.repo = repo;
            mapper = MapperConfig.GetMapper();
        }

        public List<WaterRequirementDTO> Get()
        {
            var data = repo.Get();
            return mapper.Map<List<WaterRequirementDTO>>(data);
        }
        public WaterRequirementDTO Get(int id)
        {
            var data = repo.Get(id);
            return mapper.Map<WaterRequirementDTO>(data);
        }

        public bool Create(WaterRequirementDTO WaterRequirement)
        {
            var mapped = mapper.Map<WaterRequirement>(WaterRequirement);
            return repo.Create(mapped);
        }

        public bool Update(WaterRequirementDTO WaterRequirement)
        {
            var mapped = mapper.Map<WaterRequirement>(WaterRequirement);
            return repo.Update(mapped);
        }
        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
