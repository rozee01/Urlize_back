using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Urlize_back.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionStrings = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string  not found."); ;
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(connectionStrings)
);
builder.Services.AddControllers();

// Add CORS services.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder
            .WithOrigins("http://localhost:3000") // Replace with your client's origin
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services
    .AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddAuthorization();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS policy.
app.UseCors("AllowSpecificOrigin");
app.MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();
