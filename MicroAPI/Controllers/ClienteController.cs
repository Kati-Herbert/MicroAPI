using MicroAPI.Models;
using MicroAPI.Services;

namespace MicroAPI.Controllers
{
    public static class ClienteController
    {
        public static void MapClienteEndPoints(this WebApplication app)
        {
            var service = new ClienteService();

            app.MapGet("/", () => "API de Clientes rodando!");

            app.MapGet("/clientes", () => service.ObterTodos()).RequireAuthorization();

            app.MapGet("/cliente/{id:int}", (int id) =>
            {
                var cliente = service.ObterPorId(id);
                return cliente is null ? Results.NotFound() : Results.Ok(cliente);
            }) .RequireAuthorization();

            app.MapPost("/cliente", (Cliente cliente) =>
            {
                var novo = service.Adicionar(cliente);
                return Results.Created($"/cliente/{novo.Id}", novo);
            }) .RequireAuthorization();
        }
    }
}
