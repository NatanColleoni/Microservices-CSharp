namespace GeekShopping.Product.API.Data.ValueObjects
{
    public class ProductVO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }

        public static explicit operator ProductVO(Domain.Product entity)
        {
            return new ProductVO()
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                Description = entity.Description,
                CategoryName = entity.CategoryName,
                ImageUrl = entity.ImageUrl
            };
        }

        public static explicit operator Domain.Product(ProductVO vo)
        {
            return new Domain.Product()
            {
                Id = vo.Id,
                Name = vo.Name,
                Price = vo.Price,
                Description = vo.Description,
                CategoryName = vo.CategoryName,
                ImageUrl = vo.ImageUrl
            };
        }
    }
}
