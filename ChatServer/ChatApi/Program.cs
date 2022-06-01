using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ChatApi.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ChatApiContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ChatApiContext") ?? throw new InvalidOperationException("Connection string 'ChatApiContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();


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
app.UseCors(fuilder => fuilder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());   

app.Run();