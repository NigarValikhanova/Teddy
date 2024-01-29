using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Teddy.DalAccess.DAL;
using Teddy.DalAccess.Repository;
using Teddy.DalAccess.Repository.IRepository;
using Teddy.Models;

namespace TeddyWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public FoodType FoodType { get; set; }
        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }
        public void OnGet()
        {
        }
        
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.FoodType.Add(FoodType);
                _unitOfWork.Save();
                TempData["success"] = "FoodType created successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
