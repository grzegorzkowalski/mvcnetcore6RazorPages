using FilmDB.Data;
using FilmDB.Models;
using FilmDB.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FilmDB.Pages
{
    public class EditFilmModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly FilmManager _manager;

        public EditFilmModel(ApplicationDbContext context, FilmManager manager)
        {
            _context = context;
            _manager = manager; 
        }

        [BindProperty]
        public Film Film { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Films == null)
            {
                return NotFound();
            }

            var film =  await _manager.GetFilm(id);
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
