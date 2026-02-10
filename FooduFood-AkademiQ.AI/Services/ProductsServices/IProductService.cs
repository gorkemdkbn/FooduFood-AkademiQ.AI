using FooduFood_AkademiQ.AI.DTOs.CategoryDtos;
using FooduFood_AkademiQ.AI.DTOs.ProductDtos;

namespace FooduFood_AkademiQ.AI.Services.ProductsServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllAsycn();

        Task<UpdateProductDto> GetByIdAsycn(string id);

        Task CreateAsycn(CreateProductDto productDto);
        Task UpdateAsycn(UpdateProductDto productDto);

        Task DeleteAsycn(string id);
    }
}
