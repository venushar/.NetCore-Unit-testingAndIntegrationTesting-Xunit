using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShoppingServices.Common.Entities;
using OnlineShoppingServices.Data;

namespace OnlineShoppingServices.Common.Models
{
  public  class ShoppingDBContext: DbContext
    {
        public ShoppingDBContext(DbContextOptions options) : base(options)
        { }
        public  DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(ConfigureUser);
            modelBuilder.Entity<Order>(ConfigureOrder);
            modelBuilder.Entity<OrderItem>(ConfigureOrderItem);
            modelBuilder.Entity<Product>(ConfigureProduct);
        }

        public static void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.UserId);
            builder.Property(e => e.UserName).HasColumnType("varchar(50)");
            builder.Property(e => e.Password).HasColumnType("binary(64)");
            builder.Property(e => e.FirstName).HasColumnType("varchar(50)");
            builder.Property(e => e.LastName).HasColumnType("varchar(50)");
            builder.Property(e => e.Mobile).HasColumnType("int");

        }

        public static void ConfigureOrder(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(e => e.OrderId);
            builder.HasMany(e => e.OrderItems);          

        }

        public static void ConfigureProduct(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.ProductId);
            builder.Property(e => e.ProductName).HasColumnType("varchar(50)").IsRequired(true);
            builder.Property(e => e.catogeryId).HasColumnType("int").IsRequired(true);

        }
        public static void ConfigureOrderItem(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(e => e.OrderItemId);
            builder.HasOne(e => e.Orderobj).WithMany(e => e.OrderItems).HasForeignKey(e => e.OrderId);
          
        }

    }
}
