using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class DistrictRepo
    {
        AgroGuideMsContext db;

        public DistrictRepo(AgroGuideMsContext db)
        {
            this.db = db;
        }

        public List<District> Get()
        {
            return db.Districts.ToList();
        }

        public District Get(int id)
        {
            return db.Districts.Find(id);
        }

        public List<District> GetByDivisionId(int divisionId)
        {
            return db.Districts.Where(x => x.DivisionId == divisionId).ToList();
        }

    }
}
