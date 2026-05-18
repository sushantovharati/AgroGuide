using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;

namespace BLL.Services
{
    public class AdminService
    {
        AdminRepo repo;
        Mapper mapper;

        public AdminService(AdminRepo repo)
        {
            this.repo = repo;
            mapper = MapperConfig.GetMapper();
        }

        public AdminDTO Get(int id)
        {
            var data = repo.Get(id);

            return mapper.Map<AdminDTO>(data);
        }

        public bool Update(AdminDTO admin)
        {
            var data = mapper.Map<Admin>(admin);

            return repo.Update(data);
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}