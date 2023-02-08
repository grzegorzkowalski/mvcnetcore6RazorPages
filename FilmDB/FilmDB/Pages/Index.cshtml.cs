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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        private readonly FilmManager _manager;

        public IndexModel(ApplicationDbContext context, FilmManager manager)
        {
            _context = context;
            _manager = manager; 
        }

        public IList<Film> Film { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Films != null)
            {
                //var manager = new FilmManager(_context);
                Film = await _manager.GetFilms();
            }
        }
    }
}
