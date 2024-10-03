using MediaReviewHubWeb.Data;
using MediaReviewHubWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MediaReviewHubWeb.Pages.Reviews
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Review Review { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        // Load the Review on GET request
        public async Task<IActionResult> OnGet(int id)
        {
            Review = await _db.Reviews.FindAsync(id);

            if (Review == null)
            {
                return NotFound();
            }

            return Page();
        }
            public async Task<IActionResult> OnPost()
            {
                if (Review.Title == Review.Rating.ToString())
                {
                    ModelState.AddModelError("Review.Title", "The Title cannot exactly match the Rating.");
                }
            if (Review.DateReviewed.Kind == DateTimeKind.Unspecified)
            {
                Review.DateReviewed = DateTime.SpecifyKind(Review.DateReviewed, DateTimeKind.Utc);
            }


            if (ModelState.IsValid)
            {
                var reviewFromDb = await _db.Reviews.FindAsync(Review.ReviewID);

                if (reviewFromDb != null)
                {
                    // Update the fields
                    reviewFromDb.Title = Review.Title;
                    reviewFromDb.Category = Review.Category;
                    reviewFromDb.ReviewText = Review.ReviewText;
                    reviewFromDb.Rating = Review.Rating;
                    reviewFromDb.DateReviewed = Review.DateReviewed;

                    // Save the changes
                    await _db.SaveChangesAsync();
                    TempData["success"] = "Category Edited successfully";
                    return RedirectToPage("Index");
                }
            }

            return Page();
            }
        }
    }
