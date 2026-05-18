using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;

namespace BLL.Services
{
    public class NotificationService
    {
        private readonly NotificationRepo repo;
        Mapper mapper;

        public NotificationService(NotificationRepo repo)
        {
            this.repo = repo;
            mapper = MapperConfig.GetMapper();
        }

        public bool Create(NotificationDTO notification)
        {
            var data = mapper.Map<Notification>(notification);

            return repo.Create(data);
        }

        public List<NotificationDTO> GetByRole(string role)
        {
            var data = repo.GetByRole(role);

            return mapper.Map<List<NotificationDTO>>(data);
        }

        public int UnreadCount(string role)
        {
            return repo.UnreadCount(role);
        }

        public bool MarkAllAsRead(string role)
        {
            return repo.MarkAllAsRead(role);
        }
    }
}