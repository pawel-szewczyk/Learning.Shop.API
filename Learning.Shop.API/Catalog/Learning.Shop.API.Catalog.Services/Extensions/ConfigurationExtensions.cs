using Learning.Shop.API.Catalog.Services.Abstract.Interfaces.Search;
using Learning.Shop.API.Catalog.Services.Search;
using Microsoft.Extensions.DependencyInjection;

namespace Learning.Shop.API.Catalog.Services.Extensions
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
            => services.AddScoped<ISearchService, SearchService>();
    }
}
