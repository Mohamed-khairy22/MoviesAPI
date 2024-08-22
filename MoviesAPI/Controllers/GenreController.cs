using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.DTO;
using MoviesAPI.Migrations;
using MoviesAPI.Models;
using MoviesAPI.Repsitories;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        IGenreRepo GenreRepo;

        public GenreController(IGenreRepo genreRepo)
        {
            GenreRepo = genreRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Genre> genres = GenreRepo.GetAll();
            return Ok(genres);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetGenre([FromRoute]int id)
        {
            Genre genre = GenreRepo.GetById(id);
            return Ok(genre);
        }
        [HttpPost]
        public IActionResult PostGenre(CreateGenre genre)
        {
            if (ModelState.IsValid)
            {
                Genre genre1 = new Genre { Name = genre.Name };
                GenreRepo.Create(genre1);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        public IActionResult PutGenre([FromRoute]int id, [FromBody]CreateGenre genre)
        {
            if (ModelState.IsValid)
            {
                Genre genre1 = new Genre {Name = genre.Name};
                GenreRepo.Update(id, genre1);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id:int}")]
        public IActionResult deleteGenre([FromRoute] int id)
        {
            Genre genre = GenreRepo.GetById(id);
            GenreRepo.Delete(id);
            return Ok(genre);
        }

    }
}
    