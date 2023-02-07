using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FilmDB.Data;
using FilmDB.Models;
using FilmDB.Repositories;

namespace FilmDB.Pages
{
    public class EditFilmModel : PageModel
    {
        private readonly FilmDB.Data.ApplicationDbContext _context;

        public EditFilmModel(FilmDB.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Film Film { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var manaqer = new FilmManager(_context);
            if (id == null || _context.Films == null)
            {
                return NotFound();
            }

            var film =  await manaqer.GetFilm(id);
            if (film == null)
            {
                return NotFound();
            }
            Film = film;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var manaqer = new FilmManager(_context);
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Film).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmExists(Film.ID))
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

        private bool FilmExists(int id)
        {
          return _context.Films.Any(e => e.ID == id);
        }
    }
}
