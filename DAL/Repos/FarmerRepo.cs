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

        public int Count()
        {
            return db.Farmers.Count();
        }

        public List<Farmer> RecentFarmers()
        {
            return db.Farmers
                     .OrderByDescending(x => x.CreatedAt)
                     .Take(5).Include(f => f.District)
                     .ToList();
        }

        public Farmer Get(int id)
        {
            return db.Farmers.Find(id);
        }

        public bool Update(Farmer farmer)
        {
            var exObj = db.Farmers.Find(farmer.Id);

            if (exObj == null)
            {
                return false;
            }

            exObj.FirstName = farmer.FirstName;
            exObj.LastName = farmer.LastName;
            exObj.Phone = farmer.Phone;
            exObj.Address = farmer.Address;
            exObj.LandSize = farmer.LandSize;
            exObj.DivisionId = farmer.DivisionId;
            exObj.DistrictId = farmer.DistrictId;

            return db.SaveChanges() > 0;
        }

        public bool ChangePassword(int id, string password)
        {
            var exObj = db.Farmers.Find(id);

            if (exObj == null)
            {
                return false;
            }

            exObj.Password = password;

            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exObj = db.Farmers.Find(id);

            if (exObj == null)
            {
                return false;
            }

            db.Farmers.Remove(exObj);

            return db.SaveChanges() > 0;
        }

    }
}
