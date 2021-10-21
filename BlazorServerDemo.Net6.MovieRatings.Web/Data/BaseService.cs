using BlazorServerDemo.Net6.MovieRatings.Models.Configuration;

namespace BlazorServerDemo.Net6.MovieRatings.Web.Data
{
    public class BaseService
    {
        private IServiceProvider _serviceProvider;
        public BaseService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IConfiguration? Configuration => _serviceProvider.GetService<IConfiguration>();

        public PathConfiguration? PathConfiguration
        {
            get
            {
                return Configuration?.GetSection(PathConfiguration.SectionName).Get<PathConfiguration>();
            }
        }
    }
}