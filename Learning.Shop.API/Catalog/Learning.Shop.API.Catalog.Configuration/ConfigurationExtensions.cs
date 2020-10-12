using Learning.Shop.API.Catalog.Configuration.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Learning.Shop.API.Catalog.Configuration
{
    public static class ConfigurationExtensions
    {
        public static ElasticsearchOptions GetElasticsearchOptions(
            this IConfiguration configuration)
        {
            var options = new CatalogOptions();
            configuration.GetSection(CatalogOptions.SectionName).Bind(options);
            return options.Elasticsearch;
        }
    }
}
