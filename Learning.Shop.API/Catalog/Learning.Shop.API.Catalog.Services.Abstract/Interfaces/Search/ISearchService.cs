using Learning.Shop.API.Catalog.Services.Abstract.Models.Search;
using System.Threading.Tasks;

namespace Learning.Shop.API.Catalog.Services.Abstract.Interfaces.Search
{
    public interface ISearchService
    {
        Task<SearchResult> Search(string searchTerm, int pageSize, int pageNumber);
    }
}
