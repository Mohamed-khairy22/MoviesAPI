
namespace MoviesAPI.DTO
{
    public class CreateAMovie
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public double Rate { get; set; }
        public string Storeline { get; set; }
        public IFormFile Poster { get; set; }
        public int GenreId { get; set; }
    }
}
