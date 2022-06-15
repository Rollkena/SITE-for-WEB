using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SITE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SITE.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) { }
        public DbSet<TextField> TextFields { get; set; }
        public DbSet<ServiceItem> ServiceItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "a8a6af02-703b-4d64-8de0-20e0217d44a1",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser 
            { 
                Id = "01bc6691-e8ec-4932-b6da-1ee1c997aa23",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "ff09e00f-b297-4c3c-a362-9528f5b45f33",
                UserId = "01bc6691-e8ec-4932-b6da-1ee1c997aa23"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("8bc221f4-b073-4b84-8830-28f7b0169393"),
                CodeWord = "PageIndex",
                Title = "Главная"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("8bc221f4-b073-4b84-8830-28f7b0169393"),
                CodeWord = "PageServices",
                Title = "Наши услуги"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("8bc221f4-b073-4b84-8830-28f7b0169393"),
                CodeWord = "PageContacts",
                Title = "Контакты"
            });
        }
    }
}
