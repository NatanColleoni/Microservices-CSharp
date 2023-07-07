using GeekShopping.Product.API.Data.ValueObjects;

namespace GeekShopping.Product.API.Data.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductVO>> FindAll();
        Task<ProductVO> FindById(int id);
        Task<ProductVO> Create(ProductVO product);
        Task<ProductVO> Update(ProductVO product);
        Task<bool> Delete(int id);
    }
}
