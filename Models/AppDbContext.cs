﻿using Microsoft.EntityFrameworkCore;

namespace Urlize_back.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) 
        { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Business> Business { get; set; }
        public DbSet<Catalogue> Catalogue {  get; set; }
        public DbSet<Categorie> Categorie { get; set; }
    }
}
