using Learning.Shop.API.Catalog.Elastic.Abstract.Queries;
using Learning.Shop.API.Catalog.Elastic.Abstract.Results;
using System.Threading.Tasks;

namespace Learning.Shop.API.Catalog.Elastic.Abstract.Interfaces
{
    public interface IProductSearchEngine
    {
        Task<ProductSearchResult> Search(ProductSearchQuery query); 
    }
}
