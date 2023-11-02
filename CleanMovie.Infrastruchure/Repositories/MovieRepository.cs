using CleanMovie.Application.Interfaces.Common;
using CleanMovie.Application.Interfaces.Repositories;
using CleanMovie.Domain.Entity;
using CleanMovie.Infrastructure.DbContexts;
using CleanMovie.Infrastructure.Repositories.Manager;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Infrastructure.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {

        public MovieRepository(ApplicationDbContext context) : base(context)
        {
        }
        public static List<Movie> movies = new List<Movie>()
        {
            new Movie {Id=1, Name="Passion of  Christit",  Cost=2},
            new Movie {Id=1, Name="Home Alone 4",  Cost=1},
            //new Movie {Id=1, Name="Passion of  Christit",  Cost=2}
        };



        public async Task<IEnumerable<Movie>> GetAllMovie()
        {

             return await _context.Set<Movie>().ToListAsync();  
            //return  movies;
        }

        
    }  
    
 }
