using Nest;
using System;

namespace Learning.Shop.API.Catalog.Elastic.Abstract.Documents
{
    public class ProductDocument
    {
        public string Id { get; set; }
        
        [Keyword]
        public string Name { get; set; }

        [Text]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
