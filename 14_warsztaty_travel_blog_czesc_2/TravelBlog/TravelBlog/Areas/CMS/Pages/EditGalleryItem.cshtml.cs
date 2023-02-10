using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelBlog.Data;
using TravelBlog.Models;
using TravelBlog.Repositories;

namespace TravelBlog.Areas.CMS.Pages
{
    public class EditGalleryItemModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        private readonly GalleryItemManager _manager;

        public EditGalleryItemModel(ApplicationDbContext context, GalleryItemManager manager)
        {
            _context = context;
            _manager = manager;
        }

        [BindProperty]
        public GalleryItem GalleryItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.GalleryItems == null)
            {
                return NotFound();
            }

            var galleryitem =  await _manager.GetGalleryItem(id);
            if (galleryitem == null)
            {
                return NotFound();
            }
            GalleryItem = galleryitem;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(GalleryItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            //try
            //{
            //    _manager.EditGalleryItem(GalleryItem);
            //}
            
            catch (DbUpdateConcurrencyException)
            {
                if (!GalleryItemExists(GalleryItem.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GalleryItemExists(int id)
        {
          return _context.GalleryItems.Any(e => e.Id == id);
        }
    }
}
