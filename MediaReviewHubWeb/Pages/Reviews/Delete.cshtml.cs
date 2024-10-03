
using MediaReviewHub.Models;
using MediaReviewHubWeb.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MediaReviewHubWeb.Pages.Reviews
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Review Review { get; set; }

        public DeleteModel(ApplicationDbContext db)
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
        public async Task<IActionResult> OnPost(int id)
        {
            var reviewFromDb = await _db.Reviews.FindAsync(id);

            if (reviewFromDb != null)
            {
                _db.Reviews.Remove(reviewFromDb);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category deleted successfully";
                return RedirectToPage("Index");
            }
            return Page();

            
        }
    }
    }
