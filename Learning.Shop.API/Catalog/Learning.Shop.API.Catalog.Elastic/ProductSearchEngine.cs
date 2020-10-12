using Learning.Shop.API.Catalog.Elastic.Abstract.Documents;
using Learning.Shop.API.Catalog.Elastic.Abstract.Interfaces;
using Learning.Shop.API.Catalog.Elastic.Abstract.Queries;
using Learning.Shop.API.Catalog.Elastic.Abstract.Results;
using Nest;
using System.Linq;
using System.Threading.Tasks;

namespace Learning.Shop.API.Catalog.Elastic
{
    public class ProductSearchEngine : IProductSearchEngine
    {
        private readonly IElasticClient _client;

        public ProductSearchEngine(IElasticClient client)
        {
            _client = client;
        }

        public async Task<ProductSearchResult> Search(ProductSearchQuery query)
        {
            var result = await _client.SearchAsync<ProductDocument>(
                s => s.Query(
                    q => q.Match(
                        m => m.Field(f => f.Name)
                            .Query(query.Term)
                            .Fuzziness(Fuzziness.EditDistance(2))))
                .Skip((query.BatchNumber - 1) * query.BatchSize)
                .Take(query.BatchSize));

            return new ProductSearchResult
            {
                Hits = result.Hits.Select(h => h.Source).ToList(),
                TotalNumberOfHits = (int)result.Total
            };
        }
    }
}
