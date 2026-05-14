using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class FertilizerRepo
    {
        AgroGuideMsContext db;

        public FertilizerRepo(AgroGuideMsContext db)
        {
            this.db = db;
        }

        public List<Fertilizer> Get()
        {
            return db.Fertilizers.ToList();
        }

        public Fertilizer Get(int id)
        {
            return db.Fertilizers.Find(id);
        }

        public bool Create(Fertilizer f)
        {
            db.Fertilizers.Add(f);
            return db.SaveChanges() > 0;
        }

        public bool Update(Fertilizer f)
        {
            var exobj = Get(f.Id);
            db.Entry(exobj).CurrentValues.SetValues(f);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Fertilizers.Remove(exobj);
            return db.SaveChanges() > 0;
        }
    }
}
