using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class FertilizerService
    {
        FertilizerRepo repo;
        Mapper mapper;

        public FertilizerService(FertilizerRepo repo)
        {
            this.repo = repo;
            mapper = MapperConfig.GetMapper();
        }

        public List<FertilizerDTO> Get()
        {
            var data = repo.Get();
            return mapper.Map<List<FertilizerDTO>>(data);
        }
        public FertilizerDTO Get(int id)
        {
            var data = repo.Get(id);
            return mapper.Map<FertilizerDTO>(data);
        }

        public bool Create(FertilizerDTO fertilizer)
        {
            var mapped = mapper.Map<Fertilizer>(fertilizer);
            return repo.Create(mapped);
        }

        public bool Update(FertilizerDTO fertilizer)
        {
            var mapped = mapper.Map<Fertilizer>(fertilizer);
            return repo.Update(mapped);
        }
        public bool Delete(int id)
        {
            return repo.Delete(id);
        }

    }
}
