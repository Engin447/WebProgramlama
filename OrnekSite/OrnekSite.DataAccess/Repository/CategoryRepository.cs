﻿using OrnekSite.DataAccess.Data;
using OrnekSite.DataAccess.Repository.IRepository;
using OrnekSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrnekSite.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Category category)
        {
            var nesne = _db.Categories.FirstOrDefault(i => i.Id == category.Id);
            if (nesne != null)
            {
                nesne.Name = category.Name;
                _db.SaveChanges();
            }
        }
    }
}
