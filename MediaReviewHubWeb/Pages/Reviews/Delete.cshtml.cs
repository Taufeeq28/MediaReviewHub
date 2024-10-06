using MediaReviewHub.DataAccess.Repository.IRepository;
using MediaReviewHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace MediaReviewHubWeb.Pages.Reviews
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public Review Review { get; set; }

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Load the Review on GET request
        public async Task<IActionResult> OnGet(int id)
        {
            Review = _unitOfWork.Review.GetFirstOrDefault(r => r.ReviewID == id);

            if (Review == null)
            {
                return NotFound();
            }

            return Page();
        }

        // Delete the Review on POST request
        public async Task<IActionResult> OnPost(int id)
        {
            var reviewFromDb = _unitOfWork.Review.GetFirstOrDefault(r => r.ReviewID == id);

            if (reviewFromDb != null)
            {
                _unitOfWork.Review.Remove(reviewFromDb);
                _unitOfWork.Save();
                TempData["success"] = "Category deleted successfully";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
