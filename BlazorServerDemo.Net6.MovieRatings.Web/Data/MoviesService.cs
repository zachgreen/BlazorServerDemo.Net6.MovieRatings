using BlazorServerDemo.Net6.MovieRatings.Models;
using System.Text.Json;

namespace BlazorServerDemo.Net6.MovieRatings.Web.Data
{
    public class MoviesService : BaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MoviesService(IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<Movie>?> GetAsync()
        {
            var client = _httpClientFactory.CreateClient("user_client");
            var response = await client.GetAsync("movies");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<Movie>>(content, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, PropertyNameCaseInsensitive = true });



            var favoritesResponse = await client.GetAsync("favorites");
            var favoriteContent = await favoritesResponse.Content.ReadAsStringAsync();
            favoritesResponse.EnsureSuccessStatusCode();
            var favoritesContent = JsonSerializer.Deserialize<List<string>>(favoriteContent, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, PropertyNameCaseInsensitive = true });

            return result;
        }

        //public HttpClient _httpClient;
        //public MoviesService(HttpClient httpClient, IServiceProvider serviceProvider) : base(serviceProvider)
        //{
        //    _httpClient = httpClient;
        //}

        //public async Task<IEnumerable<Movie>?> GetAsync()
        //{
        //    var response = await _httpClient.GetAsync("movies");
        //    response.EnsureSuccessStatusCode();

        //    var content = await response.Content.ReadAsStringAsync();
        //    return JsonSerializer.Deserialize<List<Movie>>(content, new System.Text.Json.JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, PropertyNameCaseInsensitive = true });
        //}
    }
}