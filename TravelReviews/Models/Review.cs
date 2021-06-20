namespace TravelReview.Models
{
  public class Review
  {
    public int ReviewId { get; set; }
    public string Title { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Author { get; set; }
    public string Text { get; set; }
    public int Rating { get; set; }
  }
}