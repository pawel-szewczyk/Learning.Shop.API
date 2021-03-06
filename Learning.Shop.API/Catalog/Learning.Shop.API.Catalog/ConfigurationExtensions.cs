﻿using Learning.Shop.API.Catalog.Elastic;
using Learning.Shop.API.Catalog.Services.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Learning.Shop.API.Catalog
{
    public static class ConfigurationExtensions
    {
        public static IMvcBuilder AddCatalog(this IMvcBuilder builder, 
            IConfiguration configuration)
        {
            builder.AddApplicationPart(Assembly.GetExecutingAssembly());
            builder.Services.AddElasticsearch(configuration)
                .AddServices()
                .AddHealthChecks()
                .AddElasticHealthCheck(configuration);
            return builder;
        }
    }
}
