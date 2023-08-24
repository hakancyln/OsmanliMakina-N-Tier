using Osm.BusinessLayer;
using Osm.BusinessLayer.Ýmplementation;
using Osm.BusinessLayer.Interface;
using Osm.DataAccessLayer.EF.Repositories;
using Osm.DataAccessLayer.Interfaces;
using OsmanliMakina_N_Tier;
using OsmanliMakina_N_Tier.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddBusinessServices();
builder.Services.AddApiServices();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCustomExeption();
app.UseAuthorization();

app.MapControllers();

app.Run();
