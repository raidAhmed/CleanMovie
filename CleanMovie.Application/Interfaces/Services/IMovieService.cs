using CleanMovie.Application.DTO.Movie;
using CleanMovie.Application.Interfaces.Common;
using CleanMovie.Application.Interfaces.Repositories;
using CleanMovie.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application.Interfaces.Services
{
    public interface IMovieService
    {
        Task<IResult<MovieQueryDto>> GetAllMovies(); 
        Task<IResult<IEnumerable<MovieQueryDto>>> GetAll(); 
        Task<IResult<MovieQueryDto>> Add(MovieDto movie, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<MovieQueryDto>>> Find(Expression<Func<MovieQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<MovieQueryDto>>> GetAllPagination(int skip, int take, CancellationToken cancellationToken = default);

    }
}
