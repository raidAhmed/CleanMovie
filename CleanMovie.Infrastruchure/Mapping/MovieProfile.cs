using AutoMapper;
using CleanMovie.Application.DTO.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Infrastructure.Mapping
{
    internal class MovieProfile:Profile
    {
        public MovieProfile()
        {

            //Mapping CreateDto To Entity
            CreateMap<MovieDto, CleanMovie.Domain.Entity.Movie>().ReverseMap();

            //Mapping QueryDto To Entity
            CreateMap<MovieQueryDto, CleanMovie.Domain.Entity.Movie>().ReverseMap();
        }
    }
}
