namespace Learning.Shop.API.Catalog.Configuration.Options
{
    public class CatalogOptions
    {
        internal const string SectionName = "Catalog";

        public ElasticsearchOptions Elasticsearch { get; set; }
    }
}
