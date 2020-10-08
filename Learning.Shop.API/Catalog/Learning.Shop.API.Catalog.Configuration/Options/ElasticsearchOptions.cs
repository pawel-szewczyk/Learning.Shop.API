namespace Learning.Shop.API.Catalog.Configuration.Options
{
    public class ElasticsearchOptions
    {
        internal const string SectionName = "Elasticsearch";

        public string Index { get; set; }
        public string Url { get; set; }
    }
}
