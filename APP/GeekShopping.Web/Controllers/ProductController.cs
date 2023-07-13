using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices.IProductService;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _service.FindAll();
            return View(products);
        }

        public async Task<IActionResult> CreateView()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                var response = await _service.Create(product);
                
                if (response is not null) return RedirectToAction(nameof(Index));
            }

            return View();
        }
        
        public async Task<IActionResult> UpdateView(int id)
        {
            var product = await _service.FindById(id);
            if(product is not null) return View(product);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                var response = await _service.Update(product);
                
                if (response is not null) return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> DeleteView(int id)
        {
            var product = await _service.FindById(id);
            if (product is not null) return View(product);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductModel product)
        {
            
            var response = await _service.DeleteById(product.Id);
            if (response) return RedirectToAction(nameof(Index));
            
            return View();
        }
    }
}
