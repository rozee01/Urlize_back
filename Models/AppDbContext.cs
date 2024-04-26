using Microsoft.EntityFrameworkCore;
using Urlize_back.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Urlize_back.Models
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) 
        { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Business> Business { get; set; }
    }
}
