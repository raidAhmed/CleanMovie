﻿using CleanMovie.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application.Interfaces.Common
{
    public interface IServiceManager
    {
        IMovieService MovieService { get; }  
    }
}
