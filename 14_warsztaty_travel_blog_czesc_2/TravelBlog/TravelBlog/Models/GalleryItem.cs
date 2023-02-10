using System.ComponentModel.DataAnnotations;

namespace TravelBlog.Models
{
    public class GalleryItem
    {
        public int Id { get; set; }
        [Required, MinLength(2), MaxLength(120)]
        public string Title { get; set; }
        [Required, MinLength(13)]
        public string Link { get; set; }
    }
}
