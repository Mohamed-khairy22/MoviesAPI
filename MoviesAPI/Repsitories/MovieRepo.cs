using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;

namespace MoviesAPI.Repsitories
{
    public class MovieRepo : IMovieRepo
    {
        MovieDbContext context;
        public MovieRepo(MovieDbContext context)
        {
            this.context = context;
        }
        public List<Movie> GetAll(int GenreId=0)
        {
            return context.Movies.Where(m=>m.GenreId==GenreId || GenreId==0).OrderByDescending(m=>m.Rate).Include(m=>m.Genre).ToList();
        }
        public Movie GetById(int id)
        {
            return context.Movies.Include(m=>m.Genre).FirstOrDefault(m => m.Id == id);
        }
        public void Create(Movie movie)
        {
            context.Movies.Add(movie);
            context.SaveChanges();
        }
        public void Update(int id, Movie newMovie)
        {
            Movie oldMovie = GetById(id);
            oldMovie.Title = newMovie.Title;
            oldMovie.Year = newMovie.Year;
            oldMovie.Storeline = newMovie.Storeline;
            oldMovie.Rate = newMovie.Rate;
            oldMovie.Poster= newMovie.Poster;

            context.SaveChanges();

        }
        public void Delete(int id)
        {
            context.Movies.Remove(GetById(id));
            context.SaveChanges();
        }
        public bool IsValid(int id)
        {
           return context.Genres.Any(g => g.Id == id);
        }
    }
}

