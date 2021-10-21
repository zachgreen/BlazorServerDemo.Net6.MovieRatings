namespace BlazorServerDemo.Net6.MovieRatings.Models
{
    public record Movie (int Id, string Name, string Genre);
    public record User (int Id, string FirstName, string LastName);
    public record Review (int Id, int UserId, int MovieId, int NumberOfStars);
}