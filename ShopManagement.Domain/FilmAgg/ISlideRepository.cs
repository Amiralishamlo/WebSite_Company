
using _0_Framework.Domain;
using ShopManagement.Application.Contracts.Film;
using ShopManagement.Application.Contracts.Slide;

namespace ShopManagement.Domain.FilmAgg;

public interface IFilmRepository : IRepository<long, Film>
{
    EditFilm GetDetails(long id);
    List<FilmViewModel> GetList();
}