using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FilmDB.Data;
using FilmDB.Models;
using FilmDB.Repositories;

namespace FilmDB.Pages
{
    public class RemoveFilmModel : PageModel
    {
        private readonly FilmDB.Data.ApplicationDbContext _context;

        public RemoveFilmModel(FilmDB.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Film Film { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var manaqer = new FilmManager(_context);
            if (id == null || _context.Films == null)
            {
                return NotFound();
            }  
            var film = await manaqer.GetFilm(id);

            if (film == null || film.ID == 0)
            {
                return NotFound();
            }
            else 
            {
                Film = film;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var manaqer = new FilmManager(_context);
            if (id == null || _context.Films == null)
            {
                return NotFound();
            }
            var film = await manaqer.GetFilm(id);

            if (film != null)
            {
                Film = film;
                await manaqer.RemoveFilm(Film.ID);
            }

            return RedirectToPage("./Index");
        }
    }
}
