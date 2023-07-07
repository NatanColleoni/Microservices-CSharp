using GeekShopping.Product.API.Data.Repository;

namespace GeekShopping.Product.API.IoC
{
    public static class NativeInjector
    {
        public static void ResolveDependencies(this IServiceCollection service)
        {
            service.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
