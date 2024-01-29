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
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        private readonly AppDbContext _db;
        public MenuItemRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(MenuItem obj)
        {
            var objFromDb = _db.MenuItem.FirstOrDefault(u => u.Id == obj.Id);
            objFromDb.Name = obj.Name;
            objFromDb.Description = obj.Description;
            objFromDb.Price = obj.Price;
            objFromDb.CategoryId = obj.CategoryId;
            objFromDb.FoodTypeId = obj.FoodTypeId;
            if (objFromDb.Image != null)
            {
                objFromDb.Image = obj.Image;
            }
        }
    }
}
