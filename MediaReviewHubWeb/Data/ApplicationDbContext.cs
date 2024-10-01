using MediaReviewHubWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace MediaReviewHubWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Review> Reviews { get; set; }
    }
}
