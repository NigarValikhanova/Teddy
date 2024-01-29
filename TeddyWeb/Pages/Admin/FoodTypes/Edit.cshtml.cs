using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Teddy.DalAccess.DAL;
using Teddy.DalAccess.Repository.IRepository;
using Teddy.Models;

namespace TeddyWeb.Pages.Admin.FoodTypes
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public FoodType FoodType { get; set; }
        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id)
        {
            FoodType = _unitOfWork.FoodType.GetFirstOrDefault(u => u.Id == id);
			//Category = _db.Category.FirstOrDefault(u=>u.Id==id);
			//Category = _db.Category.SingleOrDefault(u => u.Id == id);
			//Category = _db.Category.Where(u => u.Id == id).FirstOrDefault();

		}

		public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.FoodType.Update(FoodType);
                _unitOfWork.Save();
                TempData["success"] = "FoodType updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
