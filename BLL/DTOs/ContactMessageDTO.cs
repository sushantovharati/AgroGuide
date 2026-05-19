using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class ContactMessageDTO
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public string? ReplyMessage { get; set; }

        public bool IsReplied { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}