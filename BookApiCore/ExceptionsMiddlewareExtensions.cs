using BooksApiDtos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookApiCore
{
    public class ExceptionsMiddlewareExtensions
    {

        private readonly RequestDelegate _next;

        public ExceptionsMiddlewareExtensions(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var response = new ErrorDto()
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error from Custom Middleware",
                Path = "Path-goes-here"
            };

            return context.Response.WriteAsync(response.ToString());
        }
    }
}
