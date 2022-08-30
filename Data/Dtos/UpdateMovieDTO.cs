using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.Dtos
{
    public class UpdateMovieDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Genre { get; set; }
        [Range(1, 20)]
        public int Duration { get; set; }
    }

}
