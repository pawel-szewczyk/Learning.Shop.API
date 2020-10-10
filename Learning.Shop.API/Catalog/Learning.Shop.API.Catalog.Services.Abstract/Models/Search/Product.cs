using System;

namespace Learning.Shop.API.Catalog.Services.Abstract.Models.Search
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public float Rating { get; set; }
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
