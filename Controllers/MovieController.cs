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
        private static List<Movie> moviesList = new();


        private static int ID = 1;

        [HttpPost]
        public IActionResult AddMovie([FromBody]Movie movie)
        {
            moviesList.Add(movie);
            movie.ID = ID++;
            return CreatedAtAction(nameof(GetMovieById), new { id = movie.ID }, movie);
        }
        [HttpGet]
        public IActionResult GetMovies()
        {
            return Ok(moviesList);
        }

        [HttpGet("{ID}")]
        public IActionResult GetMovieById(int ID)
        {
            Movie movie = moviesList.FirstOrDefault(movie => movie.ID == ID);

            if(!(movie == null))
            {
                return Ok(movie);
            }
            return NotFound();
        }
        //[HttpGet("{genre}" )]
        //public Movie GetMovieByGenre(string genre)
        //{
        //    return moviesList.FirstOrDefault(movie => movie.Genre == genre);
        //}

    }
}
