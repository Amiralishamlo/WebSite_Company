using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Film;

namespace EndPoint.Areas.Administration.Pages.Shop.Films;

public class IndexModel : PageModel
{
    private readonly IFilmApplication _FilmApplication;
    public List<FilmViewModel> Films;

    public IndexModel(IFilmApplication FilmApplication)
    {
        _FilmApplication = FilmApplication;
    }

    [TempData] public string Message { get; set; }

    public void OnGet()
    {
        Films = _FilmApplication.GetList();
    }

    public IActionResult OnGetCreate()
    {
        var command = new CreateFilm();
        return Partial("./Create", command);
    }

    public JsonResult OnPostCreate(CreateFilm command)
    {
        var result = _FilmApplication.Create(command);
        return new JsonResult(result);
    }

    public IActionResult OnGetEdit(long id)
    {
        var Film = _FilmApplication.GetDetails(id);
        return Partial("Edit", Film);
    }

    public JsonResult OnPostEdit(EditFilm command)
    {
        var result = _FilmApplication.Edit(command);
        return new JsonResult(result);
    }

    public IActionResult OnGetRemove(long id)
    {
        var result = _FilmApplication.Remove(id);
        if (result.IsSuccedded)
            return RedirectToPage("./Index");

        Message = result.Message;
        return RedirectToPage("./Index");
    }

    public IActionResult OnGetRestore(long id)
    {
        var result = _FilmApplication.Restore(id);
        if (result.IsSuccedded)
            return RedirectToPage("./Index");

        Message = result.Message;
        return RedirectToPage("./Index");
    }
}