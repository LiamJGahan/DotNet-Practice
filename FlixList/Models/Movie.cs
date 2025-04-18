namespace FlixList.Models;

public class Movie
{
    public int MovieId { get; set; }
    public string Title { get; set; } = "";
    public string Genre { get; set; } = "";
    public string Platform { get; set; } = "";
    public int AgeRating { get; set; }
}
