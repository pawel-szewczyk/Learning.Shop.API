namespace Learning.Shop.API.Catalog.Contract.Query
{
    public class CatalogSearchQuery
    {
        public string SearchTerm { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
