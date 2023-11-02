
using Microsoft.EntityFrameworkCore;
using CleanMovie.Domain.Entity;

namespace CleanMovie.Application.Interfaces.Common
{
    public interface IApplicationDbContext
    {
       
        DbSet<Movie>  Movies { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
