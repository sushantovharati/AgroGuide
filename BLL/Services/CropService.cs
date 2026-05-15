using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class CropService
    {
        CropRepo repo;
        Mapper mapper;

        public CropService(CropRepo repo)
        {
            this.repo = repo;
            mapper = MapperConfig.GetMapper();
        }

        public List<CropDTO> Get()
        {
            var data = repo.Get();
            return mapper.Map<List<CropDTO>>(data);
        }
        public CropDTO Get(int id)
        {
            var data = repo.Get(id);
            return mapper.Map<CropDTO>(data);
        }

        public bool Create(CropDTO Crop)
        {
            var mapped = mapper.Map<Crop>(Crop);
            return repo.Create(mapped);
        }

        public bool Update(CropDTO Crop)
        {
            var mapped = mapper.Map<Crop>(Crop);
            return repo.Update(mapped);
        }
        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
