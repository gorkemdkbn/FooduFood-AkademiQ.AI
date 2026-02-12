using FooduFood_AkademiQ.AI.DTOs.ProductDtos;
using FooduFood_AkademiQ.AI.Services.CategoryServices;
using FooduFood_AkademiQ.AI.Services.ProductsServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FooduFood_AkademiQ.AI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController(IProductService _productService,
        ICategoryService _categoryService) : Controller
    {

        public async Task GetCategoriesAsync()
        {
            var categories = await _categoryService.GetAllAsycn();
            ViewBag.categories = (from category in categories
                                  select new SelectListItem
                                  {
                                      Text = category.Name,
                                      Value = category.Id
                                  }).ToList();

        }


        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsycn();
            return View(products);
        }

        public async Task<IActionResult> CreateProduct()
        {
            await GetCategoriesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                await GetCategoriesAsync();

                return View(productDto);
            }

            await _productService.CreateAsycn(productDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateProduct(string id)
        {
            await GetCategoriesAsync();
            var product = await _productService.GetByIdAsycn(id);
            return View(product);
        }

        [HttpPost]

        public async Task<IActionResult> UpdateProduct(UpdateProductDto productDto)
        {
            await _productService.UpdateAsycn(productDto);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteAsycn(id);
            return RedirectToAction("Index");
        }
    }
}

