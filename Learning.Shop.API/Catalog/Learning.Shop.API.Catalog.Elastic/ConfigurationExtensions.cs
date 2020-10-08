using Learning.Shop.API.Catalog.Configuration;
using Learning.Shop.API.Catalog.Elastic.Abstract.Documents;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;

namespace Learning.Shop.API.Catalog.Elastic
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection AddElasticsearch(
            this IServiceCollection serviceCollection, 
            IConfiguration configuration)
        {
            var elasticsearchConfiguration = configuration.GetElasticsearchOptions();

            var settings = new ConnectionSettings(new Uri(elasticsearchConfiguration.Url))
                .DefaultIndex(elasticsearchConfiguration.Index)
                .DefaultMappingFor<ProductDocument>(c=>c.IdProperty(p=>p.Id));

            var client = new ElasticClient(settings);
            serviceCollection.AddSingleton<IElasticClient>(client);
            return serviceCollection;
        }

        public static IHealthChecksBuilder AddElasticHealthCheck(this IHealthChecksBuilder builder,
            IConfiguration configuration)
            => builder.AddElasticsearch(configuration.GetElasticsearchOptions()?.Url);
    }
}
