namespace BlazorServerDemo.Net6.MovieRatings.Web.Data
{
    public class PathService : BaseService
    {
        public PathService(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public string? IdentityUrl => PathConfiguration?.Identity;
        public string? ApiUrl => PathConfiguration?.Api;
    }
}
