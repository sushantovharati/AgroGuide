using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class ContactMessage
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string Message { get; set; } = null!;

    public string? ReplyMessage { get; set; }

    public bool IsReplied { get; set; }

    public DateTime CreatedAt { get; set; }
}
