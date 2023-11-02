
using CleanMovie.Application.DTO.Movie;
using CleanMovie.Application.Interfaces.Common;
using CleanMovie.Application.Interfaces.Services;
using CleanMovie.Application.Wrapper;
using CleanMovie.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace CleanMovie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IServiceManager  _serviceManager;

        public MoviesController(IMovieService movieService, IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
             
        }
        [HttpGet]

        public async Task<IActionResult> GetAction()
        {
            var movie=await _serviceManager.MovieService.GetAll(); 
            return Ok(movie);
        }
        [HttpPost("Add")]

        public async Task<IActionResult> Add(MovieDto entity) 
        {
            if(entity == null) return BadRequest("null");
            var result = await _serviceManager.MovieService.Add(entity);
 
            if (result.Succeeded)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result.Status);

            }
        }
        
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id,int cost)
        {
                if(id == null) return BadRequest("null");
                var result = await _serviceManager.MovieService.Find(x=>x.Id==id&&x.cost==cost);
 
                if (result.Succeeded)
                {
                    return Ok(result);

                }
                else
                {
                    return BadRequest(result.Status);

                }
        }
        
        [HttpGet("GetAll")] 
        public async Task<IActionResult> GetAllPagenation(int skip,int take) 
        {
                //if(id == null) return BadRequest("null");
                var result = await _serviceManager.MovieService.GetAllPagination(skip,take); 
 
                if (result.Succeeded)
                {
                    return Ok(result);

                }
                else
                {
                    return BadRequest(result.Status);

                }
        }
    }
}

