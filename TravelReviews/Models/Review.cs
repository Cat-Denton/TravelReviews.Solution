using System.ComponentModel.DataAnnotations;
namespace TravelReview.Models
{
  public class Review
  {
    public int ReviewId { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Title must be fewer than 50 characters long")]
    public string Title { get; set; }
    [Required]
    [StringLength(25)]
    public string City { get; set; }
    [Required]
    public string Country { get; set; }
    [Required]
    public string Author { get; set; }
    [Required]
    public string Text { get; set; }
    [Required]
    [Range(0,5, ErrorMessage = "Rating must be between 0 and 5.")]
    public int Rating { get; set; }
  }
}