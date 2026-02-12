using FooduFood_AkademiQ.AI.DTOs.ProductDtos;
using FooduFood_AkademiQ.AI.Entities;
using FooduFood_AkademiQ.AI.Settings;
using Mapster;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace FooduFood_AkademiQ.AI.Services.ProductsServices
{
    public class ProductService : IProductService
    {

        private readonly IMongoCollection<Product> _productCollection;

        public ProductService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>
             (databaseSettings.ProductCollectionName);
        }

        public async Task CreateAsycn(CreateProductDto productDto)
        {
            var product = productDto.Adapt<Product>();
            await _productCollection.InsertOneAsync(product);
        }

        public async Task DeleteAsycn(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.Id == id);

        }

        public async Task<List<ResultProductDto>> GetAllAsycn()
        {
            var products = await _productCollection.AsQueryable().ToListAsync();
                

            return products.Adapt<List<ResultProductDto>>();
        }

        public async Task<UpdateProductDto> GetByIdAsycn(string id)
        {
            var product = await _productCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return product.Adapt<UpdateProductDto>();
        }

        public async Task UpdateAsycn(UpdateProductDto productDto)
        {
            var product = productDto.Adapt<Product>();
            await _productCollection.FindOneAndReplaceAsync(x => x.Id == product.Id, product);
           
        }
    }
}
