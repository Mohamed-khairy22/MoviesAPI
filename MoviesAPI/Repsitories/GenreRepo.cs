using MoviesAPI.Models;


namespace MoviesAPI.Repsitories
{
    public class GenreRepo : IGenreRepo
    {
        MovieDbContext context;
        public GenreRepo(MovieDbContext context)
        {
            this.context = context;
        }
        public List <Genre> GetAll()
        {
            return context.Genres.OrderBy(g=>g.Name).ToList();
        }
        public Genre GetById(int id)
        {
            return context.Genres.FirstOrDefault(g => g.Id == id);
        }
        public void Create(Genre genre)
        {
            context.Genres.Add(genre);
            context.SaveChanges();
        }
        public void Update(int id,Genre newGenre)
        {
            Genre oldGenre = GetById(id);
            oldGenre.Name = newGenre.Name;
            context.SaveChanges();

        }
        public void Delete(int id) 
        {
            context.Genres.Remove(GetById(id));
            context.SaveChanges();
        }
    }
}
