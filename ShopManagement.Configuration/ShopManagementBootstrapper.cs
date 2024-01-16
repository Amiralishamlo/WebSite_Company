

using _01_LampshadeQuery.Contracts.Film;
using _01_LampshadeQuery.Contracts.Product;
using _01_LampshadeQuery.Contracts.ProductCategory;
using _01_LampshadeQuery.Contracts.Slide;
using _01_LampshadeQuery.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.Film;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.FilmAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.SlideAgg;
using ShopManagement.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore.Repository;

namespace ShopManagement.Configuration;

public class ShopManagementBootstrapper
{
    public static void Configure(IServiceCollection services, string connectionString)
    {
        services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
        services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

        services.AddTransient<IProductApplication, ProductApplication>();
        services.AddTransient<IProductRepository, ProductRepository>();

        services.AddTransient<ISlideApplication, SlideApplication>();
        services.AddTransient<ISlideRepository, SlideRepository>();

        services.AddTransient<IFilmApplication, FilmApplication>();
        services.AddTransient<IFilmRepository, FilmRepository>();



        services.AddTransient<ISlideQuery, SlideQuery>();
        services.AddTransient<IFilmQuery, FilmQuery>();

        services.AddTransient<IProductCategoryQuery, ProductCategoryQuery>();
       services.AddTransient<IProductQuery, ProductQuery>();

        services.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionString));
    }
}