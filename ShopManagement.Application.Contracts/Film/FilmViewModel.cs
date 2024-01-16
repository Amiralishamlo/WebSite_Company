using _0_Framework.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contracts.Film;

public class FilmViewModel
{
    public long Id { get; set; }
    public string Picture { get; set; }
    public string PictureAlt { get; set; }
    public string PictureTitle { get; set; }
    public string Name { get; set; }
    public bool IsRemoved { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
}