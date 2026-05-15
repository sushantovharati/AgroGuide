using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class CategoryService
    {
        CategoryRepo repo;
        Mapper mapper;

        public CategoryService(CategoryRepo repo)
        {
            this.repo = repo;
            mapper = MapperConfig.GetMapper();
        }

        public List<CategoryDTO> Get()
        {
            var data = repo.Get();
            return mapper.Map<List<CategoryDTO>>(data);
        }
        public CategoryDTO Get(int id)
        {
            var data = repo.Get(id);
            return mapper.Map<CategoryDTO>(data);
        }

        public bool Create(CategoryDTO category)
        {
            var mapped = mapper.Map<Category>(category);
            return repo.Create(mapped);
        }

        public bool Update(CategoryDTO category)
        {
            var mapped = mapper.Map<Category>(category);
            return repo.Update(mapped);
        }
        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
