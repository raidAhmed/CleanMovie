using CleanMovie.Application.Interfaces.Common;
using CleanMovie.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application.Services.Manager
{
    internal class ServiceManager : IServiceManager
    {

        private Lazy<IMovieService> _lazyMovieService;

        public ServiceManager(
            Lazy<IMovieService> lazyMovieService
            
            )
        {

            _lazyMovieService = lazyMovieService;
        }

        public IMovieService MovieService => _lazyMovieService.Value;
    }
}
