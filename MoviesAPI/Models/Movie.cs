using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public double Rate { get; set; }
        public string Storeline { get; set; }
        public byte[] Poster { get; set; }
        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
