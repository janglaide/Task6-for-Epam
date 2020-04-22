using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class MyDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetails>().HasKey(k => k.Id);
            modelBuilder.Entity<Order>().HasKey(k => k.Id);
            modelBuilder.Entity<Product>().HasKey(k => k.Id);

            modelBuilder.Entity<OrderDetails>()
                .HasOne(o => o.Order)
                .WithMany(d => d.OrderDetails)
                .HasForeignKey(k => k.OrderId);

            modelBuilder.Entity<OrderDetails>()
                .HasOne(p => p.Product)
                .WithMany(d => d.OrderDetails)
                .HasForeignKey(k => k.ProductId);
            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new Product{ Id = 1, Name = "Apple", Price = 5.75},
                new Product{Id = 2, Name = "Pineapple", Price = 15.00},
                new Product{Id = 3, Name = "Pear", Price = 7.25},
                new Product{Id = 4, Name = "Sparkling water", Price = 2.50}
            });
            modelBuilder.Entity<Order>().HasData(new Order[]
            {
                new Order{Id = 1, OrderDate = Convert.ToDateTime("2020-03-03")},
                new Order{Id = 2, OrderDate = Convert.ToDateTime("2020-04-01")}
            });
            modelBuilder.Entity<OrderDetails>().HasData(new OrderDetails[]
            {
                new OrderDetails{Id = 1, OrderId = 1, ProductId = 1},
                new OrderDetails{Id = 2, OrderId = 1, ProductId = 2},
                new OrderDetails{Id = 3, OrderId = 1, ProductId = 4},
                new OrderDetails{Id = 4, OrderId = 2, ProductId = 3},
                new OrderDetails{Id = 5, OrderId = 2, ProductId = 1}
            });
        }
    }
}
