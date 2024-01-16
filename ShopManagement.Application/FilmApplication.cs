using _0_Framework.Application;
using ShopManagement.Application.Contracts.Film;
using ShopManagement.Domain.FilmAgg;

namespace ShopManagement.Application;

public class FilmApplication : IFilmApplication
{
    private readonly IFileUploader _fileUploader;
    private readonly IFilmRepository _FilmRepository;

    public FilmApplication(IFilmRepository FilmRepository, IFileUploader fileUploader)
    {
        _fileUploader = fileUploader;
        _FilmRepository = FilmRepository;
    }

    public OperationResult Create(CreateFilm command)
    {
        var operation = new OperationResult();

        var pictureName = _fileUploader.Upload(command.Picture, "Films");

        var Film = new Film(command.Name,command.Description,command.PictureAlt,command.PictureTitle,pictureName,command.Url);

        _FilmRepository.Create(Film);
        _FilmRepository.SaveChanges();
        return operation.Succedded();
    }

    public OperationResult Edit(EditFilm command)
    {
        var operation = new OperationResult();
        var Film = _FilmRepository.Get(command.Id);
        if (Film == null)
            return operation.Failed(ApplicationMessages.RecordNotFound);

        var pictureName = _fileUploader.Upload(command.Picture, "Films");

        Film.Edit(command.Name, command.Description, command.PictureAlt, command.PictureTitle, pictureName, command.Url);
        _FilmRepository.SaveChanges();
        return operation.Succedded();
    }

    public EditFilm GetDetails(long id)
    {
        return _FilmRepository.GetDetails(id);
    }

    public List<FilmViewModel> GetList()
    {
        return _FilmRepository.GetList();
    }

    public OperationResult Remove(long id)
    {
        var operation = new OperationResult();
        var Film = _FilmRepository.Get(id);
        if (Film == null)
            return operation.Failed(ApplicationMessages.RecordNotFound);

        Film.Remove();
        _FilmRepository.SaveChanges();
        return operation.Succedded();
    }

    public OperationResult Restore(long id)
    {
        var operation = new OperationResult();
        var Film = _FilmRepository.Get(id);
        if (Film == null)
            return operation.Failed(ApplicationMessages.RecordNotFound);

        Film.Restore();
        _FilmRepository.SaveChanges();
        return operation.Succedded();
    }
}