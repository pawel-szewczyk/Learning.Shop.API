using Learning.Shop.API.Catalog.Services.Abstract.Interfaces.Search;
using Learning.Shop.API.Catalog.Services.Abstract.Models.Search;
using System.Threading.Tasks;

namespace Learning.Shop.API.Catalog.Services.Search
{
    public class SearchService : ISearchService
    {
        public Task<SearchResult> Search(string searchTerm, int pageSize, int pageNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}
