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

        // Kategori Listesi
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsycn();
            return View(categories);
        }

        // Yeni Kategori Ekleme (Sayfayı Aç)
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        // Yeni Kategori Ekleme (Kaydet)
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryDto);
            }

            await _categoryService.CreateAsycn(categoryDto);
            return RedirectToAction("Index");
        }

        // Kategori Güncelleme (Veriyi Getir)
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            // ID boş gelirse direkt listeye dön
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index");
            }

            var category = await _categoryService.GetByIdAsycn(id);

            // Veritabanında bu ID ile bir kayıt bulunamadıysa hata almamak için kontrol et
            if (category == null)
            {
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // Kategori Güncelleme (Değişiklikleri Kaydet)
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryDto);
            }

            await _categoryService.UpdateAsycn(categoryDto);
            return RedirectToAction("Index");
        }

        // Kategori Silme
        public async Task<IActionResult> DeleteCategory(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                await _categoryService.DeleteAsycn(id);
            }

            return RedirectToAction("Index");
        }
    }
}