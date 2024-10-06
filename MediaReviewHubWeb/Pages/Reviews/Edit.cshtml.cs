using MediaReviewHub.DataAccess.Repository.IRepository;
using MediaReviewHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace MediaReviewHubWeb.Pages.Reviews
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public Review Review { get; set; }

        public EditModel(IUnitOfWork unitOfWork)
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

        public async Task<IActionResult> OnPost()
        {
            // Validation logic: Title should not be the same as the Rating
            if (Review.Title == Review.Rating.ToString())
            {
                ModelState.AddModelError("Review.Title", "The Title cannot exactly match the Rating.");
            }

            // Convert DateReviewed to UTC if unspecified
            if (Review.DateReviewed.Kind == DateTimeKind.Unspecified)
            {
                Review.DateReviewed = DateTime.SpecifyKind(Review.DateReviewed, DateTimeKind.Utc);
            }

            // If the model is valid, proceed with the update
            if (ModelState.IsValid)
            {
                var reviewFromDb = _unitOfWork.Review.GetFirstOrDefault(r => r.ReviewID == Review.ReviewID);

                if (reviewFromDb != null)
                {
                    // Update the fields
                    reviewFromDb.Title = Review.Title;
                    reviewFromDb.Category = Review.Category;
                    reviewFromDb.ReviewText = Review.ReviewText;
                    reviewFromDb.Rating = Review.Rating;
                    reviewFromDb.DateReviewed = Review.DateReviewed;

                    // Save the changes through the Unit of Work
                    _unitOfWork.Save();

                    TempData["success"] = "Review edited successfully";
                    return RedirectToPage("Index");
                }
            }

            return Page();
        }
    }
}
