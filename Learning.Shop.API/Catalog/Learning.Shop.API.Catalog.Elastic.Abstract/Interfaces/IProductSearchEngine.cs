using Learning.Shop.API.Catalog.Elastic.Abstract.Documents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learning.Shop.API.Catalog.Elastic.Abstract.Interfaces
{
    public interface IProductSearchEngine
    {
        Task<IList<ProductDocument>> Search(); 
    }
}
