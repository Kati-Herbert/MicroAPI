using MicroAPI.Models;
using MicroAPI.Services;
using System.Runtime.CompilerServices;

namespace MicroAPI.Controllers
{
    public static class AuthController
    {
        public static void MapAuthEndpoints (this WebApplication app, string jwtSecret)
        {
            app.MapPost("/login", (Usuario usuario) =>
            {
                if (usuario.Username == "admin" && usuario.Password == "123")
                {
                    var token = TokenService.GerarToken(usuario.Username, jwtSecret);
                    return Results.Ok(new { token });
                }
                return Results.Unauthorized();
            });
        }
    }
}
