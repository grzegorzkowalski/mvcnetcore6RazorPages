using FilmDB.Data;
using FilmDB.Models;
using FilmDB.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FilmDB.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            //Film film = new();
            //film.Title = "Uwolnić orkę";
            //film.Year = 1990;
            //film.ID = 1;
            //FilmManager manager = new(_context);
            //await manager.AddFilm(film);
            ////manager.RemoveFilm(2);
            //var filmWithID3 = manager.GetFilm(3);
            //var filmWithID4 = manager.GetFilm(4);
            //filmWithID4.Title = "Terminator";
            //filmWithID4.Year = 1989;
            //manager.UpdateFilm(filmWithID4);
            //manager.ChangeTitle(3, "Uwolnić orkę 2");
            //manager.ChangeTitle(5, null);
            //var films = manager.GetFilms();
        }
    }
}