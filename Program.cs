using AuthenticationAndAuthorization.Config;
using AuthenticationAndAuthorization.Models;
using AuthenticationAndAuthorization.Repository;
using AuthenticationAndAuthorization.Services;

string myCors = "myCors";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<UserRepository>();
builder.Services.AddScoped<LoginService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// configuracion de CORS
builder.Services.AddAllowedCors(myCors);

// se agrega configuracion de autenticacion basada en JWT
builder.Services.AddJwtAuthentication(builder.Configuration);
// sea agrega configuracion de autorizacion
builder.Services.AddLocalAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Se habilitan los cors
app.UseCors(myCors);
//Se habilita uso de autenticacion y autorizacion
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
