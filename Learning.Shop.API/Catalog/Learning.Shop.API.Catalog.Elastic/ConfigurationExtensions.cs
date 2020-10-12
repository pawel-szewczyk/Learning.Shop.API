using Learning.Shop.API.Catalog.Configuration;
using Learning.Shop.API.Catalog.Configuration.Options;
using Learning.Shop.API.Catalog.Elastic.Abstract.Documents;
using Learning.Shop.API.Catalog.Elastic.Abstract.Interfaces;
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
            serviceCollection.Configure<ElasticsearchOptions>(
                o => o = elasticsearchConfiguration);

            var settings = new ConnectionSettings(new Uri(elasticsearchConfiguration.Url))
                .DefaultIndex(elasticsearchConfiguration.Index)
                .DefaultMappingFor<ProductDocument>(c=>c.IdProperty(p=>p.Id));

            var client = new ElasticClient(settings);
            serviceCollection.AddSingleton<IElasticClient>(client)
                .AddScoped<IProductSearchEngine, ProductSearchEngine>()
                .AddScoped<IProductRepository, ProductRepository>();
            return serviceCollection;
        }

        public static IHealthChecksBuilder AddElasticHealthCheck(this IHealthChecksBuilder builder,
            IConfiguration configuration)
            => builder.AddElasticsearch(configuration.GetElasticsearchOptions()?.Url);

        public static IAnalysis AddSearchAnalyzerFor(this AnalysisDescriptor analysis, string indexName)
        {
            var indexAnalyzerName = $"{indexName}_search";
            var indexAnalyzerKey = "lowercase";

            return
                analysis
                    .Analyzers(a => a
                        .Custom(indexAnalyzerName, c => c
                            .Tokenizer(indexAnalyzerName)
                            .Filters(indexAnalyzerKey)
                        )
                    )
                    .Tokenizers(t => t
                        .EdgeNGram(indexAnalyzerName, e => e
                            .MinGram(1)
                            .MaxGram(20)
                            .TokenChars(TokenChar.Letter)
                        )
                    );
        }
    }
}
