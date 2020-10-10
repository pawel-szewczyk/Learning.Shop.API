using System.Collections.Generic;

namespace Learning.Shop.API.Catalog.Contract.Response
{
    public class SearchResponse
    {
        public int TotalNumberOfResults { get; set; }
        public List<Product> CurrentPageResult { get; set; }
    }
}
