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
        private readonly ApplicationDbContext _context;
        private readonly FilmManager _manager;

        public RemoveFilmModel(ApplicationDbContext context, FilmManager manager)
        {
            _context = context;
            _manager = manager;
        }

        [BindProperty]
      public Film Film { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Films == null)
            {
                return NotFound();
            }  
            var film = await _manager.GetFilm(id);

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
            if (id == null || _context.Films == null)
            {
                return NotFound();
            }
            var film = await _manager.GetFilm(id);

            if (film != null)
            {
                Film = film;
                await _manager.RemoveFilm(Film.ID);
            }

            return RedirectToPage("./Index");
        }
    }
}
