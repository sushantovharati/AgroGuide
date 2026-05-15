using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BLL.Services
{
    public class DistrictService
    {
        DistrictRepo repo;
        Mapper mapper;

        public DistrictService(DistrictRepo repo)
        {
            this.repo = repo;
            mapper = MapperConfig.GetMapper();
        }
                
        public List<DistrictDTO> Get()
        {
            var data = repo.Get();
            return mapper.Map<List<DistrictDTO>>(data);
        }
        public DistrictDTO Get(int id)
        {
            var data = repo.Get(id);
            return mapper.Map<DistrictDTO>(data);
        }

        public List<DistrictDTO> GetByDivisionId(int divisionId)
        {
            var data = repo.GetByDivisionId(divisionId);
            return mapper.Map<List<DistrictDTO>>(data);
        }

    }
}
