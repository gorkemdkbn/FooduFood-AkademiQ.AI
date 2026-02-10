using FooduFood_AkademiQ.AI.DTOs.CategoryDtos;
using FooduFood_AkademiQ.AI.Entities;
using FooduFood_AkademiQ.AI.Settings;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace FooduFood_AkademiQ.AI.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;

        public CategoryService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>
                (databaseSettings.CategoryCollectionName);
        }
        public async Task CreateAsycn(CreateCategoryDto categoryDto)
        {
            var category = new Category
            {
                Name = categoryDto.name,
            };

            await _categoryCollection.InsertOneAsync(category);
        }

        public async Task DeleteAsycn(string id)
        {
            await _categoryCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllAsycn()
        {
            var categories = await _categoryCollection.AsQueryable().ToListAsync();

            return categories.Select(c => new ResultCategoryDto
            {

                Id = c.Id,
                Name = c.Name,

            }).ToList();
        }

        public async Task<UpdateCategoryDto> GetByIdAsycn(string id)
        {
            var category = await _categoryCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return new UpdateCategoryDto
            {
                Id = category.Id,
                Name = category.Name,

            };
        }

        public async Task UpdateAsycn(UpdateCategoryDto categoryDto)
        {
            var category = new Category
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
            };
            await _categoryCollection.FindOneAndReplaceAsync(x => x.Id == category.Id, category);
        }
    }
}
