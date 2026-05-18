using DAL.EF;
using DAL.EF.Tables;
using System.Linq;

namespace DAL.Repos
{
    public class AdminRepo
    {
        private readonly AgroGuideMsContext db;

        public AdminRepo(AgroGuideMsContext db)
        {
            this.db = db;
        }

        public Admin Get(int id)
        {
            return db.Admins.Find(id);
        }

        public Admin GetByEmailPassword(string email, string password)
        {
            var data = (from a in db.Admins
                        where a.Email.Equals(email)
                        && a.Password.Equals(password)
                        select a).SingleOrDefault();

            return data;
        }

        public bool Update(Admin admin)
        {
            var exObj = db.Admins.Find(admin.Id);

            if (exObj == null)
            {
                return false;
            }

            exObj.FirstName = admin.FirstName;
            exObj.LastName = admin.LastName;
            exObj.Phone = admin.Phone;
            exObj.DoB = admin.DoB;
            exObj.Address = admin.Address;

            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Admins.Remove(exobj);
            return db.SaveChanges() > 0;
        }
    }
}