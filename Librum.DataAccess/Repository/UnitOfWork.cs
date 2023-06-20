﻿using Librum.DataAccess.Data;
using Librum.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librum.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _db;
        public ICategoryRepository CategoryRepository { get; private set; }
        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            CategoryRepository = new CategoryRepository(_db);
            
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}