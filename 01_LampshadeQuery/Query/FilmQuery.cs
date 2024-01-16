using _01_LampshadeQuery.Contracts.Film;
using ShopManagement.Infrastructure.EFCore;

namespace _01_LampshadeQuery.Query
{
    public class FilmQuery:IFilmQuery
    {
        private readonly ShopContext _shopContext;

        public FilmQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<FilmQueryModel> GetFilms()
        {
            return _shopContext.Films
                .Where(x => x.IsRemoved == false)
                .Select(x => new FilmQueryModel
                {
                    Picture = x.Image,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Description = x.Description,
                    Name = x.Name,
                    Url = x.Url
                }).ToList();
        }
    }
}