using System.ComponentModel.DataAnnotations;

namespace FilmDB.Models
{
    public class Film
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }
        public int Year { get; set; }
    }
}
