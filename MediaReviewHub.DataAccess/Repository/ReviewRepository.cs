using MediaReviewHub.DataAccess.Repository.IRepository;
using MediaReviewHub.Models;
using MediaReviewHubWeb.DataAccess.Data;
using System;
using System.Linq;

namespace MediaReviewHub.DataAccess.Repository
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        private readonly ApplicationDbContext _db;
        public ReviewRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Review review)
        {
            var objFromDb = _db.Reviews.FirstOrDefault(u => u.ReviewID == review.ReviewID);

            if (objFromDb != null)
            {
                // Update the fields based on the provided review
                objFromDb.Title = review.Title;
                objFromDb.Category = review.Category;
                objFromDb.ReviewText = review.ReviewText;
                objFromDb.Rating = review.Rating;

                // Ensure DateReviewed is set with a specified DateTimeKind (if unspecified)
                if (review.DateReviewed.Kind == DateTimeKind.Unspecified)
                {
                    objFromDb.DateReviewed = DateTime.SpecifyKind(review.DateReviewed, DateTimeKind.Utc);
                }
                else
                {
                    objFromDb.DateReviewed = review.DateReviewed;
                }

            }
        }
    }
}
