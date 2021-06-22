using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelReview.Models;
using System.Linq;

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
    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<Review>>> Get()
    // {
    //   return await _db.Reviews.ToListAsync();
    // }
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
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Review review)
    {
      if (id != review.ReviewId)
      {
        return BadRequest();
      }

      _db.Entry(review).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ReviewExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReview(int id)
    {
      var review = await _db.Reviews.FindAsync(id);
      if (review == null)
      {
        return NotFound();
      }

      _db.Reviews.Remove(review);
      await _db.SaveChangesAsync();

      return NoContent();
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Review>>> Get(string city, string country, string author)
    {
      var query = _db.Reviews.AsQueryable();

      if (city != null)
      {
        query = query.Where(entry => entry.City == city);
      }

      if (country != null)
      {
        query = query.Where(entry => entry.Country == country);
      }

      if (author != null)
      {
        query = query.Where(entry => entry.Author == author);
      }

      return await query.ToListAsync();
    }
    private bool ReviewExists(int id)
    {
      return _db.Reviews.Any(e => e.ReviewId == id);
    }
  }
}