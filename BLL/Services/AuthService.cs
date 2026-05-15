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
        private readonly AdminRepo adminRepo;

        public AuthService(FarmerRepo farmerRepo, AdminRepo adminRepo)
        {
            this.farmerRepo = farmerRepo;
            this.adminRepo = adminRepo;
            mapper = MapperConfig.GetMapper();
        }

        public bool Register(RegisterDTO data)
        {
            var farmer = mapper.Map<Farmer>(data);

            farmer.CreatedAt = DateTime.Now;

            return farmerRepo.Create(farmer);
        }

        public LoginResponseDTO Login(LoginDTO data)
        {
            var admin = adminRepo.GetByEmailPassword(data.Email, data.Password);

            if (admin != null)
            {
                return new LoginResponseDTO
                {
                    Id = admin.Id,
                    Name = admin.FirstName + " " + admin.LastName,
                    Email = admin.Email,
                    Role = "Admin"
                };
            }

            var farmer = farmerRepo.GetByEmailPassword(data.Email, data.Password);

            if (farmer != null)
            {
                return new LoginResponseDTO
                {
                    Id = farmer.Id,
                    Name = farmer.FirstName + " " + farmer.LastName,
                    Email = farmer.Email,
                    Role = "Farmer"
                };
            }

            return null;
        }
    }
}
