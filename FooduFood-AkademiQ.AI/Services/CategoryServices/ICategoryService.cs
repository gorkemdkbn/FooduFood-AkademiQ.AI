using FooduFood_AkademiQ.AI.DTOs.CategoryDtos;

namespace FooduFood_AkademiQ.AI.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllAsycn();

        Task<UpdateCategoryDto> GetByIdAsycn(string id);

        Task CreateAsycn(CreateCategoryDto categoryDto);
        Task UpdateAsycn(UpdateCategoryDto categoryDto);

        Task DeleteAsycn(string id);

    }
}
