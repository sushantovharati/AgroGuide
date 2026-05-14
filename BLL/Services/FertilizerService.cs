using AutoMapper;
using BLL.DTOs;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    internal class FertilizerService
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
    }
}
