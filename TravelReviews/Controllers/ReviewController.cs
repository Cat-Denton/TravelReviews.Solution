using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelReview.Models;

namespace TravelReview.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ReviewController : ControllerBase
  {
    private readonly TravelReviewContext _db;
    public ReviewController(TravelReviewContext db)
    {
      _db = db;
    
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Review >>> Get()
    {
      return await _db.Reviews.ToListAsync();
    }
    [HttpPost]
    public async Task<ActionResult<Review>> Post(Review review)
    {
      _db.Reviews.Add(review);
      await _db.SaveChangesAsync();
      // return CreatedAtAction("Post", new { id = review.ReviewId }, review);
      return CreatedAtAction(nameof(GetReview), new { id = review.ReviewId }, review);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Review>> GetReview(int id)
    {
      var review = await _db.Reviews.FindAsync(id);

      if (review == null)
    {
      return NotFound();
    }
    return review;
}
  }
}