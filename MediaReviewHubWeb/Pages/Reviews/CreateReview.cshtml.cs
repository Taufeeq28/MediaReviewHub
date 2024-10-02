using MediaReviewHubWeb.Data;
using MediaReviewHubWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace MediaReviewHubWeb.Pages.Reviews
{
    [BindProperties]
    public class CreateReviewModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Review Review { get; set; }

        public CreateReviewModel(ApplicationDbContext db)
        {
            _db = db;
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
                await _db.Reviews.AddAsync(Review);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
