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
        public FilmManager AddFilm(Film film)
        {
            try
            {
                _context.Films.Add(film);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                film.ID = 0;
                _context.SaveChanges();
            }

            return this;
        }

        public FilmManager RemoveFilm(int id)
        {
            return this;
        }

        public FilmManager UpdateFilm(Film film)
        {
            return this;
        }

        public FilmManager ChangeTitle(int id, string newTitle)
        {
            return this;
        }

        public FilmManager GetFilm(int id)
        {
            return null;
        }

        public List<Film> GetFilms()
        {
            return null;
        }
    }
}
