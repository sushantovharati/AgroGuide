using DAL.EF;
using DAL.EF.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class CropRepo
    {
        AgroGuideMsContext db;

        public CropRepo(AgroGuideMsContext db)
        {
            this.db = db;
        }

        public List<Crop> Get()
        {
            //return db.Crops.ToList();
            return db.Crops.Include(c => c.Category)
                .Include(c => c.Season)
                .Include(c => c.SoilType)
                .Include(c => c.WaterRequirement)
                .ToList();
        }

        public Crop Get(int id)
        {
            return db.Crops.Find(id);
            //return db.Crops
            //    .Include(c => c.Category)
            //    .Include(c => c.Season)
            //    .Include(c => c.SoilType)
            //    .Include(c => c.WaterRequirement)
            //    .FirstOrDefault(c => c.Id == id);
        }

        public bool Create(Crop c)
        {
            db.Crops.Add(c);
            return db.SaveChanges() > 0;
        }

        public bool Update(Crop c)
        {
            var exobj = Get(c.Id);
            db.Entry(exobj).CurrentValues.SetValues(c);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Crops.Remove(exobj);
            return db.SaveChanges() > 0;
        }
    }
}
