using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teddy.DalAccess.DAL;
using Teddy.DalAccess.Repository.IRepository;
using Teddy.Models;

namespace Teddy.DalAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _db;
        public CategoryRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            var ObjFromDb = _db.Category.FirstOrDefault(u => u.Id == category.Id);
            ObjFromDb.Name = category.Name;
            ObjFromDb.DisplayOrder = category.DisplayOrder;
        }
    }
}
