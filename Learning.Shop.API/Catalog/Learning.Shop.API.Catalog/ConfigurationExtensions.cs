using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Learning.Shop.API.Catalog
{
    public static class ConfigurationExtensions
    {
        public static IMvcBuilder AddCatalog(this IMvcBuilder builder)
            => builder.AddApplicationPart(Assembly.GetExecutingAssembly());
    }
}
