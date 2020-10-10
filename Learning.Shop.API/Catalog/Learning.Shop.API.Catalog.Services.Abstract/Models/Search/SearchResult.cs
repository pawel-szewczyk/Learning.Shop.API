using System.Collections.Generic;

namespace Learning.Shop.API.Catalog.Services.Abstract.Models.Search
{
    public class SearchResult
    {
        public int TotalNumberOfResults { get; }
        public IList<Product> Result { get; } = new List<Product>();

        public SearchResult(IList<Product> result, int totalNumberOfResults)
        {
            TotalNumberOfResults = totalNumberOfResults;
            Result = result;
        }
    }
}
