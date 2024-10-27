using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configurarion) 
        {
            var client = new MongoClient(configurarion.GetValue<string>("DatabaseSettings:ConnectionString"));

            var database = client.GetDatabase(configurarion.GetValue<string>("DatabaseSettings:DatabaseName"));

            Products = database.GetCollection<Product>(configurarion.GetValue<string>("DatabaseSettings:CollectionName"));

            CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}
