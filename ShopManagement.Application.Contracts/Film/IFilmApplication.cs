using System.Collections.Generic;
using _0_Framework.Application;

namespace ShopManagement.Application.Contracts.Film;

public interface IFilmApplication
{
    OperationResult Create(CreateFilm command);
    OperationResult Edit(EditFilm command);
    OperationResult Remove(long id);
    OperationResult Restore(long id);
    EditFilm GetDetails(long id);
    List<FilmViewModel> GetList();
}