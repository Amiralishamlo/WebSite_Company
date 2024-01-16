using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace EndPoint.Areas.Administration.Pages;
[Authorize]
public class IndexModel : PageModel
{

    public void OnGet()
    {
    }

}