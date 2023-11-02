using CleanMovie.Application.Interfaces.Common;
using CleanMovie.Application.Interfaces.Repositories;
using CleanMovie.Infrastructure.DbContexts;
using CleanMovie.Infrastructure.Repositories;
using CleanMovie.Infrastructure.Repositories.Manager;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Infrastructure.Extensions
{
    public static class AddPresistenceExtensisionAPI
    {

        public static IServiceCollection AddPresistenceAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //services.AddIdentityCore<User>(bulder =>
            //{
            //    bulder.User.RequireUniqueEmail = false;



            //    bulder.Password.RequireLowercase = false;
            //    bulder.Password.RequireDigit = false;
            //    bulder.Password.RequiredUniqueChars = 0;
            //    bulder.Password.RequireUppercase = false;
            //    bulder.Password.RequireNonAlphanumeric = false;
            //    bulder.Password.RequiredLength = 6;
            //}).AddSignInManager().AddRoles<IdentityRole>().AddDefaultTokenProviders().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.AddScoped<IRepositoryManager, RepositoryManager>();

            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();




            /// INJECT LAZY
            services.AddTransient(provider =>
                  new Lazy<IUnitOfWork>(provider.GetService<IUnitOfWork>));


      
              
            services.AddTransient(provider =>
                  new Lazy<IMovieRepository>(provider.GetService<IMovieRepository>));



             return services;
        }
    }
}
