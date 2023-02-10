using FilmDB.Data;
using FilmDB.Models;
using FilmDB.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FilmDB.Pages
{
    public class ChangeCategoryModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly FilmManager _manager;
        public ChangeCategoryModel (ApplicationDbContext context, FilmManager manager)
        {
            _context = context;
            _manager = manager;
        }

        public List<Film> Films { get; set; }
        public List<Genre> Genres { get; set; }
        [FromForm]
        public int FilmID { get; set; }
        [FromForm]
        public int GenreID { get; set; }
        public void OnGet()
        {
            Films = _manager.GetFilmsSync();
            Genres = _context.Genres.ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var film = await _manager.GetFilm(FilmID);
            film.GenreID = GenreID;
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
