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
                    ReviewText = "A mind-bending thriller with stunning visuals.",
                    Rating = 5,
                    DateReviewed = DateTime.SpecifyKind(new DateTime(2024, 9, 30), DateTimeKind.Utc)
                },
                new Review
                {
                    ReviewID = 2,
                    Title = "The Great Gatsby",
                    Category = "Books",
                    ReviewText = "A classic novel about the American dream.",
                    Rating = 4,
                    DateReviewed = DateTime.SpecifyKind(new DateTime(2024, 10, 1), DateTimeKind.Utc)
                },
                new Review
                {
                    ReviewID = 3,
                    Title = "Interstellar",
                    Category = "Movies",
                    ReviewText = "A visually stunning space exploration journey.",
                    Rating = 5,
                    DateReviewed = DateTime.SpecifyKind(new DateTime(2024, 10, 2), DateTimeKind.Utc)
                },
                new Review
                {
                    ReviewID = 4,
                    Title = "The Alchemist",
                    Category = "Books",
                    ReviewText = "A magical fable about following your dreams.",
                    Rating = 5,
                    DateReviewed = DateTime.SpecifyKind(new DateTime(2024, 10, 3), DateTimeKind.Utc)
                },
                new Review
                {
                    ReviewID = 5,
                    Title = "Bohemian Rhapsody",
                    Category = "Music",
                    ReviewText = "A legendary song by Queen.",
                    Rating = 5,
                    DateReviewed = DateTime.SpecifyKind(new DateTime(2024, 10, 4), DateTimeKind.Utc)
                },
                new Review
                {
                    ReviewID = 6,
                    Title = "The Godfather",
                    Category = "Movies",
                    ReviewText = "An epic tale of a mafia family.",
                    Rating = 5,
                    DateReviewed = DateTime.SpecifyKind(new DateTime(2024, 10, 5), DateTimeKind.Utc)
                },
                new Review
                {
                    ReviewID = 7,
                    Title = "To Kill a Mockingbird",
                    Category = "Books",
                    ReviewText = "A novel about racial injustice in the American South.",
                    Rating = 5,
                    DateReviewed = DateTime.SpecifyKind(new DateTime(2024, 10, 6), DateTimeKind.Utc)
                },
                new Review
                {
                    ReviewID = 8,
                    Title = "God of War",
                    Category = "Games",
                    ReviewText = "An epic adventure game with stunning combat.",
                    Rating = 4,
                    DateReviewed = DateTime.SpecifyKind(new DateTime(2024, 10, 7), DateTimeKind.Utc)
                },
                new Review
                {
                    ReviewID = 9,
                    Title = "Red Dead Redemption 2",
                    Category = "Games",
                    ReviewText = "An open-world Western adventure.",
                    Rating = 5,
                    DateReviewed = DateTime.SpecifyKind(new DateTime(2024, 10, 8), DateTimeKind.Utc)
                },
                new Review
                {
                    ReviewID = 10,
                    Title = "The Beatles - Abbey Road",
                    Category = "Music",
                    ReviewText = "A legendary album by The Beatles.",
                    Rating = 5,
                    DateReviewed = DateTime.SpecifyKind(new DateTime(2024, 10, 9), DateTimeKind.Utc)
                },
                new Review
                {
                    ReviewID = 11,
                    Title = "The Matrix",
                    Category = "Movies",
                    ReviewText = "A sci-fi movie about reality and human existence.",
                    Rating = 5,
                    DateReviewed = DateTime.SpecifyKind(new DateTime(2024, 10, 10), DateTimeKind.Utc)
                },
                new Review
                {
                    ReviewID = 12,
                    Title = "1984",
                    Category = "Books",
                    ReviewText = "A dystopian novel about surveillance and totalitarianism.",
                    Rating = 4,
                    DateReviewed = DateTime.SpecifyKind(new DateTime(2024, 10, 11), DateTimeKind.Utc)
                }
            );
        }

    }
}
