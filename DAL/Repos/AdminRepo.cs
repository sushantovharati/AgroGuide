using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class AdminRepo
    {
        AgroGuideMsContext db;
        public AdminRepo(AgroGuideMsContext db)
        {
            this.db = db;
        }

    }
}
