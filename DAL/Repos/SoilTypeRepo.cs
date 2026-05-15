using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class SoilTypeRepo
    {
        AgroGuideMsContext db;

        public SoilTypeRepo(AgroGuideMsContext db)
        {
            this.db = db;
        }

        public List<SoilType> Get()
        {
            return db.SoilTypes.ToList();
        }

        public SoilType Get(int id)
        {
            return db.SoilTypes.Find(id);
        }

        public bool Create(SoilType s)
        {
            db.SoilTypes.Add(s);
            return db.SaveChanges() > 0;
        }

        public bool Update(SoilType s)
        {
            var exobj = Get(s.Id);
            db.Entry(exobj).CurrentValues.SetValues(s);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.SoilTypes.Remove(exobj);
            return db.SaveChanges() > 0;
        }
    }
}
