using _01_LampshadeQuery.Contracts.Product;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint.Pages
{
    public class ProductModel : PageModel
    {
        private readonly IProductQuery _productQuery;
        public ProductQueryModel Product;

        public ProductModel(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        public void OnGet(string id)
        {
            Product = _productQuery.GetProductDetails(id);
        }
    }
}