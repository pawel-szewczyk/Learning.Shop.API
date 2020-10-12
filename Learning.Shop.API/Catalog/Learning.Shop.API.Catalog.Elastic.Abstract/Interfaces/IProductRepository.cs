using Learning.Shop.API.Catalog.Elastic.Abstract.Documents;
using System.Threading.Tasks;

namespace Learning.Shop.API.Catalog.Elastic.Abstract.Interfaces
{
    public interface IProductRepository
    {
        Task<bool> Index(ProductDocument document);
    }
}
