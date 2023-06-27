using Librum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librum.DataAccess.Repository.IRepository
{
    public interface ISchoolRepository : IRepository<School>
    {
        void Update(School c);


    }
}
