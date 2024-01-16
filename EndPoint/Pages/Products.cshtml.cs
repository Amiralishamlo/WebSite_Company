using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Product;

namespace EndPoint.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly IProductApplication _productApplication;

        public ProductsModel(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }
        public List<ProductViewModel> productViews;

        public void OnGet()
        {
            productViews = _productApplication.GetProducts();
        }
    }
}
