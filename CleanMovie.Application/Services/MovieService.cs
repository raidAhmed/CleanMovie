using AutoMapper;
using CleanMovie.Application.DTO.Movie;
using CleanMovie.Application.Interfaces.Common;
using CleanMovie.Application.Interfaces.Repositories;
using CleanMovie.Application.Interfaces.Services;
using CleanMovie.Application.Wrapper;
using CleanMovie.Domain.Entity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanMovie.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepositoryManager _repositoryManager;

        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper, IRepositoryManager repositoryManager)
        {
             _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<IResult<MovieQueryDto>> GetAllMovies()
        {
            var movie =await _repositoryManager.MovieRepository.GetAllMovie();
            var itemMap=_mapper.Map<MovieQueryDto>(movie);
            return await Result<MovieQueryDto>.SuccessAsync(itemMap, "" , 200);
        }

        public async Task<IResult<IEnumerable<MovieQueryDto>>> GetAll()
        {

            var movie = await _repositoryManager.MovieRepository.GetAll(); 
            var itemMap = _mapper.Map<IEnumerable<MovieQueryDto>>(movie);
            return await Result<IEnumerable<MovieQueryDto>>.SuccessAsync(itemMap, "Get Brand Datatable.", 200);
         }

        public async Task<IResult<MovieQueryDto>> Add(MovieDto movie, CancellationToken cancellationToken = default)
        {
            if(movie == null) return  await Result<MovieQueryDto>.FailAsync("AddMovie > the passed entity IS NULL !!!.");
            try
            {
                var enrity = await _repositoryManager.MovieRepository.AddAndReturn(_mapper.Map<Movie>(movie));
                    await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
            
                var itemMap = _mapper.Map<MovieQueryDto>(enrity);

                return await Result<MovieQueryDto>.SuccessAsync(itemMap,"",200);


            }
            catch (Exception ex)
            {
                return await Result<MovieQueryDto>.FailAsync($"AddMovie > Something went wrong !!!\n\n\n{ex.Message}");

            }

        }

        public async Task<IResult<IEnumerable<MovieQueryDto>>> Find(Expression<Func<MovieQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Movie, bool>>>(expression);

            var d = await _repositoryManager.MovieRepository.Find(x=>new MovieQueryDto
            {
                 Id=x.Id,
                 Name=x.Name,
                 cost=x.Cost,
            },mapExpr );


            var itemMap = _mapper.Map<IEnumerable<MovieQueryDto>>(d);

            return await Result<IEnumerable<MovieQueryDto>>.SuccessAsync(itemMap, "", 200);
        }

        public async Task<IResult<IEnumerable<MovieQueryDto>>> GetAllPagination(int skip, int take, CancellationToken cancellationToken = default)
        {
            try
            {
               // var mapExpr = _mapper.Map<Expression<Func<Movie>>>(expression);

                var result=await _repositoryManager.MovieRepository.GetAll(skip,take);

                var mapExpr = _mapper.Map<IEnumerable<MovieQueryDto>>(result);

                return await Result<IEnumerable<MovieQueryDto>>.SuccessAsync(mapExpr,"hhjjhjh",200);

            }catch (Exception ex)
            {
                return await Result<IEnumerable<MovieQueryDto>>.FailAsync($"AddProduct > Something went wrong !!!\n\n\n{ex.Message}");

            }

        }

      
    }
}
