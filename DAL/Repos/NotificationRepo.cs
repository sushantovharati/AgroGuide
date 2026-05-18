using DAL.EF;
using DAL.EF.Tables;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    public class NotificationRepo
    {
        private readonly AgroGuideMsContext db;

        public NotificationRepo(AgroGuideMsContext db)
        {
            this.db = db;
        }

        public bool Create(Notification notification)
        {
            db.Notifications.Add(notification);
            return db.SaveChanges() > 0;
        }

        public List<Notification> GetByRole(string role)
        {
            return db.Notifications
                     .Where(n => n.UserRole == role)
                     .OrderByDescending(n => n.CreatedAt)
                     .ToList();
        }

        public int UnreadCount(string role)
        {
            return db.Notifications
                     .Count(n => n.UserRole == role && n.IsRead == false);
        }

        public bool MarkAllAsRead(string role)
        {
            var data = db.Notifications
                         .Where(n => n.UserRole == role && n.IsRead == false)
                         .ToList();

            foreach (var item in data)
            {
                item.IsRead = true;
            }

            return db.SaveChanges() > 0;
        }
    }
}