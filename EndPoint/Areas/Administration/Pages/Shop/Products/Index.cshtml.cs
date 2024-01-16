using System.Collections.Generic;
using _0_Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;

namespace EndPoint.Areas.Administration.Pages.Shop.Products;
[Authorize]

public class IndexModel : PageModel
{
    private readonly IProductApplication _productApplication;
    private readonly IProductCategoryApplication _productCategoryApplication;
    public SelectList ProductCategories;
    public List<ProductViewModel> Products;
    public ProductSearchModel SearchModel;

    public IndexModel(IProductApplication productApplication,
        IProductCategoryApplication productCategoryApplication)
    {
        _productApplication = productApplication;
        _productCategoryApplication = productCategoryApplication;
    }

    [TempData] public string Message { get; set; }
    public void OnGet(ProductSearchModel searchModel)
    {
        ProductCategories = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
        Products = _productApplication.Search(searchModel);
    }
}