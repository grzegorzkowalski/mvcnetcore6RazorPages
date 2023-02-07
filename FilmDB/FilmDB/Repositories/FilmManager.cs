using FilmDB.Data;
using FilmDB.Models;

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

        public FilmManager RemoveFilm(int id)
        {
            var filmToDelete = _context.Films.SingleOrDefault(x => x.ID == id);
            if (filmToDelete != null)
            { 
                _context.Remove(filmToDelete);
                _context.SaveChanges();
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

        public FilmManager ChangeTitle(int id, string newTitle)
        {
            var film = GetFilm(id);
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
                
                _context.SaveChanges();
            }
            return this;
        }

        public Film GetFilm(int id)
        {
            var film = _context.Films.SingleOrDefault(x => x.ID == id);
            return film;
        }

        public List<Film> GetFilms()
        {
            return _context.Films.ToList();
        }
    }
}
