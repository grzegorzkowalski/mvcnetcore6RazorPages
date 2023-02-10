using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelBlog.Data;
using TravelBlog.Models;

namespace TravelBlog.Areas.CMS.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly TravelBlog.Data.ApplicationDbContext _context;

        public DeleteModel(TravelBlog.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public GalleryItem GalleryItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.GalleryItems == null)
            {
                return NotFound();
            }

            var galleryitem = await _context.GalleryItems.FirstOrDefaultAsync(m => m.Id == id);

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
            if (id == null || _context.GalleryItems == null)
            {
                return NotFound();
            }
            var galleryitem = await _context.GalleryItems.FindAsync(id);

            if (galleryitem != null)
            {
                GalleryItem = galleryitem;
                _context.GalleryItems.Remove(GalleryItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
