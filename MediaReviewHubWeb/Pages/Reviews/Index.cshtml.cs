using MediaReviewHub.DataAccess.Repository.IRepository;
using MediaReviewHub.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace MediaReviewHubWeb.Pages.Reviews
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<Review> Reviews { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
            // Fetch all reviews using the Unit of Work
            Reviews = _unitOfWork.Review.GetAll();
        }
    }
}
