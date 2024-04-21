using Microsoft.EntityFrameworkCore;
using Urlize_back.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionStrings = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string  not found."); ;
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(connectionStrings)
);
builder.Services.AddControllers();

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
