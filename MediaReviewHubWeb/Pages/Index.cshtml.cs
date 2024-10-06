using MediaReviewHub.Models;
using MediaReviewHubWeb.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MediaReviewHubWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        // Property to hold the featured reviews
        public List<Review> FeaturedReviews { get; set; }

        // Constructor to inject the database context
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        // Method to handle GET requests asynchronously
        public async Task OnGetAsync()
        {
            // Fetching top 3 featured reviews, ordered by highest rating
            FeaturedReviews = await _db.Reviews
                .OrderByDescending(r => r.Rating) // Sorting by Rating (highest first)
                .Take(6) // Limiting the result to 3 reviews
                .ToListAsync(); // Asynchronously fetching the data
        }
    }
}
