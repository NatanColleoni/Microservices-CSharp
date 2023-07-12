using GeekShopping.Product.API.Data.Context;
using GeekShopping.Product.API.Data.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GeekShopping.Product.API.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySQLContext _context;

        public ProductRepository(MySQLContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            var products = await _context.Products.AsNoTracking().ToListAsync();

            return products.Select(x => (ProductVO)x);
        }

        public async Task<ProductVO> FindById(int id)
        {
            var product = await _context.Products.AsNoTracking().SingleOrDefaultAsync(product => product.Id == id);
            return (ProductVO)product;
        }

        public async Task<ProductVO> Create(ProductVO product)
        {
            var createdProduct = (Domain.Product)product;
            await _context.Products.AddAsync(createdProduct);
            await _context.SaveChangesAsync();
            return (ProductVO)createdProduct;
        }

        public async Task<ProductVO> Update(ProductVO product)
        {
            var createdProduct = (Domain.Product)product;
            _context.Products.Update(createdProduct);
            await _context.SaveChangesAsync();
            return (ProductVO)createdProduct;
        }

        public async Task<bool> Delete(int id)
        {
            var deleteObject = await _context.Products.FirstOrDefaultAsync(product => product.Id == id);
            if (deleteObject != null)
            {
                _context.Products.Remove(deleteObject);
                await _context.SaveChangesAsync();
                return true;
            }
            else 
                return false;
        }
    }
}
