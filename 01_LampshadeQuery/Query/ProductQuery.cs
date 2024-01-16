using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _01_LampshadeQuery.Contracts.Product;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EFCore;

namespace _01_LampshadeQuery.Query;

public class ProductQuery : IProductQuery
{
    private readonly ShopContext _context;

    public ProductQuery(ShopContext context)
    {
        _context = context;
    }

    public ProductQueryModel GetProductDetails(string slug)
    {

        var product = _context.Products
            .Include(x => x.Category)
            .Select(x => new ProductQueryModel
            {
                Id = x.Id,
                Category = x.Category.Name,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                CategorySlug = x.Category.Slug,
                Code = x.Code,
                Description = x.Description,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                ShortDescription = x.ShortDescription,
            }).AsNoTracking().FirstOrDefault(x => x.Slug == slug);

        if (product == null)
            return new ProductQueryModel();
        return product;
    }

    public List<ProductQueryModel> GetLatestArrivals()
    {
      
        var products = _context.Products.Include(x => x.Category)
            .Select(product => new ProductQueryModel
            {
                Id = product.Id,
                Category = product.Category.Name,
                Name = product.Name,
                Picture = product.Picture,
                PictureAlt = product.PictureAlt,
                PictureTitle = product.PictureTitle,
                Slug = product.Slug
            }).AsNoTracking().OrderByDescending(x => x.Id).Take(6).ToList();

        

        return products;
    }

    public List<ProductQueryModel> Search(string value)
    {


        var query = _context.Products
            .Include(x => x.Category)
            .Select(product => new ProductQueryModel
            {
                Id = product.Id,
                Category = product.Category.Name,
                CategorySlug = product.Category.Slug,
                Name = product.Name,
                Picture = product.Picture,
                PictureAlt = product.PictureAlt,
                PictureTitle = product.PictureTitle,
                ShortDescription = product.ShortDescription,
                Slug = product.Slug
            }).AsNoTracking();

        if (!string.IsNullOrWhiteSpace(value))
            query = query.Where(x => x.Name.Contains(value) || x.ShortDescription.Contains(value));

        var products = query.OrderByDescending(x => x.Id).ToList();
        ;

       

        return products;
    }
}