using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Api.core.Interfaces;
using Api.core.Security;

namespace Api.Middlewares;

public class JwtValidationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IJwt _jwtService;

    public JwtValidationMiddleware(RequestDelegate next, IJwt jwtService)
    {
        _next = next;
        _jwtService = jwtService;
    }

    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        
        if (token != null)
        {
            var isValid = await _jwtService.ValidateTokenAsync(token);
            
            if (!isValid)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Invalid token");
                return;
            }
        }

        await _next(context);
    }
}
