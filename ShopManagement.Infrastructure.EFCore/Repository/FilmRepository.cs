using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using ShopManagement.Application.Contracts.Film;
using ShopManagement.Domain.FilmAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository;

public class FilmRepository : RepositoryBase<long, Film>, IFilmRepository
{
    private readonly ShopContext _context;

    public FilmRepository(ShopContext context) : base(context)
    {
        _context = context;
    }

    public EditFilm GetDetails(long id)
    {
        return _context.Films.Select(x => new EditFilm
        {
            Id = x.Id,
            PictureAlt = x.PictureAlt,
            PictureTitle = x.PictureTitle,
            Description = x.Description,
            Name = x.Name,
            Url = x.Url,
        }).FirstOrDefault(x => x.Id == id);
    }

    public List<FilmViewModel> GetList()
    {
        return _context.Films.Select(x => new FilmViewModel
        {
            Id = x.Id,
            Description = x.Description,
            Url = x.Url,
            Picture = x.Image,
            Name = x.Name,
            IsRemoved = x.IsRemoved,
        }).OrderByDescending(x => x.Id).ToList();
    }
}