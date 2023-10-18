using _2._Domain;
using _3._Data;
using _3._Data.Context;
using _3._Data.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyeccion dependencias
builder.Services.AddScoped<ITutorialData, TutorialMySQLData>();
builder.Services.AddScoped<ITutorialDomain, TutorialDomain>();


//Pomelo MySQL Conexion
var connectionString = builder.Configuration.GetConnectionString("LearningCenterDB");
builder.Services.AddDbContext<LearningCenterBD>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString),
            options => options.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: System.TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null)
        );
    });

var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<LearningCenterBD>())
{
    context.Database.EnsureCreated();
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();