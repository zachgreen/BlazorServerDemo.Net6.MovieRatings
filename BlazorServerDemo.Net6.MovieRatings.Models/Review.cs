namespace BlazorServerDemo.Net6.MovieRatings.Models
{
    public record Review (int Id, int UserId, int MovieId, int NumberOfStars);
}