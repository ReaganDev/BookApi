﻿using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApiCore
{
    public static class ConfigureExceptionMiddleware
    {
        public static void ConfigureCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionsMiddlewareExtensions>();
        }
    }
}
