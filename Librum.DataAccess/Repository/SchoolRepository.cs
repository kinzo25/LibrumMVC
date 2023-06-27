using Librum.DataAccess.Data;
using Librum.DataAccess.Repository.IRepository;
using Librum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librum.DataAccess.Repository
{
    public class SchoolRepository : Repository<School>, ISchoolRepository
    {
        private AppDbContext _db;
        public SchoolRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(School c)
        {
            _db.Schools.Update(c);
        }
    }
}
