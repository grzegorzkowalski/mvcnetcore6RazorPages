using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelBlog.Models;
using TravelBlog.Repositories;

namespace TravelBlog.Pages
{
    public class GalleryModel : PageModel
    {
        private readonly GalleryItemManager _manager;
        public GalleryModel(GalleryItemManager manager)
        {
            _manager = manager;
        }
        public List<GalleryItem> GalleryItems;
        public async Task<IActionResult> OnGetAsync()
        {
            GalleryItems = await _manager.GetList();
            return Page();
        }
    }
}
