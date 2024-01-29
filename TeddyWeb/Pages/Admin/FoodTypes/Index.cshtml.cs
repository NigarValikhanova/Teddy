using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Teddy.DalAccess.DAL;
using Teddy.DalAccess.Repository.IRepository;
using Teddy.Models;

namespace TeddyWeb.Pages.Admin.FoodTypes
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<FoodType> FoodTypes { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
            FoodTypes = _unitOfWork.FoodType.GetAll();
        }
    }
}
