using MoviesAPI.Models;

namespace MoviesAPI.Repsitories
{
    public interface IGenreRepo
    {
        List<Genre> GetAll();
        Genre GetById(int id);
        void Create(Genre genre);
        void Update(int id, Genre newGenre);
        void Delete(int id);
    }
}
