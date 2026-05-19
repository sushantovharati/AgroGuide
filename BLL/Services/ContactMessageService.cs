using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;
using System.Collections.Generic;

namespace BLL.Services
{
    public class ContactMessageService
    {
        private readonly ContactMessageRepo repo;
        private readonly Mapper mapper;

        public ContactMessageService(ContactMessageRepo repo)
        {
            this.repo = repo;
            mapper = MapperConfig.GetMapper();
        }

        public bool Create(ContactMessageDTO message)
        {
            var data = mapper.Map<ContactMessage>(message);
            return repo.Create(data);
        }

        public List<ContactMessageDTO> Get()
        {
            var data = repo.Get();
            return mapper.Map<List<ContactMessageDTO>>(data);
        }

        public ContactMessageDTO Get(int id)
        {
            var data = repo.Get(id);
            return mapper.Map<ContactMessageDTO>(data);
        }

        public bool Reply(int id, string replyMessage)
        {
            return repo.Reply(id, replyMessage);
        }
    }
}