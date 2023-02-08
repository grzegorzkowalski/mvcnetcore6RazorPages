using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FilmDB.Data;
using FilmDB.Models;
using FilmDB.Repositories;

namespace FilmDB.Pages
{
    public class AddFilmModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        private readonly FilmManager _manager;

        public AddFilmModel(ApplicationDbContext context, FilmManager manager)
        {
            _context = context;
            _manager = manager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Film Film { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            await _manager.AddFilm(Film);

            return RedirectToPage("./Index");
        }
    }
}
