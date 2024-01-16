using _01_LampshadeQuery.Contracts.Film;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.ViewComponents
{
    public class FilmsViewComponent: ViewComponent
    {
        private readonly IFilmQuery _FilmQuery;

        public FilmsViewComponent(IFilmQuery FilmQuery)
        {
            _FilmQuery = FilmQuery;
        }
        public IViewComponentResult Invoke()
        {
            var film = _FilmQuery.GetFilms();
            return View(film);
        }
    }
}
