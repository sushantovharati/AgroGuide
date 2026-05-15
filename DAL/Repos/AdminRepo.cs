using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class AdminRepo
    {
        AgroGuideMsContext db;
        public AdminRepo(AgroGuideMsContext db)
        {
            this.db = db;
        }

        public Admin GetByEmailPassword(string email, string password)
        {
            var data = (from a in db.Admins
                        where a.Email.Equals(email)
                        && a.Password.Equals(password)
                        select a).SingleOrDefault();

            return data;
        }
    }
}
