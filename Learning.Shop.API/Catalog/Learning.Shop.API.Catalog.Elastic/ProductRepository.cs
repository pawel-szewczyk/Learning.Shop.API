using Learning.Shop.API.Catalog.Configuration.Options;
using Learning.Shop.API.Catalog.Elastic.Abstract.Documents;
using Learning.Shop.API.Catalog.Elastic.Abstract.Interfaces;
using Microsoft.Extensions.Options;
using Nest;
using System;
using System.Threading.Tasks;

namespace Learning.Shop.API.Catalog.Elastic
{
    public class ProductRepository : IProductRepository
    {
        private readonly IElasticClient _client;
        private readonly string _indexName;

        public ProductRepository(
            IElasticClient client,
            IOptions<ElasticsearchOptions> catalogOptions)
        {
            _client = client;
            _indexName = catalogOptions.Value?.Index;
        }

        public async Task<bool> Index(ProductDocument document)
        {
            await CreateIndexIfNeeded(_indexName);
            var response = await _client.IndexDocumentAsync(document);

            return response.IsValid;
        }

        private async Task CreateIndexIfNeeded(string indexName)
        {
            if (string.IsNullOrWhiteSpace(indexName))
            {
                throw new ArgumentException("Index Name cannot be empty!", nameof(indexName));
            }

            var index = await _client.Indices.ExistsAsync(indexName);
            if (index.Exists)
            {
                return;
            }

            await _client.Indices.CreateAsync(indexName,
                c => c.Settings(
                    s => s.Analysis(
                        a => a.AddSearchAnalyzerFor(indexName)))
                .Map<ProductDocument>(d=>d.AutoMap()));
        }
    }
}
