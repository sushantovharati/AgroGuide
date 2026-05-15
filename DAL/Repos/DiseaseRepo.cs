using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class DiseaseRepo
    {
        AgroGuideMsContext db;

        public DiseaseRepo(AgroGuideMsContext db)
        {
            this.db = db;
        }

        public List<Disease> Get()
        {
            return db.Diseases.ToList();
        }

        public Disease Get(int id)
        {
            return db.Diseases.Find(id);
        }

        public bool Create(Disease c)
        {
            db.Diseases.Add(c);
            return db.SaveChanges() > 0;
        }

        public bool Update(Disease c)
        {
            var exobj = Get(c.Id);
            db.Entry(exobj).CurrentValues.SetValues(c);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Diseases.Remove(exobj);
            return db.SaveChanges() > 0;
        }
    }
}
