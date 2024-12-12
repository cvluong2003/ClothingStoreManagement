using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace API.MiddleWare
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        // private readonly HttpContext _context;
        public RequestLoggingMiddleware(RequestDelegate next)
        { _next = next; }
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
            await _next(context);
            Console.WriteLine($"Response: {context.Response.StatusCode}");
        }
    }
}