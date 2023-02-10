using FilmDB.Data;
using FilmDB.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmDB.Repositories
{
    public class FilmManager
    {
        private readonly ApplicationDbContext _context;
        public FilmManager (ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<FilmManager> AddFilm(Film film)
        {
            try
            {
                _context.Films.Add(film);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                film.ID = 0;
                await _context.SaveChangesAsync();
            }

            return this;
        }

        public async Task<FilmManager> RemoveFilm(int id)
        {
            var filmToDelete = await GetFilm(id);
            if (filmToDelete != null)
            { 
                _context.Remove(filmToDelete);
                await _context.SaveChangesAsync();
            }
            return this;
        }

        public FilmManager UpdateFilm(Film film)
        {
            if (film != null)
            {
                _context.Films.Update(film);
                _context.SaveChanges();
            }
            return this;
        }

        public async Task<FilmManager> ChangeTitle(int id, string newTitle)
        {
            var film = await GetFilm(id);
            if (film != null)
            {
                if (String.IsNullOrWhiteSpace(newTitle))
                {
                    film.Title = "Brak tytułu";
                }
                else
                {
                    film.Title = newTitle;
                }
                
                await _context.SaveChangesAsync();
            }
            return this;
        }

        public async Task<Film> GetFilm(int? id)
        {
            var film = new Film();
            if (id != null) 
            {
                film = await _context.Films.SingleOrDefaultAsync(x => x.ID == id);
            }
            return film;

        }
        public List<Film> GetFilmsSync()
        {
            return _context.Films.ToList();
        }
        public async Task<List<Film>> GetFilms()
        {
            return await _context.Films.Include(g => g.Genre).ToListAsync();
        }
    }
}
