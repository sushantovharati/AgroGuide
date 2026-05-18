using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class NotificationDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public string Type { get; set; }

        public string UserRole { get; set; }

        public bool IsRead { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}