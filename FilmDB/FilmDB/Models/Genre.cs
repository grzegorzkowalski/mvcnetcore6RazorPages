namespace FilmDB.Models
{
    public class Genre
    {
        public string Name { get; set; }
        public int GenreID { get; set; }
        public ICollection<Film> Films { get; set; }
    }
}
