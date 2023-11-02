using AutoMapper.Extensions.ExpressionMapping;
using CleanMovie.Application.Interfaces.Common;
using CleanMovie.Application.Interfaces.Services;
using CleanMovie.Application.Services;
using CleanMovie.Application.Services.Manager;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application.Extensions
{
    public static class AddApplicationExtension
    {

        public static IServiceCollection AddApplicationAPI(this IServiceCollection services) {


            services.AddTransient<IServiceManager, ServiceManager>();
 
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(cx => { cx.AddExpressionMapping(); }, AppDomain.CurrentDomain.Load("CleanMovie.Application"));
           // services.AddValidatorsFromAssembly(AppDomain.CurrentDomain.Load("Agricultural.Application"));
            services.AddTransient<IMovieService, MovieService>();

            services.AddTransient(provider => new Lazy<IServiceManager>(provider.GetService<IServiceManager>));
            
            services.AddTransient(provider => new Lazy<IMovieService>(provider.GetService<IMovieService>));


            return services;
        
        }
    }
}
