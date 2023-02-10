using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FilmDB.Data;
using FilmDB.Models;

namespace FilmDB.Pages
{
    public class ListGenresModel : PageModel
    {
        private readonly FilmDB.Data.ApplicationDbContext _context;

        public ListGenresModel(FilmDB.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Genre> Genre { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Genres != null)
            {
                Genre = await _context.Genres.ToListAsync();
            }
        }
    }
}
