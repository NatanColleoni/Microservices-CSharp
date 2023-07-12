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
                
                if (response is not null) return RedirectToAction(nameof(response));
            }

            return View();
        }
    }
}
