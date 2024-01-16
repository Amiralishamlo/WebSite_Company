using BlogManagement.Application.Contracts.Article;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;

namespace EndPoint.Areas.Administration.Pages.Shop.Products
{
    [Authorize]

    public class CreateModel : PageModel
    {
        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;
        public CreateProduct Command;
        public SelectList ProductCategory;


        public CreateModel(IProductApplication productApplication,
    IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }
        public void OnGet()
        {
            ProductCategory = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
        }


        public IActionResult OnPost(CreateProduct command)
        {
            var result = _productApplication.Create(command);
            return RedirectToPage("./Index");
        }
    }
}
