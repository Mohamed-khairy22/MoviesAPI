using MoviesAPI.Models;

namespace MoviesAPI.Repsitories
{
    public interface IMovieRepo
    {
        List<Movie> GetAll(int GenreId=0);
        Movie GetById(int id);
        void Create(Movie movie);
        void Update(int id, Movie newMovie);
        void Delete(int id);
        bool IsValid(int id);
    }
}
