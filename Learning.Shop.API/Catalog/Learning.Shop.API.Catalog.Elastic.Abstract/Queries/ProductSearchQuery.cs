namespace Learning.Shop.API.Catalog.Elastic.Abstract.Queries
{
    public class ProductSearchQuery
    {
        public string Term { get; set; }
        public int BatchSize { get; set; }
        public int BatchNumber { get; set; }
    }
}
