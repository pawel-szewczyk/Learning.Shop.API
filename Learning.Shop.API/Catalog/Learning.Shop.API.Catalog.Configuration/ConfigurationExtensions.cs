using Learning.Shop.API.Catalog.Configuration.Options;
using Microsoft.Extensions.Configuration;

namespace Learning.Shop.API.Catalog.Configuration
{
    public static class ConfigurationExtensions
    {
        public static ElasticsearchOptions GetElasticsearchOptions(
            this IConfiguration configuration)
        {
            var options = configuration.GetSection(CatalogOptions.SectionName) as CatalogOptions;
            return options.Elasticsearch;
        }
    }
}
