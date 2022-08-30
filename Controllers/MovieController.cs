using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmesAPI.Data.Dtos;
using AutoMapper;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class MovieController : ControllerBase
    {

        private MovieContext _context;
        private IMapper _mapper;

        public MovieController(MovieContext context, IMapper autoMapper)
        {
            _context = context;
            _mapper = autoMapper;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
        {
            Movie movie = _mapper.Map<Movie>(movieDto);

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
                ReadMovieDto movieDto = _mapper.Map<ReadMovieDto>(movie);
                return Ok(movieDto);
            }
            return NotFound();
        }
        [HttpPut("{ID}")]
        public IActionResult UpdateMovieById(int ID,[FromBody] UpdateMovieDto movieDto)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.ID == ID);

            if (movie == null)
            {
                return NotFound();
            }

            _mapper.Map(movieDto, movie);
            _context.SaveChanges();
            return NoContent();
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
      
    }

}
