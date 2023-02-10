using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelBlog.Data;
using TravelBlog.Models;
using TravelBlog.Repositories;

namespace TravelBlog.Areas.CMS.Pages
{
    public class AddGalleryItemModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        private readonly GalleryItemManager _manager; 

        public AddGalleryItemModel(ApplicationDbContext context, GalleryItemManager manager)
        {
            _context = context;
            _manager = manager; 
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public GalleryItem GalleryItem { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            await _manager.AddGalleryItem(GalleryItem);
            //_context.GalleryItems.Add(GalleryItem);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
