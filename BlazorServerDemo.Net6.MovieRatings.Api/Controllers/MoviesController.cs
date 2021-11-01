using BlazorServerDemo.Net6.MovieRatings.DataAccessLayer;
using BlazorServerDemo.Net6.MovieRatings.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServerDemo.Net6.MovieRatings.Api.Controllers
{
    [Route("movies")]
    [ApiController]
    [Authorize("apis.movies")]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MovieController(IHttpContextAccessor httpContextAccessor, ILogger<MovieController> logger)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IEnumerable<Movie>> Get()
        {
            _logger.LogInformation("GET /movies called");
            return await Movies.GetMoviesAsync();
        }
    }

    [Route("favorites")]
    [ApiController]
    [Authorize("apis.favorites")]
    public class FavoritesController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FavoritesController(IHttpContextAccessor httpContextAccessor, ILogger<MovieController> logger)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            _logger.LogInformation("GET /favorites called");
            return new [] { "one", "two" };
        }
    }
}
