using FooduFood_AkademiQ.AI.Services.ProductsServices;
using Microsoft.AspNetCore.Mvc;

namespace FooduFood_AkademiQ.AI.ViewComponents.DefaultComponents
{
    public class _DefaultProductsViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public _DefaultProductsViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        // "Asycn" değil, "Async" olmalı:
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _productService.GetAllAsycn(); // Servis metodundaki ismi de kontrol etmeyi unutma!
            return View(products);
        }
    }
}