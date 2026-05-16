using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class FarmerService
    {
        FarmerRepo repo;
        Mapper mapper;

        public FarmerService(FarmerRepo repo)
        {
            this.repo = repo;
            mapper = MapperConfig.GetMapper();
        }

        public List<FarmerDTO> Get()
        {
            var data = repo.Get();
            return mapper.Map<List<FarmerDTO>>(data);
        }
        public FarmerDTO Get(int id)
        {
            var data = repo.Get(id);
            return mapper.Map<FarmerDTO>(data);
        }

        public bool Create(FarmerDTO Farmer)
        {
            var mapped = mapper.Map<Farmer>(Farmer);
            return repo.Create(mapped);
        }

        public bool Update(FarmerDTO Farmer)
        {
            var mapped = mapper.Map<Farmer>(Farmer);
            return repo.Update(mapped);
        }
        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
