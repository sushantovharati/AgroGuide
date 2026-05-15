using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class FarmerRepo
    {
        AgroGuideMsContext db;

        public FarmerRepo(AgroGuideMsContext db)
        {
            this.db = db;
        }

        public bool Create(Farmer farmer)
        {
            db.Farmers.Add(farmer);
            return db.SaveChanges() > 0;
        }

        public Farmer GetByEmailPassword(string email, string password)
        {
            var data = (from f in db.Farmers
                        where f.Email.Equals(email)
                        && f.Password.Equals(password)
                        select f).SingleOrDefault();

            return data;
        }
    }
}
