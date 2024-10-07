using MediaReviewHub.Models;
using Microsoft.EntityFrameworkCore;

namespace MediaReviewHubWeb.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Review> Reviews { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data with DateTime set to UTC
            modelBuilder.Entity<Review>().HasData(
               new Review
               {
                   ReviewID = 1,
                   Title = "Inception",
                   Category = "Movies",
                   ReviewText = "A visually stunning, complex thriller with layered storytelling.",
                   Rating = 5,
                   DateReviewed = DateTime.SpecifyKind(new DateTime(2024, 9, 30), DateTimeKind.Utc)
               },
            new Review
            {
                ReviewID = 2,
                Title = "Avengers: Endgame",
                Category = "Movies",
                ReviewText = "An epic, emotional conclusion to the Avengers saga with intense action.",
                Rating = 5,
                DateReviewed = DateTime.SpecifyKind(new DateTime(2024, 10, 1), DateTimeKind.Utc)
            },
            new Review
            {
                ReviewID = 3,
                Title = "God of War",
                Category = "Games",
                ReviewText = "An intense adventure with powerful storytelling and a compelling father-son dynamic.",
                Rating = 5,
                DateReviewed = DateTime.SpecifyKind(new DateTime(2024, 10, 2), DateTimeKind.Utc)
            },
            new Review
            {
                ReviewID = 4,
                Title = "Grand Theft Auto V (GTA 5)",
                Category = "Games",
                ReviewText = "An immersive open-world game with thrilling missions and endless freedom.",
                Rating = 5,
                DateReviewed = DateTime.SpecifyKind(new DateTime(2024, 10, 3), DateTimeKind.Utc)
            },
            new Review
            {
                ReviewID = 5,
                Title = "Believer",
                Category = "Music",
                ReviewText = "A high-energy song with empowering lyrics that resonate deeply.",
                Rating = 4,
                DateReviewed = DateTime.SpecifyKind(new DateTime(2024, 10, 4), DateTimeKind.Utc)
            },
            new Review
            {
                ReviewID = 6,
                Title = "Perfect",
                Category = "Music",
                ReviewText = "A beautiful, heartfelt romantic ballad by Ed Sheeran.",
                Rating = 5,
                DateReviewed = DateTime.SpecifyKind(new DateTime(2024, 10, 5), DateTimeKind.Utc)
            },
            new Review
            {
                ReviewID = 7,
                Title = "Atomic Habits",
                Category = "Books",
                ReviewText = "A practical guide with actionable advice for building good habits.",
                Rating = 5,
                DateReviewed = DateTime.SpecifyKind(new DateTime(2024, 10, 6), DateTimeKind.Utc)
            },
            new Review
            {
                ReviewID = 8,
                Title = "Rich Dad Poor Dad",
                Category = "Books",
                ReviewText = "An insightful book on financial literacy and mindset transformation.",
                Rating = 4,
                DateReviewed = DateTime.SpecifyKind(new DateTime(2024, 10, 7), DateTimeKind.Utc)
            }

            );
        }

    }
}
