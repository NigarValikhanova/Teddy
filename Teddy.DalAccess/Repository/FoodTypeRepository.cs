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
    public class FoodTypeRepository : Repository<FoodType>, IFoodTypeRepository
    {
        private readonly AppDbContext _db;
        public FoodTypeRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(FoodType obj)
        {
            var ObjFromDb = _db.FoodType.FirstOrDefault(u => u.Id == obj.Id);
            ObjFromDb.Name = obj.Name;
        }
    }
}
