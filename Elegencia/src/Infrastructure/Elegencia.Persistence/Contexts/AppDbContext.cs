using Elegencia.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Persistence.Contexts
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealImages> MealImages { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Dessert> Desserts { get; set; }
        public DbSet<DessertCategory> DessertCategories{ get; set; }
        public DbSet<DessertImage> DessertImages { get; set; }
        public DbSet<Salad> Salads { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<DrinkCategory> DrinkCategories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Famous> Famous { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);  
        }
    }
}
