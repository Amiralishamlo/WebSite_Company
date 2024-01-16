using System.Collections.Generic;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPoint.Areas.Administration.Pages.Blog.Articles;
[Authorize]

public class IndexModel : PageModel
{
    private readonly IArticleApplication _articleApplication;
    private readonly IArticleCategoryApplication _articleCategoryApplication;
    public SelectList ArticleCategories;
    public List<ArticleViewModel> Articles;
    public ArticleSearchModel SearchModel;

    public IndexModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
    {
        _articleApplication = articleApplication;
        _articleCategoryApplication = articleCategoryApplication;
    }

    public void OnGet(ArticleSearchModel searchModel)
    {
        ArticleCategories = new SelectList(_articleCategoryApplication.GetArticleCategories(), "Id", "Name");
        Articles = _articleApplication.Search(searchModel);
    }
}