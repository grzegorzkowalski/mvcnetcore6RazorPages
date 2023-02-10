using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelBlog.Data;
using TravelBlog.Models;
using TravelBlog.Repositories;

namespace TravelBlog.Areas.CMS.Pages
{
    public class ListGalleryItemsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly GalleryItemManager _manager;

        public ListGalleryItemsModel(ApplicationDbContext context, GalleryItemManager manager)
        {
            _context = context;
            _manager = manager;
        }

        public IList<GalleryItem> GalleryItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.GalleryItems != null)
            {
                GalleryItem = await _manager.GetList();
            }
        }
    }
}
