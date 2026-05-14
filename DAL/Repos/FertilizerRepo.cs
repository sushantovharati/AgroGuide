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

    }
}
