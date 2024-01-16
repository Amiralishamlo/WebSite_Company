using _01_LampshadeQuery.Contracts.Article;
using _01_LampshadeQuery.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint.Pages
{
    public class ArticleModel : PageModel
    {
        private readonly IArticleCategoryQuery _articleCategoryQuery;
        private readonly IArticleQuery _articleQuery;
        public ArticleQueryModel Article;
        public List<ArticleCategoryQueryModel> ArticleCategories;


        public ArticleModel(IArticleQuery articleQuery, IArticleCategoryQuery articleCategoryQuery)
        {
            _articleQuery = articleQuery;
            _articleCategoryQuery = articleCategoryQuery;
        }

        public void OnGet(string id)
        {
            Article = _articleQuery.GetArticleDetails(id);
            ArticleCategories = _articleCategoryQuery.GetArticleCategories();
        }
    }
}
