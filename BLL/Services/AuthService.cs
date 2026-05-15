using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class AuthService
    {
        private readonly FarmerRepo farmerRepo;
        private readonly Mapper mapper;

        public AuthService(FarmerRepo farmerRepo)
        {
            this.farmerRepo = farmerRepo;
            mapper = MapperConfig.GetMapper();
        }

        public bool Register(RegisterDTO data)
        {
            var farmer = mapper.Map<Farmer>(data);

            farmer.CreatedAt = DateTime.Now;

            return farmerRepo.Create(farmer);
        }
    }
}
