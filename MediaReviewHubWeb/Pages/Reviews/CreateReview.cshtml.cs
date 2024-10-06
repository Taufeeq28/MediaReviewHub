
using MediaReviewHub.DataAccess.Repository.IRepository;
using MediaReviewHub.Models;
using MediaReviewHubWeb.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace MediaReviewHubWeb.Pages.Reviews
{
    [BindProperties]
    public class CreateReviewModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public Review Review { get; set; }

        public CreateReviewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            // Convert DateReviewed to UTC
            if (Review.DateReviewed.Kind == DateTimeKind.Unspecified)
            {
                Review.DateReviewed = DateTime.SpecifyKind(Review.DateReviewed, DateTimeKind.Utc);
            }
            if (ModelState.IsValid) {
                _unitOfWork.Review.Add(Review);
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
