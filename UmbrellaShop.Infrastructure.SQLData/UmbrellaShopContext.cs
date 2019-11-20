using Microsoft.EntityFrameworkCore;
using UmbrellaShop.Core.Entity;
using System;

namespace UmbrellaShop.Infrastructure.SQLData
{
    public class UmbrellaShopContext : DbContext
    {
        public DbSet<Umbrella> Umbrellas { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public UmbrellaShopContext(DbContextOptions<UmbrellaShopContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Umbrella>()//one umbrella has 
                .HasOne(e => e.Order)//one order
                .WithMany(c => c.Umbrellas)//one order can have many umbrellas
                .OnDelete(DeleteBehavior.SetNull);// if umbrella is deleted the order will be set to null.

            modelBuilder.Entity<Order>()//one order has many umbrellas
                .HasMany(e => e.Umbrellas) //each umbrella has one order
                .WithOne(c => c.Order) // each umbrella has one order
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Order>()
                .HasOne(e => e.Customers)
                .WithMany(c => c.Orders)
                .OnDelete(DeleteBehavior.SetNull);



        }

    }
}
