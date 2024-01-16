
using _01_LampshadeQuery.Contracts.Product;
using _01_LampshadeQuery.Contracts.ProductCategory;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrastructure.EFCore;


namespace _01_LampshadeQuery.Query;

public class ProductCategoryQuery : IProductCategoryQuery
{
    private readonly ShopContext _context;

    public ProductCategoryQuery(ShopContext context)
    {
        _context = context;
    }

    public List<ProductCategoryQueryModel> GetProductCategories()
    {
        return _context.ProductCategories.Select(x => new ProductCategoryQueryModel
        {
            Id = x.Id,
            Name = x.Name,
            Picture = x.Picture,
            PictureAlt = x.PictureAlt,
            PictureTitle = x.PictureTitle,
            Slug = x.Slug
        }).AsNoTracking().ToList();
    }

    public List<ProductCategoryQueryModel> GetProductCategoriesWithProducts()
    {

        var categories = _context.ProductCategories
            .Include(x => x.Products)
            .ThenInclude(x => x.Category)
            .Select(x => new ProductCategoryQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Products = MapProducts(x.Products)
            }).AsNoTracking().ToList();
        return categories;
    }

    public ProductCategoryQueryModel GetProductCategoryWithProducstsBy(string slug)
    {

        var catetory = _context.ProductCategories
            .Include(a => a.Products)
            .ThenInclude(x => x.Category)
            .Select(x => new ProductCategoryQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                MetaDescription = x.MetaDescription,
                Keywords = x.Keywords,
                Slug = x.Slug,
                Products = MapProducts(x.Products)
            }).AsNoTracking().FirstOrDefault(x => x.Slug == slug);

        return catetory;
    }

    private static List<ProductQueryModel> MapProducts(List<Product> products)
    {
        return products.Select(product => new ProductQueryModel
        {
            Id = product.Id,
            Category = product.Category.Name,
            Name = product.Name,
            Picture = product.Picture,
            PictureAlt = product.PictureAlt,
            PictureTitle = product.PictureTitle,
            Slug = product.Slug
        }).ToList();
    }
}