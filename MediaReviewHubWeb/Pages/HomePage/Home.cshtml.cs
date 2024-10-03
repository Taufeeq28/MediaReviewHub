
using MediaReviewHub.Models;
using MediaReviewHubWeb.DataAccess.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaReviewHubWeb.Pages.HomePage
{
    public class HomeModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        // Property to hold the featured reviews
        public List<Review> FeaturedReviews { get; set; }

        // Constructor to inject the database context
        public HomeModel(ApplicationDbContext db)
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
