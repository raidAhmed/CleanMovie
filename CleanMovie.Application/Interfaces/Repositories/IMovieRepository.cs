using CleanMovie.Application.Interfaces.Common;
using CleanMovie.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application.Interfaces.Repositories
{
    public interface IMovieRepository: IGenericRepository<Movie> 
    {
        Task<IEnumerable<Movie>> GetAllMovie();
    }

 }
