using Microsoft.EntityFrameworkCore;

namespace TravelReview.Models
{
    public class TravelReviewContext : DbContext
    {
        public TravelReviewContext(DbContextOptions<TravelReviewContext> options)
            : base(options)
        {
        }

        public DbSet<Review> Reviews { get; set; }
    }
}