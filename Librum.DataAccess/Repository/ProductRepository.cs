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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private AppDbContext _db;
        public ProductRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product p)
        {
            _db.Products.Update(p);
        }
    }
}
