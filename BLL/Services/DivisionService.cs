using AutoMapper;
using BLL.DTOs;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class DivisionService
    {
        DivisionRepo repo;
        Mapper mapper;

        public DivisionService(DivisionRepo repo)
        {
            this.repo = repo;
            mapper = MapperConfig.GetMapper();
        }

        public List<DivisionDTO> Get()
        {
            var data = repo.Get();
            return mapper.Map<List<DivisionDTO>>(data);
        }
        public DivisionDTO Get(int id)
        {
            var data = repo.Get(id);
            return mapper.Map<DivisionDTO>(data);
        }
    }
}
