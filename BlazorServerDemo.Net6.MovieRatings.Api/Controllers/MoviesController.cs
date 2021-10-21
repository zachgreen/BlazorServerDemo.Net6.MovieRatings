using BlazorServerDemo.Net6.MovieRatings.DataAccessLayer;
using BlazorServerDemo.Net6.MovieRatings.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServerDemo.Net6.MovieRatings.Api.Controllers
{
    [Route("movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;

        public MovieController(ILogger<MovieController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Movie>> Get()
        {
            _logger.LogInformation("GET /movies called");

            return await Movies.GetMoviesAsync();
        }
    }
}
