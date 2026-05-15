using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class SeasonService
    {
        SeasonRepo repo;
        Mapper mapper;

        public SeasonService(SeasonRepo repo)
        {
            this.repo = repo;
            mapper = MapperConfig.GetMapper();
        }

        public List<SeasonDTO> Get()
        {
            var data = repo.Get();
            return mapper.Map<List<SeasonDTO>>(data);
        }
        public SeasonDTO Get(int id)
        {
            var data = repo.Get(id);
            return mapper.Map<SeasonDTO>(data);
        }

        public bool Create(SeasonDTO season)
        {
            var mapped = mapper.Map<Season>(season);
            return repo.Create(mapped);
        }

        public bool Update(SeasonDTO season)
        {
            var mapped = mapper.Map<Season>(season);
            return repo.Update(mapped);
        }
        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
