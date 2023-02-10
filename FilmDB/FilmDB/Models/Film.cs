using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmDB.Models
{
    public class Film
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }
        public int Year { get; set; }
        public int? GenreID { get; set; }
        [ForeignKey("GenreID")]
        public Genre? Genre { get; set; }
    }
}
