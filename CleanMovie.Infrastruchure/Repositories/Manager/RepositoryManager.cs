using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanMovie.Application.Interfaces.Common;
using CleanMovie.Application.Interfaces.Repositories;
namespace CleanMovie.Infrastructure.Repositories.Manager
{
    public class RepositoryManager : IRepositoryManager
    {
        private  Lazy<IUnitOfWork> _lazyUnitOfWork;

        private Lazy<IMovieRepository> _LazyMovieRepository;
        public RepositoryManager(Lazy<IMovieRepository> LazyMovieRepository,
             Lazy<IUnitOfWork> lazyUnitOfWork
            )
        {
        _LazyMovieRepository = LazyMovieRepository;
            _lazyUnitOfWork = lazyUnitOfWork;     
        }
        public IMovieRepository MovieRepository => _LazyMovieRepository.Value;
        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value; 
    }
}
