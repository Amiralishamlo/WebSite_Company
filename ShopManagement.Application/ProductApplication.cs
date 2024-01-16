using _0_Framework.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using System.Collections.Generic;

namespace ShopManagement.Application;

public class ProductApplication : IProductApplication
{
    private readonly IFileUploader _fileUploader;
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly IProductRepository _productRepository;

    public ProductApplication(IProductRepository productRepository, IFileUploader fileUploader,
        IProductCategoryRepository productCategoryRepository)
    {
        _fileUploader = fileUploader;
        _productRepository = productRepository;
        _productCategoryRepository = productCategoryRepository;
    }

    public OperationResult Create(CreateProduct command)
    {
        var operation = new OperationResult();
        if (_productRepository.Exists(x => x.Name == command.Name))
            return operation.Failed(ApplicationMessages.DuplicatedRecord);

        var slug = command.Slug.Slugify();
        var categorySlug = _productCategoryRepository.GetSlugById(command.CategoryId);
        var path = $"{categorySlug}/{slug}";
        var pictureName = _fileUploader.Upload(command.Picture, path);

        var article = new Product(command.Name,command.Code,command.ShortDescription,command.Description,
            pictureName,command.PictureAlt,command.PictureTitle,command.CategoryId,slug,command.Keywords,command.MetaDescription);

        _productRepository.Create(article);
        _productRepository.SaveChanges();
        return operation.Succedded();
    }

    public OperationResult Edit(EditProduct command)
    {
        var operation = new OperationResult();
        var article = _productRepository.GetProductWithCategory(command.Id);

        if (article == null)
            return operation.Failed(ApplicationMessages.RecordNotFound);

        if (_productRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
            return operation.Failed(ApplicationMessages.DuplicatedRecord);

        var slug = command.Slug.Slugify();
        var path = $"{article.Category.Slug}/{slug}";
        var pictureName = _fileUploader.Upload(command.Picture, path);

        article.Edit(command.Name, command.Code, command.ShortDescription, command.Description,
            pictureName, command.PictureAlt, command.PictureTitle, command.CategoryId, slug, command.Keywords, command.MetaDescription);

        _productRepository.SaveChanges();
        return operation.Succedded();
    }

    public EditProduct GetDetails(long id)
    {
        return _productRepository.GetDetails(id);
    }

    public List<ProductViewModel> GetProducts()
    {
        return _productRepository.GetProducts();
    }

    public List<ProductViewModel> Search(ProductSearchModel searchModel)
    {
        return _productRepository.Search(searchModel);
    }
}