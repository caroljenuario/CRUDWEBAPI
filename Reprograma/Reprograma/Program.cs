using Microsoft.EntityFrameworkCore;
using Reprograma.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<Contexto>
    (options => options.UseMySql(
        "server=localhost;initial catalog=Usuarias_REPROGRAMA;uid=root;pwd=car@@1457",
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
