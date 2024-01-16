namespace _01_LampshadeQuery.Contracts.Film;

public interface IFilmQuery
{
    List<FilmQueryModel> GetFilms();
}