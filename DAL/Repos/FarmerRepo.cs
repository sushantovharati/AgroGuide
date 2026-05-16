using DAL.EF;
using DAL.EF.Tables;
using Microsoft.EntityFrameworkCore;
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

        public List<Farmer> Get()
        {
            return db.Farmers.Include(f => f.District)
                .Include(f => f.Division)
                .ToList();
        }

        public Farmer Get(int id)
        {
            return db.Farmers.Find(id);
        } 

        public bool Create(Farmer farmer)
        {
            db.Farmers.Add(farmer);
            return db.SaveChanges() > 0;
        }

        public bool Update(Farmer f)
        {
            var exobj = Get(f.Id);
            db.Entry(exobj).CurrentValues.SetValues(f);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Farmers.Remove(exobj);
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
