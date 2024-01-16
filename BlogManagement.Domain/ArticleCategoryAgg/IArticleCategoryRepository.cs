using System.Collections.Generic;
using _0_Framework.Domain;
using BlogManagement.Application.Contracts.ArticleCategory;

namespace BlogManagement.Domain.ArticleCategoryAgg;

public interface IArticleCategoryRepository : IRepository<long, ArticleCategory>
{
    string GetSlugBy(long id);
    EditArticleCategory GetDetails(long id);
    List<ArticleCategoryViewModel> GetArticleCategories();
    List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel);
}