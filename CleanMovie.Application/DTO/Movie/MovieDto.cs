using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application.DTO.Movie
{
    public class MovieDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; } 

    }
}
