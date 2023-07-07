using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librum.DataAccess.DbInitializer
{
    public interface IDbInitializer
    {
        void Initialize();
        //this creates admin user and roles in the website
    }
}
