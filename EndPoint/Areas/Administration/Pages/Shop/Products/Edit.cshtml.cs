using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;

namespace EndPoint.Areas.Administration.Pages.Shop.Products
{
    [Authorize]

    public class EditModel : PageModel
    {
        private readonly IProductApplication _articleApplication;
        private readonly IProductCategoryApplication _articleCategoryApplication;
        public SelectList ProductCategories;
        public EditProduct Command;
        public EditModel(IProductApplication articleApplication, IProductCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }
        public void OnGet(long id)
        {
            Command = _articleApplication.GetDetails(id);
            ProductCategories = new SelectList(_articleCategoryApplication.GetProductCategories(), "Id", "Name");
        }

        public IActionResult OnPost(EditProduct command)
        {
            var result = _articleApplication.Edit(command);
            return RedirectToPage("./Index");
        }
    }
}
