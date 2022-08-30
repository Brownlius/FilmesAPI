using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class MovieController : ControllerBase
    {

        private MovieContext _context;

        public MovieController(MovieContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody]Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetMovieById), new { id = movie.ID }, movie);
        }
        [HttpGet]
        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies;
        }

        [HttpGet("{ID}")]
        public IActionResult GetMovieById(int ID)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.ID == ID);   
            if(movie != null)
            {
                return Ok(movie);
            }
            return NotFound();
        }
        [HttpPut("{ID}")]
        public IActionResult UpdateMovieById(int ID,[FromBody] Movie newMovie)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.ID == ID);
            if (movie != null)
            {
                movie.Title = newMovie.Title;
                movie.Director = newMovie.Director;
                movie.Duration = newMovie.Duration;
                movie.Genre = newMovie.Genre;
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }
        [HttpDelete("{ID}")]
        public IActionResult DeleteMovieById(int ID)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.ID == ID);
            if (movie != null)
            {
                _context.Remove(movie);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }
        Movie Gustavo = new();
      
    }

}
