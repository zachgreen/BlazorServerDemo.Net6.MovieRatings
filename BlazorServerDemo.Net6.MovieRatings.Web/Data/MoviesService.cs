using BlazorServerDemo.Net6.MovieRatings.Models;
using System.Text.Json;

namespace BlazorServerDemo.Net6.MovieRatings.Web.Data
{
    public class MoviesService : BaseService
    {
        public MoviesService(IServiceProvider serviceProvider) : base(serviceProvider) {  }

        public async Task<IEnumerable<Movie>> GetAsync()
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(PathConfiguration.Api);

                var response = await client.GetAsync("movies");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Movie>>(content, new System.Text.Json.JsonSerializerOptions { IgnoreNullValues = true, PropertyNameCaseInsensitive = true });
            }
        }
    }
}