using Learning.Shop.API.Catalog.Elastic.Abstract.Documents;
using System.Collections.Generic;

namespace Learning.Shop.API.Catalog.Elastic.Abstract.Results
{
    public class ProductSearchResult
    {
        public IList<ProductDocument> Hits { get; set; }
        public int TotalNumberOfHits { get; set; }
    }
}
