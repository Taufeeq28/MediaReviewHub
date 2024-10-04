using MediaReviewHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaReviewHub.DataAccess.Repository.IRepository
{
    
    public interface IReviewRepository : IRepository<Review>
    {
        void Update(Review review);
        void Save();
    }
}
