using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.IServices.IProductService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> FindAll();
        Task<ProductModel> FindById(int id);
        Task<ProductModel> Create(ProductModel product);
        Task<ProductModel> Update(ProductModel product);
        Task<bool> DeleteById(int id);
    }
}
