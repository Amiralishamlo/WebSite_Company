using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using Microsoft.AspNetCore.Http;

namespace ShopManagement.Application.Contracts.Film;

public class CreateFilm
{
    public IFormFile Picture { get; set; }

    [Required(ErrorMessage = ValidationMessages.IsRequired)]
    public string PictureAlt { get; set; }

    [Required(ErrorMessage = ValidationMessages.IsRequired)]
    public string PictureTitle { get; set; }

    [Required(ErrorMessage = ValidationMessages.IsRequired)]
    public string Name { get; set; }

    [Required(ErrorMessage = ValidationMessages.IsRequired)]
    public string Description { get; set; }

    [Required(ErrorMessage = ValidationMessages.IsRequired)]
    public string Url { get; set; }
}