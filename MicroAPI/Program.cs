using MicroAPI.Controllers;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var secret = "01234567890123456789012345678901";


var builder = WebApplication.CreateBuilder(args);
var key = Encoding.ASCII.GetBytes(secret);

builder.Services.AddAuthentication("Bearer")

    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapAuthEndpoints(secret);

app.MapClienteEndPoints();

app.Run();
