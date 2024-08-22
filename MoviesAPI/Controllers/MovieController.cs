using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.DTO;
using MoviesAPI.Models;
using MoviesAPI.Repsitories;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        List<string> extentions = new List<string> { ".jpg", ".png", ".jpeg" };
        long maxlength = 1024 * 1024 * 5;
        IMovieRepo _movieRepo;
        IMapper mapper;
        public MovieController(IMovieRepo movieRepo,IMapper mapper)
        {
            _movieRepo = movieRepo;
            this.mapper = mapper;
        }
        //Get All Movies
        [HttpGet]
        public IActionResult GetMovies(int GenreId=0)
        {
            List<Movie> movies = _movieRepo.GetAll(GenreId);
            return Ok(movies);
        }
        //Get spacific Movie
        [HttpGet("{id:int}")]
        public IActionResult GetMovie(int id)
        {
            Movie movie = _movieRepo.GetById(id);
            return Ok(movie);
        }

        // Add new Movie
        [HttpPost]
        public IActionResult PostMovie([FromForm] CreateAMovie newMovie)
        {
            if (!extentions.Contains(Path.GetExtension(newMovie.Poster.FileName.ToLower())))
                return BadRequest("The file must be .JPG or .PNG");
            if (newMovie.Poster.Length > maxlength)
                return BadRequest("The maximum size is 5M");
            if (!_movieRepo.IsValid(newMovie.GenreId))
                return BadRequest("InValid Genre Id");
            if (ModelState.IsValid)
            {
                using var dataStream = new MemoryStream();
                newMovie.Poster.CopyTo(dataStream);
                Movie movie = mapper.Map<Movie>(newMovie);
                movie.Poster = dataStream.ToArray();
                _movieRepo.Create(movie);
                return Ok("Added Succesfully");
            }
            return BadRequest(ModelState);
        }
        //Update a Movie
        [HttpPut("{id:int}")]
        public IActionResult PutMovie(int id, [FromForm]CreateAMovie newMovie)
        {
            if (!extentions.Contains(Path.GetExtension(newMovie.Poster.FileName.ToLower())))
                return BadRequest("The file must be .JPG or .PNG");
            if (newMovie.Poster.Length > maxlength)
                return BadRequest("The maximum size is 5M");
            if (!_movieRepo.IsValid(newMovie.GenreId))
                return BadRequest("InValid Genre Id");
            using var dataStream = new MemoryStream();
            newMovie.Poster.CopyTo(dataStream);
            if (ModelState.IsValid)
            {
                Movie movie = mapper.Map<Movie>(newMovie);
                movie.Poster = dataStream.ToArray();
                _movieRepo.Update(id, movie);
                return Ok("Updated Succesfully");
            }
            return BadRequest(ModelState);
        }
        //Delete a Movie
        [HttpDelete("{id:int}")]
        public IActionResult DeleteMovie(int id)
        {
            Movie movie = _movieRepo.GetById(id);
            if (movie == null)
                return BadRequest("This is Invalid Id");
            _movieRepo.Delete(id);
            return Ok("Deleted Succesfully");
        }

    }
}
