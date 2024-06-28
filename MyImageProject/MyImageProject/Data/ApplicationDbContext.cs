using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyImageProject.Models;
using System.Reflection.Emit;

namespace MyImageProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUsers>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Photograph> Photographs { get; set; }
        public DbSet<PrintSize> PrintSizes { get; set; }
        public DbSet<CreditCard> CreditCard { get; set; }
        public DbSet<ShippingInfo> ShippingInfo { get; set; }
        public DbSet<Gallery> Gallery { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var admin = new IdentityRole("admin");
            admin.NormalizedName = "admin";
            var client = new IdentityRole("client");
            client.NormalizedName = "client";

            builder.Entity<IdentityRole>().HasData(admin, client);

            builder.Entity<Contact>()
            .HasIndex(u => u.Email)
            .IsUnique();
            
            builder.Entity<ShippingInfo>()
            .HasIndex(u => u.TracingNumber)
            .IsUnique();
        }
    }
}
