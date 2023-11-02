using CleanMovie.Application.Interfaces.Common;
using CleanMovie.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Infrastructure.DbContexts
{
    public class ApplicationDbContext :  DbContext,IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public DbSet<Movie> Movies { get;private set; }

       

      
    }
}
