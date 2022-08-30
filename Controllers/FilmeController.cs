using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Models;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Movie> movies  = new(); 

        [HttpPost]  
        public void AddMovie([FromBody] Movie movie)
        {
            movies.Add(movie);
            System.Console.WriteLine(movie.Duration);
        }
    }
}
