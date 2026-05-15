using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class DivisionRepo
    {
        AgroGuideMsContext db;

        public DivisionRepo(AgroGuideMsContext db)
        {
            this.db = db;
        }

        public List<Division> Get()
        {
            return db.Divisions.ToList();
        }

        public Division Get(int id)
        {
            return db.Divisions.Find(id);
        }
    }
}
