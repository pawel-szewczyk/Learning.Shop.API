using Learning.Shop.API.Catalog.Elastic.Abstract.Documents;
using Learning.Shop.API.Catalog.Elastic.Abstract.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learning.Shop.API.Catalog.Elastic
{
    public class ProductSearchEngine : IProductSearchEngine
    {
        public Task<IList<ProductDocument>> Search()
        {
            throw new System.NotImplementedException();
        }
    }
}
