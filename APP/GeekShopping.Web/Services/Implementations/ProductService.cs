using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices.IProductService;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private const string BasePath = "api/product";

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductModel>> FindAll()
        {
            var response = await _httpClient.GetAsync(BasePath);
            return await response.ReadContentAsync<IEnumerable<ProductModel>>();
        }

        public async Task<ProductModel> FindById(int id)
        {
            var response = await _httpClient.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAsync<ProductModel>();
        }

        public async Task<ProductModel> Create(ProductModel product)
        {
            var response = await _httpClient.PostAsync(BasePath, product);
            
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAsync<ProductModel>();
            
            throw new Exception("Deu ruim no micro de Produtos"); // Vai virar notification pattern
        }

        public async Task<ProductModel> Update(ProductModel product)
        {
            var response = await _httpClient.PutAsync(BasePath, product);
            
            if(response.IsSuccessStatusCode) 
                return await response.ReadContentAsync<ProductModel>();

            throw new Exception("Deu ruim no micro de Produtos"); // Vai virar notification pattern
        }

        public async Task<bool> DeleteById(int id)
        {
            var response = await _httpClient.DeleteAsync($"{BasePath}/{id}");

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAsync<bool>();

            throw new Exception("Deu ruim no micro de Produtos"); // Vai virar notification pattern
        }
    }
}
