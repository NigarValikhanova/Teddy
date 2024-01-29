using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Operations;
using Teddy.DalAccess.DAL;
using Teddy.DalAccess.Repository.IRepository;
using Teddy.Models;

namespace TeddyWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public FoodType FoodType { get; set; }

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }
        public void OnGet(int id)
        {
            FoodType = _unitOfWork.FoodType.GetFirstOrDefault(u=>u.Id==id);
            //Category = _db.Category.FirstOrDefault(u=>u.Id==id);
            //Category = _db.Category.SingleOrDefault(u => u.Id == id);
            //Category = _db.Category.Where(u => u.Id == id).FirstOrDefault();

        }

        public async Task<IActionResult> OnPost()
        {
            var foodTypeFromDb = _unitOfWork.FoodType.GetFirstOrDefault(u => u.Id == FoodType.Id);
			if (foodTypeFromDb != null)
            {
                _unitOfWork.FoodType.Remove(foodTypeFromDb);
                _unitOfWork.Save();
                TempData["success"] = "FoodType deleted successfully";
                return RedirectToPage("Index");

            }
            return Page();
        }
    }
}


