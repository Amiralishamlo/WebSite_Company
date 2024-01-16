using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPoint.Areas.Administration.Pages.Blog.Articles;
[Authorize]

public class CreateModel : PageModel
{
    private readonly IArticleApplication _articleApplication;
    private readonly IArticleCategoryApplication _articleCategoryApplication;
    public SelectList ArticleCategories;
    public CreateArticle Command;

    public CreateModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
    {
        _articleApplication = articleApplication;
        _articleCategoryApplication = articleCategoryApplication;
    }

    public void OnGet()
    {
        ArticleCategories = new SelectList(_articleCategoryApplication.GetArticleCategories(), "Id", "Name");
    }

    public IActionResult OnPost(CreateArticle command)
    {
        var result = _articleApplication.Create(command);
        return RedirectToPage("./Index");
    }
}