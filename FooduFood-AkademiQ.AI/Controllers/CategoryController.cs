using FooduFood_AkademiQ.AI.DTOs.CategoryDtos;
using FooduFood_AkademiQ.AI.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace FooduFood_AkademiQ.AI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsycn();
            return View(categories);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto categoryDto)
        {
            await _categoryService.CreateAsycn(categoryDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateCategory(string id)
        {
            var category = await _categoryService.GetByIdAsycn(id);
            return View(category);

        }


        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto categoryDto)
        {
           await _categoryService.UpdateAsycn(categoryDto);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteAsycn(id);
            return RedirectToAction("Index");
        }
    }

}
