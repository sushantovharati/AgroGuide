using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class DiseaseService
    {
        DiseaseRepo repo;
        Mapper mapper;

        public DiseaseService(DiseaseRepo repo)
        {
            this.repo = repo;
            mapper = MapperConfig.GetMapper();
        }

        public List<DiseaseDTO> Get()
        {
            var data = repo.Get();
            return mapper.Map<List<DiseaseDTO>>(data);
        }
        public DiseaseDTO Get(int id)
        {
            var data = repo.Get(id);
            return mapper.Map<DiseaseDTO>(data);
        }

        public bool Create(DiseaseDTO Disease)
        {
            var mapped = mapper.Map<Disease>(Disease);
            return repo.Create(mapped);
        }

        public bool Update(DiseaseDTO Disease)
        {
            var mapped = mapper.Map<Disease>(Disease);
            return repo.Update(mapped);
        }
        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
