using DAL.EF;
using DAL.EF.Tables;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    public class ContactMessageRepo
    {
        private readonly AgroGuideMsContext db;

        public ContactMessageRepo(AgroGuideMsContext db)
        {
            this.db = db;
        }

        public bool Create(ContactMessage message)
        {
            db.ContactMessages.Add(message);
            return db.SaveChanges() > 0;
        }

        public List<ContactMessage> Get()
        {
            return db.ContactMessages
                     .OrderByDescending(x => x.CreatedAt)
                     .ToList();
        }

        public ContactMessage Get(int id)
        {
            return db.ContactMessages.Find(id);
        }

        public bool Reply(int id, string replyMessage)
        {
            var exObj = db.ContactMessages.Find(id);

            if (exObj == null)
            {
                return false;
            }

            exObj.ReplyMessage = replyMessage;
            exObj.IsReplied = true;

            return db.SaveChanges() > 0;
        }
    }
}