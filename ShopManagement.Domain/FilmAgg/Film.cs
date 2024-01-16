using _0_Framework.Domain;

namespace ShopManagement.Domain.FilmAgg
{
    public class Film: EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Image { get; set; }
        public string Url {  get; set; }
        public bool IsRemoved { get; private set; }

        public Film(string name, string description, string pictureAlt, string pictureTitle, string image, string url)
        {
            Name = name;
            Description = description;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Image = image;
            Url = url;
        }
        public void Edit(string name, string description, string pictureAlt, string pictureTitle, string image, string url)
        {
            Name = name;
            Description = description;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Image = image;
            Url = url;
        }
        public void Remove()
        {
            IsRemoved = true;
        }

        public void Restore()
        {
            IsRemoved = false;
        }
    }
}
