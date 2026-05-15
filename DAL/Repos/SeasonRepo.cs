using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class SeasonRepo
    {
        AgroGuideMsContext db;

        public SeasonRepo(AgroGuideMsContext db)
        {
            this.db = db;
        }

        public List<Season> Get()
        {
            return db.Seasons.ToList();
        }

        public Season Get(int id)
        {
            return db.Seasons.Find(id);
        }

        public bool Create(Season s)
        {
            db.Seasons.Add(s);
            return db.SaveChanges() > 0;
        }

        public bool Update(Season s)
        {
            var exobj = Get(s.Id);
            db.Entry(exobj).CurrentValues.SetValues(s);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Seasons.Remove(exobj);
            return db.SaveChanges() > 0;
        }
    }
}
