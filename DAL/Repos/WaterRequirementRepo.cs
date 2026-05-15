using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class WaterRequirementRepo
    {
        AgroGuideMsContext db;

        public WaterRequirementRepo(AgroGuideMsContext db)
        {
            this.db = db;
        }

        public List<WaterRequirement> Get()
        {
            return db.WaterRequirements.ToList();
        }

        public WaterRequirement Get(int id)
        {
            return db.WaterRequirements.Find(id);
        }

        public bool Create(WaterRequirement w)
        {
            db.WaterRequirements.Add(w);
            return db.SaveChanges() > 0;
        }

        public bool Update(WaterRequirement w)
        {
            var exobj = Get(w.Id);
            db.Entry(exobj).CurrentValues.SetValues(w);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.WaterRequirements.Remove(exobj);
            return db.SaveChanges() > 0;
        }
    }
}
