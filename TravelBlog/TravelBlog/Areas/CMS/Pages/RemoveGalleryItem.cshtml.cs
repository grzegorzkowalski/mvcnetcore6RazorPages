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
    public class RemoveGalleryItemModel : PageModel
    {
        private readonly GalleryItemManager _manager;

        public RemoveGalleryItemModel(GalleryItemManager manage)
        {
            _manager = manage;
        }

        [BindProperty]
      public GalleryItem GalleryItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _manager.GetList() == null)
            {
                return NotFound();
            }

            var galleryitem = await _manager.GetGalleryItem(id);

            if (galleryitem == null)
            {
                return NotFound();
            }
            else 
            {
                GalleryItem = galleryitem;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _manager.GetList() == null)
            {
                return NotFound();
            }
            _manager.RemoveGalleryItem(id);

            return RedirectToPage("./Index");
        }
    }
}
